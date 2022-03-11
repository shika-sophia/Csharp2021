/** 
 *@title CsharpBegin / MultiThread / MTCS10_TwoPhaseTermination / TwoPhaseTermination / MainTwoPhaseTermination.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第10章 Two Phase Termination / p324 / List 10-1, 10-2
 *         ～ あとかたづけしてから、おやすみなさい ～
 *         || TwoPhaseTermination ||
 *         ＊２段階の終了: 作業中 -> 終了処理中 -> 終了
 *           ・安全性: 安全に終了する
 *           ・生存性: 必ず終了処理を行う。
 *           ・応答性: 終了要求をしたら、できるだけ早く終了処理に入る
 *         ＊TerninationRequester = Main
 *         ＊Terminator = CounterThread.DoShutdown()
 *         安全性を考慮した上で終了処理中の状態に入る。
 *         終了処理が完了した後、プログラム(= MainThread)が終了する。
 *         
 *@subject〔concurrent〕= 複数Threadが利用可
 *         ShutsownRequest(), IsShutdownRequested()に
 *         なぜ [Java] synchronized / [C#] lockをしないか
 *         Latchフラグ: プログラム中で一度しか変更しないフラグ
 *         false -> true と true -> falseの DataRace(= 競合 conflict)することがない。
 *         
 *@subject CurrentThread.Interrupt()が必要な理由
 *         フラグ shutdownReq = true;だけだと、
 *         CurrentThreadが Sleep()中の場合、
 *         Sleep()が終了してからフラグ判定するので、応答性が悪くなる。
 *         
 *@class MainTwoPhaseTermination
 *       //
 *       ◆Main()
 *       new CounterThread
 *       new Thread
 *       countTh.ShutdownRequest()
 *       th.Join()
 *
 *@class CountdownThread
 *       / - long counter;
 *         - volatile bool shutdownReq; /
 *       + void ShutDownRequest(Thread[])  〔concurrent〕
 *       + bool IsShutdownRequested()      〔concurrent〕
 *       + void Run()
 *       - void DoWork()
 *       - void DoShutdown()
 *     
 *@author shika 
 *@date 2022-03-12 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.TwoPhaseTermination 
{ 
    class MainTwoPhaseTermination 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            Thread.CurrentThread.Name = "MainThread";
            
            Console.WriteLine("Main: BEGIN");
            try
            {
                var countTh = new CountupThread();
                var th = new Thread(countTh.Run);
                th.Name = "CountThread";
                th.Start();

                Thread.Sleep(5000);

                Console.WriteLine("Main: ShutdownRequest()");
                countTh.ShutdownRequest(new Thread[] { th });

                Console.WriteLine("Main: Join()");
                th.Join();
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is interrupted.");
            }

            Console.WriteLine("Main: END");
        }//Main() 
    }//class 
}

/*
//---- CounterThread.Interrupt() ----
Main: BEGIN
DoWork(): counter = 1
DoWork(): counter = 2
DoWork(): counter = 3
DoWork(): counter = 4
DoWork(): counter = 5
DoWork(): counter = 6
DoWork(): counter = 7
DoWork(): counter = 8
DoWork(): counter = 9
DoWork(): counter = 10
Main: ShutdownRequest()
Main: Join()
CountThread is interrupted.
DoShutdown(): counter = 10
Main: END                  <- after CounterThread shutdown

//---- Thread.CurrentThread.Interrupt() ----
//MainThread is interrupted in Thread.Join().
//CounterThread is running still.
//It is fault of this program purpose.

Main: BEGIN
DoWork(): counter = 1
DoWork(): counter = 2
DoWork(): counter = 3
DoWork(): counter = 4
DoWork(): counter = 5
DoWork(): counter = 6
DoWork(): counter = 7
DoWork(): counter = 8
DoWork(): counter = 9
DoWork(): counter = 10
Main: ShutdownRequest()
Main: Join()
MainThread is interrupted.
Main: END                 <- before CounterThread shutdown
DoShutdown(): counter = 10
 */