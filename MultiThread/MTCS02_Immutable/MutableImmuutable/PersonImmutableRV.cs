using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS02_Immutable.MutableImmuutable
{
    class PersonImmutableRV
    {
        private readonly string name;
        private readonly string address;

        public PersonImmutableRV(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public PersonImmutableRV(PersonMutable mutable)
        {
            lock (mutable)
            {
                this.name = mutable.GetName();
                this.address = mutable.GetAddress();
            }//lock
        }

        public PersonMutable GetMutable()
        {
            return new PersonMutable(this);
        }

        public string GetName()
        {
            return name;
        }

        public string GetAddress()
        {
            return address;
        }

        public override string ToString()
        {
            return $"{nameof(PersonImmutableRV)}: Name {name} / Address {address}";
        }
    }//class
}
