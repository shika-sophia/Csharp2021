/** 
 *@title CsharpBegin / MultiThread / MTCS10_TwoPhaseTermination / CyclicBarrier / MainCyclicBarrier.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第10章 TwoPhaseTermination / 補講２ CyclicBarrier / p347 / List 10-6, 10-7, 
 *
 *@subject [Java] java.util.concurrent.CyclicBarrierクラス
 *         周期的(= cyclic)に障壁(= barrier)を課し、
 *         複数Thread間の実行状況を同期させるクラス
 *
 *         new CyclicBarrier(int threadNum, Runnable barrierAction)
 *         void cyclicBarrier.await() 全Threadの処理が完了するまで待機
 *         
 *@subject [C#4-|.NET 4.5-] System.Threading.Tasks.Task
 *         Task Task.Run(Action<T>) //内部的にスレッドプールを行う
 *         void task.Wait()
 *         voud task.Wait(long milliSecond);
 *         void Task.WaitAny(Task, Task, ...) 
 *                  いずれかのTaskが終了するまで待機
 *         void Task.WaitAll(Task, Task, ...) 
 *                  すべてのTaskが終了するまで待機
 *         => see .. / TaskSample.cs         
 *         
 *@class MainCyclicBarrier
 * 
 *@author shika 
 *@date 2022-03-14 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.CyclicBarrier 
{ 
    class MainCyclicBarrier 
    {
        private const int thNum = 3;  //ThreadPool数

        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            Console.WriteLine("Main BEGIN");
            

        }//Main() 
 
    }//class 
} 
