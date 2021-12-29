using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS04_Balking.FileSaveBalking
{
    class ChangeThreadMT04
    {
        private readonly string thName;
        private readonly DataMT04 data;
        private readonly Random random = new Random();

        public ChangeThreadMT04(string thName, DataMT04 data)
        {
            this.thName = thName;
            this.data = data;
        }

        public void Run()
        {
            Thread.CurrentThread.Name = thName; 
            try
            {
                for (int i = 0; true; i++)
                {
                    data.Change($"No.{i}");
                    Thread.Sleep(random.Next(1000));
                    data.CheckSave();
                }//for
            }
            catch (IOException e)
            {
                Console.WriteLine($"{e.GetType()}");
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine($"{e.GetType()}");
            }
        }//Run()
    }//class
}
