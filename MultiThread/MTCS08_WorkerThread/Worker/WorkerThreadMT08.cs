﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS08_WorkerThread.Worker
{
    class WorkerThreadMT08
    {
        private readonly AbsChannelMT08 channel;
        internal readonly string thName;

        public WorkerThreadMT08(
            string thName, AbsChannelMT08 channel)
        {
            this.thName = thName;
            this.channel = channel;
        }
        
        public void Run()
        {
            while (true)
            {
                RequestMT08 req = channel.TakeRequest();
                req.ReqExecute();
            }//while
        }//Run()
    }//class
}
