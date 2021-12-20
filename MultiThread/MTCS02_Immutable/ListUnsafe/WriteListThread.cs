using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS02_Immutable.ListUnsafe
{
    class WriteListThread
    {
        private readonly ICollection<int> list;
        private const int LIMIT = 1000;

        public WriteListThread(ICollection<int> list)
        {
            this.list = list;
        }

        public void Run()
        {
            for(int i = 0; i < LIMIT; i++)
            {
                list.Add(i);
            }//foreach
        }
    }//class
}
