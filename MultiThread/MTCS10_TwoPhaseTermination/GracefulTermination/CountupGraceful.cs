using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination.GracefulTermination
{
    class CountupGraceful : GracefulThread
    {
        private long counter = 0L;

        protected override void DoWork()
        {
            counter++;
            Console.WriteLine($"DoWork(): counter = {counter}");
            Thread.Sleep(500);
        }

        protected override void DoShutdown()
        {
            string countStr = $"DoShutdown(): counter = {counter}";
            Console.WriteLine(countStr);
            //DoShutdownWrite(countStr);
        }

        //private void DoShutdownWrite(string countStr)
        //{            
        //    string dir = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\MultiThread\MTCS10_TwoPhaseTermination\TwoPhaseTermination\";
        //    string fileName = "counter.txt";
        //    string path = $@"{dir}{fileName}";

        //    try
        //    {
        //        using(var fs = new FileStream(path, FileMode.Create))
        //        using(var writer = new StreamWriter(fs))
        //        {
        //            writer.WriteLine(countStr);

        //            writer.Close();
        //            fs.Close();
        //        }//using
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    Console.WriteLine($"WroteFile to [{fileName}]");
        //}//DoShutdown()
    }//class
}
