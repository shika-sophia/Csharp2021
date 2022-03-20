using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.HanoiTower.Modified
{
    class HanoiThreadModified
    {
        private volatile bool shutdownReq = false;
        private readonly Stopwatch sw = new Stopwatch();

        public void Run()
        {
            try
            {
                for(int level = 0; !IsShutdownRequested(); level++)
                {
                    Console.WriteLine($"==== Level {level} ====");
                    DoWork(level, 'A', 'B', 'C');
                    Console.WriteLine();
                }//for
            }
            catch (ThreadInterruptedException) 
            {
                Console.WriteLine(
                    $"{Thread.CurrentThread.Name} Interrupt()");
            }
            finally
            {
                DoShutdown();
            }
        }//Run()

        private void DoWork(int level, char c1, char c2, char c3)
        {
            if (level > 0)
            //if (level > 0 && !IsShutdownRequested())
            {
                if (IsShutdownRequested())
                {
                    throw new ThreadInterruptedException();
                }

                DoWork(level - 1, c1, c3, c2);
                Console.Write($"{c1} -> {c2}, ");
                DoWork(level - 1, c3, c2, c1);
            }
        }

        public void ShutdownRequest(Thread th)
        {
            sw.Start();
            shutdownReq = true;
            th.Interrupt();
        }//ShutdownRequest()

        private bool IsShutdownRequested()
        {
            return shutdownReq;
        }

        private void DoShutdown()
        {
            sw.Stop();
            Console.WriteLine(
                $"DoShutDown() costTime = {sw.ElapsedMilliseconds} msec");
        }
    }//class
}
