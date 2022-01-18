/**
 *@title CsharpBegin / Utility / ReferenceUtil.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 参考文献をディレクトリをkeyとして自動検索するクラス 
 * 
 *@author shika 
 *@date 2021-10-09 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Utility
{
    class ReferenceUtil
    {
        private Dictionary<string, string> ReferenceDic { get; } = 
            new Dictionary<string, string>()
            {
                ["CsharpBegin"] =
                "山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017",
                ["Java"] =
                "山田祥寛『独習 Java [新版] 』 翔泳社, 2019",
                ["Python"] = 
                "山田祥寛『独習 Python』 翔泳社, 2020",
                ["MultiThread"] =
                "結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006",
                ["SelfAspNet"] =
                "山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020",
                ["Cryptography"] = 
                "結城 浩 『暗号技術入門 第３版』SB Creative, 2015",
            };
        
        public List<string> SeekBook(string dir)
        {            
            List<string> bookList = new List<string>();
            foreach(string key in ReferenceDic.Keys)
            {
                if (dir.Contains(key))
                {
                    ReferenceDic.TryGetValue(key, out string book);
                    bookList.Add(book);
                    //bool doneSeek = ReferenceDic.TryGetValue(key, out string book);
                    //Console.WriteLine($"doneSeek: {doneSeek}");
                }
            }//foreach key

            if (bookList.Count == 0)
            {
                bookList.Add("( No Reference / 参考文献なし )");
            }

            return bookList;
        }//SeekBook()
        
        ////====== Test Main ======
        //static void Main(string[] args)
        //{
        //    var here = new ReferenceUtil();
        //    string dir = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Python\ReferenceUtil.cs";
        //    //string dir = "";
        //    Console.WriteLine($"Directory: {dir}");
        //    foreach (string book in here.SeekBook(dir))
        //    {
        //        Console.WriteLine($"Reference: {book}");
        //    }
        //}//Main()
    }//class
}

/*
//---- Test Main() ----
Directory: C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Utility\ReferenceUtil.cs
doneSeek: True
Reference: 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017

Directory: C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Python\ReferenceUtil.cs
Reference: 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
Reference: 山田祥寛『独習 Python』 翔泳社, 2020

Directory:
Reference: ( No Reference / 参考文献なし )
 */
