using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.CakeTable
{
    class CakeTableMT05
    {
        private readonly string[] buffer;
        private int head = 0; //index for TakeCake() 
        private int tail = 0; //index for PutCake()
        private int count = 0;//buffer.Length

        public CakeTableMT05(int limit)
        {
            this.buffer = new string[limit];
        }

        public void PutCake(string name, string cake)
        {
            lock (this)
            {
                while(count >= buffer.Length)
                {
                    Thread.SpinWait(100);
                }//while

                buffer[tail] = cake;
                tail = (tail + 1) % buffer.Length;
                count++;

                Console.WriteLine(
                    $"{name}: PutCake({cake})");
            }//lock

            Thread.Yield();
        }//PutCake()

        public string TakeCake(string name)
        {
            ReCondition:
            while(count <= 0)
            {
                Thread.SpinWait(100);
            }//while

            lock (this)
            {
                if(count <= 0) { goto ReCondition; }

                string cake = buffer[head];
                head = (head + 1) % buffer.Length;
                count--;

                Console.WriteLine(
                    $"{name}: TakeCake() {cake}");

                Thread.Yield();
                return cake;
            }//lock                
        }//TakeCake()
    }//class
}
