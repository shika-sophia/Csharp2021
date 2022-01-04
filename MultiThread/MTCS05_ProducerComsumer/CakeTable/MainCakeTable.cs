/** 
 *@title CsharpBegin / MultiThread / MTCS05_ProducerComsumer / CakeTable / MainCakeTable.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第５章 Producer-Consumer / p164 / List 5-1, 5-2, 5-3, 5-4 / List 5-5
 *         ||Producer-Comsumer||
 *         ◆Data     string cake
 *         ◆Producer MakerThread
 *         ◆Comsumer EaterThread
 *         ◆Channel  CakeTable / string[] buffer
 *           ・Dataの中継、通信路
 *           ・安全性を確保するためのクラス
 *           ・Producer, Comsumerの処理速度の違いを緩衝
 *              互いに独立して、相手の処理に左右されない。
 *           ・直接 Producer-Comsumerを繋げると、
 *              Producerが Comsumerを呼出ので、
 *              Comsumerの遅延の間、Producerは待機することになる。
 *           ・||GuardedSuspension|| count: buffer[]の要素数
 *                 PutCake()  ガード条件: while(count >= buffer.Length)
 *                 TakeCake() ガード条件: while(count <= 0)
 *         
 *@subject Maker, Eaterの処理速度が異なる状況で、
 *         製品だけを配列 string[] buffer に渡して、すぐに戻る非同期モデル。
 *         
 *@subject 配列のインデックス操作が 配列の規模 buffer.Lengthを越えないように
 *         剰余算を用いて、規模内のインデックスに収める。
 *         head = (head + 1) % buffer.Length;
 *         tail = (tail + 1) % buffer.Length;
 *         
 *subject [Java] Object.wait()は lockを解放するが、
 *        [C#]   Thread.SpinWait()は lockを解放せずに waitしている様子。
 *        => 巻末【考察】参照
 *
 *@subject 同期制御コレクションの利用
 *         [Java] ArrayBlockingQueue<String> (java.util.concurrent.)
 *         [C#]   ConcurrentQueue<string>    (System.Collections.Concurrent.)
 *         
 *        【考察】ConcurrentQueue<string>を利用
 *         lock()機能は ConcurrentQueueに含まれている。
 *         Queueを利用することで、インデックス操作をしなくて済む。
 *
 *@directory ==== CakeTable ====
 *@class MainCakeTable
 *       / ◆Main()
 *           AbsCakeTable = //abstractで同一視
 *             ---- synchronized / lock() ----
 *             new CakeTableMT05(int limit);
 *             ---- Concurrent Collection ----
 *             new CakeTableBlocking(int limit);
 *           
 *           new MakerThreadMT05(string name, AbsCakeTable, int seed) * 3
 *           new EaterThreadMT05(string name, AbsCakeTable, int seed) * 3
 *           new Thread(ThreadStart) * 6
 *                └  delegate void ThreadStart();
 *                     └ XxxxThread.Run();
 *
 *@class AbsCakeTable
 *       //
 *       + abstract void PutCake(string cake)
 *       + abstract string TakeCake()
 *       
 *@class CakeTableMT05 : AbsCakeTable
 *       / - readonly string[] buffer;
 *         - int head; //index for TakeCake() 
 *         - int tail; //index for PutCake()
 *         - int count;//buffer.Length /
 *       + CakeTableMT05(int limit) 
 *          { this.buffer = new string[limit]; }
 *       + void PutCake(string cake)
 *          { buffer[tail] = cake; }
 *       + string TakeCake()
 *          { string cake = buffer[head]; }
 *
 *@class CakeTableBlocking : AbsCakeTable
 *       / - readonly ConcurrentQueue<string> queue; 
 *         - readonly int LIMIT; /
 *       + CakeTableBlocking(int limit)
 *       + void PutCake(string cake)
 *          { queue.Enqueque(cake); }
 *       + string TakeCake();
 *          { queue.TryDequeue(out string cake) }
 *          
 *@class MakerThreadMT05
 *       / - readonly string name;
 *         - readonly AbsCakeTable table;
 *         - readonly Random random;
 *         - static Object lockObj = new Object();
 *         - static int id; /
 *       + MakerThreadMT05(string name, AbsCakeTable, int seed)
 *       + void Run() 
 *           { string cake; table.PutCake(cake); }
 *           
 *@class EaterThreadMT05
 *       / - readonly string name;
 *         - readonly AbsCakeTable table;
 *         - readonly Random random;  /
 *       + EaterThreadMT05(string name, AbsCakeTable, int seed)
 *       + void Run() 
 *           { string cake = table.TakeCake(); }
 *           
 *@author shika 
 *@date 2022-01-03, 01-04 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.CakeTable 
{ 
    class MainCakeTable 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            //----synchronized / lock () ----
            //AbsCakeTable table = new CakeTableMT05(3);

            //----Concurrent Collection----
            AbsCakeTable table = new CakeTableBlocking(3);
            var maker1 = new MakerThreadMT05("Maker1", table, 31415);
            var maker2 = new MakerThreadMT05("Maker2", table, 92653);
            var maker3 = new MakerThreadMT05("Maker3", table, 58979);
            var eater1 = new EaterThreadMT05("Eater1", table, 32384);
            var eater2 = new EaterThreadMT05("Eater2", table, 62643);
            var eater3 = new EaterThreadMT05("Eater3", table, 38327);

            new Thread(maker1.Run).Start();
            new Thread(maker2.Run).Start();
            new Thread(maker3.Run).Start();
            new Thread(eater1.Run).Start();
            new Thread(eater2.Run).Start();
            new Thread(eater3.Run).Start();
        }//Main() 
    }//class 
}

/*
//==== Original Code ====
Count 0: EntryWait [Cake No.0 by Maker1]
Count 0: EntryWait [Cake No.1 by Maker3]
Count 0: EntryWait [Cake No.2 by Maker2]
  :
( -- Dead Lock -- )

【考察】Original Code
テキストのサンプルコードのままだと、
先に TakeCake()をしに来て、CakeTableの lock()を持っているThreadが
ガード条件の変化を待ち続け、
PutCake()しに来た Threadは上記のように手前までは来ているが
lock()を取れずに、EntryWaitのまま、lock解放を待ち続けて、
DeadLock状態となる。

[Java] Object.wait()は lockを手放して waitするが
[C#] Thread.SpinWait()は lockを手放さずに waitするようだ。

//==== Mod 1 ====
//TakeCake()の lock()から while(count <= 0)を外すと、
//DeadLockは解消するが、以下のように Cakeがなくても食べてしまう。

Maker1: PutCake([Cake No.0 by Maker1])
Eater1: TakeCake() [Cake No.0 by Maker1]
Eater2: TakeCake() 
Eater2: TakeCake() 
Maker3: PutCake([Cake No.3 by Maker3])
Eater3: TakeCake() [Cake No.3 by Maker3]
  :

//==== Mod 2 ====
//TakeCake()の lock内に再度 if(count <= 0)を設け、
//ガード条件に満たなければ、再度 while()へ gotoするようにした。
//同条件を２回判定していて、スマートではない。

Count 1: PutCake([Cake No.0 by Maker1])
Count 0: TakeCake() [Cake No.0 by Maker1]
Count 1: PutCake([Cake No.1 by Maker3])
Count 0: TakeCake() [Cake No.1 by Maker3]
Count 1: PutCake([Cake No.2 by Maker2])
Count 0: TakeCake() [Cake No.2 by Maker2]
Count 1: PutCake([Cake No.3 by Maker3])
Count 0: TakeCake() [Cake No.3 by Maker3]
Count 1: PutCake([Cake No.4 by Maker1])
Count 0: TakeCake() [Cake No.4 by Maker1]
Count 1: PutCake([Cake No.5 by Maker3])
Count 0: TakeCake() [Cake No.5 by Maker3]
Count 1: PutCake([Cake No.6 by Maker1])
Count 2: PutCake([Cake No.7 by Maker3])
Count 1: TakeCake() [Cake No.6 by Maker1]
Count 2: PutCake([Cake No.8 by Maker2])
Count 1: TakeCake() [Cake No.7 by Maker3]
Count 2: PutCake([Cake No.9 by Maker2])
Count 1: TakeCake() [Cake No.8 by Maker2]
Count 2: PutCake([Cake No.10 by Maker3])
Count 3: PutCake([Cake No.11 by Maker3])
Count 2: TakeCake() [Cake No.9 by Maker2]
Count 1: TakeCake() [Cake No.10 by Maker3]
Count 2: PutCake([Cake No.12 by Maker1])
Count 3: PutCake([Cake No.13 by Maker2])
  :
//==== Concurrent Collection ====
//CakeTableBlocking - ConcurrentQueue<string>
Count 0: PutCake([Cake No.0 by Maker1])
Count 0: TakeCake() [Cake No.0 by Maker1]
Count 0: PutCake([Cake No.1 by Maker3])
Count 0: TakeCake() [Cake No.1 by Maker3]
Count 0: PutCake([Cake No.2 by Maker2])
Count 0: TakeCake() [Cake No.2 by Maker2]
Count 0: PutCake([Cake No.3 by Maker3])
Count 0: TakeCake() [Cake No.3 by Maker3]
Count 1: PutCake([Cake No.4 by Maker1])
Count 0: TakeCake() [Cake No.4 by Maker1]
Count 1: PutCake([Cake No.5 by Maker3])
Count 0: TakeCake() [Cake No.5 by Maker3]
Count 0: TakeCake() [Cake No.6 by Maker1]
Count 0: PutCake([Cake No.6 by Maker1])
Count 1: PutCake([Cake No.7 by Maker3])
Count 2: PutCake([Cake No.8 by Maker2])
Count 3: PutCake([Cake No.9 by Maker2])
Count 2: TakeCake() [Cake No.7 by Maker3]
Count 3: PutCake([Cake No.10 by Maker3])
  :
【考察】ConcurrentQueue<string>を利用
lock()機能は ConcurrentQueueに含まれている。
Queueを利用することで、インデックス操作をしなくて済む。

 */