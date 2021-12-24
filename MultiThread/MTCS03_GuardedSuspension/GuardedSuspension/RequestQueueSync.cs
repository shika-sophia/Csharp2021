using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CsharpBegin.MultiThread.MTCS03_GuardedSuspension.GuardedSuspension
{
    class RequestQueueSync : RequestQueue
    {
        private readonly Queue<RequestMT03>
            queue = new Queue<RequestMT03>();

        public override RequestMT03 GetRequest()
        {
            lock (queue)
            {
                while (queue.Peek() == null)
                {
                    Thread.SpinWait(100);
                }//while

                return queue.Dequeue();
            }//lock
        }//GetRequest()

        public override void PutRequest(RequestMT03 request)
        {
            lock (queue)
            {
                queue.Enqueue(request);
            }//lock

            Thread.Yield();
        }//PutRequest()
    }//class
}
