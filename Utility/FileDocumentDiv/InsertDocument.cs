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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Utility.FileDocumentDiv
{
    class InsertDocument
    {
        static void Main(string[] args)
        //public void Main(string[] args)
        {
            var fileDoc = new FileDocument();
            string document = fileDoc.document;
            Console.WriteLine(document);
        }//Main()

    }//class
}
