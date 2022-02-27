/*
 *@see MainWorkerPool.cs
 *@see MTCS05_ProducerComsumer/CakeTable/CakeTableBlocking.cs
 */

using CsharpBegin.MultiThread.MTCS08_WorkerThread.Worker;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS08_WorkerThread.WorkerPool
{
    class ChannelPool : AbsChannelMT08
    {
        private const int REQ_LIMIT = 100;
        private readonly ConcurrentQueue<RequestMT08> queue
            = new ConcurrentQueue<RequestMT08>();
        private List<WorkerThreadMT08> workerList;
        private int poolNum; //initial workerPool

        public ChannelPool(int poolNum = 2)
        {
            this.poolNum = poolNum;

            workerList = new List<WorkerThreadMT08>();
            for (int i = 0; i < poolNum; i++)
            {
                workerList.Add(
                    new WorkerThreadMT08($"Worker-{i}", this));
            }//for
        }//constructor

        public override void StartWorker()
        {
            foreach(WorkerThreadMT08 worker in workerList)
            {
                Thread workerTh = new Thread(worker.Run);
                workerTh.Name = worker.thName;
                workerTh.Start();
            }//foreach
        }//StartWorker()

        private void AddWorker()
        {
            var workerNew = new WorkerThreadMT08(
                    $"Worker-{(poolNum++) - 1}", this);
            workerList.Add(workerNew);
            Thread workerTh = new Thread(workerNew.Run);
            workerTh.Name = workerNew.thName;
            workerTh.Start();
        }

        public override void PutRequest(RequestMT08 req)
        {
            var sw = new Stopwatch();
            sw.Start();
            while(queue.Count >= REQ_LIMIT)
            {
                Thread.Sleep(100);

                if(sw.ElapsedMilliseconds >= 500)
                {
                    AddWorker();
                    sw.Restart();
                }
            }//while
            sw.Stop();
            
            queue.Enqueue(req);
            Thread.Yield();
        }//PutRequest()

        public override RequestMT08 TakeRequest()
        {
            RequestMT08 req;
            while (!queue.TryDequeue(out req))
            {
                Thread.Sleep(100);
            }//while

            Thread.Yield();
            return req;
        }//TakeRequest()
    }//class
}
