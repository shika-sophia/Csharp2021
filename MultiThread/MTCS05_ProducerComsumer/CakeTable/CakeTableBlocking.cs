using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.CakeTable
{
    class CakeTableBlocking : AbsCakeTable
    {
        private readonly ConcurrentQueue<string>
           queue = new ConcurrentQueue<string>();
        private readonly int LIMIT;

        public CakeTableBlocking(int limit)
        {
            this.LIMIT = limit;
        }

        public override void PutCake(string cake)
        {
            while(queue.Count >= LIMIT)
            {
                Thread.SpinWait(100);
            }//while

            queue.Enqueue(cake);
            Thread.Yield();

            Console.WriteLine($"Count {queue.Count}: PutCake({cake})");
        }//PutCake()

        public override string TakeCake()
        {
            string cake;
            while(!queue.TryDequeue(out cake))
            {
                Thread.SpinWait(100);
            }//while

            Console.WriteLine($"Count {queue.Count}: TakeCake() {cake}");
            Thread.Yield();
            return cake;
        }//TakeCake()
    }//class
}
