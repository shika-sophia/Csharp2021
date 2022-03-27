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
            var queue = new ActiveQueue();
            var schedule = new SchduleThreadMT12(queue);
            var thSchesule = new Thread(schedule.Run);
            var proxy = new ProxyMT12(server, schedule);

            thSchesule.Name = schedule.GetName();
            thSchesule.Start();

            return proxy;
        }
    }//class
}
