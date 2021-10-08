/**
 *@title CsharpBegin / Utility / FileDocumentDiv / InsertDocument.cs
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 *@content documentを Main()実行ファイルに挿入するクラス
 *     そのファイルの既述のコードを事前に読み取り、
 *     すでに documentがあれば、処理なし。
 *     documentが未挿入なら、ファイル先頭に挿入し、
 *     既述のコードを Appendする。
 *
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Utility.FileDocumentDiv
{
    class InsertDocument
    {
        private FileDocument doc;
        private bool existDoc = false;
        private string contentAll;

        public InsertDocument() : this("") { }

        public InsertDocument(string content)
        {
            doc = new FileDocument(content);
        }

        public InsertDocument(string content, string path)
        {
            doc = new FileDocument(content, path);
        }

        public void InsertExe()
        {
            string absDir = doc.absDir;
            string relDir = doc.relDir;

            //using (var fs = new FileStream(absDir, FileMode.Open))
            using (var reader = new StreamReader(absDir))
            using (var writer = new StreamWriter(absDir, append: false))
            {                
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Contains(@"/**"))
                    {
                        existDoc = true;
                        break;
                    }
                }//while                

                if (existDoc)
                {
                    return;
                }
                
                string document = doc.document;
                contentAll = reader.ReadToEnd();
                writer.WriteLine(document);
                writer.WriteLine(contentAll);
            }//using

        }//InsertExe()

        //static void Main(string[] args)
        ////public void Main(string[] args)
        //{
        //    string path = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Data\iroha.txt";
        //    new InsertDocument("", path).InsertExe();
        //}//Main()

    }//class
}
