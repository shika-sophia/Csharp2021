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
        private const int thNum = 3;   //ThreadPool数
        private const int phaseNum = 5;

        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            Console.WriteLine("Main BEGIN");
            var myTask = new MyTaskCyclicBarrier();            

            Task[] taskAry = new Task[thNum];            
            try
            {
                for(int phase = 0; phase < phaseNum; phase++)
                {
                    taskAry[0] = Task.Run(
                        () => myTask.PhaseAction(0, phase));
                    taskAry[1] = Task.Run(
                        () => myTask.PhaseAction(1, phase));
                    taskAry[2] = Task.Run(
                        () => myTask.PhaseAction(2, phase));
                    Task.WaitAll(taskAry);
                    myTask.BarrierAction();
                }//for
            }
            finally
            {
                foreach(var task in taskAry)
                {
                    task.Dispose();
                }
                Console.WriteLine("Main END");
            }
        }//Main() 
 
    }//class 
}

/*
Main BEGIN
Task-1 MyTask BEGIN: context = 0, phase = 0
Task-2 MyTask BEGIN: context = 2, phase = 0
Task-3 MyTask BEGIN: context = 1, phase = 0
Task-3 MyTask END  : context = 1, phase = 0
Task-1 MyTask END  : context = 0, phase = 0
Task-2 MyTask END  : context = 2, phase = 0
-- BarrierAction --
Task-4 MyTask BEGIN: context = 0, phase = 1
Task-6 MyTask BEGIN: context = 1, phase = 1
Task-5 MyTask BEGIN: context = 2, phase = 1
Task-5 MyTask END  : context = 2, phase = 1
Task-6 MyTask END  : context = 1, phase = 1
Task-4 MyTask END  : context = 0, phase = 1
-- BarrierAction --
Task-7 MyTask BEGIN: context = 0, phase = 2
Task-9 MyTask BEGIN: context = 1, phase = 2
Task-8 MyTask BEGIN: context = 2, phase = 2
Task-9 MyTask END  : context = 1, phase = 2
Task-8 MyTask END  : context = 2, phase = 2
Task-7 MyTask END  : context = 0, phase = 2
-- BarrierAction --
Task-10 MyTask BEGIN: context = 0, phase = 3
Task-11 MyTask BEGIN: context = 1, phase = 3
Task-12 MyTask BEGIN: context = 2, phase = 3
Task-10 MyTask END  : context = 0, phase = 3
Task-11 MyTask END  : context = 1, phase = 3
Task-12 MyTask END  : context = 2, phase = 3
-- BarrierAction --
Task-13 MyTask BEGIN: context = 0, phase = 4
Task-14 MyTask BEGIN: context = 1, phase = 4
Task-15 MyTask BEGIN: context = 2, phase = 4
Task-14 MyTask END  : context = 1, phase = 4
Task-15 MyTask END  : context = 2, phase = 4
Task-13 MyTask END  : context = 0, phase = 4
-- BarrierAction --
Main END

【NOTE 考察】
サンプルと似た結果を作ることができたが、
Taskは本来 3つで済むのに、各 phaseごとに新しいTaskを定義しているので要修正。
 */