using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS08_WorkerThread.Worker
{
    class ChannelMT08
    {
        private const int MAX_REQ = 100;
        private readonly RequestMT08[] reqAry;
        private readonly WorkerThreadMT08[] threadPool;
        private int head;
        private int tail;
        private int count;

        public ChannelMT08(int thNum)
        {
            reqAry = new RequestMT08[MAX_REQ];
            this.head = 0;
            this.tail = 0;
            this.count = 0;

            this.threadPool = new WorkerThreadMT08[thNum];
            for(int i = 0; i < threadPool.Length; i++)
            {
                threadPool[i] = new WorkerThreadMT08($"Worker-{i}", this);
            }//for
        }//constructor

        public void StartWorker()
        {
            foreach(WorkerThreadMT08 worker in threadPool)
            {
                Thread workerTh = new Thread(worker.Run);
                workerTh.Name = worker.thName;
                workerTh.Start(); 
            }//foreach
        }//StartWorker()

        public void PutRequest(RequestMT08 req)
        {
            reCondition:
            while(count >= reqAry.Length)
            {
                try
                {
                    Thread.SpinWait(Timeout.Infinite);
                }
                catch (ThreadInterruptedException) { }
            }//while

            lock (this)
            {
                if(count >= reqAry.Length) { goto reCondition; }

                reqAry[tail] = req;
                tail = (tail + 1) % reqAry.Length;
                count++;
                Thread.Yield();
            }//lock
        }//PutRequest()

        public RequestMT08 TakeRequest()
        {
            reCondition:
            while(count <= 0)
            {
                Thread.SpinWait(Timeout.Infinite);
            }//while

            lock (this)
            {
                if(count <= 0) { goto reCondition; }

                RequestMT08 req = reqAry[head];
                head = (head + 1) % reqAry.Length;
                count--;
                Thread.Yield();

                return req;
            }//lock
        }//TakeRequest()
    }//class
}
