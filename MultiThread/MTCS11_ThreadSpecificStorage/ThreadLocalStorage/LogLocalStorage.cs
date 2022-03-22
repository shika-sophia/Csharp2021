using System.Threading;

namespace CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage.ThreadLocalStorage
{
    class LogLocalStorage : ThreadLocal<LogWriterSpecific>
    {
        private static readonly ThreadLocal<LogWriterSpecific> thLocal
            = new ThreadLocal<LogWriterSpecific>();

        private static LogWriterSpecific GetWriter()
        {
            var logWriter = thLocal.Value;

            if(logWriter == null)
            {
                string fileName = $"log_{Thread.CurrentThread.Name}.txt";
                logWriter = new LogWriterSpecific(fileName);
                thLocal.Value = logWriter;
            }

            return logWriter;
        }

        public static void WriteLog(string content)
        {
            GetWriter().WriteLog(content);
        }

        public static void WriteFinish()
        {
            GetWriter().WriteFinish();
        }
    }//class
}
