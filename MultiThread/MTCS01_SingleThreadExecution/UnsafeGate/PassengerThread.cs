using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.UnsafeGate
{
    class PassengerThread
    {
        private readonly AbsMT01Gate gate;
        private readonly string passName;
        private readonly string passAddress;

        public PassengerThread(AbsMT01Gate gate, string name, string address)
        {
            this.gate = gate;
            this.passName = name;
            this.passAddress = address;
        }

        public void Run()
        {
            Console.WriteLine($"{passName} BEGIN");

            while (true)
            {
                gate.PassGate(passName, passAddress);
            }//while loop
        }
    }//class
}
