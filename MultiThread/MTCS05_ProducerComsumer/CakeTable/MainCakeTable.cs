/** 
 *@title CsharpBegin / MultiThread / MTCS05_ProducerComsumer / CakeTable / MainCakeTable.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第５章 Producer-Consumer / p164 / List 5-1, 5-2, 5-3, 5-4 
 *@subject Maker, Eaterの処理速度が異なる状況で、
 *         製品だけを配列 string[] buffer に渡して、すぐに戻る非同期モデル。
 *         
 *@subject 配列のインデックス操作が 配列の規模 buffer.Lengthを越えないように
 *         剰余算を用いて、規模内のインデックスに収める。
 *         head = (head + 1) % buffer.Length;
 *         tail = (tail + 1) % buffer.Length;
 *         
 *subject [Java] Thread.wait()は lockを解放するが、
 *        [C#]   Thread.SpinWait()は lockを解放せずに waitしている様子。
 *        => 巻末【考察】参照
 *
 *@directory ==== CakeTable ====
 *@class MainCakeTable
 *       / ◆Main()
 *           new CakeTableMT05(int limit);
 *           new MakerThreadMT05(string name, CakeTableMT05, int seed) * 3
 *           new EaterThreadMT05(string name, CakeTableMT05, int seed) * 3
 *           new Thread(ThreadStart) * 6
 *                └  delegate void ThreadStart();
 *                     └ XxxxThread.Run();
 *@class CakeTableMT05
 *       / - readonly string[] buffer;
 *         - int head; //index for TakeCake() 
 *         - int tail; //index for PutCake()
 *         - int count;//buffer.Length /
 *       + CakeTableMT05(int limit) 
 *          { this.buffer = new string[limit]; }
 *       + void PutCake(string name, string cake)
 *          { buffer[tail] = cake; }
 *       + string TakeCake(string name)
 *          { string cake = buffer[head]; }
 *          
 *@class MakerThreadMT05
 *       / - readonly string name;
 *         - readonly CakeTableMT05 table;
 *         - readonly Random random;
 *         - static Object lockObj = new Object();
 *         - static int id; /
 *       + MakerThreadMT05(string name, CakeTableMT05, int seed)
 *       + void Run() 
 *           { string cake; table.PutCake(name, cake); }
 *           
 *@class EaterThreadMT05
 *       / - readonly string name;
 *         - readonly CakeTableMT05 table;
 *         - readonly Random random;  /
 *       + EaterThreadMT05(string name, CakeTableMT05, int seed)
 *       + void Run() 
 *           { string cake = table.TakeCake(name); }
 *           
 *@author shika 
 *@date 2022-01-03 
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
            CakeTableMT05 table = new CakeTableMT05(3);
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

[Java] Thread.wait()は lockを手放して waitするが
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

Maker1: PutCake([Cake No.0 by Maker1])
Eater1: TakeCake() [Cake No.0 by Maker1]
Maker3: PutCake([Cake No.1 by Maker3])
Eater2: TakeCake() [Cake No.1 by Maker3]
Maker2: PutCake([Cake No.2 by Maker2])
Eater2: TakeCake() [Cake No.2 by Maker2]
Maker3: PutCake([Cake No.3 by Maker3])
Eater3: TakeCake() [Cake No.3 by Maker3]
Maker1: PutCake([Cake No.4 by Maker1])
Eater2: TakeCake() [Cake No.4 by Maker1]
Maker3: PutCake([Cake No.5 by Maker3])
Eater1: TakeCake() [Cake No.5 by Maker3]
Maker1: PutCake([Cake No.6 by Maker1])
Maker3: PutCake([Cake No.7 by Maker3])
Eater2: TakeCake() [Cake No.6 by Maker1]
Eater3: TakeCake() [Cake No.7 by Maker3]
Maker2: PutCake([Cake No.8 by Maker2])
Maker2: PutCake([Cake No.9 by Maker2])
Eater2: TakeCake() [Cake No.8 by Maker2]
Maker3: PutCake([Cake No.10 by Maker3])
Maker3: PutCake([Cake No.11 by Maker3])
Eater1: TakeCake() [Cake No.9 by Maker2]
Eater3: TakeCake() [Cake No.10 by Maker3]
Maker1: PutCake([Cake No.12 by Maker1])
Maker2: PutCake([Cake No.13 by Maker2])
Eater2: TakeCake() [Cake No.11 by Maker3]
Eater2: TakeCake() [Cake No.12 by Maker1]
Maker3: PutCake([Cake No.14 by Maker3])
Maker1: PutCake([Cake No.15 by Maker1])
  :
 */