using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv
{
    class ActiveQueueMT12
    {
        private const int MAX_REQUEST = 100;
        private readonly ConcurrentQueue<AbsMethodRequest> reqQueue;

        public ActiveQueueMT12()
        {
            this.reqQueue = new ConcurrentQueue<AbsMethodRequest>();
        }

        public void PutRequest(AbsMethodRequest req)
        {
            reCondition:
            while(reqQueue.Count >= MAX_REQUEST)
            {
                try
                {
                    Thread.SpinWait(Timeout.Infinite);
                }
                catch (ThreadInterruptedException) { }
            }//while

            if(reqQueue.Count >= MAX_REQUEST) { goto reCondition; }

            reqQueue.Enqueue(req);
            Thread.Yield();
        }//PutRequest()

        public AbsMethodRequest TakeRequest()
        {
            reCondition:
            while(reqQueue.Count <= 0)
            {
                Thread.SpinWait(Timeout.Infinite);
            }//while

            AbsMethodRequest req;
            if(!reqQueue.TryDequeue(out req)) { goto reCondition; }

            Thread.Yield();
            return req;
        }//TakeRequest()
    }//class
}
