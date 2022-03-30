using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv
{
    class ActiveObjectFactory
    {
        public static AbsActiveObjectMT12 CreateActiveObject()
        {
            var server = new ServerMT12();
            var queue = new ActiveQueueMT12();
            var schedule = new ScheduleThreadMT12(queue);
            var thSchedule = new Thread(schedule.Run);            
            var proxy = new ProxyMT12(server, schedule);

            thSchedule.Name = "ScheduleThread";
            thSchedule.Start();

            return proxy;
        }//CreateActiveObject()
    }//class
}
