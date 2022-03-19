/** 
 *@title CsharpBegin / MultiThread / MTCS10_TwoPhaseTermination / GracefulTermination / MainGracefulTermination.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第10章 TwoPhaseTermination / 練習問題 10-4 / p354, p579 / List 10-9, A10-3
 *         || Templete Method || [GoF]
 *           ・superクラスで処理の基本設計を行い、
 *             そのメソッドから呼び出されるメソッドを subクラスで具体的に定義
 *           ・TemplateMethod: superクラスのメソッド 
 *             HookMethod:     subクラスのメソッド /[英]hook 引っ掛ける
 *             
 *         GracefulThreadクラスを Templeteとして、
 *         CountupThreadクラスに継承するプログラム
 *         
 *@subject ◆メソッドの継承
 *         [Java] final 継承不可のメソッド
 *                (それ以外は、いつでも @Override 可)
 *         [C#]   virtual - override 継承可能なメソッドを予め定義
 *                (それ以外は継承不可。[Java]finalのように、たくさん付けなくても済む)
 *
 *@based MainTwoPhaseTermination
 *@class MainGracefulTermination
 *         new CountupGraceful()
 *         
 *@class GracefulThread
 *       / - volatile bool shutdownReq /
 *       + void ShutdownRequest(Thread[]) 〔concurrent〕複数Threadで利用
 *       + bool IsShutdownRequested()     〔concurrent〕
 *       + void Run() 〔frozen〕継承不可
 *       # void DoWork()
 *       # void DoShutdown()
 *         ↑
 *@class CountupGraceful : GracefulThread
 *       / - long counter /
 *       # void DoWork()
 *       # void DoShutdown()
 *
 *@author shika 
 *@date 2022-03-19 
*/

using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.GracefulTermination 
{ 
    class MainGracefulTermination 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            Thread.CurrentThread.Name = "MainThread";

            Console.WriteLine("Main: BEGIN");
            try
            {
                var countTh = new CountupGraceful();
                var th = new Thread(countTh.Run);
                th.Name = "CountupGraceful";
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
//---- CountupGraceful ----
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
CountupGraceful is interrupted.
DoShutdown(): counter = 10
Main: END

 */