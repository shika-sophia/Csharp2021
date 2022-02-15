using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.Semaphore
{
    class UseResourceThreadMT01
    {
        private readonly Random random = new Random(262536);
        private readonly LimitedResourceMT01 resource;
        
        public UseResourceThreadMT01(LimitedResourceMT01 resource)
        {
            this.resource = resource;
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    resource.UseResource();
                    Thread.Sleep(random.Next(3000));
                }
            }
            catch (ThreadInterruptedException) { }
        }//Run()
    }//class
}
