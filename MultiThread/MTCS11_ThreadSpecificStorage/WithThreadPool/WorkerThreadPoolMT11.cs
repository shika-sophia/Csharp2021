using CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage.ThreadLocalStorage;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage.WithThreadPool
{
    class WorkerThreadPoolMT11
    {
        private readonly ConcurrentQueue<string> queue
            = new ConcurrentQueue<string>();
        private readonly int poolNum;
        private Thread[] thPool;

        public WorkerThreadPoolMT11(int poolNum)
        {
            this.poolNum = poolNum;
            this.thPool = new Thread[poolNum];
            CreateWorkerThread();
        }

        private void CreateWorkerThread()
        {
            for (int i = 0; i < poolNum; i++)
            {
                Thread th = new Thread( () =>
                    {
                        while (true)
                        {
                            LogLocalStorage.WriteLog(TakeContent());
                        }//while
                    }
                );
                th.Name = $"Worker-{i}";
                th.Start();

                thPool[i] = th;
            }//for
        }//CreateWorkerThread()

        private string TakeContent()
        {
            reCondition:
            while (queue.IsEmpty)
            {
                Thread.SpinWait(100);
            }//while

            string content;
            if(!queue.TryDequeue(out content)) { goto reCondition; }

            return content;
        }//TakeContent()

        public void PutContent(string content)
        {
            queue.Enqueue(content);
        }

        public void Close()
        {
            foreach(var th in thPool)
            {
                while (queue.Count > 0)
                {
                    Thread.Sleep(100);
                }
                    
                th.Abort();
            }//foreach

            Console.WriteLine($"RestWork = {queue.Count}");
        }
    }//class
}
