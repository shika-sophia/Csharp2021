/**
 *@title CsharpBegin / Utility / FileDocumentDiv / FileDocument.cs
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 *@content ファイル先頭の documentation commentを作成するクラス
 *@class FileDocument
 *       / ◇ReferenceUtil referance,
 *         - string absDir, //絶対パス
 *         - string relDir, //projectからの相対パス
 *         - string content,
 *         + string document /
 *       + new FileDocument(string) 
 *       - string SeekDir() 
 *           //static Main()を実行した fileName(絶対パス)を抽出。
 *       - string BuildDocument()
 *           //documentを作成     
 *         
 *@class ReferenceUtil
 *       / - Dictionary<string,string> fileDic /
 *       + List<string> SeekBook(string dir)
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
        private string absDir; //絶対パス
        private string relDir; //projectからの相対パス
        private string content;
        public string document; 

        public FileDocument() : this("") { }

        public FileDocument(string content)
        {
            this.absDir = SeekDir();
            this.relDir = absDir.Substring(
                absDir.LastIndexOf(@"CsharpBegin\"));            
            this.content = content;            
            this.document = BuildDocument();
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

            absDir = fileName;
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
                document = bld.ToString();
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
