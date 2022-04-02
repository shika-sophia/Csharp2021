/*
 *@based ../ActiveObjectSample/ActiveDiv/MakeStringRequest
 *@see MainAppendMethod
 */

using CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.AppendMethod
{
    class AddStringRequest : AbsMethodRequest<string>
    {
        private string x;
        private string y;

        public AddStringRequest(
            ServerMT12 server, FutureResult<string> future, string x, string y)
            : base(server, future)
        {
            this.x = x;
            this.y = y;
        }

        public override void Execute()
        {
            AbsResultMT12<string> result = server.AddString(x, y);
            future.SetResult(result);
        }//Execute()
    }//class
}
