using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.HostHelper
{
    class HostMT07
    {
        private readonly HelperMT07 helper = new HelperMT07();

        public void RequestMT07(int count, char c)
        {
            Console.WriteLine($"Request [{count}, {c}] BEGIN");

            new Thread(
                new ThreadStart(
                    delegate() {
                        helper.Handle(count, c);
                    }
                )
            ).Start();

            Console.WriteLine($"Request [{count}, {c}] END");
        }//RequestMT07

        
    }//class
}
