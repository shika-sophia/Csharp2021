using CsharpBegin.MultiThread.MTCS06_ReadWriteLock.Concurrent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.ReadWrite
{
    class ReadThreadMT06
    {
        private readonly string thName;
        private readonly AbsDataMT06 data;

        public ReadThreadMT06(string thName, AbsDataMT06 data)
        {
            this.thName = thName;
            this.data = data;
        }

        public void Run()
        {
            var sw = new Stopwatch();
            sw.Start();
            try
            {
                               
                int LIMIT = 20;               
                for(int i = 0; i < LIMIT; i++)
                {
                    char[] readBuffer = data.TryRead();
                    Console.WriteLine(
                        $"{thName}: reads {String.Join("", readBuffer)}");
                }//for
            }
            catch (ThreadInterruptedException) { }

            sw.Stop();
            Console.WriteLine(
                $"{thName} Cost Time: {sw.ElapsedMilliseconds} (milliSeconds)");
        }
    }//class
}
