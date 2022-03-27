using CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample
{
    class DisplayThreadMT12
    {
        private readonly AbsActiveObjectMT12 activeObj;
        private readonly string thName;

        public DisplayThreadMT12(
            string thName, AbsActiveObjectMT12 activeObj)
        {
            this.activeObj = activeObj;
            this.thName = thName;
        }

        public void Run()
        {
            try
            {
                for(int i = 0; true; i++)
                {
                    string content = $"{thName}: {i}";
                    activeObj.DisplayString(content);
                    Thread.Sleep(200);
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
