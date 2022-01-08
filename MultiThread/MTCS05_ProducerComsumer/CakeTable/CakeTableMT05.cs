using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.CakeTable
{
    class CakeTableMT05 : AbsCakeTable
    {
        private readonly string[] buffer;
        private int head = 0; //index for TakeCake() 
        private int tail = 0; //index for PutCake()
        private int count = 0;//buffer.Length

        public CakeTableMT05(int limit)
        {
            this.buffer = new string[limit];
        }

        public override void PutCake(string cake)
        {
            ReCondition:
            while(count >= buffer.Length)
            {
                Thread.SpinWait(100);
            }//while

            lock (this)
            {
                if(count >= buffer.Length) { goto ReCondition; }

                buffer[tail] = cake;
                tail = (tail + 1) % buffer.Length;
                count++;

                Console.WriteLine(
                    $"Count {count}: PutCake({cake})");
            }//lock

            Thread.Yield();
        }//PutCake()

        public override string TakeCake()
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
                    $"Count {count}: TakeCake() {cake}");

                Thread.Yield();
                return cake;
            }//lock                
        }//TakeCake()

        public override void ClearCake()
        {
            lock (this)
            {
                Console.WriteLine(
                        $"Count {count}: ClearCake()");

                for (int i = 0; i < buffer.Length; i++)
                {
                    buffer[i] = null;
                }//for

                head = 0;
                tail = 0;
                count = 0;
                Thread.Yield();
            }//lock
        }//ClearCake()
    }//class
}
