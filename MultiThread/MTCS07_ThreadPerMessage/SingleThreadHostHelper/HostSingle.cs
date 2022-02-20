using CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.HostHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.SingleThreadHostHelper
{
    class HostSingle
    {
        private HelperMT07 helper = new HelperMT07();

        public void RequestMT07(int count, char c)
        {
            Console.WriteLine($"Request [{count}, {c}]: BEGIN");
            helper.Handle(count, c);
            Console.WriteLine($"Request [{count}, {c}]: END");
        }
    }//class
}
