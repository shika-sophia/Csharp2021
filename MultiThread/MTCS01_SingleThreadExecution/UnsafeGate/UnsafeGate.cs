using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.UnsafeGate
{
    class UnsafeGate : AbsGateMT01
    {
        private string name = "Nobody";
        private string address = "Nowhere";

        public override void PassGate(string name, string address)
        {
            this.Count++;
            this.name = name;
            this.address = address;
            CheckGate();
        }

        internal override void CheckGate()
        {
            if (! name.StartsWith(address.Substring(0,1)))
            {
                Console.WriteLine($"**** BROKEN **** {this.ToString()}");
            }
        }//CheckGate()

        public override string ToString()
        {
            return $"[{Count}] {name}, {address}";
        }//ToString()
    }//class
}
