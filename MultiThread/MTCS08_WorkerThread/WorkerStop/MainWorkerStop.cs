/** 
 *@title CsharpBegin / MultiThread / MTCS08_WorkerThread / WorkerStop / MainWorkerStop.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第８章 WorkerThread / 練習問題 8-6 / p293, p561
 *         Stop WorkerThread Program
 *
 *@based MainWorkerPerformance
 *@class MainWorkerStop
 *       Channel.Thread[]/List<Thread>を定義、
 *       起動したWorkerThreadを保持
 *       
 *       Channel.StopAllWorker() 
 *         [Java] Thread.stop()  ※非推奨: lock中でも停止してしまう
 *                Thread.interrupt() を利用
 *                Executor.shutdown()
 *         [C#]   Thread.Abort()
 *                       
 *@author shika 
 *@date 2022-03-03 
*/
using CsharpBegin.MultiThread.MTCS08_WorkerThread.Worker;
using CsharpBegin.MultiThread.MTCS08_WorkerThread.WorkerPerformance;
using CsharpBegin.MultiThread.MTCS08_WorkerThread.WorkerPool;
using System; 
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS08_WorkerThread.WorkerStop 
{ 
    class MainWorkerStop 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            //---- Channel ----
            AbsChannelMT08 channel = new ChannelMT08(3);
            //AbsChannelMT08 channel = new ChannelPool(3);
            //AbsChannelMT08 channel = new ChannelThreadPerMessage(3);

            //---- WorkerThread ----
            channel.StartWorker();

            //---- ClientThread ----
            var thAlice = new Thread(
                    new ClientThreadMT08("Alice", channel).Run);
            var thBobby = new Thread(
                    new ClientThreadMT08("Booby", channel).Run);
            var thChris = new Thread(
                    new ClientThreadMT08("Chris", channel).Run);
            thAlice.Start();
            thBobby.Start();
            thChris.Start();

            //---- 5 seconds later ----
            Thread.Sleep(5000);

            //---- stop each Thread ----
            try
            {
                thAlice.Abort();
                thBobby.Abort();
                thChris.Abort();
                channel.StopAllWorker();
            }
            catch (ThreadAbortException) { }
            
        }//Main() 
    }//class 
}

/*
//---- ChannelMT08(3) ---- 
Worker-2 Execute() [Request from Chris No.2233]
Worker-2 Execute() [Request from Booby No.1854]
Worker-2 Execute() [Request from Chris No.2234]
Worker-1 Execute() [Request from Alice No.2598]
Worker-1 Execute() [Request from Booby No.1855]
Worker-1 Execute() [Request from Chris No.2236]
(stopped at 5 seconds later)

//---- ChannelPool(3) ----
Worker-2 Execute() [Request from Chris No.1243]
Worker-2 Execute() [Request from Alice No.1395]
Worker-2 Execute() [Request from Booby No.1246]
Worker-2 Execute() [Request from Chris No.1244]
Worker-2 Execute() [Request from Alice No.1396]
Worker-2 Execute() [Request from Alice No.1394]
(stopped at 5 seconds later)

//---- ChannelThreadPerMessage(3) ----
Worker-5030 Execute() [Request from Booby No.1731]
Worker-5031 Execute() [Request from Chris No.1575]
Worker-5032 Execute() [Request from Booby No.1732]
Worker-5033 Execute() [Request from Chris No.1576]
Worker-5034 Execute() [Request from Chris No.1577]
Worker-5035 Execute() [Request from Chris No.1578]
Worker-5038 Execute() [Request from Chris No.1581]
Worker-5039 Execute() [Request from Chris No.1582]
Worker-5040 Execute() [Request from Chris No.1583]
Worker-5041 Execute() [Request from Chris No.1584]
Worker-5042 Execute() [Request from Chris No.1585]
Worker-5043 Execute() [Request from Chris No.1586]
Worker-5037 Execute() [Request from Chris No.1580]
(stopped at 5 seconds later)
 */