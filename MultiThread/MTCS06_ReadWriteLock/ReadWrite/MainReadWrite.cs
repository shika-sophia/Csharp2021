/** 
 *@title CsharpBegin / MultiThread / MTCS06_ReadWriteLock / ReadWrite / MainReadWrite.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第６章 Read-Write Lock / p198 / List 6-1, 6-2, 6-3, 6-4
 *         ||Read-Write Lock||「みんなで読んでいいけど、書いている間は読んじゃダメ」
 *@subject ◆Sample Code
 *         Guard Condition: (whileは待機条件)
 *         ＊Read時 書いているスレッドがなく、書き待機もない場合のみ
 *             while(writing > 0 
 *                  || (preferWrite && waitWrite > 0))
 *         ＊Write時 読んでいる途中、書いている途中のスレッドが存在しない場合のみ
 *             while (reading > 0 || writing > 0)
 *             
 *@note 【考察】
 *       [Java] Object.wait(); 待機中は Lock解放
 *       [C#]   Thread.SpinWait(-1);待機中も Lockを保持したまま
 *       
 *       ここも、やはり [C#]の SpinWait()の仕様により、
 *       [Java]テキストコードそのままだと DeadLockを起こす。
 *       原因は ReadThread, WriteThreadが Lockを保持したまま、
 *       SpinWait(Timeout.Infinite)に入り、他Threadが
 *       ReadWriteLockの他メソッドに入れなくなり、
 *       Thread.Yield()もされないし、ガード条件も変更しないため、DeadLock。
 *       
 *       二度の同じ条件判定をするのは不本意ながら、
 *       while(待機条件式){ SpinWait(Timeout.Infinite);}を
 *       lock()から外し、lock()内で改めて if(待機条件)を行う。
 *       こうしないとテキストコードの意図通りの動作は得られない。
 *       
 *       [C#]の Threadクラスのメソッドに Lock解放して待機するものがないか
 *       探してみたが、見つからず。他に良い方法はないものか。
 *       ひとつの可能性としては、BlockingQueue<T>や SynchronizedCollection<T>のような、
 *       排他処理をするConcurrent系のコレクションを共有リソースに起用することである。
 */
#region -> Class-Chart
/*       ==== ReadWrite ====
 *@class MainReadWrite
 *       // ◆Main()
 *       AbsReadWrite lockRW = new ReadWriteLock();
 *       new DataMT06(int bufferSize, AbsReadWrite);
 *       new ReaderThreadMT06(string thName, DataMT06); * 6
 *       new WriterThreadMT06(DataMT06); * 2
 *       new Thread(ThreadStart);
 *         └ delegate void ThreadStart();
 *            └ XxxxThread.Run();
 *       - string Alphabet(char);
 *       
 *@class AbsReadWrite
 *       + abstract void ReadLock();
 *       + abstract void ReadUnlock();
 *       + abstract void WriteLock();
 *       + abstract void WriteUnlock();
 *       
 *@class ReadWriteLock : AbsReadWrite
 *       / - int reading = 0;   //Read中の Thread数
 *         - int waitWrite = 0; //Write待機中の Thread数
 *         - int writing = 0;   //Write中の Thread数
 *         - bool preferWrite = true; //Write優先なら true /
 *       + override void ReadLock()
 *           { while(writing > 0 
 *                  || (preferWrite && waitWrite > 0))
 *             { Thread.SpinWait(Timeout.Infinite); }}
 *             
 *       + override void ReadUnlock() {  Thread.Yield(); }
 *       + override void WriteLock()
 *           { while (reading > 0 || writing > 0)
 *             { Thread.SpinWait(Timeout.Infinite); }}
 *       + override void WriteUnlock() {  Thread.Yield(); }
 *
 *@class DataMT06
 *       / - readonly char[] buffer;
 *         - readonly ◇AbsReadWrite lockRW; /
 *      + DataMT06(int bufferSize, AbsReadWrite lockRW)
 *      + char[] TryRead()
 *          { lockRW.ReadLock();
 *            DoRead();
 *            lockRW.ReadUnlock(); }
 *      + void TryWrite(char)
 *          { lockRW.WriteLock();
 *            DoWrite();
 *            lockRW.WriteUnlock(); }
 *      - char[] DoRead() { char[] newBuffer[i] = buffer[i]; }
 *      - void  DoWrite() { buffer[i] = c; }
 *      - void Slowly()
 *      
 *@class ReadThreadMT06
 *       / - readonly string thName;
 *         - readonly ◇DataMT06 data; /
 *       + ReadThreadMT06(string thName, DataMT06 data)
 *       + void Run() { char[] readBuffer = data.TryRead(); }
 *       
 *@class WriterThreadMT06
 *       / - readonly ◇DataMT06 data; /
 *       + WriteThreadMT06(DataMT06 data)
 *       + void Run() { data.TryWrite(char); }
 *       - char NextChar()
 */
#endregion
/*
 *@author shika 
 *@date 2022-01-10 
*/
using CsharpBegin.MultiThread.MTCS06_ReadWriteLock.Performance;
using System; 
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.ReadWrite 
{ 
    class MainReadWrite 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            AbsReadWriteLock lockRW = new ReadWriteLockMT06();
            var data = new DataMT06(bufferSize: 10, lockRW);
            
            var readerAry = new ReadThreadMT06[6];
            for (int i = 0; i < readerAry.Length; i++)
            {
                readerAry[i] = new ReadThreadMT06($"reader{i}", data);
                new Thread(readerAry[i].Run).Start();
            }//for
            
            var here = new MainReadWrite();
            var writer1 = new WriteThreadMT06(data, here.Alphabet('A'));
            var writer2 = new WriteThreadMT06(data, here.Alphabet('a'));
            new Thread(writer1.Run).Start();
            new Thread(writer2.Run).Start();
        }//Main() 

        internal string Alphabet(char init)
        {
            var bld = new StringBuilder(26);

            for(int i = init; i < 26 + init; i++)
            {
                bld.Append((char) i);
            }

            return bld.ToString();
        }

        ////==== Test Main() for Alphabet(char) ====
        //static void Main()
        //{
        //    var here = new MainReadWrite();
        //    string filter1 = here.Alphabet('A');
        //    string filter2 = here.Alphabet('a');
        //    Console.WriteLine($"filter1: {filter1}\nfilter2: {filter2}");
        //}
    }//class 
}

/*
reader1: reads **********
reader4: reads **********
reader2: reads **********
reader3: reads **********
reader5: reads **********
reader0: reads **********
reader5: reads aaaaaaaaaa
reader3: reads aaaaaaaaaa
reader2: reads aaaaaaaaaa
reader0: reads aaaaaaaaaa
reader1: reads aaaaaaaaaa
reader4: reads aaaaaaaaaa
reader1: reads AAAAAAAAAA
reader4: reads AAAAAAAAAA
reader5: reads AAAAAAAAAA
reader2: reads AAAAAAAAAA
  :
reader3: reads AAAAAAAAAA
reader5: reads AAAAAAAAAA
reader0: reads AAAAAAAAAA
reader1: reads bbbbbbbbbb
reader2: reads bbbbbbbbbb
reader3: reads bbbbbbbbbb
reader4: reads bbbbbbbbbb
reader5: reads bbbbbbbbbb
reader0: reads bbbbbbbbbb
reader3: reads BBBBBBBBBB
reader4: reads BBBBBBBBBB
reader1: reads BBBBBBBBBB
  :

//==== Test Main() for Alphabet(char) ====
filter1: ABCDEFGHIJKLMNOPQRSTUVWXYZ
filter2: abcdefghijklmnopqrstuvwxyz
 */