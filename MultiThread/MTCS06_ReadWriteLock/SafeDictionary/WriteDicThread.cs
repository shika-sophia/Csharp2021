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
        private readonly DatabaseMT06<int, char> db;
        private readonly string thName;

        public WriteDicThread(
            DatabaseMT06<int, char> db, string thName)
        {
            this.db = db;
            this.thName = thName;
        }

        public void Run()
        {
            for(int i = 0; true; Interlocked.Increment(ref i))
            {
                lock (db)
                {
                    while(db.dic.ContainsKey(i))
                    {
                        Interlocked.Increment(ref i);
                    }//while

                    char c = NextAlphabet(i);
                    Console.WriteLine($"{thName}: Assign [{i}:{c}]");
                    db.Assign(i, c);
                }//lock

                Thread.Sleep(random.Next(1000));
            }//for loop
        }//Run()

        private char NextAlphabet(int index)
        {
            return (char) ('A' + (index % 26));
        }
    }//class
}
