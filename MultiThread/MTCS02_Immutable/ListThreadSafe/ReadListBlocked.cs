using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS02_Immutable.ListThreadSafe
{
    class ReadListBlocked<T>
    {
        private readonly BlockingCollection<T> list;

        public ReadListBlocked(BlockingCollection<T> list)
        {
            this.list = list;
        }

        public void Run()
        {
            while (true)
            {
                foreach (T value in list)
                {
                    Console.WriteLine(value);
                }
            }//while loop
        }
    }//class 
}
