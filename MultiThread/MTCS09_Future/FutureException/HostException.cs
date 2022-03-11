using CsharpBegin.MultiThread.MTCS09_Future.FutureSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS09_Future.FutureException
{
    class HostException
    {
        public AbsDataMT09 RequestData(int count, char c)
        {
            Console.WriteLine($"  RequestData({count}, {c}) BEGIN");
            var future = new FutureDataException();

            try
            {
                new Thread(() =>
                {
                    RealDataMT09 realData = new RealDataMT09(count, c);
                    future.SetRealData(realData);
                }
                ).Start();
            }
            catch (Exception e)
            {
                future.SetException(e);
            }

            Console.WriteLine($"  RequestData({count}, {c}) END");

            return future;
        }//RequestData()
    }//class
}
