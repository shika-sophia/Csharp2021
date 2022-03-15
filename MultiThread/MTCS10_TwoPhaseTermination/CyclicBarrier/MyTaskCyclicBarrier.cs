using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.CyclicBarrier
{
    class MyTaskCyclicBarrier
    {
        private readonly Random random = new Random(314159);

        public void PhaseAction(int context, int phase)
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
        }//PhaseAction()

        public void BarrierAction()
        {
            Console.WriteLine("-- BarrierAction --");
        }
    }//class
}
