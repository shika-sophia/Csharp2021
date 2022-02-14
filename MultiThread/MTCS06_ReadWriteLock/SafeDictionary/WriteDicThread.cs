using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.SafeDictionary
{
    class WriteDicThread
    {
        private readonly Random random = new Random(314159);
        private readonly DatabaseMT06<string, string> db;
        private readonly string thName;
        private string key;
        private string value;

        public WriteDicThread(
            DatabaseMT06<string, string> db, string thName,
            string key, string value)
        {
            this.db = db;
            this.thName = thName;
            this.key = key;
            this.value = value;
        }

        public void Run()
        {
            while(true)
            {
                Console.WriteLine($"{thName}: Assign [{key}:{value}]");
                db.Assign(key, value);

                Thread.Sleep(random.Next(1000));
            }//while
        }//Run()

    }//class
}
