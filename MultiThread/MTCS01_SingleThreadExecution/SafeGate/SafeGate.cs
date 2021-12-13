using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.SafeGate
{
    class SafeGate : AbsMT01Gate
    {
        private string name = "Nobody";
        private string address = "Nowhere";

        public override void PassGate(string name, string address)
        {
            lock (this)
            {
                this.Count++;
                this.name = name;
                this.address = address;
                CheckGate();
            }
        }//PassGate() as locked

        internal override void CheckGate()
        {
            if (! name.StartsWith(address.Substring(0,1)))
            {
                Console.WriteLine($"**** BROKEN **** {this.ToString()}");
            }
        }//CheckGate() as locked

        public override string ToString()
        {
            return $"[{Count}] {name}, {address}";
        }//ToString() as locked
    }//class
}
