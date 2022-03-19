using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.GracefulTermination
{
    class GracefulThread
    {
        private volatile bool shutdownReq = false;

        public void ShutdownRequest(Thread[] thAry)
        {
            shutdownReq = true;
            foreach (Thread th in thAry)
            {
                th.Interrupt();
            }
        }//ShutdownRequest()

        public bool IsShutdownRequested()
        {
            return shutdownReq;
        }

        public void Run()
        {
            try
            {
                while (!IsShutdownRequested())
                {
                    DoWork();
                }//while

            }
            catch (ThreadInterruptedException) 
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is interrupted.");
            }
            finally
            {
                DoShutdown();
            }
        }//Run()

        protected virtual void DoWork() { }
        protected virtual void DoShutdown() { }
    }//class
}
