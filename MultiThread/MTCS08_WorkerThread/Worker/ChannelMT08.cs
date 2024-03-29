﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS08_WorkerThread.Worker
{
    class ChannelMT08 : AbsChannelMT08
    {
        private const int QUEUE_SIZE = 300;
        internal readonly RequestMT08[] queue;
        private readonly WorkerThreadMT08[] workerAry;
        protected readonly Thread[] threadPool;
        private int head;
        private int tail;
        private int count;

        public ChannelMT08(int thNum)
        {
            queue = new RequestMT08[QUEUE_SIZE];
            this.head = 0;
            this.tail = 0;
            this.count = 0;

            this.workerAry = new WorkerThreadMT08[thNum];
            this.threadPool = new Thread[thNum];

            for(int i = 0; i < workerAry.Length; i++)
            {
                workerAry[i] = new WorkerThreadMT08($"Worker-{i}", this);
            }//for
        }//constructor

        public override void StartWorker()
        {
            for(int i = 0; i < workerAry.Length; i++) 
            {
                threadPool[i] = new Thread(workerAry[i].Run);
                threadPool[i].Name = workerAry[i].thName;
                threadPool[i].Start(); 
            }//foreach
        }//StartWorker()

        public override void StopAllWorker()
        {
            foreach(Thread workerTh in threadPool)
            {
                workerTh.Abort();
            }
        }//StopAllWorker()

        public override void PutRequest(RequestMT08 req)
        {
            reCondition:
            while(count >= queue.Length)
            {
                try
                {
                    Thread.SpinWait(Timeout.Infinite);
                }
                catch (ThreadInterruptedException) { }
            }//while

            lock (this)
            {
                if(count >= queue.Length) { goto reCondition; }

                queue[tail] = req;
                tail = (tail + 1) % queue.Length;
                count++;
                Thread.Yield();
            }//lock
        }//PutRequest()

        public override RequestMT08 TakeRequest()
        {
            reCondition:
            while(count <= 0)
            {
                Thread.SpinWait(Timeout.Infinite);
            }//while

            lock (this)
            {
                if(count <= 0) { goto reCondition; }

                RequestMT08 req = queue[head];
                head = (head + 1) % queue.Length;
                count--;
                Thread.Yield();

                return req;
            }//lock
        }//TakeRequest()
    }//class
}
