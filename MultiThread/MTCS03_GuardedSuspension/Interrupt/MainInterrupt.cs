/** 
 *@title CsharpBegin / MultiThread / MTCS03_GuardedSuspension / Interrupt / MainInterrupt.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第３章 GuardedSuspension / p136, p497 / 練習問題 3-6 / List 3-14,
 *@subject ◆Interrupt()を用いて、Threadを終了するプログラム
 *         Thread.Sleep();
 *         Thread.Interrupt();
 *         
 *         【解答】[Java] 修正点
 *         ＊try-catch を ClientThread, ServerThreadでも
 *           実装して、Interrupt()を受け取るようにする。
 *         ＊wait()する RequestQueue.GetRequest()のメソッド宣言に
 *           throws句を付けて Main() catchにExceptionの処理を委譲。
 *           
 *         〔【Answer】[Java] Modification Point:
 *         ＊It should be put 'try-catch' in ClientThread and ServerThread
 *           in order to catch 'InterruptedException'.
 *         ＊'RequestQueue.GetRequest()' which do 'wait()', should add 'throws' phrase
 *         at the method definition. 〕
 *         
 *@class MainInterrupt
 *       / ◆Main()
 *         new RequestQueue();
 *         new ClientThread();
 *         new ServerThread();
 *         new Thread(ThreadStart) * 2
 *           └ delegate void ThreadStart();
 *              └ XxxxThread.Run()
 *         Thread.Sleep();
 *         Thread.Interrupt();
 * 
 *@author shika 
 *@date 2021-12-26 
*/
using CsharpBegin.MultiThread.MTCS03_GuardedSuspension.GuardedSuspension;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS03_GuardedSuspension.Interrupt 
{ 
    class MainInterrupt 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var queue = new RequestQueue();
            var client = new ClientThreadMT03(queue, "Alice", 314159);
            var server = new ServerThreadMT03(queue, "Bobby", 265358);
            var thA = new Thread(client.Run);
            var thB = new Thread(server.Run);
            thA.Start();
            thB.Start();

            //---- 10 sec wait ----
            try
            {
                Thread.Sleep(10000);
            } catch (ThreadInterruptedException) { }

            //---- interrupt ----
            Console.WriteLine("**** calling interrupt ****");
            thA.Interrupt();
            thB.Interrupt();
        }//Main() 
    }//class 
}

/*
//====== Reault ======
  :
ServerThread Bobby: gets [ Request No.16 ].
ClientThread Alice: requests [ Request No.17 ]
**** calling interrupt ****

【考察】
オリジナル・コードでは、Innterrupt()が呼ばれても
即時に停止せず、スレッド処理が継続していた。
練習問題 3-6は「それを即時停止するように修正せよ」
との課題であったが、[C#]だと Main()だけで即時停止した。
解答を見ても理由は不明。Javaと C#の仕様の違いかも。

〔【NOTE】
In the original code, though it called 'Interrupt()',
it stoped running not immediately, it continued to run in Threads.
Therefore, Practice 3-6 quests that
  "How do you modify the other class in order to stop immediately?"
But [C#] code realized that, by ONLY 'Main()'.
I didn't find why, as seeing this answer.
Perhaps, the cause may be difference from
  Java and C# language specification(?)〕
 */