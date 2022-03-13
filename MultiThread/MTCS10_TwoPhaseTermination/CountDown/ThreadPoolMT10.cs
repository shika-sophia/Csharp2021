using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.CountDown
{
    class ThreadPoolMT10
    {
        private readonly ConcurrentQueue<MyTaskMT10> queue
            = new ConcurrentQueue<MyTaskMT10>();
        private readonly int poolNum;
        private Thread[] thAry;

        public ThreadPoolMT10(int poolNum)
        {
            this.poolNum = poolNum;
            this.thAry = new Thread[poolNum];
        }

        public void CreateThread()
        {
            
            for(int i = 0; i < poolNum; i++)
            {
                var th = new Thread(() =>
                    {
                        while (true)
                        {
                            GetMyTask().Run();
                        }//while
                    }
                );
                th.Name = $"Pool-{i}";
                th.Start();

                thAry[i] = th;
            }//for
        }//CreateThread()

        public void AddRequest(MyTaskMT10 myTask)
        {
            queue.Enqueue(myTask);
        }

        public MyTaskMT10 GetMyTask()
        {
            MyTaskMT10 myTask;
            while (!queue.TryDequeue(out myTask))
            {
                Thread.Sleep(300);
            }//while

            return myTask;
        }//GetMyTask()

        public void Shutdown()
        {
            try
            {
                foreach(Thread th in thAry)
                {
                    th.Abort();
                    Console.WriteLine(
                        $"{th.Name} Shutdown()");
                }
            }
            catch (ThreadAbortException) { }
            
        }//Shutdown()
    }//class
}
