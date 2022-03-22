using System;
using System.IO;

namespace CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage.ThreadLocalStorage
{
    class LogWriterSpecific
    {
        private readonly string fileName;

        public LogWriterSpecific(string fileName)
        {
            this.fileName = fileName;            
        }

        public void WriteLog(string content)
        {
            string dir = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\MultiThread\MTCS11_ThreadSpecificStorage\ThreadLocalStorage\LogFileSpecific\";
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
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }      
        }//WriteLog()

        public void WriteFinish()
        {
            WriteLog("==== End of Log ====");
        }
    }//class
}
