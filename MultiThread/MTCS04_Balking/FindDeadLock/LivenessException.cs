using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS04_Balking.FindDeadLock
{
    class LivenessException : AggregateException
    {
        public LivenessException(string msg) : base(msg) { }
        
    }//class
}
