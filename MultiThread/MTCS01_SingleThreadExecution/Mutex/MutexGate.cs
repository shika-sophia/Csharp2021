using CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.UnsafeGate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.Mutex
{
    class MutexGate : AbsGateMT01
    {
        private string name = "Nobody";
        private string address = "Nowhere";
        private AbsMutex mutex;

        public MutexGate(AbsMutex mutex)
        {
            this.mutex = mutex;
        }

        public override sealed void PassGate(string name, string address)
        {
            mutex.Lock();
            try 
            {
                this.Count++;
                this.name = name;
                this.address = address;
                CheckGate();
            }
            finally
            {
                mutex.Unlock();
            }
        }//PassGate() as locked

        internal override void CheckGate()
        {
            if (!name.StartsWith(address.Substring(0, 1)))
            {
                Console.WriteLine($"**** BROKEN **** {this.ToString()}");
            }
        }//CheckGate() as locked

        public override string ToString()
        {
            mutex.Lock();
            try
            {
                return $"[{Count}] {name}, {address}";
            }
            finally
            {
                mutex.Unlock();
            }
        }//ToString() as locked
    }//class
}
