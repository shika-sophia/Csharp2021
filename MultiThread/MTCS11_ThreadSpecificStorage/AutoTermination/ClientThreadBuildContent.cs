using CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage.ThreadLocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage.AutoTermination
{
    class ClientThreadBuildContent
    {
        private readonly string thName;

        public ClientThreadBuildContent(string thName)
        {
            this.thName = thName;
        }
        public void Run()
        {
            Console.WriteLine($"{GetName()} BEGIN");
            const int LIMIT = 10;
            var bld = new StringBuilder(LIMIT * 20);
            bld.Append($"==== LogFile {GetName()} ====\n");

            for (int i = 0; i < LIMIT; i++)
            {
                bld.Append($"Log i = {i}\n");
                try
                {
                    Thread.Sleep(100);
                }
                catch (ThreadInterruptedException) { }
            }//for
            bld.Append("==== End of Log ====\n");
            //Console.WriteLine($"bld.Length = {bld.Length}");
            //bld.Length = 151 * 3 rows

            LogLocalStorage.WriteLog(bld.ToString());            
            Console.WriteLine($"{GetName()} END");
        }//Run()

        public string GetName()
        {
            return thName;
        }

    }//class
}
