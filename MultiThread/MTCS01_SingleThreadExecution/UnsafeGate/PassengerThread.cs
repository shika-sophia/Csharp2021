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
        private readonly AbsGateMT01 gate;
        private readonly string passName;
        private readonly string passAddress;
        internal const int TEST_TIMES = 10_000;

        public PassengerThread(AbsGateMT01 gate, string name, string address)
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
                
                if (gate.Count >= TEST_TIMES)
                {
                    break;
                }
            }//while loop

            Console.WriteLine($"{passName} END");
        }//Run()
    }//class
}
