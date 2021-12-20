using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS02_Immutable.Immutable
{
    sealed class PersonImmutable
    {
        private readonly string name;
        private readonly string address;

        public PersonImmutable(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public override string ToString()
        {
            return $"[{nameof(PersonImmutable)}: Name {name}, Address {address}]";
        }
    }//class
}
