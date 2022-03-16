using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.CyclicBarrier
{
    class MyTask2CyclicBarrierMod
    {
        private const int thNum = 3;   //ThreadPool数
        private const int phaseNum = 5;//Phase数
        private readonly Random random = new Random(314159);
        private CountdownEvent countdown;
        private Task[] taskAry;

        public MyTask2CyclicBarrierMod()
        {
            this.countdown = new CountdownEvent(thNum);
            this.taskAry = new Task[thNum];
        }

        public Task[] CreateTask()
        {            
            for(int context = 0; context < taskAry.Length; context++)
            {
                taskAry[context] = Task.Run(
                    () => PhaseActionMod(context));
            }//for
            
            return taskAry;
        }//CreateTask()
    
        private void PhaseActionMod(int context)
        {
            for(int phase = 0; phase < phaseNum; phase++)
            {
                string name = $"Task-{Task.CurrentId}";

                Console.WriteLine(
                    $"{name} MyTask BEGIN: context = {context}, phase = {phase}");

                try
                {
                    Thread.Sleep(random.Next(1000));
                }
                catch (ThreadInterruptedException) { }

                Console.WriteLine(
                    $"{name} MyTask END  : context = {context}, phase = {phase}");

                DoCyclicBarrier(phase);                
            }//for
        }//PhaseActionMod()

        private void DoCyclicBarrier(int phase)
        {
            countdown.Signal();

            while (!countdown.IsSet)
            {
                Thread.Sleep(300);
            }

            BarrierAction(phase);
            countdown.Reset();
        }//DoCyclicBarrier()

        private void BarrierAction(int phase)
        {
            Console.WriteLine($"-- BarrierAction phase = {phase} --");
        }

        public void Shutdown()
        {
            foreach(var task in taskAry)
            {
                task.Dispose();
            }
            countdown.Dispose();
        }//Shutdown()
    }//class
}
