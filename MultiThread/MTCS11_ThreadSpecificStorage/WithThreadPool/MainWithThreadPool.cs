/** 
 *@title CsharpBegin / MultiThread / MTCS11_ThreadSpecificStorage / WithThreadPool / MainWithThreadPool.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第11章 Thread Specific Storage / 練習問題 11-6 / p389, p593 / List 11-8
 *         ◆WorkerThread(= ThreadPool)との併用
 *         下記の両者は相容れないので、意図通りの動作をしない可能性がある *         
 *         || Thread Specific Storage ||
 *         現在Threadを keyとして、Threadごとに利用するオブジェクトを振り分ける仕組み。
 *         || WorkerThread ||
 *         ThreadPoolに WorkerThreadを保持し、１つの仕事が終了したら、
 *         同じThreadが別の処理を行う仕組み。
 *         
 *@subject ThreadPoolを ThreadSpecificStorageに適用すると、
 *         期待していた数の処理を行えないプログラム。
 *         
 *         ThreadPoolを自己定義して WorkerThreadを 3つ作成
 *         WORK_NUM = 10だが、ログファイルは WorkerThreadと同じ 3つ。
 *         各ログファイルに WORK"Hello-n"が複数書き込まれる。
 *         
 *         Threadごとのログファイルにはなっているが、
 *         Workごとのログファイルを意図しているのなら、意図を達成していない。
 *         
 *         //log_Worker-0.txt
 *         Hello-2
 *         Hello-4
 *         Hello-6
 *         Hello-9
 *
 *@class MainWithThreadPool
 *@class WorkerThreadPoolMT11
 *
 *@see ThreadLocalStorage / LogFileSpecific / log_Worker-0.txt
 *@author shika 
 *@date 2022-03-26 
*/
using CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage.ThreadLocalStorage;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage.WithThreadPool 
{ 
    class MainWithThreadPool 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            Console.WriteLine("Main BEGIN");
            const int WORK_NUM = 10;
            var workerPool = new WorkerThreadPoolMT11(3);

            for(int i = 0; i < WORK_NUM; i++)
            {
                workerPool.PutContent($"Hello-{i}");
            }

            workerPool.Close();
            LogLocalStorage.Close();
            Console.WriteLine("Main END");
        }//Main() 
    }//class 
}

/*
Main BEGIN
RestWork = 0
Main END

//log_Worker-0.txt
Hello-2
Hello-4
Hello-6
Hello-9

// log_Worker-1.txt
Hello-0
Hello-3
Hello-7

//log_Worker-2.txt
Hello-1
Hello-5
Hello-8
 */
