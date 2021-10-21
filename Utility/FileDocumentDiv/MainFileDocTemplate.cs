/* ---- Template ----
    static void Main(string[] args)
    {
        new Utility.FileDocumentDiv.InsertDocument("").InsertExe();        
    }//Main()
/*
/**
 *@title CsharpBegin / Utility / FileDocumentDiv / MainFileDocTemplate.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content documentを自動生成する Main()
 *         ここの documentも自動生成されたものに加筆。
 *         継承ではなく、委譲(=集約)によってクラス間を連結。
 *         各フィールドに必要なクラスのインスタンスを保持。
 *
 *@class MainFileDocTemplate / ◆Main() [EntryPoint]
 *@class InsertDocument
 *       / ◇FileDocument doc,
 *         - string contentAll /
 *       + InsertDocument() { new FileDocument() }
 *       + InsertDocument(string content) { new FileDocument(string) }
 *       + InsertDocument(string content, string path) { new FileDocument(string, string) }
 *       + InsertExe()
 *         { using(FileSteam), using(StreamReader)
 *           using(StreamWriter)
 *         }
 *           ◇
 *           ↓
 *@class FileDocument
 *       / ◇ReferenceUtil referance,
 *         - string absDir, //絶対パス
 *         - string relDir, //projectからの相対パス
 *         - string content,
 *         + string document /
 *       + FileDocument() 
 *       + FileDocument(string content) 
 *       + FileDocument(string content, string path) 
 *       - string SeekDir() 
 *           //static Main()を実行した fileName(絶対パス)を抽出。
 *       - string BuildDocument()
 *           //documentを作成     
 *           ◇
 *           ↓         
 *@class ReferenceUtil
 *       / - Dictionary<string,string> fileDic /
 *       + List<string> SeekBook(string dir)
 *       
 *@author shika 
 *@date 2021-10-09 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Utility.FileDocumentDiv
{
    class MainFileDocTemplate
    {
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            new Utility.FileDocumentDiv.InsertDocument("").InsertExe();            
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
 */
