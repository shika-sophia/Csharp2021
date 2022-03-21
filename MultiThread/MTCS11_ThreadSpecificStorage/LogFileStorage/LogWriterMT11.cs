using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage.LogFileStorage
{
    class LogWriterMT11
    {
        public void WriteLog(string content)
        {
            string dir = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\MultiThread\MTCS11_ThreadSpecificStorage\LogFileStorage\LogFile\";
            string fileName = "logStorage.txt";
            string path = $"{dir}{fileName}";
            
            try
            {
                using(var fs = new FileStream(path, FileMode.Append))
                using (var writer = new StreamWriter(fs))
                {
                    writer.WriteLine(content);

                    writer.Close();
                    fs.Close();
                }//using
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }//WriteLog()

        public void WriteFinish()
        {
            WriteLog("==== End of Log ====");
        }
    }//class
}//class
