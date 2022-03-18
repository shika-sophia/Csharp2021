using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.TwoPhaseTermination
{
    class CountupThread
    {
        private long counter = 0L;
        private volatile bool shutdownReq = false;

        public void ShutdownRequest(Thread[] thAry)
        {
            shutdownReq = true;
            foreach(Thread th in thAry)
            {
                th.Interrupt();
            }
        }//ShutdownRequest()

        public bool IsShutdownReqested()
        {
            return shutdownReq;
        }//IsShutdownReqested()

        public void Run()
        {
            try
            {
                while (!IsShutdownReqested())
                {
                    DoWork();
                }//while
            }
            catch(ThreadInterruptedException)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is interrupted.");
            }
            finally
            {
                DoShutdown();
            }
        }//Run();

        private void DoWork()
        {
            counter++;
            Console.WriteLine($"DoWork(): counter = {counter}");
            Thread.Sleep(500);
        }

        private void DoShutdown()
        {
            string countStr = $"DoShutdown(): counter = {counter}";
            Console.WriteLine(countStr);
            DoShutdownWrite(countStr);
        }

        private void DoShutdownWrite(string countStr)
        {            
            string dir = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\MultiThread\MTCS10_TwoPhaseTermination\TwoPhaseTermination\";
            string fileName = "counter.txt";
            string path = $@"{dir}{fileName}";

            try
            {
                using(var fs = new FileStream(path, FileMode.Create))
                using(var writer = new StreamWriter(fs))
                {
                    writer.WriteLine(countStr);

                    writer.Close();
                    fs.Close();
                }//using
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine($"WroteFile to [{fileName}]");
        }//DoShutdown()
    }//class
}
