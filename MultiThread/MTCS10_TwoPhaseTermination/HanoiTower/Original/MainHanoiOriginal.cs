/** 
 *@title CsharpBegin / MultiThread / MTCS10_TwoPhaseTermination / HanoiTower / Original / MainHanoiOriginal.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第10章 TwoPhaseTermination / 練習問題 10-7 / p357, p583
 *         問 Originalのコードの応答性を上げる
 *         ShutdownRequest()をしてから、DoShutdown()までの時間を早くする。
 *         
 *@subject ◆パズル【ハノイの塔】Hanoi Tower
 *         ・A, B, C 3本の棒があり、
 *         ・最初は１本の棒に円盤が(ここでは３つ)積まれている。
 *         ・円盤の大きさは全て異なる
 *         ・一番上の円盤を取り、他の棒の一番上に移動できる
 *         ・大きい円盤の上に小さい円盤を載せることはできる。逆は不可。
 *         ・パズルの目的は ある棒に積まれている円盤を、全て他の棒に移動させること
 *         
 *@NOTE 【考察】
 *       応答性が遅延する原因は、ShutdownRequest()をしても
 *       Threadが Wait(), Sleep(), Join()内になければ、Interrupt()しないから。
 *       フラグ shutdownReqを判定するのは、各Level終了時点なので、
 *       時間の掛かる処理中に ShutdownReqest()があっても、
 *       そのLevelの処理を完了させてから、フラグ判定 -> 終了処理に入る。
 *       
 *       解決策は、DoWork()中にフラグ判定するように改良すればいい。
 *       => 〔MainHanoiModified〕
 *
 *@RESULT ==== HanoiThread ====
 *        DoShutDown() costTime = 1759 msec 
 *        //DoWork() { if(level > 0) }
 *        
 *        ==== HanoiThreadModified ====
 *        DoShutDown() costTime = 2 msec
 *        //DoWork()内の if文に 
 *        //if(level > 0 && !IsShutdownRequest())を追加下だけ。
 *        
 *@ANSWER ==== HanoiThreadModified ====
 *        if(level > 0){
 *        { 
 *           if(IsShutdownRequest())
 *           }
 *               throw new ThreadInterruptException();
 *           }
 *        }
 *        
 *        HanoiThread Interrupt()
 *        DoShutDown() costTime = 4 msec
 *                
 *@class MainHanoiOriginal
 *@class HanoiThread
 *@class MainHanoiModified
 *@class HanoiThreadModified
 *
 *@author shika 
 *@date 2022-03-20 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.HanoiTower.Original 
{ 
    class MainHanoiOriginal 
    {
        //static void Main(string[] args)
        public void Main(string[] args) 
        {
            Console.WriteLine("Main() BEGIN");
            Thread.CurrentThread.Name = "MainThread";
            var hanoi = new HanoiThread();
            try
            {
                Thread th = new Thread(hanoi.Run);
                th.Name = "HanoiThread";
                th.Start();

                Thread.Sleep(3000);

                Console.WriteLine("Main ShutdownRequest()");
                hanoi.ShutdownRequest(th);

                Console.WriteLine("Main Join()");
                th.Join();
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} Interrupt()");
            }

            Console.WriteLine("Main() END");
        }//Main() 
 
    } 
}

/*
Main() BEGIN
==== Level 0 ====

==== Level 1 ====
A -> B,
==== Level 2 ====
A -> C, A -> B, C -> B,
==== Level 3 ====
A -> B, A -> C, B -> C, A -> B, C -> A, C -> B, A -> B,
==== Level 4 ====
A -> C, A -> B, C -> B, A -> C, B -> A, B -> C, A -> C, A -> B, C -> B, C -> A, B -> A, C -> B, A -> C, A -> B, C -> B,
==== Level 5 ====
A -> B, A -> C, B -> C, A -> B, C -> A, C -> B, A -> B, A -> C, B -> C, B -> A, C -> A, B -> C, A -> B, A -> C, B -> C, A -> B, C -> A, C -> B, A -> B, C -> A, B -> C, B -> A, C -> A, C -> B, A -> B, A -> C, B -> C, A -> B, C -> A, C -> B, A -> B,
==== Level 6 ====
  :
==== Level 13 ====
Main ShutdownRequest()
Main Join()
  :
DoShutDown() costTime = 1759 msec 
  //ShutdownRequest()から DoShutdown()までの時間
Main() END

==== ANSWER ====
  :
Main ShutdownRequest()
C -> A, C -> B, Main Join()
HanoiThread Interrupt()
DoShutDown() costTime = 4 msec
Main() END
 */