using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv
{
    class FutureResult<T> : AbsResultMT12<T>
    {
        private AbsResultMT12<T> result;
        private bool ready = false;

        public void SetResult(AbsResultMT12<T> result)
        {
            lock (this)
            {
                this.result = result;
                this.ready = true;
            }
            Thread.Yield();
        }//SetResult()

        public override T GetResultValue()
        {
            reCondition:
            while (!ready)
            {
                try
                {
                    Thread.SpinWait(Timeout.Infinite);
                }
                catch (ThreadInterruptedException) { }
            }//while

            if(!ready) { goto reCondition; }
            lock (this)
            {
                return result.GetResultValue();
            }//lock
        }//GetResultValue()
    }//class
}
