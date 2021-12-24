/** 
 *@title CsharpBegin / MultiThread / MTCS03_GuardedSuspension 
 *       / GuardedSuspension / MainGuardedSuspension.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content Chapter 3 [Guarded Suspension] / p114 / List 3-1 ～ 3-5
 *         [別名] Guarded Wait, Busy Wait, Spin Lock, Polling
 *         / [英] suspension 停止, [英] spin 回転,　[英] polling 世論調査
 *         ～ 準備ができるまで待っててね ～
 *         -- Please wait until ready --
 *         
 *         RequestQueueを用いて Requestオブジェクトを渡す、スレッド間通信。
 *         ClientThreadによって PutRequest()されるまで、
 *         GetRequest()するServerThreadは待機する。
 *           It is a communicate with Request object through RequestQueue,
 *             between Threads.
 *           GetRequest() in ServerThread has been waited
 *             until PutRequest() in ClientThread.
 *         
 *         Guarded Condition ガード条件: if(queue.Peek() != null)
 *         <-> (Reversed) Wait Condition 待機条件:
 *         if(queue.Peek() == null)
 *         queueに要素が何もないとき、SpinWait()する
 *         
 *@subject ◆[C#]  ConcurentQueue<T> (System.Collections.Concurrent.)
 *         void queue.Enqueue   //put value to Queue tail
 *         bool queue.TryPeek() 
 *           //try to get value from Queue tail without delete
 *         bool queue.TryDequeque() 
 *           //try to get value from Queue tail with delete
 *         
 *         ◆[Java] BlockingQueue<T>  (java.util.concurrent.)
 *           //it is locked by itself when read and written,
 *           //therefore it is used without synchronized() to GetRequest(), PutRequest().           
 *         T    queue.take() //get value
 *         void queue.put(T) //put value
 *         
 *         ◆Random (System.)
 *         [Java] Random new Random([long seed]) 
 *         [C#]   Random new Random([int  seed]) 
 *           //it yields fixed random by constructor argument 'seed'
 *           
 *@class MainGuadedSuspension /
 *      ◆Main() 
 *      new RequestQueue, new CrientThread(), new ServerThread()
 *      new Thread(TreadStart) * 2
 *        └ delegate void ThreadStart()
 *          └ XxxxThread.Run()
 *        
 *@class RequestMT03
 *      / - string readonly name /
 *      + Request(string name)
 *      + string ToString()
 *      
 *@class RequestQueue
 *         //as revised virsion -- [Java] BlockingQueue<T> 
 *       / - readonly ConcurrentQueue<RequestMT03> queue /
 *       + virtual RequestMT03 GetRequest() 
 *       + virtual void        PutRequest()
 *       
 *@class RequestQueueSync : RequestQueue
 *          // as original code -- [Java] synchronized()
 *       / - readonly Queue<RequestMT03> queue /
 *       + ovrride RequestMT03 GetRequest() { lock(queue) }
 *       + ovrride void        PutRequest() { lock(queue) }
 *      
 *@class ClientThread 
 *       / - readonly RequestQueue queue;
 *         - readonly string thName;
 *         - readonly Random random;
 *         - const int LIMIT = 10_000; /
 *       + ClientThread(RequestQueue, string thName, int seed)
 *       + void Run() 
 *           new RequestMT03(string name)
 *           queue.PutRequest(RequestMT03)
 *           
*@class ServerThread 
 *       / - readonly RequestQueue queue;
 *         - readonly string thName;
 *         - readonly Random random;
 *         - const int LIMIT = 10_000; /
 *       + ServerThread(RequestQueue, string thName, int seed)
 *       + void Run() 
 *           RequestMT03 queue.GetRequest()
 *           
【NOTE】Modification point from the original code 
MT original [Java] code uses synchronized() to GetRequest(), PutRequest().
But it ran like DeadLock. 
It is realized as 'RequestQueueSync' class.

My [C#] code uses 'ConcurrentQueue<Request> queue' instead of 'synchronized',
which is locked by itself when read and written.
GetRequest() and PutRequest() with lock(queue) maybe lead to DeadLock
because the queue already has been locked.
Therefore, I get off these 'lock(queue) { }'.
Then it ran expectedly.

 *@author shika 
 *@date 2021-12-22 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS03_GuardedSuspension.GuardedSuspension 
{ 
    class MainGuardedSuspension 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var queue = new RequestQueue();
            //var queue = new RequestQueueSync();

            new Thread(new ClientThreadMT03(
                queue, "Alice", 3141592).Run).Start();
            new Thread(new ServerThreadMT03(
                queue, "Bobby", 6535897).Run).Start();
        }//Main() 
    }//class 
}

/*
//==== Result ====
ClientThread Alice: requests [ Request No.0 ]
ServerThread Bobby: gets [ Request No.0 ].
ClientThread Alice: requests [ Request No.1 ]
ServerThread Bobby: gets [ Request No.1 ].
ClientThread Alice: requests [ Request No.2 ]
ServerThread Bobby: gets [ Request No.2 ].
ClientThread Alice: requests [ Request No.3 ]
ServerThread Bobby: gets [ Request No.3 ].
ClientThread Alice: requests [ Request No.4 ]
ClientThread Alice: requests [ Request No.5 ]
ServerThread Bobby: gets [ Request No.4 ].
ServerThread Bobby: gets [ Request No.5 ].
ClientThread Alice: requests [ Request No.6 ]
ClientThread Alice: requests [ Request No.7 ]
ServerThread Bobby: gets [ Request No.6 ].
ClientThread Alice: requests [ Request No.8 ]
ServerThread Bobby: gets [ Request No.7 ].
ServerThread Bobby: gets [ Request No.8 ].
ClientThread Alice: requests [ Request No.9 ]
ServerThread Bobby: gets [ Request No.9 ].
ClientThread Alice: requests [ Request No.10 ]
ClientThread Alice: requests [ Request No.11 ]
ServerThread Bobby: gets [ Request No.10 ].
ServerThread Bobby: gets [ Request No.11 ].
ClientThread Alice: requests [ Request No.12 ]
ServerThread Bobby: gets [ Request No.12 ].
  :
 */