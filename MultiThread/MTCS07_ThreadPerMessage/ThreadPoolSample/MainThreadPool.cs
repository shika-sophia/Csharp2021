/** 
 *@title CsharpBegin / MultiThread / MTCS07_ThreadPerMessage / ThreadPoolSample / MainThreadPool.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第７章 Thread per Message / p243
 *         補講２ Executor / ThreadPool
 */
#region -> [Java] Executors / ExecutorService / ScheduledExecutorService
/*
 *@subject ◆補講２ [Java] java.util.concurrent.Executors
 *         ＊ThreadFactory <<interface>>
 *             Thread newThread(Runnable)
 *             
 *         ＊Executor <<interface>> 〔MT27, MT33, DJ149〕
 *            └ ExecutorService <<interface>>
 *                └ ScheduledExecutorService <<interface>>
 *                └ AbstractExecutorService class
 *                    └ ThreadPoolExecutor class
 *                        └ ScheduledThreadPoolExecutor class
 *                    └ ForkJoinPool class
 *                    
 *           Executorsクラス factory-methods
 *           
 *         ＊Executors class 〔MT27, MT33, DJ149〕
 *         ThreadFactory defaultThreadFactory
 *         void          execute(Runnable)
 *         void          shutdown()
 *         void          shutdownNow()
 *         ExecutorService Executors.newSingleThreadExecutor()
 *         ScheduledExecutorService
 *                         Executors.newSingleThreadScheduledExecutor(int size)
 *         ExecutorService Executors.newFixedThreadPool(int size)
 *         ExecutorService Executors.newCachedThreadPool(int size)
 *         ExecutorService Executors.newWorkStealingPool(int size)
 *         ScheduledExecutorService
 *                         Executors.newScheduledThreadPool(int size)
 *         Callable<Object> Executors.callable(Runnable<T>)
 *         Callable<T>      Executors.callable(Runnable<T>, T result)
 *         
 *         ＊ExecutorService <<interface>>〔MT38〕
 *         void    execute()
 *         void    submit()
 *         void    shutdown()
 *         boolean awaitTermination(long timeout, TimeUnit)
 *         boolean isTerminated()
 *         boolean isShutdown()
 *         
 *         ＊ScheduledExecutorService <<interface>>〔MT27〕
 *         ScheduledExecutorService
 *                Executors.newScheduledThreadPool(int, ThreadFactory)
 *         void?  scheduled(Runnable, long timeout, TimeUnit)
 *         void   schesuledAtFixedRate()
 *         void   scheduledWithFixedDelay()
 */
#endregion
#region -> [C#] ThreadPool / [C#4-] Task
/*
*@subject [C#] System.Threading.ThreadPool 〔VS2019〕
 *         => 文末 class reference
 *         
 *@subject [C#4-|.NET 4.5-] System.Threading.Tasks.Task 〔CS88〕
 *         Task Task.Run(Action<T>)
 *                  Task(= Thread pool を伴うThread)を生成して実行
 *         void task.Wait()
 *         voud task.Wait(long milliSecond);
 *         void Task.WaitAny(Task, Task, ...) 
 *                  いずれかのTaskが終了するまで待機
 *         void Task.WaitAll(Task, Task, ...) 
 *                  すべてのTaskが終了するまで待機
 *         => see ../TaskSample.cs
 */
#endregion
/*
 *@class MainThreadPool
 * 
 *@author shika 
 *@date 2022-02-18 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.ThreadPoolSample 
{ 
    class MainThreadPool 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            ThreadPool.SetMaxThreads(3, 3);
            ThreadPool.GetMaxThreads(out int worker, out int completation);
            Console.WriteLine($"workerThread: {worker}");
            Console.WriteLine($"completation: {completation}");
        }//Main() 
 
    }//class 
}
/*
workerThread: 2047
completation: 1000
 */

/* ==== ThreadPool ====
#region アセンブリ mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 
// C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\mscorlib.dll 
#endregion 
 
using System.Runtime.InteropServices; 
using System.Security; 
 
namespace System.Threading 
{ 
    // 
    // 概要: 
    //     タスクの実行、作業項目の送信、非同期 I/O の処理、他のスレッドの代理で行う待機、およびタイマーの処理に使用できるスレッドのプールを提供します。 
    public static class ThreadPool 
    { 
        // 
        // 概要: 
        //     オペレーティング システム ハンドルを System.Threading.ThreadPool にバインドします。 
        // 
        // パラメーター: 
        //   osHandle: 
        //     オペレーティング システム ハンドルを保持する System.Runtime.InteropServices.SafeHandle。 ハンドルは、アンマネージ側の重複 
        //     I/O で開かれている必要があります。 
        // 
        // 戻り値: 
        //     ハンドルがバインドされている場合は true。それ以外の場合は false。 
        // 
        // 例外: 
        //   T:System.ArgumentNullException: 
        //     osHandle は nullです。 
        [SecuritySafeCritical] 
        public static bool BindHandle(SafeHandle osHandle); 
        // 
        // 概要: 
        //     オペレーティング システム ハンドルを System.Threading.ThreadPool にバインドします。 
        // 
        // パラメーター: 
        //   osHandle: 
        //     ハンドルを保持する System.IntPtr。 ハンドルは、アンマネージ側の重複 I/O で開かれている必要があります。 
        // 
        // 戻り値: 
        //     ハンドルがバインドされている場合は true。それ以外の場合は false。 
        // 
        // 例外: 
        //   T:System.Security.SecurityException: 
        //     呼び出し元に、必要なアクセス許可がありません。 
        [Obsolete("ThreadPool.BindHandle(IntPtr) has been deprecated.  Please use ThreadPool.BindHandle(SafeHandle) instead.", false)] 
        [SecuritySafeCritical] 
        public static bool BindHandle(IntPtr osHandle); 
        // 
        // 概要: 
        //     スレッド プール スレッドの最大数 (System.Threading.ThreadPool.GetMaxThreads(System.Int32@,System.Int32@) 
        //     メソッドから返される) と現在アクティブなスレッドの数との差を取得します。 
        // 
        // パラメーター: 
        //   workerThreads: 
        //     使用できるワーカー スレッドの数。 
        // 
        //   completionPortThreads: 
        //     使用できる非同期 I/O スレッドの数。 
        [SecuritySafeCritical] 
        public static void GetAvailableThreads(out int workerThreads, out int completionPortThreads); 
        // 
        // 概要: 
        //     同時にアクティブにできるスレッド プールへの要求の数を取得します。 この数を超える要求はすべて、スレッド プール スレッドが使用可能になるまでキューに置かれたままになります。 
        // 
        // パラメーター: 
        //   workerThreads: 
        //     スレッド プール内のワーカー スレッドの最大数。 
        // 
        //   completionPortThreads: 
        //     スレッド プール内の非同期 I/O スレッドの最大数。 
        [SecuritySafeCritical] 
        public static void GetMaxThreads(out int workerThreads, out int completionPortThreads); 
        // 
        // 概要: 
        //     スレッドの作成と破棄を管理するためのアルゴリズムに切り替える前に、スレッドがオンデマンドで (新しい要求の発生ごとに) 作成するスレッド プールの最小数を取得します。 
        // 
        // パラメーター: 
        //   workerThreads: 
        //     このメソッドが戻るとき、スレッド プールがオンデマンドで作成するワーカー スレッドの最小数が含まれています。 
        // 
        //   completionPortThreads: 
        //     このメソッドが戻るとき、スレッド プールがオンデマンドで作成する非同期 I/O スレッドの最小数が含まれています。 
        [SecuritySafeCritical] 
        public static void GetMinThreads(out int workerThreads, out int completionPortThreads); 
        // 
        // 概要: 
        //     メソッドを実行するためのキューに置きます。 メソッドは、スレッド プールのスレッドが使用可能になったときに実行されます。 
        // 
        // パラメーター: 
        //   callBack: 
        //     実行するメソッドを表す System.Threading.WaitCallback。 
        // 
        // 戻り値: 
        //     メソッドが正常にキューに配置された場合は true。作業項目をキューに配置できなかった場合は System.NotSupportedException がスローされます。 
        // 
        // 例外: 
        //   T:System.ArgumentNullException: 
        //     callBack は nullです。 
        // 
        //   T:System.NotSupportedException: 
        //     共通言語ランタイム (CLR) がホストされており、ホストではこのアクションがサポートされていません。 
        [SecuritySafeCritical] 
        public static bool QueueUserWorkItem(WaitCallback callBack); 
        // 
        // 概要: 
        //     実行するためのキューにメソッドを置き、そのメソッドが使用するデータを含んだオブジェクトを指定します。 メソッドは、スレッド プールのスレッドが使用可能になったときに実行されます。 
        // 
        // パラメーター: 
        //   callBack: 
        //     実行するメソッドを表す System.Threading.WaitCallback。 
        // 
        //   state: 
        //     メソッドが使用するデータを格納したオブジェクト。 
        // 
        // 戻り値: 
        //     メソッドが正常にキューに配置された場合は true。作業項目をキューに配置できなかった場合は System.NotSupportedException がスローされます。 
        // 
        // 例外: 
        //   T:System.NotSupportedException: 
        //     共通言語ランタイム (CLR) がホストされており、ホストではこのアクションがサポートされていません。 
        // 
        //   T:System.ArgumentNullException: 
        //     callBack は nullです。 
        [SecuritySafeCritical] 
        public static bool QueueUserWorkItem(WaitCallback callBack, object state); 
        // 
        // 概要: 
        //     タイムアウトとして System.Threading.WaitHandle 値を指定して、System.TimeSpan を待機するデリゲートを登録します。 
        // 
        // パラメーター: 
        //   waitObject: 
        //     登録する System.Threading.WaitHandle。 System.Threading.WaitHandle 以外の System.Threading.Mutex 
        //     を使用します。 
        // 
        //   callBack: 
        //     waitObject パラメーターがシグナル通知されたときに呼び出す System.Threading.WaitOrTimerCallback デリゲート。 
        // 
        //   state: 
        //     デリゲートに渡されたオブジェクト。 
        // 
        //   timeout: 
        //     System.TimeSpan で表されるタイムアウト。 timeout が 0 (ゼロ) の場合、関数はオブジェクトの状態をテストして、すぐに制御を戻します。 
        //     timeout が -1 の場合、関数のタイムアウト間隔が経過することはありません。 
        // 
        //   executeOnlyOnce: 
        //     デリゲートの呼び出し後、スレッドが waitObject パラメーターを待機しなくなる場合は true。待機が登録解除されるまでは、待機操作が完了するたびにタイマーをリセットする場合は 
        //     false。 
        // 
        // 戻り値: 
        //     ネイティブ ハンドルをカプセル化する System.Threading.RegisteredWaitHandle。 
        // 
        // 例外: 
        //   T:System.ArgumentOutOfRangeException: 
        //     timeout パラメーターが -1 未満。 
        // 
        //   T:System.NotSupportedException: 
        //     timeout パラメーターが System.Int32.MaxValue より大きい値です。 
        [SecuritySafeCritical] 
        public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, TimeSpan timeout, bool executeOnlyOnce); 
        // 
        // 概要: 
        //     64 ビット符号付き整数でミリ秒単位のタイムアウトを指定して、System.Threading.WaitHandle を待機するデリゲートを登録します。 
        // 
        // パラメーター: 
        //   waitObject: 
        //     登録する System.Threading.WaitHandle。 System.Threading.WaitHandle 以外の System.Threading.Mutex 
        //     を使用します。 
        // 
        //   callBack: 
        //     waitObject パラメーターがシグナル通知されたときに呼び出す System.Threading.WaitOrTimerCallback デリゲート。 
        // 
        //   state: 
        //     デリゲートに渡されたオブジェクト。 
        // 
        //   millisecondsTimeOutInterval: 
        //     ミリ秒単位のタイムアウト。 millisecondsTimeOutInterval パラメーターが 0 (ゼロ) の場合、関数はオブジェクトの状態をテストして、すぐに制御を戻します。 
        //     millisecondsTimeOutInterval が -1 の場合、関数のタイムアウト間隔が経過することはありません。 
        // 
        //   executeOnlyOnce: 
        //     デリゲートの呼び出し後、スレッドが waitObject パラメーターを待機しなくなる場合は true。待機が登録解除されるまでは、待機操作が完了するたびにタイマーをリセットする場合は 
        //     false。 
        // 
        // 戻り値: 
        //     ネイティブ ハンドルをカプセル化する System.Threading.RegisteredWaitHandle。 
        // 
        // 例外: 
        //   T:System.ArgumentOutOfRangeException: 
        //     millisecondsTimeOutInterval パラメーターが -1 未満。 
        [SecuritySafeCritical] 
        public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, long millisecondsTimeOutInterval, bool executeOnlyOnce); 
        // 
        // 概要: 
        //     ミリ秒単位のタイムアウトとして 32 ビット符号付き整数を指定して、System.Threading.WaitHandle を待機するデリゲートを登録します。 
        // 
        // パラメーター: 
        //   waitObject: 
        //     登録する System.Threading.WaitHandle。 System.Threading.WaitHandle 以外の System.Threading.Mutex 
        //     を使用します。 
        // 
        //   callBack: 
        //     waitObject パラメーターがシグナル通知されたときに呼び出す System.Threading.WaitOrTimerCallback デリゲート。 
        // 
        //   state: 
        //     デリゲートに渡されたオブジェクト。 
        // 
        //   millisecondsTimeOutInterval: 
        //     ミリ秒単位のタイムアウト。 millisecondsTimeOutInterval パラメーターが 0 (ゼロ) の場合、関数はオブジェクトの状態をテストして、すぐに制御を戻します。 
        //     millisecondsTimeOutInterval が -1 の場合、関数のタイムアウト間隔が経過することはありません。 
        // 
        //   executeOnlyOnce: 
        //     デリゲートの呼び出し後、スレッドが waitObject パラメーターを待機しなくなる場合は true。待機が登録解除されるまでは、待機操作が完了するたびにタイマーをリセットする場合は 
        //     false。 
        // 
        // 戻り値: 
        //     ネイティブ ハンドルをカプセル化する System.Threading.RegisteredWaitHandle。 
        // 
        // 例外: 
        //   T:System.ArgumentOutOfRangeException: 
        //     millisecondsTimeOutInterval パラメーターが -1 未満。 
        [SecuritySafeCritical] 
        public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, int millisecondsTimeOutInterval, bool executeOnlyOnce); 
        // 
        // 概要: 
        //     ミリ秒単位のタイムアウトとして 32 ビット符号なし整数を指定して、System.Threading.WaitHandle を待機するデリゲートを登録します。 
        // 
        // パラメーター: 
        //   waitObject: 
        //     登録する System.Threading.WaitHandle。 System.Threading.WaitHandle 以外の System.Threading.Mutex 
        //     を使用します。 
        // 
        //   callBack: 
        //     waitObject パラメーターがシグナル通知されたときに呼び出す System.Threading.WaitOrTimerCallback デリゲート。 
        // 
        //   state: 
        //     デリゲートに渡されたオブジェクト。 
        // 
        //   millisecondsTimeOutInterval: 
        //     ミリ秒単位のタイムアウト。 millisecondsTimeOutInterval パラメーターが 0 (ゼロ) の場合、関数はオブジェクトの状態をテストして、すぐに制御を戻します。 
        //     millisecondsTimeOutInterval が -1 の場合、関数のタイムアウト間隔が経過することはありません。 
        // 
        //   executeOnlyOnce: 
        //     デリゲートの呼び出し後、スレッドが waitObject パラメーターを待機しなくなる場合は true。待機が登録解除されるまでは、待機操作が完了するたびにタイマーをリセットする場合は 
        //     false。 
        // 
        // 戻り値: 
        //     登録された待機操作をキャンセルするために使用できる System.Threading.RegisteredWaitHandle。 
        // 
        // 例外: 
        //   T:System.ArgumentOutOfRangeException: 
        //     millisecondsTimeOutInterval パラメーターが -1 未満。 
        [CLSCompliant(false)] 
        [SecuritySafeCritical] 
        public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, uint millisecondsTimeOutInterval, bool executeOnlyOnce); 
        // 
        // 概要: 
        //     同時にアクティブにできるスレッド プールへの要求の数を設定します。 この数を超える要求はすべて、スレッド プール スレッドが使用可能になるまでキューに置かれたままになります。 
        // 
        // パラメーター: 
        //   workerThreads: 
        //     スレッド プール内のワーカー スレッドの最大数。 
        // 
        //   completionPortThreads: 
        //     スレッド プール内の非同期 I/O スレッドの最大数。 
        // 
        // 戻り値: 
        //     変更が成功した場合は true。それ以外の場合は false。 
        [SecuritySafeCritical] 
        public static bool SetMaxThreads(int workerThreads, int completionPortThreads); 
        // 
        // 概要: 
        //     スレッドの作成と破棄を管理するためのアルゴリズムに切り替える前に、スレッドがオンデマンドで (新しい要求の発生ごとに) 作成するスレッド プールの最小数を設定します。 
        // 
        // パラメーター: 
        //   workerThreads: 
        //     スレッド プールがオンデマンドで作成するワーカー スレッドの最小数。 
        // 
        //   completionPortThreads: 
        //     スレッド プールがオンデマンドで作成する非同期 I/O スレッドの最小数。 
        // 
        // 戻り値: 
        //     変更が成功した場合は true。それ以外の場合は false。 
        [SecuritySafeCritical] 
        public static bool SetMinThreads(int workerThreads, int completionPortThreads); 
        // 
        // 概要: 
        //     重複した I/O 操作を、実行するためのキューに置きます。 
        // 
        // パラメーター: 
        //   overlapped: 
        //     キューに置く System.Threading.NativeOverlapped 構造体。 
        // 
        // 戻り値: 
        //     操作が I/O 完了ポートのキューに正常に置かれた場合は true。それ以外の場合は false。 
        [CLSCompliant(false)] 
        [SecurityCritical] 
        public static bool UnsafeQueueNativeOverlapped(NativeOverlapped* overlapped); 
        // 
        // 概要: 
        //     指定したデリゲートをスレッド プールのキューに置きます。ただし、コール スタックをワーカー スレッドに反映しません。 
        // 
        // パラメーター: 
        //   callBack: 
        //     スレッド プール内のスレッドが作業項目をピック アップするときに呼び出すデリゲートを表す System.Threading.WaitCallback。 
        // 
        //   state: 
        //     スレッド プールから処理されるときにデリゲートに渡されるオブジェクト。 
        // 
        // 戻り値: 
        //     メソッドが成功した場合は true。作業項目をキューに配置できなかった場合は System.OutOfMemoryException がスローされます。 
        // 
        // 例外: 
        //   T:System.Security.SecurityException: 
        //     呼び出し元に、必要なアクセス許可がありません。 
        // 
        //   T:System.ApplicationException: 
        //     メモリが不足しています。 
        // 
        //   T:System.OutOfMemoryException: 
        //     作業項目をキューに配置できません。 
        // 
        //   T:System.ArgumentNullException: 
        //     callBack は nullです。 
        [SecurityCritical] 
        public static bool UnsafeQueueUserWorkItem(WaitCallback callBack, object state); 
        // 
        // 概要: 
        //     64 ビット符号付き整数でミリ秒単位のタイムアウトを指定して、System.Threading.WaitHandle を待機するデリゲートを登録します。 
        //     このメソッドはコール スタックをワーカー スレッドに反映しません。 
        // 
        // パラメーター: 
        //   waitObject: 
        //     登録する System.Threading.WaitHandle。 System.Threading.WaitHandle 以外の System.Threading.Mutex 
        //     を使用します。 
        // 
        //   callBack: 
        //     waitObject パラメーターが通知されたときに呼び出すデリゲート。 
        // 
        //   state: 
        //     デリゲートに渡されたオブジェクト。 
        // 
        //   millisecondsTimeOutInterval: 
        //     ミリ秒単位のタイムアウト。 millisecondsTimeOutInterval パラメーターが 0 (ゼロ) の場合、関数はオブジェクトの状態をテストして、すぐに制御を戻します。 
        //     millisecondsTimeOutInterval が -1 の場合、関数のタイムアウト間隔が経過することはありません。 
        // 
        //   executeOnlyOnce: 
        //     デリゲートの呼び出し後、スレッドが waitObject パラメーターを待機しなくなる場合は true。待機が登録解除されるまでは、待機操作が完了するたびにタイマーをリセットする場合は 
        //     false。 
        // 
        // 戻り値: 
        //     登録された待機操作をキャンセルするために使用できる System.Threading.RegisteredWaitHandle オブジェクト。 
        // 
        // 例外: 
        //   T:System.ArgumentOutOfRangeException: 
        //     millisecondsTimeOutInterval パラメーターが -1 未満。 
        // 
        //   T:System.Security.SecurityException: 
        //     呼び出し元に、必要なアクセス許可がありません。 
        [SecurityCritical] 
        public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, long millisecondsTimeOutInterval, bool executeOnlyOnce); 
        // 
        // 概要: 
        //     ミリ秒単位のタイムアウトとして 32 ビット符号なし整数を指定して、System.Threading.WaitHandle を待機するデリゲートを登録します。 
        //     このメソッドはコール スタックをワーカー スレッドに反映しません。 
        // 
        // パラメーター: 
        //   waitObject: 
        //     登録する System.Threading.WaitHandle。 System.Threading.WaitHandle 以外の System.Threading.Mutex 
        //     を使用します。 
        // 
        //   callBack: 
        //     waitObject パラメーターが通知されたときに呼び出すデリゲート。 
        // 
        //   state: 
        //     デリゲートに渡されたオブジェクト。 
        // 
        //   millisecondsTimeOutInterval: 
        //     ミリ秒単位のタイムアウト。 millisecondsTimeOutInterval パラメーターが 0 (ゼロ) の場合、関数はオブジェクトの状態をテストして、すぐに制御を戻します。 
        //     millisecondsTimeOutInterval が -1 の場合、関数のタイムアウト間隔が経過することはありません。 
        // 
        //   executeOnlyOnce: 
        //     デリゲートの呼び出し後、スレッドが waitObject パラメーターを待機しなくなる場合は true。待機が登録解除されるまでは、待機操作が完了するたびにタイマーをリセットする場合は 
        //     false。 
        // 
        // 戻り値: 
        //     登録された待機操作をキャンセルするために使用できる System.Threading.RegisteredWaitHandle オブジェクト。 
        // 
        // 例外: 
        //   T:System.Security.SecurityException: 
        //     呼び出し元に、必要なアクセス許可がありません。 
        [CLSCompliant(false)] 
        [SecurityCritical] 
        public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, uint millisecondsTimeOutInterval, bool executeOnlyOnce); 
        // 
        // 概要: 
        //     タイムアウトとして System.Threading.WaitHandle 値を指定して、System.TimeSpan を待機するデリゲートを登録します。このメソッドはコール 
        //     スタックをワーカー スレッドに反映しません。 
        // 
        // パラメーター: 
        //   waitObject: 
        //     登録する System.Threading.WaitHandle。 System.Threading.WaitHandle 以外の System.Threading.Mutex 
        //     を使用します。 
        // 
        //   callBack: 
        //     waitObject パラメーターが通知されたときに呼び出すデリゲート。 
        // 
        //   state: 
        //     デリゲートに渡されたオブジェクト。 
        // 
        //   timeout: 
        //     System.TimeSpan で表されるタイムアウト。 timeout が 0 (ゼロ) の場合、関数はオブジェクトの状態をテストして、すぐに制御を戻します。 
        //     timeout が -1 の場合、関数のタイムアウト間隔が経過することはありません。 
        // 
        //   executeOnlyOnce: 
        //     デリゲートの呼び出し後、スレッドが waitObject パラメーターを待機しなくなる場合は true。待機が登録解除されるまでは、待機操作が完了するたびにタイマーをリセットする場合は 
        //     false。 
        // 
        // 戻り値: 
        //     登録された待機操作をキャンセルするために使用できる System.Threading.RegisteredWaitHandle オブジェクト。 
        // 
        // 例外: 
        //   T:System.ArgumentOutOfRangeException: 
        //     timeout パラメーターが -1 未満。 
        // 
        //   T:System.NotSupportedException: 
        //     timeout パラメーターが System.Int32.MaxValue より大きい値です。 
        // 
        //   T:System.Security.SecurityException: 
        //     呼び出し元に、必要なアクセス許可がありません。 
        [SecurityCritical] 
        public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, TimeSpan timeout, bool executeOnlyOnce); 
        // 
        // 概要: 
        //     ミリ秒単位のタイムアウトとして 32 ビット符号付き整数を使用して、System.Threading.WaitHandle を待機するデリゲートを登録します。 
        //     このメソッドはコール スタックをワーカー スレッドに反映しません。 
        // 
        // パラメーター: 
        //   waitObject: 
        //     登録する System.Threading.WaitHandle。 System.Threading.WaitHandle 以外の System.Threading.Mutex 
        //     を使用します。 
        // 
        //   callBack: 
        //     waitObject パラメーターが通知されたときに呼び出すデリゲート。 
        // 
        //   state: 
        //     デリゲートに渡されたオブジェクト。 
        // 
        //   millisecondsTimeOutInterval: 
        //     ミリ秒単位のタイムアウト。 millisecondsTimeOutInterval パラメーターが 0 (ゼロ) の場合、関数はオブジェクトの状態をテストして、すぐに制御を戻します。 
        //     millisecondsTimeOutInterval が -1 の場合、関数のタイムアウト間隔が経過することはありません。 
        // 
        //   executeOnlyOnce: 
        //     デリゲートの呼び出し後、スレッドが waitObject パラメーターを待機しなくなる場合は true。待機が登録解除されるまでは、待機操作が完了するたびにタイマーをリセットする場合は 
        //     false。 
        // 
        // 戻り値: 
        //     登録された待機操作をキャンセルするために使用できる System.Threading.RegisteredWaitHandle オブジェクト。 
        // 
        // 例外: 
        //   T:System.ArgumentOutOfRangeException: 
        //     millisecondsTimeOutInterval パラメーターが -1 未満。 
        // 
        //   T:System.Security.SecurityException: 
        //     呼び出し元に、必要なアクセス許可がありません。 
        [SecurityCritical] 
        public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, int millisecondsTimeOutInterval, bool executeOnlyOnce); 
    } 
} 
 */
