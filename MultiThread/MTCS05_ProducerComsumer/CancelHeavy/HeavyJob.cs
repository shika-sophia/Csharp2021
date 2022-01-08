using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.CancelHeavy
{
    class HeavyJob
    {
        public void ExecuteHeavy(object countObj)
        {
            int count;
            if(countObj is Int32)
            {
                count = (int) countObj;
            }
            else
            {
                bool canParse = Int32.TryParse(
                    countObj.ToString(), out int countOut);
                if (canParse)
                {
                    count = countOut;
                }
                else
                {
                    throw new ArgumentException(
                        "<!> Argument cannot parse to Number.");
                }
            }

            for (int i = 0; i < count; i++)
            {
                DoHeavy();
            }
        }//ExecuteHeavy()

        private void DoHeavy()
        {
            const long TIMEOUT = 10_000L;
            Console.WriteLine($"{nameof(DoHeavy)}(): BEGIN");
            var sw = new Stopwatch();
            sw.Start();

            while(TIMEOUT - sw.ElapsedMilliseconds > 0)
            { 
               //heavy job
            }//while loop

            sw.Stop();
            Console.WriteLine($"{nameof(DoHeavy)}(): END");
        }//DoHeavy()
    }//class
}
