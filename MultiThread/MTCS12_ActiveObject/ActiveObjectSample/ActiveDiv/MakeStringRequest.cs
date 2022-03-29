using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv
{
    class MakeStringRequest : AbsMethodRequest<string>
    {
        private readonly int count;
        private readonly char headChar;

        public MakeStringRequest(
            ServerMT12 server, FutureResult<string> future, int count, char headChar)
            : base(server, future)
        {
            this.count = count;
            this.headChar = headChar;
        }

        public override void Execute()
        {
            AbsResultMT12<string> result = server.MakeString(count, headChar);
            future.SetResult(result);
        }//Execute()
    }//class
}
