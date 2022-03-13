/** 
 *@title CsharpBegin / MultiThread / MTCS10_TwoPhaseTermination / CountDown / MainCountDown.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第10章 TwoPhaseTermination / 補講２ CountDownLatch / p342 / List 10-4, 10-5
 *         graceful termination (= 優雅な終了)のために、
 *         仕事の総量をあらかじめ指定し、指定回数に達したら終了するプログラム
 *         
 *@subject [Java] java.util.concurrent.CountDownLatch
 *         new CountDownLatch(Runable)
 *         void cdl.countDown()
 *         void cdl.await()
 *         void cdl.shutdown()
 *         
 *@subject [C#]   System.Threading.CountdownEvent
 *         new CountdownEvent(int initialCount)
 *         int countdownEvent.InitalCount
 *         int countdownEvent.CurrentCount
 *         bool countdownEvent.IsSet       //count 0かどうか
 *         void countdownEvent.AddCount([int signalCount]) //increament
 *         bool countdownEvent.TryAddCount([int signalCount])
 *         void countdownEvent.Signal([int signalCount])   //decrement
 *         void countdownEvent.Wait([int millisec / TimeSpan])
 *         void countdownEvent.Reset([int count])
 *         void countdownEvent.Dispose()
 *         => see for detail〔CountdownEvent below/文末参照〕
 *         
 *@NOTE 【考察】CountdownEventクラスの必要性
 *       static int countでも代用できそう。
 *       ただし、複数Threadで利用しても、排他処理を自動でしてくれる利点がある。
 *       
 *       テキストサンプルの ExecutorService/ThreadPoolがなかったので自己定義。
 *       終了処理で WorkerThreadも Shutdown()する必要がある。
 *       
 *@class MainCountDown
 *@class MyTaskMT10
 *@class ThreadPoolMT10
 *       [Java] ExecutorService Executor.newFixThreadPool(5);
 *       [C#]   ThreadPoolMT10を自己定義
 *       
 *@author shika 
 *@date 2022-03-13 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.CountDown 
{ 
    class MainCountDown 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            const int TASK_NUM = 10;
            Console.WriteLine("Main BEGIN");
            var countdown = new CountdownEvent(TASK_NUM);
            var threadPool = new ThreadPoolMT10(5);
            
            try
            {
                for (int i = 0; i < TASK_NUM; i++)
                {
                    var myTask = new MyTaskMT10(countdown, i);
                    threadPool.AddRequest(myTask);
                }//for

                threadPool.CreateThread();

                while (!countdown.IsSet)
                {
                    Thread.Sleep(300);
                }
            }
            catch (ThreadInterruptedException) { }
            finally
            {
                //---- Termination Operation ----
                countdown.Dispose();
                threadPool.Shutdown();
                Console.WriteLine("Main END");
            }
        }//Main() 
    }//class 
}

/*
Main BEGIN
Pool-0: DoTask() BEGIN contect = 0
Pool-1: DoTask() BEGIN contect = 1
Pool-3: DoTask() BEGIN contect = 3
Pool-4: DoTask() BEGIN contect = 4
Pool-2: DoTask() BEGIN contect = 2
Pool-3: DoTask() END   contect = 3
Pool-3: DoTask() BEGIN contect = 5
Pool-4: DoTask() END   contect = 4
Pool-4: DoTask() BEGIN contect = 6
Pool-1: DoTask() END   contect = 1
Pool-1: DoTask() BEGIN contect = 7
Pool-2: DoTask() END   contect = 2
Pool-2: DoTask() BEGIN contect = 8
Pool-0: DoTask() END   contect = 0
Pool-0: DoTask() BEGIN contect = 9
Pool-3: DoTask() END   contect = 5
Pool-1: DoTask() END   contect = 7
Pool-2: DoTask() END   contect = 8
Pool-0: DoTask() END   contect = 9
Pool-4: DoTask() END   contect = 6
Pool-0 Shutdown()
Pool-1 Shutdown()
Pool-2 Shutdown()
Pool-3 Shutdown()
Pool-4 Shutdown()
Main END
 */
#region ====【参照】CountdownEvent ====
/*
#region アセンブリ mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\mscorlib.dll
#endregion

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System.Threading
{
    //
    // 概要:
    //     カウントが 0 になったときに通知される同期プリミティブを表します。
    [ComVisible(false)]
    [DebuggerDisplay("Initial Count={InitialCount}, Current Count={CurrentCount}")]
    public class CountdownEvent : IDisposable
    {
        //
        // 概要:
        //     指定されたカウントを使用して System.Threading.CountdownEvent クラスの新しいインスタンスを初期化します。
        //
        // パラメーター:
        //   initialCount:
        //     System.Threading.CountdownEvent の設定に最初に必要な通知の数。
        //
        // 例外:
        //   T:System.ArgumentOutOfRangeException:
        //     initialCount が 0 未満です。
        public CountdownEvent(int initialCount);

        //
        // 概要:
        //     イベントの設定に最初に必要な通知の数を取得します。
        //
        // 戻り値:
        //     イベントの設定に最初に必要な通知の数。
        public int InitialCount { get; }
        //
        // 概要:
        //     イベントの設定に必要な残りの通知の数を取得します。
        //
        // 戻り値:
        //     イベントの設定に必要な残りの通知の数。
        public int CurrentCount { get; }
        //
        // 概要:
        //     System.Threading.CountdownEvent オブジェクトの現在の数が 0 に達したかどうかを示します。
        //
        // 戻り値:
        //     現在の数が 0 の場合は、true。それ以外の場合は、false。
        public bool IsSet { get; }
        //
        // 概要:
        //     イベントの設定を待機するために使用する System.Threading.WaitHandle を取得します。
        //
        // 戻り値:
        //     イベントの設定を待機するために使用する System.Threading.WaitHandle。
        //
        // 例外:
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。
        public WaitHandle WaitHandle { get; }

        //
        // 概要:
        //     System.Threading.CountdownEvent の現在のカウントを 1 つインクリメントします。
        //
        // 例外:
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。
        //
        //   T:System.InvalidOperationException:
        //     現在のインスタンスは既に設定されています。 または System.Threading.CountdownEvent.CurrentCount が System.Int32.MaxValue
        //     以上になっています。
        public void AddCount();
        //
        // 概要:
        //     System.Threading.CountdownEvent の現在のカウントを指定された値だけインクリメントします。
        //
        // パラメーター:
        //   signalCount:
        //     System.Threading.CountdownEvent.CurrentCount を増やす値。
        //
        // 例外:
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。
        //
        //   T:System.ArgumentOutOfRangeException:
        //     signalCount が 0 以下です。
        //
        //   T:System.InvalidOperationException:
        //     現在のインスタンスは既に設定されています。 または カウントが signalCount. ずつインクリメントされた後、System.Threading.CountdownEvent.CurrentCount
        //     が System.Int32.MaxValue 以上です
        public void AddCount(int signalCount);
        //
        // 概要:
        //     System.Threading.CountdownEvent クラスの現在のインスタンスによって使用されているすべてのリソースを解放します。
        public void Dispose();
        //
        // 概要:
        //     System.Threading.CountdownEvent.CurrentCount を System.Threading.CountdownEvent.InitialCount
        //     の値にリセットします。
        //
        // 例外:
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。
        public void Reset();
        //
        // 概要:
        //     System.Threading.CountdownEvent.InitialCount プロパティを指定した値にリセットします。
        //
        // パラメーター:
        //   count:
        //     System.Threading.CountdownEvent の設定に必要な通知の数。
        //
        // 例外:
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。
        //
        //   T:System.ArgumentOutOfRangeException:
        //     count が 0 未満です。
        public void Reset(int count);
        //
        // 概要:
        //     通知を System.Threading.CountdownEvent に登録して、System.Threading.CountdownEvent.CurrentCount
        //     の値をデクリメントします。
        //
        // 戻り値:
        //     通知によってカウントが 0 になり、イベントが設定された場合は true。それ以外の場合は false。
        //
        // 例外:
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。
        //
        //   T:System.InvalidOperationException:
        //     現在のインスタンスは既に設定されています。
        public bool Signal();
        //
        // 概要:
        //     複数の通知を System.Threading.CountdownEvent に登録して、System.Threading.CountdownEvent.CurrentCount
        //     の値を指定された量だけデクリメントします。
        //
        // パラメーター:
        //   signalCount:
        //     登録する通知の数。
        //
        // 戻り値:
        //     通知によってカウントが 0 になり、イベントが設定された場合は true。それ以外の場合は false。
        //
        // 例外:
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。
        //
        //   T:System.ArgumentOutOfRangeException:
        //     signalCount が 1 未満です。
        //
        //   T:System.InvalidOperationException:
        //     現在のインスタンスは既に設定されています。 -または- または、signalCount が System.Threading.CountdownEvent.CurrentCount
        //     より大きいです。
        public bool Signal(int signalCount);
        //
        // 概要:
        //     System.Threading.CountdownEvent.CurrentCount を 1 つインクリメントすることを試みます。
        //
        // 戻り値:
        //     インクリメントが正常に行われた場合は true。それ以外の場合は false。 System.Threading.CountdownEvent.CurrentCount
        //     が既に 0 の場合、このメソッドは false を返します。
        //
        // 例外:
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。
        //
        //   T:System.InvalidOperationException:
        //     System.Threading.CountdownEvent.CurrentCount と System.Int32.MaxValue が等価です。
        public bool TryAddCount();
        //
        // 概要:
        //     System.Threading.CountdownEvent.CurrentCount を指定した値だけインクリメントすることを試みます。
        //
        // パラメーター:
        //   signalCount:
        //     System.Threading.CountdownEvent.CurrentCount を増やす値。
        //
        // 戻り値:
        //     インクリメントが正常に行われた場合は true。それ以外の場合は false。 System.Threading.CountdownEvent.CurrentCount
        //     が既に 0 の場合、これは false を返します。
        //
        // 例外:
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。
        //
        //   T:System.ArgumentOutOfRangeException:
        //     signalCount が 0 以下です。
        //
        //   T:System.InvalidOperationException:
        //     System.Threading.CountdownEvent.CurrentCount + signalCount が System.Int32.MaxValue
        //     以上になっています。
        public bool TryAddCount(int signalCount);
        //
        // 概要:
        //     System.Threading.CountdownEvent が設定されるまで、現在のスレッドをブロックします。
        //
        // 例外:
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。
        public void Wait();
        //
        // 概要:
        //     System.Threading.CountdownEvent を観察すると同時に、System.Threading.CancellationToken
        //     が設定されるまで、現在のスレッドをブロックします。
        //
        // パラメーター:
        //   cancellationToken:
        //     観察する System.Threading.CancellationToken。
        //
        // 例外:
        //   T:System.OperationCanceledException:
        //     cancellationToken が取り消されました。
        //
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。 または、cancellationToken を作成した System.Threading.CancellationTokenSource
        //     が破棄されています。
        public void Wait(CancellationToken cancellationToken);
        //
        // 概要:
        //     System.Threading.CountdownEvent を使用してタイムアウトを計測し、System.TimeSpan が設定されるまで、現在のスレッドをブロックします。
        //
        // パラメーター:
        //   timeout:
        //     待機するミリ秒数を表す System.TimeSpan。無制限に待機する場合は、-1 ミリ秒を表す System.TimeSpan。
        //
        // 戻り値:
        //     System.Threading.CountdownEvent が設定された場合は true。それ以外の場合は false。
        //
        // 例外:
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。
        //
        //   T:System.ArgumentOutOfRangeException:
        //     timeout が -1 ミリ秒以外の負数です。-1 は無制限のタイムアウトを表します。または、タイムアウトが System.Int32.MaxValue
        //     を超えています。
        public bool Wait(TimeSpan timeout);
        //
        // 概要:
        //     System.Threading.CountdownEvent を観察すると同時に、System.TimeSpan を使用してタイムアウトを計測し、System.Threading.CancellationToken
        //     が設定されるまで、現在のスレッドをブロックします。
        //
        // パラメーター:
        //   timeout:
        //     待機するミリ秒数を表す System.TimeSpan。無制限に待機する場合は、-1 ミリ秒を表す System.TimeSpan。
        //
        //   cancellationToken:
        //     観察する System.Threading.CancellationToken。
        //
        // 戻り値:
        //     System.Threading.CountdownEvent が設定された場合は true。それ以外の場合は false。
        //
        // 例外:
        //   T:System.OperationCanceledException:
        //     cancellationToken が取り消されました。
        //
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。 または、cancellationToken を作成した System.Threading.CancellationTokenSource
        //     が破棄されています。
        //
        //   T:System.ArgumentOutOfRangeException:
        //     timeout が -1 ミリ秒以外の負数です。-1 は無制限のタイムアウトを表します。または、タイムアウトが System.Int32.MaxValue
        //     を超えています。
        public bool Wait(TimeSpan timeout, CancellationToken cancellationToken);
        //
        // 概要:
        //     32 ビット符号付き整数を使用してタイムアウトを計測し、System.Threading.CountdownEvent が設定されるまで、現在のスレッドをブロックします。
        //
        // パラメーター:
        //   millisecondsTimeout:
        //     待機するミリ秒数。無制限に待機する場合は System.Threading.Timeout.Infinite (-1)。
        //
        // 戻り値:
        //     System.Threading.CountdownEvent が設定された場合は true。それ以外の場合は false。
        //
        // 例外:
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。
        //
        //   T:System.ArgumentOutOfRangeException:
        //     millisecondsTimeout は無限のタイムアウトを表す -1 以外の負の数です。
        public bool Wait(int millisecondsTimeout);
        //
        // 概要:
        //     System.Threading.CountdownEvent を観察すると同時に、32 ビット符号付き整数を使用してタイムアウトを計測し、現在の System.Threading.CancellationToken
        //     が設定されるまで、現在のスレッドをブロックします。
        //
        // パラメーター:
        //   millisecondsTimeout:
        //     待機するミリ秒数。無制限に待機する場合は System.Threading.Timeout.Infinite (-1)。
        //
        //   cancellationToken:
        //     観察する System.Threading.CancellationToken。
        //
        // 戻り値:
        //     System.Threading.CountdownEvent が設定された場合は true。それ以外の場合は false。
        //
        // 例外:
        //   T:System.OperationCanceledException:
        //     cancellationToken が取り消されました。
        //
        //   T:System.ObjectDisposedException:
        //     現在のインスタンスは既に破棄されています。 または、cancellationToken を作成した System.Threading.CancellationTokenSource
        //     が破棄されています。
        //
        //   T:System.ArgumentOutOfRangeException:
        //     millisecondsTimeout は無限のタイムアウトを表す -1 以外の負の数です。
        public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken);
        //
        // 概要:
        //     System.Threading.CountdownEvent が使用しているアンマネージド リソースを解放します。オプションとして、マネージド リソースを解放することもできます。
        //
        // パラメーター:
        //   disposing:
        //     マネージド リソースとアンマネージド リソースの両方を解放する場合は true、アンマネージド リソースだけを解放する場合は false。
        protected virtual void Dispose(bool disposing);
    }
}
 */
#endregion