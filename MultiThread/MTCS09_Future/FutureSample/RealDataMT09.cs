using System;
using System.Threading;

namespace CsharpBegin.MultiThread.MTCS09_Future.FutureSample
{
    class RealDataMT09 : AbsDataMT09
    {
        private readonly string result;
        
        public RealDataMT09(int count, char c)
        {
            Console.WriteLine(
                $"    making RealData({count}, {c}) BEGIN");

            char[] buffer = new char[count];
            for(int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = c;

                try
                {
                    Thread.Sleep(100);
                }
                catch (ThreadInterruptedException) { }
            }

            Console.WriteLine(
                $"    making RealData({count}, {c}) END");
            this.result = String.Join("", buffer);
        }//constructor

        public override string GetResult()
        {
            return result;
        }
    }//class
}