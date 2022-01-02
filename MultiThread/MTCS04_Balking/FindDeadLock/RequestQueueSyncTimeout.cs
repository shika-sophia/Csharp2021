using CsharpBegin.MultiThread.MTCS03_GuardedSuspension.GuardedSuspension;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS04_Balking.FindDeadLock
{
    class RequestQueueSyncTimeout
    {
        private readonly Queue<RequestMT03> queue = new Queue<RequestMT03>();
        private readonly Stopwatch sw = new Stopwatch();
        private const long TIMEOUT = 10_000L;

        public RequestMT03 GetRequest()
        {
            lock (queue)
            {
                sw.Start();

                while(queue.Count == 0)
                {
                    long rest = TIMEOUT - sw.ElapsedMilliseconds;

                    try
                    {
                        if (rest <= 0)
                        {
                            throw new LivenessException(
                                "<!> It maybe DeadLock Timeout.");
                        }
                    
                        Thread.SpinWait((int) rest);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine(e.GetType());
                    }
                }//while

                sw.Reset();
                return queue.Dequeue();               
            }//lock
        }//GetRequest()

        public void PutRequest(RequestMT03 request)
        {
            lock (queue)
            {
                queue.Enqueue(request);
            }
            Thread.Yield();
        }//PutRequest()
    }//class
}
