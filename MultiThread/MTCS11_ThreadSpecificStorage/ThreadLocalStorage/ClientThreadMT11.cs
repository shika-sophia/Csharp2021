using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage.ThreadLocalStorage
{
    class ClientThreadMT11
    {
        private readonly string thName;

        public ClientThreadMT11(string thName)
        {
            this.thName = thName;
        }

        public void Run()
        {
            Console.WriteLine($"{GetName()} BEGIN");
            const int LIMIT = 10;

            for(int i = 0; i < LIMIT; i++)
            {
                LogLocalStorage.WriteLog($"Log = {i}");

                try
                {
                    Thread.Sleep(100);
                }
                catch (ThreadInterruptedException) { }
            }//for

            LogLocalStorage.WriteFinish();
            Console.WriteLine($"{GetName()} END");
        }//Run()

        public string GetName()
        {
            return thName;
        }
    }//class
}
