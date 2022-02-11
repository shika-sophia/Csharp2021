/** 
 *@title CsharpBegin / MultiThread / MTCS06_ReadWriteLock
 *       / Concurrent / MainConcurrent.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第６章 Read-Write Lock / 排他制御クラスの利用 / p216 / List 6-6
 */
#region -> [Java] ReentrantReadWriteLock / [C#] ReaderWriterLock
/*
 *@reference from [VS-2019 intelisense]
 *@subject ◆[Java] java.util.concurrent.locks.Lock
 *                  java.util.concurrent.locks.ReentrantReadWriteLock
 *         var lock = new ReentrantReadWriteLock(boolean isFair)
 *         Lock lock.readLock()
 *         Lock lock.writeLock()
 *         
 *@subject ◆[C#] System.Threading.
 *         ＊【ReaderWriterLockクラス】単一Writerと複数Readerの排他制御
 *           var lockRW = new ReaderWriterLock();
 *           void lockRW.AcquireReaderLock(int timeout); 
 *               //タイムアウト(ミリ秒)を指定してReaderLockを取得
 *           void lockRW.AcquireWriterLock(int timeout);
 *               //タイムアウト(ミリ秒)を指定してWriterLockを取得
 *               
 *           LockCookie lockRW.ReleaseLock()   
 *               //ThreadがLock取得した回数に関係なくLockを解放。
 *               //戻り値 Lock解放したThreadの Cookie値
 *           void lockRW.RestoreLock(LockCookie)
 *               //ReleaseLock()を呼び出す前の ThreadのLock状態を復元
 *               
 *           LockCookie lockRW.UpgradeToWriterLock(int timeoutMillisec)
 *               //タイムアウト後に ReaderLockを WriterLockにアップグレード
 *           void lockRW.DowngradeFromWriterLock(LockCookie)
 *               //アップグレードしたThreadを　UpgradeToWriterLock()の Lock状態に復元
 *               
 *           void lockRW.ReleaseReaderLock() Lockカウントをデクリメント
 *           void lockRW.ReleaseWriterLock() Lockカウントをデクリメント
 *           
 *           int  lockRW.WriterSeqNum     //現在のシーケンス番号を取得
 *           bool lockRW.AnyWritersSince(int seqNum) 
 *               //シーケンス番号を取得後に WriteLockを取得したThreadがあったかどうか
 *           bool lockRW.IsReaderLockHeld //現在のThreadが ReaderLockを保持しているか
 *           bool lockRW.IsWriterLockHeld //現在のThreadが WriterLockを保持しているか
 *           
 *          ＊【ReaderWriterLockSlim】 複数Writerと複数Readerの排他制御
 *           var lockRW = new ReaderWriterLockSlim();
 *           void lockRW.EnterReadLock()  読取モードでLock取得を試みる
 *           void lockRW.EnterWriteLock() 書込モードでLock取得を試みる
 *           bool lockRW.TryEnterReadLock(int timeoutMillisec)  TimeSpanも可
 *           bool lockRW.TryEnterWriteLock(int timeoutMillisec) TimeSpanも可
 *           bool lockRW.TryEnterUpgradeableReadLock(int timeoutMillisec) TimeSpanも可
 *           void lockRW.EnterUpgradeableReadLock() アップグレード可能で読取モード Lock
 *           void lockRW.ExitReadLock()   再帰カウントを減らし、0なら読取モード終了
 *           void lockRW.ExitWriteLock()  再帰カウントを減らし、0なら書込モード終了
 *           void lockRW.ExitUpgradeableReadLock 再帰カウントを減らし、0ならアップグレード可能モード終了
 *           
 *           int lockRW.CurrentReadCount     読取モードで入った 一意のThread数
 *           int lockRW.RecursiveReadCount   読取モードで入った 再帰カウント
 *           int lockRW.RecursiveWriteCount  書込モードで入った 再帰カウント
 *           int lockRW.RecursiveUpgradeCount アップグレード可能モードで入った 再帰カウント
 *               ※再帰カウント int
 *               0: 現在Threadは、そのモードにまだ入っていない。
 *               1: モードには入ったが 再帰していない(= Lockは取れていない)
 *               n: (n-1)回の 再帰し、Lockを取得
 *               
 *           bool lockRW.IsReadLockHeld 現在のThreadが ReaderLockを保持しているか
 *           bool lockRW.IsWriteLockHeld 現在のThreadが WriterLockを保持しているか
 *           bool lockRW.IsUpgradeableReadLockHeld アップグレード可能モードで入ったか
 *           
 *           (enum)LockRecursionPolicy lockRW.RecursionPolicy 再帰ポリシーを示すenum値
 *               LockRecursionPolicy.NoRecursion = 0, 
 *                  スレッドが再帰的にロックを入力しようとすると、例外がスローされます。 
 *                  いくつかのクラスは、この設定が有効な場合、特定再帰を使用することができます。
 *               LockRecursionPolicy.SupportsRecursion = 1
 *                  スレッドは、再帰的にロックに入ることができます。
 *                  一部のクラスは、この機能を制限することがあります。
 *           void lockRW.Dispose() 現在のlockRWインスタンスで利用する全てのリソースを解放
 */
#endregion
/*
 *@author shika 
 *@date 2022-02-11 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.Concurrent 
{ 
    class MainConcurrent 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            var lockRW = new ReaderWriterLockSlim();
            LockRecursionPolicy recursionPolicy = lockRW.RecursionPolicy;

        }//Main() 
    }//class 
} 
