using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS04_Balking.GuardedTimeout
{
    class ExeTimeout
    {
        private readonly long TIMEOUT;
        private volatile bool ready = false;

        public ExeTimeout(long timeout)
        {
            this.TIMEOUT = timeout;
        }

        public void CheckExe()
        {
            lock (this)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (!ready)
                {
                    long rest = TIMEOUT - sw.ElapsedMilliseconds;
                    try
                    {
                    
                        if(rest <= 0)
                        {
                            throw new TimeoutException(
                                $"Timeout: {sw.ElapsedMilliseconds} msec.");
                        }

                        Thread.SpinWait((int) rest);
                    } 
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine($"{e.GetType()}");
                    }
                }//while
                sw.Reset();

                Execute();
            }//lock
        }//CheckExe()

        private void Execute()
        {
            Console.WriteLine(
                $"{Thread.CurrentThread.Name}: {nameof(Execute)}()");
        }//Execute()

        public void SetOn(bool on)
        {
            lock (this)
            {
                ready = on;
                Thread.Yield();
            }//lock
        }//SetOn()
    }//class
}
