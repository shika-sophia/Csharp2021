using CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.AppendMethod
{
    class AddThreadMT12
    {
        private readonly AbsActiveObjectMT12 activeObject;
        private readonly string thName;
        private string x = "1";
        private string y = "1";

        public AddThreadMT12(
            string thName, AbsActiveObjectMT12 activeObject)
        {
            this.activeObject = activeObject;
            this.thName = thName;
        }

        public void Run()
        {
            try
            {
                for(int i = 0; true; i++)
                {
                    AbsResultMT12<string> result = activeObject.AddString(x, y);

                    Thread.Sleep(100);

                    string value = result.GetResultValue();
                    Console.WriteLine($"{thName}: {x} + {y} = {value}");
                    x = y;
                    y = value;
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
