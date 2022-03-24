/** 
 *@title CsharpBegin / MultiThread / MTCS11_ThreadSpecificStorage / ThreadLocalStorage / MainThreadLocalStorage.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第11章 Thread Specific Storage / サンプル２ / p369 / List 11-3 ～　11-6
 *         || Thread Specific Storage ||
 *           ・Thread間の排他制御が必要ない(= ThreadLocalクラスに内部化)
 *           ・スループット(= 処理速度)よりも、再利用性のためのパターン
 *           ・再利用性: プログラム構造を修正する必要はない。
 *                      排他制御が内部化されているため、データ競合の誤りを防ぐ
 *           ・context(=文脈, データの状態)利用
 *             Thread分類に「GetWriter()を呼び出す現在Thread」という文脈(= データの状態を利用。
 *             処理内容が明確に記述されていないため、
 *             引数を渡す必要がないなど、コードをシンプルにできる反面、
 *             可読性を落としバグ究明を困難にする可能性を含む。
 *           ・|| WorkerThread ||との併用不可
 *             WorkerThread, ThreadPoolは 同じThreadで何回も処理させる仕組み。
 *             Threadごとのオブジェクトで処理をする || ThreadSpecificStorage ||を
 *             利用するには、確実に別のThreadで実行されることを保証しないと利用できない。
 *                    
 *         ＊Client 依頼者 = ClientThreadMT11
 *           ・ThreadSpecific-ObjectProxyに処理を依頼
 *           ・１つの ThreadSpecific-ObjectProxyを複数のClientで利用。
 *           
 *         ＊ThreadSpecific-ObjectProxy スレッド固有オブジェクトの代理人
 *           = LogLocalStorage
 *           ・Clientからの依頼を処理
 *           ・Collectionを利用して、Clientに対応するオブジェクトを取得
 *           ・実際の処理は取得したオブジェクトに委譲。
 *           
 *         ＊ThreadSpecific-Collection スレッド固有オブジェクトの集まり
 *           = ThreadLocalクラス
 *           ・現在Threadに対応した ThreadSpecific-Objectを保持。
 *           ・GetWriter()を呼び出した 現在Threadに対応した ThreadSpecific-Objectを取得。
 *           
 *         ＊ThreadSpecific-Object    スレッド固有オブジェクト
 *           = LogWriterSpecific
 *           ・Collectionで管理
 *           ・FileStream, StreamWriterで Thread固有の ログファイルに書き込み。
 *           
 *@subject ◆サンプル２ Threadごとに別のログファイルに保存するプログラム
 *         サンプル１: LogWriterクラスによる Single-Thread処理
 *         サンプル２: static ThreadLocalクラスに
 *                    Threadごとの LogWriterを保持した Multi-Thread処理
 *
 *@subject ◆ThreadLocal<LogWriterSpecific>
 *         Thread固有の LogWriterSpecificインスタンスを保持。
 *         GetWriter()によって、呼び出した現在Threadを自動的に判別し、
 *         そのThreadの LogWriterSpecificインスタンスを取得。
 *         
 *         Threadごとに LogWriterAlice, LogWriterBobby..などを作る必要がない。
 *         引数に keyとなる Thread.Nameなどを渡す必要もない。
 *         Thread振り分けの条件式は ThreadLocalクラスに内部化されており、記述不要。
 *         
 *@subject ◆Thread固有情報の保管場所
 *         ＊Thread-stack:    Thread内には局所変数を保持するスタック領域が存在する
 *                            メソッド呼出時に利用され、メソッド処理終了時に破棄される。
 *         ＊Thread-internal: Thread内のフィールドに サブクラスのThreadを保持
 *                            Thread固有の処理を保持でき、コードを見れば処理内容が判るので可読性が高い。
 *         ＊Thread-external: Thread固有の情報を外部クラスで保持。
 *                            Threadを表す既存クラス(= ClientThread)を修正する必要がない。
 *                            他クラスにThread固有の情報が分離しているので、可動性に劣る。
 *                            ThreadLocalクラスを利用することで、
 *                            Thread固有の情報を他Threadから操作されることがない。
 *                            (= 排他制御は必要ない)                            
 *
 *@subject [Java] java.lang.ThreadLocal<T>クラス
 *         void thLocal.set( T )
 *         T    thLocal.get()
 *         
 *         ※Threadを表す引数はなく、
 *         set() メソッドを呼び出した現在Threadに対応させて格納
 *         get() 現在Threadに対応させて取得
 *
 *@subject [C#] System.Threading.ThreadLocal<T>クラス
 *         T        thLocal.Value  現在Threadに関するオブジェクトをset格納/get取得
 *         IList<T> thLocal.Values 全Threadに関するオブジェクトのListを取得
 *         bool     thLocal.IsValueCreated オブジェクトが初期化されているか
 *         void     thLocal.Dispose() このインスタンスで保持している全てのリソースを解放
 */
#region -> 〔Class Chart〕 ThreadLocalStorage
/*
 *@class MainThreadLocalStorage
 *       new ClientThreadMT11(string thName)
 *       new Thread(ClientThreadMT11.Run)
 *         ↓ new
 *@class ClientThreadMT11
 *       / - readonly string thName; /
 *       + ClientThreadMT11(string thName)
 *       + void Run(){ LogLocalStorage.WriteLog($"Log = {i}"); }
 *       + string GetName()
 *         ◇
 *         ↓
 *@class LogLocalStorage: ThreadLocal<LogWriterSpecific>
 *        / - static ◇ThreadLocal<◇LogWriterSpecific> thLocal
 *                = new ThreadLocal<LogWriterSpecific>(); /
 *       + LogWriterSpecific GetWriter()
 *         { new LogWriterSpecific(string fileName);
 *           thLocal.Value = logWriter; }
 *       + static void WriteLog(string content)
 *         { LogWriterSpecific.WriteLog(string content); }
 *       + static void WriteFinish()
 *         { LogWriterSpecific.WriteFinish(); }
 *           ◇
 *           ↓
 *@class System.Threading.ThreadLocal<LogWriterSpecific>
 *           ◇
 *           ↓
 *@class LogWriterSpecific
 *       / - readonly string fileName; /
 *       + LogWriterSpecific(string fileName)
 *       + void WriteLog(string content)
 *         { new FileStream(string path)
 *           new StreamWriter(FileStream) }
 *       + void WriteFinish()      
 */
#endregion
/*
 *@author shika 
 *@date 2022-03-22 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage.ThreadLocalStorage 
{ 
    class MainThreadLocalStorage 
    {
        //static void Main(string[] args)
        public void Main(string[] args) 
        {
            var clientAry = new ClientThreadMT11[]
            {
                new ClientThreadMT11("AliceThread"),
                new ClientThreadMT11("BobbyThread"),
                new ClientThreadMT11("ChrisThread"),
            };

            foreach(var client in clientAry)
            {
                var thClient = new Thread(client.Run);
                thClient.Name = client.GetName();
                thClient.Start();
            }//foreach

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

//==== log_AliceThread.txt ====
Log = 0
Log = 1
Log = 2
Log = 3
Log = 4
Log = 5
Log = 6
Log = 7
Log = 8
Log = 9
==== End of Log ====

 */