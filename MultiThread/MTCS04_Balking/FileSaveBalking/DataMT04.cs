using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS04_Balking.FileSaveBalking
{
    class DataMT04
    {
        private readonly string fileName;
        private volatile bool changeFlag;
        private string content;

        public DataMT04(string fileName) : this(fileName, content: "") { }

        public DataMT04(string fileName, string content)
        {
            this.fileName = fileName;
            this.content = content;
            this.changeFlag = true;
        }

        public void Change(string newContent)
        {
            lock (this)
            {
                content = newContent;
                changeFlag = true;
            }//lock
        }//Change()

        public void CheckSave()
        {
            lock (this)
            {
                if (!changeFlag)
                {
                    //Console.WriteLine($"Balked {content}");
                    return;
                }

                DoSave();
                changeFlag = false;
            }//lock
        }//CheckSave()

        private void DoSave()
        {
            string dir = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\MultiThread\MTCS04_Balking\FileSaveBalking\";
            
            Console.WriteLine(
                $"{Thread.CurrentThread.Name}: DoSave() content = {content}");
            
            using(var writer = new StreamWriter(dir + fileName))
            {
                writer.WriteLine(content);
                writer.Close();
            }//using
        }//DoSave()
    }//class
}
