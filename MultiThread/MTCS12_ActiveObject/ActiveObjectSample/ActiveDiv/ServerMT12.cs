using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv
{
    class ServerMT12 : AbsActiveObjectMT12
    {
        public override AbsResultMT12<string> MakeString(int count, char headChar)
        {
            char[] buffer = new char[count];

            for(int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = headChar;

                try
                {
                    Thread.Sleep(100);
                }
                catch (ThreadInterruptedException) { }
            }//for

            return new RealResult<string>(String.Join("", buffer));
        }//MakeString()

        public override void DisplayString(string content)
        {
            Console.WriteLine($"DisplayString(): {content}");
            
            try
            {
                Thread.Sleep(10);
            }
            catch (ThreadInterruptedException) { }
        }//DisplayString()
    }//class
}
