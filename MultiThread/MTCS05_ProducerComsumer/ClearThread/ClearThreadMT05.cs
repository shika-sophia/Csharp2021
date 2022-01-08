using CsharpBegin.MultiThread.MTCS05_ProducerComsumer.CakeTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.ClearThread
{
    class ClearThreadMT05
    {
        private readonly string thName;
        private readonly AbsCakeTable table;

        public ClearThreadMT05(string thName, AbsCakeTable table)
        {
            this.thName = thName;
            this.table = table;
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(3000);

                table.ClearCake();
                Console.WriteLine($"{thName}: Cleared");
            }//while
        }
    }//class
}
