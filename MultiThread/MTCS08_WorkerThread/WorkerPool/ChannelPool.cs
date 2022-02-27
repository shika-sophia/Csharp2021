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
        private readonly ConcurrentQueue<RequestMT08> queue
            = new ConcurrentQueue<RequestMT08>();
        private const int REQ_LIMIT = 10;
        private List<WorkerThreadMT08> workerList;
        private int poolNum; //initial workerPool


        public ChannelPool(int poolNum = 2)
        {
            this.poolNum = poolNum;
            workerList = new List<WorkerThreadMT08>(poolNum);            
        }

        public override void StartWorker()
        {
            for(int i = 0; i < poolNum; i++)
            {
                string thName = $"Worker-{i}";
                workerList.Add(
                    new WorkerThreadMT08(thName, this));             
            }
            
        }

        public override void PutRequest(RequestMT08 req)
        {
            var sw = new Stopwatch();
            sw.Start();
            while(queue.Count <= REQ_LIMIT)
            {
                Thread.Sleep(100);

                if(sw.ElapsedMilliseconds >= 10000)
                {
                    AdjustPool();
                    sw.Restart();
                }
            }//while

            queue.Enqueue(req);
            Thread.Yield();
        }//PutRequest()

        private void AdjustPool()
        {
            workerList.Add(
                new WorkerThreadMT08($"Worker-{++poolNum}", this));
        }

        public override RequestMT08 TakeRequest()
        {
            RequestMT08 req;
            while (!queue.TryDequeue(out req))
            {
                Thread.Sleep(Timeout.Infinite);
            }//while

            Thread.Yield();
            return req;
        }//TakeRequest()
    }//class
}
