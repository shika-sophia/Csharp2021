using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS09_Future.FutureSample
{
    class FutureDataMT09 : AbsDataMT09
    {
        private RealDataMT09 realData = null;
        private bool readyData = false;

        public override string GetResult()
        {
            reCondition:
            while (!readyData)
            {
                try
                {
                    Thread.SpinWait(Timeout.Infinite);
                }
                catch(ThreadInterruptedException) { }
            }//while
            
            lock (this)
            {
                if(!readyData) { goto reCondition; }

                return realData.GetResult();
            }//lock
        }//GetResult()

        public void SetRealData(RealDataMT09 realData)
        {
            lock (this)
            {
                if (readyData)
                {
                    return; // ||Balking||
                }

                this.realData = realData;
                this.readyData = true;
                Thread.Yield();
            }//lock
        }//SetRealData()
    }//class
}
