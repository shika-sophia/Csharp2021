using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.Semaphore
{
    class LimitedResourceMT01
    {
        private readonly SemaphoreSlim semaphore;
        private readonly int resourceNum;
        private readonly Random random = new Random(314159);

        public LimitedResourceMT01(int resourceNum)
        {
            this.semaphore = new SemaphoreSlim(resourceNum);
            this.resourceNum = resourceNum;
        }

        public void UseResource()
        {
            semaphore.Wait();
            try
            {
                DoUse();
            }
            catch (ThreadInterruptedException e) 
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                semaphore.Release();
            }
        }//UseResource()

        private void DoUse()
        {
            Console.WriteLine(
                $"BEGIN used: {semaphore.CurrentCount} / {resourceNum}");
            Thread.Sleep(random.Next(500));
            Console.WriteLine(
                $"END used:  {semaphore.CurrentCount} / {resourceNum}");
        }//DoUse()
    }//class
}
