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
        private const int phaseNum = 5;
        private readonly Random random = new Random(314159);
        private int context;

        private void PhaseAction(int phase)
        {
            String name = $"Task-{Task.CurrentId}";
            Console.WriteLine(
                $"{name} MyTask BEGIN: context = {context}, phase = {phase}");

            try
            {
                Thread.Sleep(random.Next(1000));
            }
            catch (ThreadInterruptedException) { }

        }

        private void BarrierAction()
        {
            Console.WriteLine("-- BarrierAction --");
        }
    }//class
}
