using CsharpBegin.MultiThread.MTCS05_ProducerComsumer.CakeTable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.LazyThread
{
    class LazyThreadMT05
    {
        private readonly string thName;
        private readonly AbsCakeTable table;

        public LazyThreadMT05(string thName, AbsCakeTable table)
        {
            this.thName = thName;
            this.table = table;
        }

        //LazyThread: Do Nothing with having lock.
        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1000);

                try
                {
                    lock (table)
                    {
                        Thread.SpinWait(Timeout.Infinite);
                    }//lock

                    Console.WriteLine(
                        $"{thName}: wake up by Thread.Yield().");
                } 
                catch (ThreadInterruptedException e)
                {
                    Console.WriteLine(e.GetType());                    
                }
            }//while
        }//Run()
    }//class
}
