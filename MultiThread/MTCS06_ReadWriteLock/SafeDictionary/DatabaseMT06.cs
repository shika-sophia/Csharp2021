using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.SafeDictionary
{
    class DatabaseMT06<K,V>
    {
        internal Dictionary<K, V> dic = new Dictionary<K, V>();
        private readonly ReaderWriterLockSlim lockRW = new ReaderWriterLockSlim();

        public void Clear()
        {
            lockRW.EnterWriteLock();
            try
            {
                VerySlowly();
                dic.Clear();
            }
            finally
            {
                lockRW.ExitWriteLock();
            }
        }//Clear()

        public void Assign(K key, V value) //[英] assign: 割当
        {
            lockRW.EnterWriteLock();
            try {
                VerySlowly();
                dic. Add(key, value);
            }
            finally
            {
                lockRW.ExitWriteLock();
            }
        }//Assign()

        public V Retreive(K key) //[英] retrieve: 取得
        {
            lockRW.EnterReadLock();
            try {
                Slowly();
                dic.TryGetValue(key, out V value);

                return value;
            }
            finally
            {
                lockRW.ExitReadLock();
            }
        }//Retreive()

        private void Slowly()
        {
            try
            {
                Thread.Sleep(50);
            }
            catch (ThreadInterruptedException) { }
        }//Slowly()

        private void VerySlowly()
        {
            try
            {
                Thread.Sleep(500);
            }
            catch (ThreadInterruptedException) { }
        }//VerySlowly()

        public override string ToString()
        {
            var bld = new StringBuilder(dic.Count * 10);

            int count = 1;
            foreach(KeyValuePair<K,V> entry in dic)
            {
                bld.Append($"[{entry.Key}: {entry.Value}], ");

                if(count % 5 == 0)
                {
                    bld.Append("\n");
                }
                count++;
            }//foreach

            //Console.WriteLine($"bld.Length: {bld.Length}");
            return bld.ToString();
        }
    }//class
}
