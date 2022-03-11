using CsharpBegin.MultiThread.MTCS09_Future.FutureSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS09_Future.FutureException
{
    class FutureDataException : AbsDataMT09
    {
        private RealDataMT09 realData = null;
        private bool readyData = false;
        private Exception excep = null;

        public override string GetResult()
        {
        reCondition:
            while (!readyData)
            {
                try
                {
                    Thread.SpinWait(Timeout.Infinite);
                }
                catch (ThreadInterruptedException) { }
            }//while

            lock (this)
            {
                if (!readyData) { goto reCondition; }

                if (excep != null)
                {
                    Console.WriteLine(excep.GetType());
                }

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

        internal void SetException(Exception e)
        {
            lock (this)
            {
                if (readyData)
                {
                    return;
                }

                this.excep = e;
                readyData = true;
                Thread.Yield();
            }//lock

        }//SetException()
    }//class
}
