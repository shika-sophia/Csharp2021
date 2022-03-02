/** 
 *@title CsharpBegin / MultiThread / MTCS08_WorkerThread / Worker / MainWorkerMT08.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第８章 WorkerThread / p262 / List 8-1 ～ 8-5
 *         (alternation) Background Thread, Thread Pool
 *         
 *         || Thread per Message || (第７章)
 *         ・非同期処理
 *         ・仕事のたびに new Threadを起動 
 *             
 *         || WorkerThread || 
 *         ・非同期処理: invocation(呼出)と execution(実行)の分離
 *           => 応答性の向上, 実行順序制御(スケジューリング), Cancel機能, 分散処理
 *           => [Java] Runnable / [C#] delegate void ThreadStart()
 *               └ 処理内容をオブジェクトとして渡す仕組み
 *               
 *         ・capacity と resourceの trade-off
 *           Thread Poolや Request保持できる上限を上げると処理を速く、多量にできるが
 *           必要以上の capacityは メモリを占有し resource逼迫を招く可能性がある。。
 *           起動時に capacityを静的に定義するのではなく、
 *           処理量に応じて動的に増減する仕組みにすることが望ましい・
 *           
 *         ・WorkerThreadが new Threadされるのは初回のみで、
 *           仕事のたびに new Threadを起動する必要はない。= 起動時間の短縮
 *           
 *         ・Request 依頼(= 仕事)
 *           Channel, Client, Workerには個々の仕事の情報はなく、Requestに集約。
 *           仕事を Requestというオブジェクトにすることで、
 *           Requestをサブクラス化すると多態性(Polymorphism)を持たせた処理も可能。
 *           
 *         ・Client 依頼者
 *           仕事 Requestインスタンスを生成し、Channelに渡す。
 *         ・Cannel 仲介者
 *           Requestの保持、Requestの取得/提供
 *           WorkerThreadを 配列として保持。Thread Pool
 *         ・Worker 作業者
 *           Requestを受け取り、実行。
 *           仕事が終了したら次の仕事を取りに行く。
 *@subject 配列によって疑似的に Queueを再現し、
 *         Thread Poolの役割を実装したサンプルコード
 */
#region -> MT08 / Worker / Class Chart
/*
 *@class MainWorkerMT08
 *       //
 *       ◆Main()
 *         new Channel(int)
 *         channel.StartWorker()
 *         new Thread(new ClientThread().Run).Start()
 *       
 *@class RequestMT08
 *       / - Random random;
 *         - string name
 *         - int number /
 *       + RequestMT08(string name, int number)
 *       + void Execute() { Console.WriteLine(); }
 *       - override string ToString()
 *       
 *@class ChannelMT08 
 *       / - const int QUEUE_SIZE;
 *         - ◇RequestMT08[] queue;
 *         - ◇WorkerThreadMt08[] threadPool;
 *         - int head;
 *         - int tail;
 *         - int count; /
 *       + Channel(int thNum) { new WorkerThreadMT08[thNum] }
 *       + void StartWorker() { new Thread(WorkerThreadMT08.Run) }
 *       + void        PutRequest(RequestMT08)
 *       + RequestMT08 TakeRequest()
 *       
 *@class ClientThreadMT08
 *       / - readonly Random random;
 *         - readonly ◇ChannelMT08 channel;
 *         - string thName /
 *       + ClientThreadMT08(string thName, ChannelMT08 channel)
 *       + void Run()
 *       { 
 *           new RequestMT08(string, int)
 *           channel.PutRequest(req);
 *       }
 *       
 *@class WorkerThreadMT08
 *       / - readonly ◇ChannelMT08 channel
 *         - string thName /
 *       + WorkerThreadMT08(string thName, ChannelMT08 channel)
 *       + void Run()
 *       { 
 *           channel.TakeRequest(); 
 *           req.Exwcute();
 *       }
 */
#endregion
/*
 *@author shika 
 *@date 2022-02-26 
*/
using CsharpBegin.MultiThread.MTCS08_WorkerThread.WorkerPool;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS08_WorkerThread.Worker 
{ 
    class MainWorkerMT08 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            //---- WorkerThread ----
            int thNum = 5; //number of WorkerThread
            AbsChannelMT08 channel = new ChannelMT08(thNum);
            channel.StartWorker();

            //---- ClientThread ----
            string[] clientAry = new string[]
            {
                "Alice", "Bobby", "Chris"
            };

            foreach(string thName in clientAry)
            {
                new Thread(
                    new ClientThreadMT08(thName, channel).Run
                ).Start();
            }//foreach
        }//Main() 
 
    }//class 
}

/*
Worker-4 Execute() [Request from Alice No.0]
Worker-3 Execute() [Request from Chris No.0]
Worker-2 Execute() [Request from Bobby No.0]
Worker-3 Execute() [Request from Chris No.1]
Worker-2 Execute() [Request from Bobby No.1]
Worker-4 Execute() [Request from Alice No.1]
Worker-0 Execute() [Request from Alice No.2]
Worker-4 Execute() [Request from Bobby No.2]
Worker-1 Execute() [Request from Chris No.2]
Worker-3 Execute() [Request from Bobby No.3]
Worker-2 Execute() [Request from Chris No.3]
Worker-1 Execute() [Request from Alice No.3]
Worker-1 Execute() [Request from Bobby No.4]
Worker-0 Execute() [Request from Chris No.4]
Worker-4 Execute() [Request from Alice No.4]
Worker-3 Execute() [Request from Chris No.5]
Worker-2 Execute() [Request from Bobby No.5]
Worker-0 Execute() [Request from Alice No.5]
Worker-1 Execute() [Request from Bobby No.6]
Worker-4 Execute() [Request from Alice No.6]
Worker-2 Execute() [Request from Chris No.6]
Worker-2 Execute() [Request from Chris No.7]
Worker-1 Execute() [Request from Bobby No.7]
Worker-0 Execute() [Request from Alice No.7]
Worker-1 Execute() [Request from Alice No.8]
Worker-4 Execute() [Request from Bobby No.8]
Worker-2 Execute() [Request from Chris No.8]
Worker-0 Execute() [Request from Bobby No.9]
Worker-4 Execute() [Request from Alice No.9]
Worker-1 Execute() [Request from Chris No.9]
Worker-3 Execute() [Request from Bobby No.10]
Worker-1 Execute() [Request from Alice No.10]
Worker-2 Execute() [Request from Chris No.10]
  :
 */