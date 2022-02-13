using CsharpBegin.MultiThread.MTCS06_ReadWriteLock.ReadWrite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.Performance
{
    class MainPerformanceMT06
    {
        //static void Main(string[] args)
        public void Main(string[] args) 
        {
            //AbsReadWriteLock lockRW = new ReadWriteLockMT06();
            AbsReadWriteLock lockRW = new BothLockMT06();

            var data = new DataMT06(bufferSize: 10, lockRW);
            
            var sw = new Stopwatch();
            sw.Start();
            var readerAry = new ReadThreadMT06[6];
            var threadAry = new Thread[6];
            for (int i = 0; i<readerAry.Length; i++)
            {
                readerAry[i] = new ReadThreadMT06($"reader{i}", data);
                threadAry[i] = new Thread(readerAry[i].Run);
                threadAry[i].Start();
            }//for

            var there = new MainReadWrite();
            var writer1 = new WriteThreadMT06(data, there.Alphabet('A'));
            var writer2 = new WriteThreadMT06(data, there.Alphabet('a'));
            new Thread(writer1.Run).Start();
            new Thread(writer2.Run).Start();

            //---- performance ----
            for (int i = 0; i < threadAry.Length; i++)
            {
                threadAry[i].Join();
            }//for

            sw.Stop();
            Console.WriteLine(
                $"Main Cost Time: {sw.ElapsedMilliseconds} (milliSeconds)");
        }//Main() 
    }//class
}

/*
//---- ReadWriteLockMT06() ----
reader5 Cost Time: 10111 (milliSeconds)
reader3 Cost Time: 10113 (milliSeconds)
reader0 Cost Time: 10117 (milliSeconds)
reader1 Cost Time: 10119 (milliSeconds)
reader4 Cost Time: 10119 (milliSeconds)
reader2 Cost Time: 10121 (milliSeconds)
Main Cost Time: 10123 (milliSeconds)

//---- BothLockMT06() ----
reader3 Cost Time: 21609 (milliSeconds)
reader1 Cost Time: 29078 (milliSeconds)
reader4 Cost Time: 30275 (milliSeconds)
reader2 Cost Time: 38391 (milliSeconds)
reader0 Cost Time: 43908 (milliSeconds)
reader5 Cost Time: 52530 (milliSeconds)
Main Cost Time: 52534 (milliSeconds)

【NOTE】
処理時間表示の間に 通常表示があるが、そこは削除してコピー。
ReadWriteLockMT06()は ほぼ同時に終了するが、
BothLockMT06()は 間に何行も表示してから終了する。

ReaderThread.Run()内で
同様のコードを while(count > LIMIT)とすると、
すぐに終了してしまう。

reader0 Cost Time: 0 (milliSeconds)
reader2 Cost Time: 0 (milliSeconds)
reader5 Cost Time: 0 (milliSeconds)
reader1 Cost Time: 0 (milliSeconds)
reader3 Cost Time: 0 (milliSeconds)
reader4 Cost Time: 0 (milliSeconds)
Main Cost Time: 3 (milliSeconds)

それを for(int i = 0; i < LIMIT; i++)だと
ちゃんと動作する。
 */