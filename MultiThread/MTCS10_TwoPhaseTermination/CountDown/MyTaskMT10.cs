using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.CountDown
{
    class MyTaskMT10
    {
        private readonly Random random = new Random(314149);
        private readonly CountdownEvent countdown;
        private readonly int context;

        public MyTaskMT10(CountdownEvent countdown, int context)
        {
            this.countdown = countdown;
            this.context = context;
        }

        public void Run()
        {           
            DoTask();
            countdown.Signal();

            if (countdown.IsSet)
            {
                return;
            }
        }//Run()

        private void DoTask()
        {
            string name = Thread.CurrentThread.Name;
            Console.WriteLine(
                $"{name}: DoTask() BEGIN contect = {context}");

            try
            {
                Thread.Sleep(random.Next(3000));
            }
            catch (ThreadInterruptedException) { }
            finally
            {
                Console.WriteLine(
                    $"{name}: DoTask() END   contect = {context}");
            }
        }//DoTask
    }//class
}
