/** 
 *@title CsharpBegin / MultiThread / MTCS03_GuardedSuspension / TalkerThread / MainTalker.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第３章 GuardedSuspension / p135, p496 / 練習問題 3-5 
 *         ◆DeadLock
 *         TalkerThread.Run()は
 *         GetRequest()から始まっているので、
 *         複数Threadを Run()しても、互いに PutRequest()されるまで待機。
 *         すべてのThreadが WaitSetで待機してしまうデッドロック状態となる。
　*         〔'TalkerThread.Run()' begin from 'GetRequest()'.
 *           Through maulti-Threads run, all of them go into WaitSet.
 *           They are waiting that any other Thread do 'PutRequest()'.
 *           But none can do, they are waiting each other. 
 *           That's -- DeadLock --.〕
 *         
 *         通常、呼び出す順番が対称的な場合にデッドロックを起こすのだが、
 *         このケースは同じ順番なのにデッドロックとなっている。
 *         このコードは対称にしないと、会話としてなりたたない。
 *         つまり、互いに 相手の inputQueueに outputして
 *         会話のキャッチボールをしようとしている。
 *         〔Usually DeadLock occur that
 *           it call the common resource in symmetric reverse order.
 *           But this code call in same order.
 *           This code must call same order. 
 *           it try to catch-ball of conversation
 *           by which one throws 'Talk' to other inputQueue.〕
 *         
 *         => 【解答】解決策として、
 *         最初に「種」として、queue内に要素を PutRequest()しておく。
 *         ちなみに、このデッドロックは、SpinWait()なので、両方とも lock()は解放している状態。
 *         MTCS01の DeadLockと比較すべし。
 *         => 〔【Answer】as a solution to this problem.
 *               Firstly it should be put a seed as one element in queue.
 *               Further, in this code, 
 *               both Threads release the lock(queue) in SpinWait().
 *               Compare to MT01/DeadLock case.〕
 *           
 *@class MainTalker 
 *       /◆Main()
 *       new RequestQueue() * 2
 *       new TalkerThread() * 2
 *       new Thread(ThreadStart)
 *         └　delegate void ThreadStart()
 *             └ TalkerThread.Run()
 *@class TalkerThread
 *       / - readonly RequestQueue input;
 *         - readonly RequestQueue output;
 *         - readonly string name;
 *         - const int LIMIT; /
 *       + TalkerThread(
 *            RequestQueue input, RequestQueue output, string name)
 *       + void Run()
 *           GetRequest(), PutRequest()
 *@see GuardedSuspension / RequestMT03.cs
 *@see GuardedSuspension / RequestQueue.cs
 *@see GuardedSuspension / MainGuardedSuspension.cs
 *@author shika 
 *@date 2021-12-25 
*/
using CsharpBegin.MultiThread.MTCS03_GuardedSuspension.GuardedSuspension;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS03_GuardedSuspension.TalkerThread 
{ 
    class MainTalker 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var queue1 = new RequestQueue();
            var queue2 = new RequestQueue();
            queue1.PutRequest(new RequestMT03("Hello"));
            var thA = new TalkerThread(queue1, queue2, "Alice");
            var thB = new TalkerThread(queue2, queue1, "Bobby");

            new Thread(thA.Run).Start();
            new Thread(thB.Run).Start();
        }//Main() 
    }//class 
}

/*
//==== reverse order of input and output ====
Alice: BEGIN
Bobby: BEGIN
  :
(-- DeadLock --)

//==== same order of input and output ====
Alice: BEGIN
Bobby: BEGIN
  :
(-- DeadLock --)

//==== 【Answer】 ====
//Firstly put one element in the queue.

Alice: BEGIN
Alice: GET [ Request Hello ]
Bobby: BEGIN
Bobby: GET [ Request Hello! ]
Bobby: PUT [ Request Hello!! ]
Alice: PUT [ Request Hello! ]
Alice: GET [ Request Hello!! ]
Bobby: GET [ Request Hello!!! ]
Bobby: PUT [ Request Hello!!!! ]
Alice: PUT [ Request Hello!!! ]
Alice: GET [ Request Hello!!!! ]
  :
Alice: END
Bobby: END
 */
