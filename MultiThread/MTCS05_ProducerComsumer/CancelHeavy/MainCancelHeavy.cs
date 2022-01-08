/**  
 *@title CsharpBegin / MultiThread / MTCS05_ProducerComsumer / CancelHeavy / MainCancelHeavy.cs  
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006  
 *@content Carp5 Producer-Consumer / Practice 5-7 / List 5-10
 *         【考察】
 *         HeavyJobクラスを途中で Intrrupt()によって中断するプログラム。
 *         しかし、Thread.Interrupt()は、SpinWait(), Sleep(), Join()の中にある場合のみ有効。
 *         そのため、下記の thHeavy.Interrupt(); では、ちゃんと中断しない。
 *         
 *         [Java]テキストのコードは、interrupt()によって、
 *         Threadの interrupt状態を変更し、boolean interrupted() でプログラムを終了している。
 *         
 *             if(Thread.interrupted){ throw new InterruptedException() }
 *             
 *         [C#]には、ThreadStateを見ても、Interrupt状態を表すプロパティはなく、
 *          '[Java] System.exit(0);'.のようなプログラムを終了させるメソッドも不明。
 *        
 *         【NOTE】
 *        〔It try to interrupt 'HeavyJob' class Running.
 *         But 'Thread.Interrpt()' is effective ONLY in SpinWait(), Sleep(), Join().
 *         Threrefore this 'thHeavy.Interrupt();' did not effect to interrupt Thread,
 *         as following Result.
 *         
 *         [Java]
 *         In Text Code, Thread.interrupt() changes Thread-status to 'interrupted'.
 *         It finished the running by 'boolean interrupted()' .
 *         
 *             if(Thread.interrupted){ throw new InterruptedException() }
 *             
 *         [C#]
 *         ThreadStatus's Properties do not have 'Interrupted-Status'.
 *         The Method like 'IsInterrupted()' does not exist.
 *         And I don't find Termination Method like '[Java] System.exit(0);'.〕
 * 
 *@class MainCancelHeavy 
 *  
 *@author shika  
 *@date 2022-01-08  
*/
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text; 
using System.Threading; 
using System.Threading.Tasks;  
  
namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.CancelHeavy  
{  
    class MainCancelHeavy  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        { 
            var heavy = new HeavyJob();
            var thHeavy = new Thread(heavy.ExecuteHeavy);
            thHeavy.Start(1000);

            bool continueFlag = true; 
            while (continueFlag) 
            { 
                Thread.Sleep(1000); 
                Console.Write("◆Cancel OK? [ Y / N ] "); 
                string confirm = Console.ReadLine(); 
 
                switch (confirm) 
                { 
                    case "y": 
                    case "Y": 
                    case "ｙ": 
                    case "Ｙ": 
                        continueFlag = false;
                        thHeavy.Interrupt();
                        break; 
                    default: 
                        continue; 
                }//switch 
            }//while 
 
            Console.WriteLine($"{nameof(HeavyJob)}.ExectuteHeavy(): Canceled"); 
        }//Main()  
  
    }//class  
}

/*
//===== Result (Fault yet) ====
DoHeavy(): BEGIN
◆Cancel OK? [ Y / N ] n
◆Cancel OK? [ Y / N ]
DoHeavy(): END
DoHeavy(): BEGIN
DoHeavy(): END
DoHeavy(): BEGIN
y
HeavyJob.ExectuteHeavy(): Canceled
  :
DoHeavy(): END
DoHeavy(): BEGIN
DoHeavy(): END
  :
(NOT END)

 */