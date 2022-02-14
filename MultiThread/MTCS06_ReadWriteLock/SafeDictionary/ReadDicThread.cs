using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.SafeDictionary
{
    class ReadDicThread
    {
        private readonly Random random = new Random(112344);
        private readonly DatabaseMT06<int,char> db;
        private readonly string thName;

        public ReadDicThread(
            DatabaseMT06<int,char> db, string thName)
        {
            this.db = db;
            this.thName = thName;
        }

        public void Run()
        {
            for (int i = 0; true; i++)
            {
                while (!db.dic.ContainsKey(0))
                {
                    Thread.Sleep(50);
                }//while
                
                char c = db.Retreive(i);
                Console.WriteLine($"{thName}: Retreive [{i}:{c}], ");
            }//for loop
        }//Run()
    }//class
}
