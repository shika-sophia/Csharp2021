using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS02_Immutable.Immutable
{
    class ShowPersonThread
    {
        private readonly PersonImmutable person;

        public ShowPersonThread(PersonImmutable person)
        {
            this.person = person;
        }

        public void Run()
        {
            string thCurrentName = Thread.CurrentThread.Name;
            while (true)
            {
                Console.WriteLine($"{thCurrentName} {person}");
            }
        }
    }//class
}
