using CsharpBegin.MultiThread.MTCS08_WorkerThread.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS08_WorkerThread.WorkerPerformance
{
    class ChannelThreadPerMessage : ChannelMT08
    {
        private static int count;
        private List<Thread> threadList;
        
        public ChannelThreadPerMessage(int thNum = 3)
            : base(thNum)
        {
            this.threadList = new List<Thread>();
        }
        

        public override void StartWorker() { }

        public override void StopAllWorker()
        {
            foreach(Thread workerTh in threadList)
            {
                workerTh.Abort();
            }//foreach
        }//StopAllWorker()

        public override void PutRequest(RequestMT08 req)
        {
            var workerNew = new Thread(() => req.ReqExecute());
            workerNew.Name = $"Worker-{count++}";
            threadList.Add(workerNew);
            workerNew.Start();
        }
    }//class
}
