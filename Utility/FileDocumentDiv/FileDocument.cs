/**
 *@title CsharpBegin / Utility / FileDocumentDiv / FileDocument.cs
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 *@content ファイル先頭の documentation commentを作成するクラス
 *
 *@author shika       
 *@date 2021-10-07
 */
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
        internal string absDir; //絶対パス
        internal string relDir; //projectからの相対パス
        internal string content;
        internal string document;

        public FileDocument() : this("") { }

        public FileDocument(string content)
        {
            this.absDir = SeekDir();
            this.relDir = AbsoluteToRelative(absDir);
            this.content = content;
            this.document = BuildDocument();
        }

        public FileDocument(string content, string path)
        {
            if (path.Contains("C:"))
            {
                this.absDir = path;
                this.relDir = AbsoluteToRelative(absDir);
            }
            else
            {
                this.absDir = SeekDir();
                this.relDir = path;
            }
            this.content = content;
            this.document = BuildDocument();
        }

        private string AbsoluteToRelative(string absDir)
        {
            return absDir.Substring(
                absDir.LastIndexOf(@"CsharpBegin\"));
        }

        public string SeekDir()
        {
            StackTrace trace = new StackTrace(true);
            string fileName = null;
            for(int i = 0; i < trace.FrameCount; i++)
            {
                StackFrame frame = trace.GetFrame(i);
                fileName = frame.GetFileName();

                if(String.IsNullOrEmpty(fileName)){ break; }
            }//for

            this.absDir = fileName;
            return fileName;
        }//SeekDir()

        private string BuildDocument()
        {
            if(document == null)
            {
                List<string> bookList = reference.SeekBook(relDir);
                string dirDoc = relDir.Replace(@"\", " / ");

                var bld = new StringBuilder(300);
                bld.Append(@"/**").Append("\n");
                bld.Append($" *@title {dirDoc} \n");
                foreach(string book in bookList)
                {
                    bld.Append($" *@reference {book} \n");
                }
                bld.Append($" *@content {content} \n");
                bld.Append( " * \n");
                bld.Append( " *@author shika \n");
                bld.Append($" *@date {now.ToString("yyyy-MM-dd")} \n");
                bld.Append(@" */").Append("\n");

                //Console.WriteLine($"bld.Length: {bld.Length}");
                this.document = bld.ToString();
            }

            return document;
        }//BuildDocument();

        ////====== Test Main() ======
        //static void Main(string[] args)
        ////public void Main(string[] args)
        //{ 
        //    var here = new FileDocument("第７章 オブジェクト指向基本");

        //    //---- Test constructor ----
        //    Console.WriteLine($"absDir: {here.absDir}");
        //    Console.WriteLine($"relDir: {here.relDir}");
        //    Console.WriteLine($"content: {here.content}");
        //    Console.WriteLine(here.document);
        //}//Main()

    }//class
}

/*
//---- Test BuildDocument() ----
/＊＊
 *@title CsharpBegin / Utility / FileDocumentDiv / FileDocument.cs
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 *@content 第７章 オブジェクト指向基本
 *
 *@author shika
 *@date 2021-10-07
＊/
bld.Length: 202

absDir: C:\Users\sophia\source\repos\CsharpBegin
\CsharpBegin\Utility\FileDocumentDiv\FileDocument.cs
relDir: CsharpBegin\Utility\FileDocumentDiv\FileDocument.cs
content: 第７章 オブジェクト指向基本
*/
