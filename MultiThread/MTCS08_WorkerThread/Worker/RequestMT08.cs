using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS08_WorkerThread.Worker
{
    class RequestMT08
    {
        private readonly Random random = new Random();
        private readonly string name;
        private readonly int number;

        public RequestMT08(string name, int number)
        {
            this.name = name;
            this.number = number;
        }

        public void ReqExecute()
        {
            Console.WriteLine(
                $"{Thread.CurrentThread.Name} Execute() [{this.ToString()}]");

            try
            {
                //Thread.Sleep(random.Next(1000));
            }
            catch (ThreadInterruptedException) { }
        }//ReqExecute()

        public override string ToString()
        {
            return $"Request from {name} No.{number}";
        }
    }//class
}
