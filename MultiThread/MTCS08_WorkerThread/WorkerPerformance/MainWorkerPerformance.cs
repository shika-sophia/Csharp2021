/** 
 *@title CsharpBegin / MultiThread / MTCS08_WorkerThread / WorkerPerformance / MainWorkerPerformance.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第８章 WorkerThread / 練習問題 8-2, 8-3 / p290, p551
 *@subject 練習問題 8-3
 *         || Thread per Message || パターンの Channelクラス
 *         => ChannelThreadPerMessage
 *            StartWorker()を { } 空処理にして、
 *            PutRequest()で毎回 新しい Threadを生成し、
 *            Request.ReqExecute()を行う。
 *            
 *@subject 練習問題 8-3 
 *         各Channelでの 10秒後の処理結果数を調べることで処理の速さを計測
 *         Client, Request内の Thread.Sleep(random.Next(1000))はコメントアウト
 *         
 *         [Java] java.lang.System.exit(0)
 *         [C#] System.Environment.Exit(0) プログラムの終了
 *              System.Application.Exit(0)
 *              
 *@subject ChannelMT08
 *           with WorkerThread Pool as array
 *         => 5232 - 5912
 *@subject ChannelPool
 *           with WorkerThread Pool as ConcurrentQueue
 *         => 2195 - 2317
 *@subject ChannelThreadPerMessage
 *           without WorkerThread Pool as each new Thread
 *         => 3938 - 3942
 *           
 *@author shika 
 *@date 2022-03-01, 03-02
*/
using CsharpBegin.MultiThread.MTCS08_WorkerThread.Worker;
using CsharpBegin.MultiThread.MTCS08_WorkerThread.WorkerPool;
using System; 
using System.Text;
using System.Threading;
 
namespace CsharpBegin.MultiThread.MTCS08_WorkerThread.WorkerPerformance 
{ 
    class MainWorkerPerformance 
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

            Thread.Sleep(10000);
            Environment.Exit(0);
        }//Main() 
    }//class 
}

/*
const int REQ_LIMIT = 50;

//---- ChannelMT08(3) ----
Worker-0 Execute() [Request from Chris No.5912]
Worker-2 Execute() [Request from Bobby No.5441]
Worker-2 Execute() [Request from Alice No.5231]
Worker-2 Execute() [Request from Alice No.5232]

//---- ChannelPool(3) ----
Worker-0 Execute() [Request from Bobby No.2195]
Worker-1 Execute() [Request from Alice No.2317]
Worker-2 Execute() [Request from Chris No.2235]
Worker-2 Execute() [Request from Chris No.2237]
Worker-3 Execute() [Request from Chris No.2236]

//---- ChannelThreadPerMessage() ----
Worker-11721 Execute() [Request from Bobby No.3942]
Worker-11712 Execute() [Request from Bobby No.3939]
Worker-11713 Execute() [Request from Alice No.3938]


 */