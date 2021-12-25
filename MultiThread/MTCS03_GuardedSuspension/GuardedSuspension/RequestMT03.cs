using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS03_GuardedSuspension.GuardedSuspension
{
    class RequestMT03
    {
        private readonly string name;

        public RequestMT03(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public override string ToString()
        {
            return $"[ Request {name} ]";
        }
    }//class
}
