using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.ResponseGUI
{
    class ButtonAction
    {
        private volatile bool working = false;
        private Thread workerTh = null;

        public void DoAction()
        {
            Console.WriteLine("act");

            try
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(200);
                }//for

                Console.WriteLine("done");
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine(
                    $"{Thread.CurrentThread.Name} canceled");
            }
            finally
            {
                working = false;
            }
        }//DoAction()

        public void ActThreadPerMessage()
        {
            new Thread(() => this.DoAction()).Start();
        }//ActThreadPerMessage()

        public void ActSingle()
        {
            new Thread(() =>
            {
                lock (this)
                {
                    this.DoAction();
                }//lock
            }).Start();
        }//ActSingle()

        public void ActBalking()
        {
            if (working)
            {
                Console.Write("(Busy)");
                return;
            }

            working = true;
            new Thread(() => this.DoAction()).Start();
        }//ActBalking()

        public void ActInterrupt()
        {
            if(workerTh != null && workerTh.IsAlive)
            {
                workerTh.Interrupt();
                try
                {
                    workerTh.Join();
                }
                catch (ThreadInterruptedException)
                {
                    workerTh = null;
                }
            }//if

            workerTh = new Thread(() => this.DoAction());
            workerTh.Start();
        }//ActInterrupt()
    }//class
}

