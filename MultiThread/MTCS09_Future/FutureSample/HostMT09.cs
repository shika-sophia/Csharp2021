using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS09_Future.FutureSample
{
    class HostMT09
    {
        public AbsDataMT09 RequestData(int count, char c)
        {
            Console.WriteLine($"  RequestData({count}, {c}) BEGIN");
            FutureDataMT09 future = new FutureDataMT09();

            new Thread(() => 
                {
                    RealDataMT09 realData= new RealDataMT09(count, c);
                    future.SetRealData(realData);
                }
            ).Start();
            Console.WriteLine($"  RequestData({count}, {c}) END");

            return future;
        }//RequestData()
    }//class
}
