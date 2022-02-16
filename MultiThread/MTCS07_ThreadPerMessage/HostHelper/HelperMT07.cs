

using System;
using System.Threading;

namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.HostHelper
{
    class HelperMT07
    {
        public void Handle(int count, char c)
        {
            Console.WriteLine($"Handle [{count}, {c}] BEGIN");

            for(int i = 0; i < count; i++)
            {
                Slowly();
                Console.Write(c);
            }
            Console.WriteLine();
            Console.WriteLine($"Handle [{count}, {c}] END");
        }//Handle()

        private void Slowly()
        {
            try
            {
                Thread.Sleep(100);
            }
            catch (ThreadInterruptedException) { }
        }
    }//class
}