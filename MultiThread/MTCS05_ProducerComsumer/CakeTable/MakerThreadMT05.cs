using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.CakeTable
{
    class MakerThreadMT05
    {
        private readonly string name;
        private readonly CakeTableMT05 table;
        private readonly Random random;
        private static Object lockObj = new Object();
        private static int id = 0;

        public MakerThreadMT05(string name, CakeTableMT05 table, int seed)
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
                    Thread.Sleep(random.Next(1000));
                    string cake = $"[Cake No.{NextId()} by {name}]";
                    table.PutCake(name, cake);
                }//while loop
            }
            catch(ThreadInterruptedException e)
            {
                Console.WriteLine(e.GetType());
            }
        }//Run()

        private static int NextId()
        {
            lock (lockObj)
            {
                return id++;
            }
        }//NextId
    }//class
}
