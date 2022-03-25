/** 
 *@title CsharpBegin / MultiThread / MTCS11_ThreadSpecificStorage / AutoTermination / MainAutoTermination.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第11章 Thread Specific Storage / 練習問題 11-3 / p388, p589
 *         ◆練習問題 11-3
 *         サンプル２〔ThreadLocalStorage〕はThreadが終了する前に、
 *         一度ログファイルを閉じ、Thread終了時に再度開いて閉じるという処理をしている。
 *         LogLocalStorage.WriteFinish()を明示的に記述しなくても、
 *         Threadが終了する際にログファイルが自動的に閉じるようにサンプル２を修正せよ。
 *
 *@NOTE 【考察】
 *       原状ではWriteFinish()だけでなく、Log i = 0, i = 1, ...ごとに
 *       FileStream, StreamWriterを開いて閉じる処理をしているので、
 *       StringBuilderなどで Logを一括記述し、WriteFinish()の記述も加えて
 *       Logの contentが完成してから、
 *       １回だけ ログファイルを開いて書き込みをするように修正すればいい。
 *       
 *       => ClientThread.Run()内に StringBuilderを適用。
 *          WriteLog()は１回だけ呼出。WriteFinish()は利用せず。
 *          ThreadLocalを Dispose()するために、Mainで Thread.Join()し
 *          static LogLocalStorage.Close()を呼出
 *          
 *@based MainThreadLocalStorage
 *@class MainAutoTermination
 *@class ClientThreadBuildContent
 * 
 *@author shika 
 *@date 2022-03-25 
*/
using CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage.ThreadLocalStorage;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage.AutoTermination 
{ 
    class MainAutoTermination 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var clientAry = new ClientThreadBuildContent[]
            {
                new ClientThreadBuildContent("AliceThread"),
                new ClientThreadBuildContent("BobbyThread"),
                new ClientThreadBuildContent("ChrisThread"),
            };

            Thread[] thClientAry = new Thread[clientAry.Length];
            for(int i = 0; i < clientAry.Length; i++)
            {
                var thClient = new Thread(clientAry[i].Run);
                thClient.Name = clientAry[i].GetName();
                thClient.Start();

                thClientAry[i] = thClient;
            }//for

            foreach(var thClient in thClientAry)
            {
                thClient.Join();
            }//foreach

            LogLocalStorage.Close();
        }//Main() 
 
    }//class 
}

/*
AliceThread BEGIN
ChrisThread BEGIN
BobbyThread BEGIN
  :
ChrisThread END
BobbyThread END
AliceThread END

==== LogFile AliceThread ====
Log i = 0
Log i = 1
Log i = 2
Log i = 3
Log i = 4
Log i = 5
Log i = 6
Log i = 7
Log i = 8
Log i = 9
==== End of Log ====
 */