using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv
{
    class DisplayStringRequest : AbsMethodRequest<object>
    {
        private readonly string content;

        public DisplayStringRequest(ServerMT12 server, string content)
            : base(server, null)
        {
            this.content = content;
        }

        public override void Execute()
        {
            server.DisplayString(content);
        }//Execute()
    }//class
}
