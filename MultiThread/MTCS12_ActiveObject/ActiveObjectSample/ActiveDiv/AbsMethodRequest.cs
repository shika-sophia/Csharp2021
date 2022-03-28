using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv
{
    abstract class AbsMethodRequest<T>
    {
        protected readonly ServerMT12 server;
        protected readonly FutureResult<T> future;

        public AbsMethodRequest(Server server, FutureResult<T> future)
        {
            this.server = server;
            this.future = future;
        }

        public abstract void Execute();

    }//class
}
