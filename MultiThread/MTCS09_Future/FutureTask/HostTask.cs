using CsharpBegin.MultiThread.MTCS09_Future.FutureSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS09_Future.FutureTask
{
    class HostTask
    {
        public async Task<AbsDataMT09> RequestAsync(int count, char c)
        {
            Console.WriteLine($"  RequestAsync({count}, {c}) BEGIN");
            //var future = new FutureDataMT09();
            var future = new FutureDataTask();
            
            await Task.Run(() => 
                {
                    RealDataMT09 realData = new RealDataMT09(count, c);
                    future.SetRealData(realData);
                }
            );

            Console.WriteLine($"  RequestAsync({count}, {c}) END");
            return future;
        }//RequestAsync()
    }//class
}
