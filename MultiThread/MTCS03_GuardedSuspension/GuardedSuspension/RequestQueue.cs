using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CsharpBegin.MultiThread.MTCS03_GuardedSuspension.GuardedSuspension
{
    class RequestQueue
    {
        private readonly ConcurrentQueue<RequestMT03>
            queue = new ConcurrentQueue<RequestMT03>();

        public RequestMT03 GetRequest()
        {
            RequestMT03 request = null;
            while (!queue.TryPeek(out request))
            {
                Thread.SpinWait(100);
            }//while

            queue.TryDequeue(out request);
            return request;
        }//GetRequest()

        public void PutRequest(RequestMT03 request)
        {
            queue.Enqueue(request);
            Thread.Yield();
        }//PutRequest()
    }//class
}
