/** 
 *@title CsharpBegin / MultiThread / MTCS11_ThreadSpecificStorage / ThreadLocalStorage / MainThreadLocalStorage.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第11章 Thread Specific Storage / サンプル２ / p369 / List 11-3 ～　11-6
 *
 *@subject ◆サンプル２ Threadごとに別のログファイルに保存するプログラム
 *         サンプル１: LogWriterクラスによる Single-Thread処理
 *         サンプル２: static ThreadLocalクラスに
 *                    Threadごとの LogWriterを保持した Multi-Thread処理
 *
 *@subject p373-
 *         
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
#region -> 〔Class Chart〕ThreadLocalStorage
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
        static void Main(string[] args)
        //public void Main(string[] args) 
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