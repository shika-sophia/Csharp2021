using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.Exchanger
{
    class ConsumeCharThread
    {
        private readonly ExchangerCS<char[]> ex;
        private readonly string thName;
        private readonly Random random;
        private char[] buffer;

        public ConsumeCharThread(
            ExchangerCS<char[]> ex, char[] buffer, int seed)
        {
            this.ex = ex;
            this.thName = nameof(ConsumeCharThread);
            this.random = new Random(seed);
            this.buffer = buffer;
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    //---- exchange buffer ----
                    Console.WriteLine($"{thName}: BEFORE Excahnge()");
                    buffer = ex.Exchange(buffer);
                    Console.WriteLine($"{thName}: AFTER  Excahnge()");

                    //---- pull out from buffer ----
                    for(int i = 0; i < buffer.Length; i++)
                    {
                        Console.WriteLine($"{thName}: -> {buffer[i]}");
                        Thread.Sleep(random.Next(1000));
                    }
                }//while loop
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.GetType());
            }
        }//Run()
    }//class
}
