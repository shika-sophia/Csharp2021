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
        
        public ChannelThreadPerMessage(int thNum = 3)
            : base(thNum)
        { }
        

        public override void StartWorker() { }

        public override void PutRequest(RequestMT08 req)
        {
            var workerNew = new Thread(() => req.ReqExecute());
            workerNew.Name = $"Worker-{count++}";
            workerNew.Start();
        }
    }//class
}
