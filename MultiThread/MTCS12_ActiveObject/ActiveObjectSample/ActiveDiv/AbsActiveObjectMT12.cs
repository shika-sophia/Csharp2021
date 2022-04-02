using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS12_ActiveObject.ActiveObjectSample.ActiveDiv
{
    public abstract class AbsActiveObjectMT12
    {
        public abstract AbsResultMT12<string> MakeString(int count, char headChar);
        public abstract void DisplayString(string content);
        public abstract AbsResultMT12<string> AddString(string x, string y);
    }//class
}
