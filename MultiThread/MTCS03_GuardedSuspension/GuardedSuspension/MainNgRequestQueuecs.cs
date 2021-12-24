/** 
 *@title CsharpBegin / MultiThread / MTCS03_GuardedSuspension / GuardedSuspension / MainNgRequestQueuecs.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第３章 GuardedSuspension NGコード / p133, p493 / 練習問題 3-4 / List 3-8 ～ 3-11
 *@subject ◆Case1: while -> if
 *         サンプルプログラムの範囲なら問題ないが、
 *         複数Threadが SpinWait()しているとき、Thread.Yeild()されると、
 *         WaitSet中の複数Threadが quque.Dequque()を実行する可能性がある。
 *         要素が１つしかなときは　InvalidOperationExceptionとなる。
 *         このコードは安全性に欠く。
 *          〔No problem within Sample Program. But it generally is problem.
 *           When some Threads are waiting, 
 *           they could be released from WaitSet by 'Thread.Yeild()'.
 *           And they could execute 'quque.Dequque()'.
 *           If there were only ONE element in queue,
 *           CLR (=[C#] Common Language Runtime) would throw InvalidOperationException.
 *           This code is not Thread-Safe.〕
 *         
 *         => WaitSetから解放された Threadは、再びガード条件をチェックする必要がある。
 *            if()だと、１回チェックするだけなので、while()にしておかなければならない。
 *              〔These Threads which are released from WaitSet, 
 *                need check the Guarded Condition AGAIN.
 *                Because 'if()' did ONLY first times, 'while()' did repeatedly,
 *                it must be discribed 'while()'.〕
 *         
 *@subject ◆Case2: lock() ONLY SpinWait()
 *         これもサンプルプログラムでは問題ないが、
 *         ガード条件と、catch節が、クリティカルセクション(= lock()ブロック)の外に
 *         出てしまうので、Interrupt()や、2Threads時に InvalidOperationException
 *         となる可能性がある。このコードは安全性に欠く。
 *          〔No problem within Sample Program too. 
 *           But because the Guarded Condition check and catch() block are put out of 
 *           the critical section (= lock() block), 
 *           when 'Interrupt()' and multi-Thread,
 *           CLR could throw InvalidOperationException.
 *           This code is not Thread-Safe.〕
 *         
 *@subject ◆Case3: try-catch put out of While()
 *         Interrupt()を利用時に、
 *         このコードはガード条件をチェックせずに queue.Dequeue()を実行してしまう。
 *         上記と同様に、ガード条件は毎回チェックされるべき。
 *         このコードは安全性に欠く。
 *        〔If 'Interrupt()' were used,
 *         the Guarded Condition wouldn't be checked,
 *         and execute queue.Dequeue().
 *         As same above, the Guarded Condition should be checked every times.
 *         This code is not Thread-Safe.〕
 *         
 *@subject ◆Case4: SpinWait() -> Sleep()
 *         「SpinWait()は Yield()で起こされるが、Sleep()は時間内ずっと待機するので、
 *         パフォーマンスが低下する」は誤り。
 *         SpinWait()はロックを解放するが、
 *         Sleep()はロックを解放せずに そのThreadの実行を休止する。
 *         そのため、GetRequest(), PutRequest()は lock()されているので、
 *         この中で Sleep()させてしまうと、
 *         他のどのThreadも GetRequest(), PutRequest()を利用できなくなる。
 *         Sleep()中は ガード条件に変更がないので、再び Sleep()に入り、
 *         LiveLock状態(= どのThreadも動いているが、処理が進まない状態)となる。
 *         パフォーマンスの問題ではなく、生存性(= 必要な処理がなされるか)の問題。
 *         
 *         〔It is wrong that 
 *              "Because 'SpinWait()' is waken up by 'Yield()',
 *              and 'Sleep()' continue sleeping in whole wait time even by 'Yield()', 
 *              it decrease the performance."
 *           Correctly, 'SpinWait()' release the lock,
 *           but 'Sleep()' rest the Thread activity with having the lock.
 *           
 *           Therefore if 'Sleep()' were used in GetRequest(), PutRequest(),
 *           any other Thread couldn't entry GetRequest(), PutRequest().
 *           Because the Guarded Condition is no change while sleeping, 
 *           when the slept Thread is waken up, it gets into sleep again.
 *           
 *           That is called -- LiveLock --
 *           (= Though all Thread is running, the code won't be done for next.)
 *           This code is not the performance problem,
 *           but the aliveness ploblem 
 *           (= the situation that the necessary code can't be done).〕
 *
 *  ==== ONLY modification point from MainGuardedSuspension ====
 *@class MainNgRequestQueuecs
 *       /◆Main() new RequestQueueNgCode()
 *@class RequestQueueNgCode : RequestQueue
 *       / - readonly Queue<RequestMT03> queue /
 *       + ovrride RequestMT03 GetRequest()
 *       + ovrride void        PutRequest()
 *       
 *@see MainGuardedSuspension.cs
 *@see RequestQueueNgCode.cs
 *@author shika 
 *@date 2021-12-24 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS03_GuardedSuspension.GuardedSuspension 
{ 
    class MainNgRequestQueuecs 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            var queue = new RequestQueueNgCode();

            new Thread(new ClientThreadMT03(
                queue, "Alice", 3141592).Run).Start();
            new Thread(new ServerThreadMT03(
                queue, "Bobby", 6535897).Run).Start();
        }//Main() 
 
    }//class 
} 
