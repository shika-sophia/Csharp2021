using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.CakeTable
{
    class EaterThreadMT05
    {
        private readonly string name;
        private readonly AbsCakeTable table;
        private readonly Random random;

        public EaterThreadMT05(string name, AbsCakeTable table, int seed)
        {
            this.name = name;
            this.table = table;
            this.random = new Random(seed);
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    string cake = table.TakeCake();
                    Thread.Sleep(random.Next(1000));
                }//while loop
            } 
            catch(ThreadInterruptedException e)
            {
                Console.WriteLine(e.GetType());
            }
        }//Run()
    }//class
}
