/*
 *@see MainNgRequestQueue.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS03_GuardedSuspension.GuardedSuspension
{
    class RequestQueueNgCode :RequestQueue
    {
        private readonly Queue<RequestMT03>
            queue = new Queue<RequestMT03>();

        public override RequestMT03 GetRequest()
        {
            //---- Case1: while -> if ----
            lock (queue)
            {
                if (queue.Peek() == null)
                {
                    try
                    {
                        Thread.SpinWait(100);
                    } catch(ThreadInterruptedException) { }
                }//if

                return queue.Dequeue();
            }//lock

            ////---- Case2: lock() ONLY SpinWait() ----
            //while (queue.Peek() == null)
            //{
            //    try
            //    {
            //        lock (queue)
            //        {
            //            Thread.SpinWait(100);
            //        }//lock
            //    }
            //    catch (ThreadInterruptedException) { }
            //}//while

            //return queue.Dequeue();

            ////---- Case3: try-catch put out of While() ----
            //lock (queue)
            //{
            //    try
            //    {
            //        while (queue.Peek() == null)
            //        {
            //            Thread.SpinWait(100);
            //        }//while
            //    }
            //    catch (ThreadInterruptedException) { }

            //    return queue.Dequeue();
            //}//lock

            ////---- Case4: SpinWait() -> Sleep() ----
            //lock (queue)
            //{
            //    if (queue.Peek() == null)
            //    {
            //        try
            //        {
            //            Thread.Sleep(100);
            //        }
            //        catch (ThreadInterruptedException) { }
            //    }//if

            //    return queue.Dequeue();
            //}//lock
        }//GetRequest

    }//class
}
