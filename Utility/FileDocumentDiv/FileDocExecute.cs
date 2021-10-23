/**  
 *@title CsharpBegin / Utility / FileDocumentDiv / FileDocExecute.cs  
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@content ファイルを読み込み、
 *         document 先頭のコメント説明,
 *         appendix 追加のコメント,
 *         contentAll 元のファイル内容,
 *         contentPlus　追加の内容 を書き込み
 *         
 *@class FileDocExecute
 *       / ◇FileDocument doc
 *         string Path /
 *       FileDocExecute()
 *       FileDocExecute(string path)
 *       FileDocExecute(string path, string contentDoc)
 *       - string JudgePath(string)
 *       + string SeekFile()
 *       + void ReadWriteExe(string, string, string)
 *       + string ReadContent()
 *       + string ReadContent(string path)
 *       - void WriteContent(string, string, string, string)
 *           ◇
 *           ↓
 *@class FileDocument
 *       /◇ReferenceUtil reference,
 *         DateTime now,
 *         string Path,
 *         string contentDoc,
 *         string document /
 *       FileDocument(string path, string contentDoc)
 *       - string BuildDocument(string contentDoc)
 *           ◇
 *           ↓         
 *@class ReferenceUtil
 *       / - Dictionary<string,string> fileDic /
 *       + List<string> SeekBook(string dir)      
 *       
 *@author shika  
 *@date 2021-10-22  
*/

using System;           
using System.Collections.Generic;           
using System.Diagnostics;           
using System.IO;           
using System.Linq;           
using System.Text;           
using System.Threading.Tasks;           
           
namespace CsharpBegin.Utility.FileDocumentDiv           
{           
    class FileDocExecute           
    {           
        private readonly FileDocument doc;                               
        public string Path { get; private set; }
        private string documentRead;
        private string contentRead;
        private string contentAll;
           
        public FileDocExecute() : this("", "") { }           
           
        public FileDocExecute(string path) : this(path, "") { }           
           
        public FileDocExecute(string path, string contentDoc)           
        {           
            this.Path = JudgePath(path);           
            this.doc = new FileDocument(this.Path, contentDoc);                     
        }           
           
        private string JudgePath(string path)           
        {           
            if (String.IsNullOrEmpty(path)){ return SeekFile(); }           
            if (path.Contains("C:")) { return path; }           
                       
            return SeekFile();           
        }//JudgePath()           
           
        //====== StackTrace -> fileName ======           
        public string SeekFile()           
        {           
            StackTrace trace = new StackTrace(true);           
            StackFrame frame = trace.GetFrame(trace.FrameCount - 1); //static Main()          
            return frame.GetFileName();           
        }//SeekFile()           
           
        public void ReadWriteExe(
            string document = "", string appendix = "", string contentPlus = "")           
        {           
            ReadContent(Path);
            if (String.IsNullOrEmpty(documentRead))
            {
                Console.WriteLine("<○> this Document just has inserted.");
                document = doc.document;
            } else
            {
                Console.WriteLine("<!> this Document already existed.");
                document = documentRead;
            }//if document

            WriteContent(document, appendix, contentRead, contentPlus);           
        }//ReadWriteExe()           
           
        //====== ReadFile ======           
        public string ReadContent()           
        {           
            return ReadContent(Path);           
        }           
        public string ReadContent(string path)           
        {           
            if (String.IsNullOrEmpty(path)) { path = this.Path; }           
            
            using (var fs = new FileStream(path, FileMode.Open))           
            using (var reader = new StreamReader(fs))           
            {                           
                var bld = new StringBuilder(2000);
                bool isContent = false;
                while (!reader.EndOfStream)           
                {           
                    string line = reader.ReadLine();
                    
                    if (line.TrimStart().StartsWith("using") && !isContent)
                    {
                        this.documentRead = bld.ToString();
                        bld.Clear();
                        isContent = true;
                    }

                    bld.Append($"{line} \n");
                }//while
                        
                this.contentRead = bld.ToString();
                reader.Close();           
                fs.Close();           
            }//using           

            this.contentAll = documentRead + contentRead;
            return contentAll;
        }//ReadContent()           

        //====== WriteFile ======
        // private厳守: 必ずReadContent()してから、WriteContent()
        private void WriteContent(
            string document, string appendix, string contentRead, string contentPlus)           
        {           
            using (var writer = new StreamWriter(Path, append: false))           
            {
                if (String.IsNullOrEmpty(contentAll))
                {
                    ReadContent();
                }

                writer.Write(document);
                writer.Write(appendix);
                writer.Write(contentRead);
                writer.Write(contentPlus);
                writer.Close();
            }//using 
        }//WriteContent()
           
        //static void Main(string[] args)           
        public void Main(string[] args)           
        {         
            new FileDocExecute().ReadWriteExe();         
        }//Main()        
    }//class        
}

/*
System.IO.IOException:  別のプロセスで使用されているため、
プロセスはファイル 'C:\Users\sophia\source\repos\CsharpBegin
\CsharpBegin\Utility\FileDocumentDiv\MainInsertTemplate.cs' 
にアクセスできません。

【考察】
VSで開いている状態なので、アクセス不可なのか。
以前、Data\iroha.txtでは Reader/Writerができたので、
これはないはず。

using(writer)の部分で上記のエラー
=> reader部と writer部の usingを分割することで解決。

【考察】
もとのファイル内容が消えてしまっているので、
reader.ReadToEnd()が nullの様子。

ReadToEnd()の前に、
while(!reader.EndOfStream) { reader.ReadLine() }を
行っているので、ポインタが最後尾になっていることが原因か。
=> StringBuilderで　while節の lineを集め、
contentAllを生成し、ReadToEnd()を廃止すると解決。

【考察】str.Contains("/**") -> 常に true
「/**」は空文字「""」と解釈されるようで、常に trueとなる。
 => str.TrimStart().StartsWith("/**")で解決。

 */
