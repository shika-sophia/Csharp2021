/** 
 *@title CsharpBegin / MultiThread / MTCS05_ProducerComsumer / ExerciseMT05.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第５章 Producer-Consumer / 練習問題 5-1, 5-2, 5-3, 5-4, 5-5, 5-6, 5-7, 5-8, 5-9, 
 * 
 *@author shika 
 *@date 2022-01-08 
*/ 
/*==== Appendix ==== 
 *@date: 2022-01-08 (土) 
 *@time: 12:59 ～ 13:32 (33分) 
 *@rate: 95.83％ (○ 23 問 / 全 24 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer 
{ 
    class ExerciseMT05 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
    }//class 
}
/* 
2022-01-08 (土)
==== Exercise Result ==== 
◆〔1〕第５章 Producer-Consumer / 練習問題 5-1 
○ (1) ○ super(name)は superクラス Threadのコンストラクタ 
○ (2) × NextId（）は MakerThread飲み。複数のMakerThreadになった場合を考慮 
○ (3) × [Java] Object.wait()中はロックを手放す 
○ (4) ○ countは CakeTable.bufferの要素数 
× (5) ○ count == buffer.Length - 1 のとき buffer[]は満杯 => ○: 満杯で置けないときは buffer.Length 
○ (6) ○ head = (head + 1) % buffer.Length;により、headは buffer.Lengthより小さくなる。 

◆〔2〕5-2 
○ (1) new Table(3)を２つ作ったので、 
○ (2) Producer, Consumerは別々のTableにアクセスし、 
○ (3) ガード条件が整うまで、どちらも待機している DeadLock状態 

◆〔3〕5-3 
○ (1) synchronizedの必要性: while()判定と
    count処理が別のスレッドによって行われる可能性があるので、
    それを排他制御するため。 

◆〔4〕5-4 
○ (1) SpinWait()の前後に Debug-Print 

◆〔5〕5-5 
○ (1) public void ClearCake() { 
○ (2)   readonly bufferなので、 buffer = null;は不可 
○ (3) foreach(string cake in buffer) { cake = null;} 

◆〔6〕5-6 
○ (1) Thread.Sleep(10000); 
○ (2) makerTh = new Thread(), eaterTh = new Thread(); 
○ (3) makerTh, eaterTh.Start(); 
○ (4) makerTh, eaterTh.Interrupt() 

◆〔7〕5-7 
○ (1) (another class) 

◆〔8〕5-8 
○ (1) [Java] Object.notify()は WaitSet中のどれか１つのThreadのみ起こす。 
○ (2) Makerだけ/Eaterだけを起こし続けた場合は LiveLockとなる 
○ (3) [C#] Thread.Yield()は notify()の仕様と同じ?
    notifyAll()に当たるものがないのでは？ 
    => [C#] Thread.Yield() は、notifyAll()の機能がある。
    => @see MainLazyThread.cs

◆〔9〕5-9 
○ (1) 引数 long xについて、if( x != 0 )なら 
○ (2) lockObject のロックを取る。
    -> wait(x);より、 Something.Method(long);は
       Thread.Sleep(int)と等価。

*/
/*==== Appendix ==== 
 *@date: 2022-01-08 (土) 
 *@time: 12:59 ～ 13:32 (33分) 
 *@rate: 95.83％ (○ 23 問 / 全 24 問) 
*/
