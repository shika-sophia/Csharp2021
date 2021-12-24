/** 
 *@title CsharpBegin / MultiThread / MTCS03_GuardedSuspension / ExerciseMT03.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第３章 GuardedSuspension / p132, p490
 *@subject 練習問題 3-1, 3-2, 3-3, 3-4, 3-5, 3-6, 
 * 
 *@author shika 
 *@date 2021-12-23 
*/ 
/*==== Appendix ==== 
 *@date: 2021-12-23 (木) 
 *@time: 10:00 ～ 10:41 (41分) 
 *@rate: 68.00％ (○ 17 問 / 全 25 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS03_GuardedSuspension 
{ 
    class ExerciseMT03 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
 
    }//class 
} 
/* 
2021-12-23 (木)
==== Exercise Result ==== 
◆〔1〕第３章 GuardedSuspension / 練習問題 3-1 
○ (1) ○ GetRequest, PutRequest()は別スレッドでcall 
○ (2) × RequestQueueのインスタンスは１つ 
○ (3) ○ queue.Dequeue()時、queue.Peek() != null -> true 
○ (4) ○ Thread.SpinWait()時 queue.Peek() != null -> false 
○ (5) × Client -> Get / Server -> Put. Both Thread are moving. 
× (6) ○ Any Thread into WaitSet release its lock. 
    => ○: WaitSet not in queue, but in RequestQueue instance 
× (7) × queue.notifyAll()はコンパイルエラー 
    => ○: 違う意味、this.notifyAll()と書くべき 

◆〔2〕3-2 
○ (1) The case that notifyAll() put before queue.Enqueue: 
○ (2) Because the guarded condition ( <-> wait condition ) is unchanged, 
○ (3) ServerThread will enter into WaitSet again. 
○ (4) When next PutRequest(), Server get one previous request. 

◆〔3〕3-3 
○ (1) (I will discribe in another file) 

◆〔4〕3-4 
○ (1) Case while -> if: Now one by one case is no problem, 
○ (2) but when some Threads move,Thread which is released, 
    will execute queue.Dequeue() by no condition. 

○ (3) 2.Case wait() ONLY: 
○ (4) wait() needs try-catch. and when if() is not, 
× (5)  it is thrown NullPointerException. 
    => ○: queue.Dequeue() put out of synchronized(),it's No ThreadSafe.

× (6) 3.Case try-catch put out of while { }: 
    => ○: if some call interrupt(), it execute queue.Dequeue() with no condition. 
× (7) OK? => ○: need test condition again. 
=>〔see MainNgRequestQueue.cs〕

× (8) 4. Case Thread.Sleep() instead of wait():
× (9) Sleep() don't wake up by notifyAll(). 
    => ○: Thread.Sleep() don't release the lock, but Wait() do. 
× (10) Therefore, GetRequest() delay slowly than before 
    => ○: Not Performance problem, But Aliveness problem. 

◆〔5〕3-5 
○ (1) DeadLock because call order is different. 
○ (2) To success, it should modify same order call 
    or integrate one RequestQueue instance. 

◆〔6〕3-6 
○ (1) interrupt (Another file) 
*/ 
/*==== Appendix ==== 
 *@date: 2021-12-23 (木) 
 *@time: 10:00 ～ 10:41 (41分) 
 *@rate: 68.00％ (○ 17 問 / 全 25 問) 
*/ 
