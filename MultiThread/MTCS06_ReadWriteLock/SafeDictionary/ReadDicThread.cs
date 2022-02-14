using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.SafeDictionary
{
    class ReadDicThread
    {
        private readonly DatabaseMT06<string, string> db;
        private readonly string thName;
        private readonly string key;

        public ReadDicThread(
            DatabaseMT06<string,string> db, string thName, string key)
        {
            this.db = db;
            this.thName = thName;
            this.key = key;
        }

        public void Run()
        {
            int count = 0;
            while (true)
            {
                Interlocked.Increment(ref count);
                string value = db.Retreive(key);
                Console.Write($"{thName} [{count}] {key}: {value}], ");

                if(count % 3 == 0)
                {
                    Console.WriteLine();
                }
            }//while loop
        }//Run()
    }//class
}
