using CsharpBegin.MultiThread.MTCS09_Future.FutureSample;

namespace CsharpBegin.MultiThread.MTCS09_Future.FutureTask
{
    class FutureDataTask : AbsDataMT09
    {
        private RealDataMT09 realData = null;

        public override string GetResult()
        {
            return realData.GetResult();
        }//GetResult()

        public void SetRealData(RealDataMT09 realData)
        {
            this.realData = realData;
        }//SetRealData()
    }//class
}
