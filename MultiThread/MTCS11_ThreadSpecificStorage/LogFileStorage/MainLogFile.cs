/** 
 *@title CsharpBegin / MultiThread / MTCS11_ThreadSpecificStorage / LogFile / MainLogFile.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第11章 ThreadSpecificStorage / p364 / List 11-1, 11-2
 *         ～ Threadごとのコインロッカー ～
 *         [英] specific: 固有の, 特定の
 *         [英] storage:  記憶領域, 貯蔵庫, 記憶装置
 *         
 *@subject Thread Specific Storage = Thread固有の記憶領域
 *  〔別名〕Per-Thread Attribute = Threadごとの属性
 *         Thread Specific Data = Thread固有のデータ
 *         Thread Specific Field = Thread固有のフィールド
 *         Thread Local Storage = Threadのクラス内記憶領域
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
 *         
 *@class MainLogFile 
 *@class LogWriterMT11
 * 
 *@author shika 
 *@date 2022-03-21 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage.LogFileStorage 
{ 
    class MainLogFile 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            Console.WriteLine("Main BEGIN");
            const int LIMIT = 10;
            var log = new LogWriterMT11(); 

            for(int i = 0; i < LIMIT; i++)
            {
                log.WriteLog($"Log i = {i}");

                try
                {
                    Thread.Sleep(100);
                }
                catch(ThreadInterruptedException) { }
            }//for

            log.WriteFinish();
            Console.WriteLine("Main END");
        }//Main() 
 
    }//class 
}

/*
Main BEGIN
Main END

//---- LogFile/logStorage.txt ----
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