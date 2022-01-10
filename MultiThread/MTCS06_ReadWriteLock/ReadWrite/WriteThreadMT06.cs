using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.ReadWrite
{
    class WriteThreadMT06
    {
        private readonly DataMT06 data;
        private readonly string filter;
        private readonly Random random = new Random();
        private int index = 0;

        public WriteThreadMT06(DataMT06 data, string filter)
        {
            this.data = data;
            this.filter = filter;
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    char c = NextChar();
                    data.TryWrite(c);

                    Thread.Sleep(random.Next(3000));
                }//while
            }
            catch (ThreadInterruptedException) { }
                
        }//Run()

        private char NextChar()
        {
            char c = filter.ToCharArray()[index];
            index = (index + 1) % filter.Length;

            return c;
        }//NextChar()
    }//class
}
