using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.Exchanger
{
    class ProduceCharThread
    {
        private readonly ExchangerCS<char[]> ex;
        private readonly string thName;
        private readonly Random random;
        private char[] buffer;
        private char index = (char) 0;

        public ProduceCharThread(
            ExchangerCS<char[]> ex, char[] buffer, int seed)
        {
            this.ex = ex;
            this.thName = nameof(ProduceCharThread);
            this.random = new Random(seed);
            this.buffer = buffer;
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    //---- insert char into buffer ----
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        buffer[i] = NextChar();
                        Console.WriteLine($"{thName}: {buffer[i]} ->");
                    }//for

                    //---- exchange buffer ----
                    Console.WriteLine($"{thName}: BEFORE Excahnge()");
                    buffer = ex.Exchange(buffer);
                    Console.WriteLine($"{thName}: AFTER  Excahnge()");
                }//while loop
            }
            catch(ThreadInterruptedException e)
            {
                Console.WriteLine(e.GetType());
            }
        }//Run()

        //==== produce char ====
        private char NextChar() 
        {
            char c = (char) ('A' + index % 26);
            index++;
            Thread.Sleep(random.Next(1000));

            return c;
        }//NextChar() 
    }//class
}
