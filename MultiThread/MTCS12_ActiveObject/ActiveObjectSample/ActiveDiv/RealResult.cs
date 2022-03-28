using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv
{
    class RealResult<T> : AbsResultMT12<T>
    {
        private readonly T resultValue;

        public RealResult(T resultValue)
        {
            this.resultValue = resultValue;
        }

        public override T GetResultValue()
        {
            return resultValue;
        }
    }//class
}
