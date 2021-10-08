/**
 *@title CsharpBegin / Utility / FileDocumentDiv / InsertDocument.cs
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 *@content documentを Main()実行ファイルに挿入するクラス
 *     そのファイルの既述のコードを事前に読み取り、
 *     すでに documentがあれば、処理なし。
 *     documentが未挿入なら、ファイル先頭に挿入し、
 *     既述のコードを Appendする。
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

            using (var fs = new FileStream(absDir, FileMode.Open))
            using (var reader = new StreamReader(fs))
            {
                var bld = new StringBuilder(10000);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Contains(@"/**"))
                    {
                        Console.WriteLine("<!> the document already has existed.");
                        bld.Clear();
                        return;
                    }

                    bld.Append(line).Append("\n");
                }//while                            

                contentAll = bld.ToString();
                reader.Close();
                fs.Close();
            }

            using (var writer = new StreamWriter(absDir, append: false))
            {                                
                string document = doc.document;
                writer.Write(document);
                writer.Write(contentAll);
                writer.Close();
            }//using

        }//InsertExe()

        ////====== Test Main() / by fix path ======
        //static void Main(string[] args)
        ////public void Main(string[] args)
        //{
        //    string path = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Data\iroha.txt";
        //    new InsertDocument("いろは歌", path).InsertExe();
        //}//Main()

    }//class
}

/*
//====== Test Main() / by fix path ======
//---- 1st ----
/＊＊
 *@title CsharpBegin / Data / iroha.txt 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content  
 * 
 *@author shika 
 *@date 2021-10-09 
 ＊/

いろはにほへと
ちりぬるを
わかよたれそ
つねならむ
うゐのおくやま
けふこえて
あさきゆめみし
ゑひもせす

//---- 2nd ----
<!> the document already has existed.

//---- with content ----
@content いろは歌 
 */