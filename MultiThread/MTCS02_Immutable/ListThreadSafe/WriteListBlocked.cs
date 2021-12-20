using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS02_Immutable.ListThreadSafe
{
    class WriteListBlocked
    {
        private readonly BlockingCollection<int> list;
        private const int LIMIT = 1000;

        public WriteListBlocked(BlockingCollection<int> list)
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
