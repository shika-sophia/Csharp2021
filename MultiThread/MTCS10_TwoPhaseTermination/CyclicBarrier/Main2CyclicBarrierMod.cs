/** 
 *@title CsharpBegin / MultiThread / MTCS10_TwoPhaseTermination / CyclicBarrier / Main2CyclicBarrierMod.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content Taskを利用した CyclicBarrierの再現〔未完成〕
 *         文末のような結果となり、原因も不明。
 *         context = 3に固定される。
 *         taskAry.Length = 3になっている。
 *         CountdownEventは ちゃんと Reset(), Signal()している。
 *         while(!countdown.IsSet), while(countdown.CurrentCount != 0)
 *         でも不可。
 *         
 *         Taskを勉強しなおしてから、再度挑戦すべし。
 *         
 *@based MainCyclicBarrier
 *@class Main2CyclicBarrierMod
 * 
 *@author shika 
 *@date 2022-03-16 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.CyclicBarrier 
{ 
    class Main2CyclicBarrierMod 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            Console.WriteLine("Main BEGIN");
            var myTask = new MyTask2CyclicBarrierMod();

            try
            {
                Task[] taskAry = myTask.CreateTask();
                Task.WaitAll(taskAry);
            }
            catch(ThreadInterruptedException) { }
            finally
            {
                myTask.Shutdown();
                Console.WriteLine("Main END");
            }
        }//Main() 
 
    }//class 
}

/*
Main BEGIN
Task-2 MyTask BEGIN: context = 3, phase = 0
Task-1 MyTask BEGIN: context = 3, phase = 0
Task-3 MyTask BEGIN: context = 3, phase = 0
Task-3 MyTask END  : context = 3, phase = 0
Task-2 MyTask END  : context = 3, phase = 0
Task-1 MyTask END  : context = 3, phase = 0
-- BarrierAction phase = 0 --
Task-1 MyTask BEGIN: context = 3, phase = 1
Task-1 MyTask END  : context = 3, phase = 1
(-- ここで DeadLock --)
 */