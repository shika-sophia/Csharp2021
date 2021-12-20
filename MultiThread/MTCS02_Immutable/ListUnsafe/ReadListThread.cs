using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS02_Immutable.ListUnsafe
{
    class ReadListThread<T>
    {
        private readonly ICollection<T> list;

        public ReadListThread(ICollection<T> list)
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
