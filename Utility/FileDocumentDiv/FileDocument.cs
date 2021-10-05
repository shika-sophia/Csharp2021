using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Utility.FileDocumentDiv
{
    class FileDocument
    {
        private ReferenceUtil reference = new ReferenceUtil();
        private DateTime now = DateTime.Now;
        private string dir;
        private string document;

        //public FileDocument()
        //{
        //    this.dir = SeekDir();
        //}

        public FileDocument(string dir)
        {
            this.dir = dir;
            this.document = BuildDocument();
        }

        //public string SeekDir()
        //{
        //    StackTrace trace = new StackTrace();
        //    StackFrame frame = trace.GetFrame(0);
            
        //    Console.WriteLine(frame.GetFileName());
        //    return frame.GetFileName();
        //}//SeekDir()

        private string BuildDocument()
        {
            if(document == null)
            {
                List<string> bookList = reference.SeekBook(dir);
                string dirDoc = dir.Replace(@"\", " / ");

                var bld = new StringBuilder(300);
                bld.Append(@"/**").Append("\n");
                bld.Append($" *@title {dirDoc} \n");
                foreach(string book in bookList)
                {
                    bld.Append($" *@reference {book} \n");
                }
                bld.Append( " *@content \n");
                bld.Append( " * \n");
                bld.Append( " *@author shika \n");
                bld.Append($" *@date {now.ToString("yyyy-MM-dd")} \n");
                bld.Append(@" */").Append("\n");

                Console.WriteLine($"bld.Length: {bld.Length}");
                document = bld.ToString();
            }

            return document;
        }//BuildDocument();

        ////====== Test Main() ======
        //static void Main(string[] args)
        ////public void Main(string[] args)
        //{
        //    string dir = @"CsharpBegin\Utility\Python\FileDocument.cs";
        //    var here = new FileDocument(dir);

        //    //---- Test BuildDocument() ----
        //    Console.WriteLine(here.document);
        //}//Main()

    }//class
}

/*
//---- Test BuildDocument() ----
/＊＊
 *@title CsharpBegin / Utility / Python / FileDocument.cs
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 *@reference 山田祥寛『独習 Python』 翔泳社, 2020 
 *@content
 *
 *@author shika
 *@date 2021-10-06
＊/
bld.Length: 202

*/
