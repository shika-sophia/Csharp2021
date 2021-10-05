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
                ["Python"] = 
                "山田祥寛『独習 Python』 翔泳社, 2020"
            };
        
        public string SeekBook(string dir)
        {            
            string book = "";
            foreach(string key in ReferenceDic.Keys)
            {
                if (dir.Contains(key))
                {
                    bool doneSeek = ReferenceDic.TryGetValue(key, out book);
                    //Console.WriteLine($"doneSeek: {doneSeek}");
                }
            }//foreach key

            return book;
        }//SeekBook()

        ////====== Test Main ======
        //static void Main(string[] args)
        //{
        //    var here = new ReferenceUtil();
        //    string dir = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Utility\ReferenceUtil.cs";
        //    Console.WriteLine($"Directory: {dir}");
        //    Console.WriteLine($"Reference: {here.SeekBook(dir)}");
        //}//Main()
    }//class
}

/*
//---- Test Main() ----
Directory: C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\Utility\ReferenceUtil.cs
doneSeek: True
Reference: 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017

 */