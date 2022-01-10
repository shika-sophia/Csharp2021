using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.ReadWrite
{
    class ReadThreadMT06
    {
        private readonly string thName;
        private readonly DataMT06 data;

        public ReadThreadMT06(string thName, DataMT06 data)
        {
            this.thName = thName;
            this.data = data;
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    char[] readBuffer = data.TryRead();
                    Console.WriteLine(
                        $"{thName}: reads {String.Join("", readBuffer)}");
                }//while
            }
            catch (ThreadInterruptedException) { }
        }
    }//class
}
