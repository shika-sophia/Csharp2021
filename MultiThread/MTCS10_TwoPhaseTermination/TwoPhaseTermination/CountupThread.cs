using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.TwoPhaseTermination
{
    class CountupThread
    {
        private long counter = 0L;
        private volatile bool shutdownReq = false;

        public void ShutdownRequest(Thread[] thAry)
        {
            shutdownReq = true;
            foreach(Thread th in thAry)
            {
                th.Interrupt();
            }
        }//ShutdownRequest()

        public bool IsShutdownReqested()
        {
            return shutdownReq;
        }//IsShutdownReqested()

        public void Run()
        {
            try
            {
                while (!IsShutdownReqested())
                {
                    DoWork();
                }//while
            }
            catch(ThreadInterruptedException)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is interrupted.");
            }
            finally
            {
                DoShutdown();
            }
        }//Run();

        private void DoWork()
        {
            counter++;
            Console.WriteLine($"DoWork(): counter = {counter}");
            Thread.Sleep(500);
        }

        private void DoShutdown()
        {
            Console.WriteLine($"DoShutdown(): counter = {counter}");
        }
    }//class
}
