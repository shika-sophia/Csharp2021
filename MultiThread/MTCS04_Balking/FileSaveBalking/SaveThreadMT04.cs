using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS04_Balking.FileSaveBalking
{
    class SaveThreadMT04
    {
        private readonly string thName;
        private readonly DataMT04 data;

        public SaveThreadMT04(string thName, DataMT04 data)
        {
            this.thName = thName;
            this.data = data;
        }

        public void Run()
        {
            Thread.CurrentThread.Name = thName;

            try
            {
                while (true)
                {
                    data.CheckSave();
                    Thread.Sleep(1000);
                }//while
            }
            catch (IOException e) {
                Console.WriteLine($"{e.GetType()}");
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine($"{e.GetType()}");
            }
        }//Run()
    }//class
}
