using CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample
{
    class MakerThreadMT12
    {
        private readonly AbsActiveObjectMT12 activeObj;
        private readonly string thName;
        private readonly char headChar;

        public MakerThreadMT12(
            string thName, AbsActiveObjectMT12 activeObj)
        {
            this.activeObj = activeObj;
            this.thName = thName;
            this.headChar = thName.ToCharArray()[0];
        }

        public void Run()
        {
            try
            {
                for(int i = 0; true; i++)
                {
                    AbsResultMT12<string> result = 
                        activeObj.MakeString(i, headChar);
                    Thread.Sleep(10);
                    string value = result.GetResultValue();
                    Console.WriteLine($"{thName}: value = {value}");
                }//for
            }
            catch (ThreadInterruptedException) { }
        }//Run()

        public string GetName()
        {
            return thName;
        }
    }//class
}
