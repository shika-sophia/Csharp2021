﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.UnsafeGate
{
    class UnsafeGate : AbsMT01Gate
    {
        private int count = 0;
        private string name = "Nobody";
        private string address = "Nowhere";

        public override void PassGate(string name, string address)
        {
            this.count++;
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
            return $"[{count}] {name}, {address}";
        }//ToString()
    }//class
}
