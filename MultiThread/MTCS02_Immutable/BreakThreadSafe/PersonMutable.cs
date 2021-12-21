using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS02_Immutable.BreakThreadSafe
{
    sealed class PersonMutable
    {
        private string name;
        private string address;

        public PersonMutable(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public PersonMutable(PersonImmutableRV person) 
            : this(person.GetName(), person.GetAddress()) { }

        public void SetPerson(string name, string address)
        {
            lock (this)
            {
                this.name = name;
                this.address = address;
            }
        }

        public PersonImmutableRV GetImmutableRV()
        {
            lock (this)
            {
                return new PersonImmutableRV(this);
            }
        }

        internal string GetName() //Called ONLY by PersonImmutableRV 
        {
            return name;
        }

        internal string GetAddress() //Called ONLY by PersonImmutableRV 
        {
            return address;
        }

        public override string ToString()
        {
            lock (this)
            {
                return $"{nameof(PersonMutable)}: Name {name} / Address {address}";
            }
        }
    }//class
}
