﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv
{
    class ScheduleThreadMT12
    {
        private readonly ActiveQueueMT12 queue;

        public ScheduleThreadMT12(ActiveQueueMT12 queue)
        {
            this.queue = queue;
        }

        public void Invoke(AbsMethodRequest<string> req)
        {
            queue.PutRequest(req);
        }//Invoke()

        public void Run()
        {
            while (true)
            {
                AbsMethodRequest<string> req = queue.TakeRequest();
                req.Execute();
            }//while
        }//Run()
    }//class
}
