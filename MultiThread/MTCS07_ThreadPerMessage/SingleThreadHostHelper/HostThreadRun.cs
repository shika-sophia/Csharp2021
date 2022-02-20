using CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.HostHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.SingleThreadHostHelper
{
    class HostThreadRun
    {
        private HelperMT07 helper = new HelperMT07();

        public void RequestMT07(int count, char c)
        {
            Console.WriteLine($"Request [{count}, {c}]: BEGIN");

            //本来 new Thread().Start()とするところを
            //誤って Run()を呼び出したケース
            var hostTh = new HostThreadMT07(helper, count, c);
            new Thread(hostTh.Run);
            hostTh.Run();
            Console.WriteLine($"Request [{count}, {c}]: END");
        }
    }//class

    class HostThreadMT07
    {
        private readonly HelperMT07 helper;
        private readonly int count;
        private readonly char c;

        public HostThreadMT07(HelperMT07 helper, int count, char c)
        {
            this.helper = helper;
            this.count = count;
            this.c = c;
        }

        public void Run()
        {
            helper.Handle(count, c);
        }//Run()
    }//class
}
