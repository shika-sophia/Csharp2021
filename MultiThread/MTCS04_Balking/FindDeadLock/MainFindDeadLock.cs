/** 
 *@title CsharpBegin / MultiThread / MTCS04_Balking / FindDeadLock / MainFindDeadLock.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第４章 Balking - Find DeadLock / p158, p504 / 練習問題 4-4
 *         Timeout機能を用いて、DeadLockを検出する。
 *         ここでは 10秒間 RequestQueueが更新されなければ DeadLockと見なす。
 *         
 *@class MainFindDeadLock
 *       デッドロックを起こす 練習問題 3-5の MainTalker.csをコピー
 *
 *【考察】
 * MTCS03 / TalkerTread だと、input, outputが 
 * baseの RequestQueue queueに入るようで、ちゃんと動作せず。
 * 新たに TalkerThreadTimeoutを定義し、
 * RequestQueueSyncTimeoutをコンストラクタから渡すように改良すると
 * デッドロックを 指定時間後に検知して、例外を throwする。
 * 
 *@author shika 
 *@date 2022-01-02 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS04_Balking.FindDeadLock 
{ 
    class MainFindDeadLock 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var queue1 = new RequestQueueSyncTimeout();
            var queue2 = new RequestQueueSyncTimeout();
            var alice = new TalkerThreadTimeout(queue1, queue2, "Alice");
            var bobby = new TalkerThreadTimeout(queue2, queue1, "Bobby");

            //デッドロックを起こすなら、Helloをコメントアウトする
            //queue1.PutRequest(new RequestMT03("Hello"));
            new Thread(alice.Run).Start();
            new Thread(bobby.Run).Start();
        }//Main() 
    }//class 
}

/*
Alice: BEGIN
Bobby: BEGIN
  :
(-- Dead Lock -- ) 
(10 sec waiting)
  :
ハンドルされていない例外:
ハンドルされていない例外: 
CsharpBegin.MultiThread.MTCS04_Balking.FindDeadLock.LivenessException:
  <!> It maybe DeadLock Timeout.
  
CsharpBegin.MultiThread.MTCS04_Balking.FindDeadLock.LivenessException:
  <!> It maybe DeadLock Timeout.
   
 */