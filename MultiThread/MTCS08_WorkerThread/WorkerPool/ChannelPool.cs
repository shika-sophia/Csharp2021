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
        internal readonly ConcurrentQueue<RequestMT08> queue
            = new ConcurrentQueue<RequestMT08>();
        private List<WorkerThreadMT08> workerList;
        private List<Thread> threadPoolList;
        private int poolNum; //initial workerPool

        public ChannelPool(int poolNum = 3)
        {
            this.poolNum = poolNum;
            workerList = new List<WorkerThreadMT08>();
            threadPoolList = new List<Thread>();

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
                threadPoolList.Add(workerTh);
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
            threadPoolList.Add(workerTh);
            workerTh.Start();
        }

        public override void StopAllWorker()
        {
            foreach(Thread workerTh in threadPoolList)
            {
                workerTh.Abort();
            }
        }//StopAllWorker()

        public override void PutRequest(RequestMT08 req)
        {
            var sw = new Stopwatch();
            sw.Start();
            while(queue.Count >= REQ_LIMIT)
            {
                Thread.Sleep(100);

                if(sw.ElapsedMilliseconds >= 200)
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
