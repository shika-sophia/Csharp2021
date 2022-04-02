using CsharpBegin.MultiThread.MTCS12_ActiveObject.AppendMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv
{
    class ProxyMT12 : AbsActiveObjectMT12
    {
        private readonly ServerMT12 server;
        private readonly ScheduleThreadMT12 schedule;

        public ProxyMT12(ServerMT12 server, ScheduleThreadMT12 schedule)
        {
            this.server = server;
            this.schedule = schedule;
        }

        public override AbsResultMT12<string> MakeString(int count, char headChar)
        {
            var future = new FutureResult<string>();
            schedule.Invoke(
                new MakeStringRequest(server, future, count, headChar));

            return future;
        }//MakeString()

        public override void DisplayString(string content)
        {
            schedule.Invoke(new DisplayStringRequest(server, content));
        }//DisplayString()

        public override AbsResultMT12<string> AddString(string x, string y)
        {
            var future = new FutureResult<string>();
            schedule.Invoke(
                new AddStringRequest(server, future, x, y));

            return future;
        }//MakeString()
    }//class
}
