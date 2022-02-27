/** 
 *@title CsharpBegin / MultiThread / MTCS08_WorkerThread / WorkerPool / MainWorkerPool.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第８章 WorkerThread / 補講２ ThreadPool / p284
 *         [Java] Executors.newFixThreadPool(int)
 *         [C#]   ChannelPool 〔自己定義〕
 *         ThreadPoolを持つクラスを自己定義し、
 *         初期状態で WorkerThread 2を pool。
 *         処理が停滞している場合は WorkerThreadを増やす。
 *
 *@based MainWorkerMT08
 *       AbsChannelMT08 channel = new ChannelMT08(int thNum);
 *       
 *@class AbsChannelMT08 〔with Polymorphism〕
 *         └ ChannelMT08
 *         └ ChannelPool
 *         
 *@class MainWorkerPool
 *       AbsChannelMT08 channel = new ChannelPool();
 *       
 *@class ChannelPool : AbsChannelMT08
 *       / - const int REQ_LIMIT = 100;
 *         - readonly ConcurrentQueue<RequestMT08> queue
 *         - List<WorkerThreadMT08> workerList;
 *         - int poolNum; //initial workerPool = 2 /
 *         
 *        + ChannelPool(int poolNum = 2) 
 *          { new WorkerThreadMT08(string, AbsChannelMT08);
 *            new List<WorkerThreadMT08>(); }
 *        + void StrartWorker()
 *        - void AddWorker()
 *        + void        PutRequest(RequestMT08)
 *        + RequestMT08 TakeRequest()
 *
 *@see MTCS05_ProducerComsumer / CakeTable / CakeTableBlocking.cs
 *@see MTCS07_ThreadPerMessage / ThreadPoolSample / MainThreadPool.cs 
 *@author shika 
 *@date 2022-02-28 
*/
using CsharpBegin.MultiThread.MTCS08_WorkerThread.Worker;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS08_WorkerThread.WorkerPool 
{ 
    class MainWorkerPool 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            //---- WorkerThread ----
            AbsChannelMT08 channel = new ChannelPool();
            channel.StartWorker();

            //---- ClientThread ----
            string[] clientAry = new string[]
            {
                "Alice", "Bobby", "Chris"
            };

            foreach (string thName in clientAry)
            {
                new Thread(
                    new ClientThreadMT08(thName, channel).Run
                ).Start();
            }//foreach
        }//Main() 
    }//class 
}

/*
//---- ClientThread / Thread.Sleep(random.Next(100)) ----
//Requestが速すぎて、queueに貯まるので、Workerを増やしていく。

Worker-1 Execute() [Request from Alice No.0]
Worker-0 Execute() [Request from Bobby No.0]
Worker-1 Execute() [Request from Chris No.0]
Worker-0 Execute() [Request from Bobby No.1]
Worker-0 Execute() [Request from Alice No.1]
Worker-1 Execute() [Request from Chris No.1]
Worker-1 Execute() [Request from Chris No.2]
Worker-2 Execute() [Request from Alice No.2]
Worker-3 Execute() [Request from Bobby No.2]
Worker-0 Execute() [Request from Alice No.3]
Worker-1 Execute() [Request from Bobby No.3]
Worker-2 Execute() [Request from Chris No.3]
Worker-1 Execute() [Request from Bobby No.4]
Worker-3 Execute() [Request from Chris No.4]
Worker-4 Execute() [Request from Alice No.4]
  :

//---- ClientThread / Thread.Sleep(random.Next(1000)) ----
//Clientの待機時間 1000ミリ秒ランダムにすると、停滞なく、
//初期の 2 WorkerThreadで処理可。
Worker-0 Execute() [Request from Alice No.0]
Worker-1 Execute() [Request from Bobby No.0]
Worker-1 Execute() [Request from Chris No.0]
Worker-0 Execute() [Request from Alice No.1]
Worker-0 Execute() [Request from Bobby No.1]
Worker-1 Execute() [Request from Chris No.1]
Worker-0 Execute() [Request from Chris No.2]
Worker-1 Execute() [Request from Alice No.2]
Worker-0 Execute() [Request from Bobby No.2]
Worker-1 Execute() [Request from Bobby No.3]
Worker-0 Execute() [Request from Alice No.3]
Worker-1 Execute() [Request from Chris No.3]
Worker-0 Execute() [Request from Alice No.4]
Worker-1 Execute() [Request from Bobby No.4]
Worker-0 Execute() [Request from Chris No.4]
Worker-0 Execute() [Request from Chris No.5]
Worker-1 Execute() [Request from Alice No.5]
Worker-0 Execute() [Request from Bobby No.5]
Worker-1 Execute() [Request from Chris No.6]
Worker-0 Execute() [Request from Alice No.6]
Worker-1 Execute() [Request from Bobby No.6]
Worker-0 Execute() [Request from Alice No.7]
Worker-1 Execute() [Request from Chris No.7]
Worker-0 Execute() [Request from Bobby No.7]
Worker-1 Execute() [Request from Bobby No.8]
Worker-1 Execute() [Request from Chris No.8]
Worker-1 Execute() [Request from Alice No.8]
Worker-1 Execute() [Request from Alice No.9]
Worker-1 Execute() [Request from Bobby No.9]
Worker-1 Execute() [Request from Chris No.9]
Worker-1 Execute() [Request from Chris No.10]
Worker-0 Execute() [Request from Bobby No.10]
Worker-1 Execute() [Request from Alice No.10]
  :
 */