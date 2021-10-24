/**
 *@title CsharpBegin / Utility / FileDocumentDiv / FileDocument.cs
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 *@content ファイル先頭の documentation commentを作成するクラス
 *
 *@class FileDocument
 *       /◇ReferenceUtil reference,
 *         DateTime now,
 *         string Path,
 *         string contentDoc,
 *         string document /
 *       FileDocument(string path, string contentDoc)
 *       - string BuildDocument(string contentDoc)
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
        public string Path { get; }
        internal string contentDoc;
        internal string document;

        public FileDocument(string path, string contentDoc)
        {
            this.Path = path;
            this.contentDoc = contentDoc;
        }
        
        public string BuildDocument(string contentDoc)
        {
            List<string> bookList = reference.SeekBook(Path);
            string dirDoc = 
                Path.Substring(Path.LastIndexOf(@"CsharpBegin\"))
                .Replace(@"\", " / ");

            var bld = new StringBuilder(300);
            bld.Append("/** \n");
            bld.Append($" *@title {dirDoc} \n");

            foreach(string book in bookList)
            {
                bld.Append($" *@reference {book} \n");
            }
            bld.Append($" *@content {contentDoc}\n");
            bld.Append( " * \n");
            bld.Append( " *@author shika \n");
            bld.Append($" *@date {now:yyyy-MM-dd} \n");
            bld.Append("*/ \n");

            return this.document = bld.ToString();
        }//BuildDocument();

        //====== Test Main() ======
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            var fileExe = new FileDocExecute();
            var here = new FileDocument(fileExe.Path ,"第７章 オブジェクト指向基本");

            //---- Test constructor ----
            Console.WriteLine($"Path: {here.Path}");
            Console.WriteLine($"contentDoc: {here.contentDoc}");
            Console.WriteLine(here.document);
        }//Main()

    }//class
}

/*
//---- Test BuildDocument() ----
Path: C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Utility\FileDocumentDiv\FileDocExecute.cs
contentDoc: 第７章 オブジェクト指向基本

/＊＊
 *@title CsharpBegin / Utility / FileDocumentDiv / FileDocExecute.cs
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 *@content 第７章 オブジェクト指向基本
 *
 *@author shika
 *@date 2021-10-22
 
＊/
bld.Length: 202

absDir: C:\Users\sophia\source\repos\CsharpBegin
\CsharpBegin\Utility\FileDocumentDiv\FileDocument.cs
relDir: CsharpBegin\Utility\FileDocumentDiv\FileDocument.cs
content: 第７章 オブジェクト指向基本
*/
