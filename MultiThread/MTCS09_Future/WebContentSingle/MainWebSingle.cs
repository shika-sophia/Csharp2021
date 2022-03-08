/** 
 *@title CsharpBegin / MultiThread / MTCS09_Future / WebContentSingle / MainWebSingle.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MainWebSingle
 *
 *         Directory.GetCurrentDirectory();
           => C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\bin\Debug
 *@NOTE [yahoo.html][hyuki.html]に
 *     「<!-- -->」が含まれており、コメントアウト不可。
 *     文字化けもしているので、実行後削除。
 *     
 *@author shika 
 *@date 2022-03-08 
*/
using System; 
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS09_Future.WebContentSingle 
{ 
    class MainWebSingle 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var here = new MainWebSingle();
            Console.WriteLine("Main() BEGIN");
            Thread.CurrentThread.Name = "MainThread";

            var sw = new Stopwatch();
            sw.Start();

            AbsContentMT09 content1 = WebReadMT09.ReadSiteSync("http://www.yahoo.com/");
            //AbsContentMT09 content2 = WebReadMT09.ReadSiteSync("http://www.google.com/");
            //AbsContentMT09 content3 = WebReadMT09.ReadSiteSync("http://www.hyuki.com/");

            here.SaveToFile("yahoo.html", content1);
            //here.SaveToFile("google.html", content2);
            //here.SaveToFile("hyuki.html", content3);

            sw.Stop();
            Console.WriteLine($"Cost Time: {sw.ElapsedMilliseconds} msec");
            Console.WriteLine("Main() END");
        }//Main() 

        private void SaveToFile(string fileName, AbsContentMT09 content)
        {
            string dir = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\MultiThread\MTCS09_Future\WebContentSingle\HtmlFile\";
            string path = $@"{dir}{fileName}";
            byte[] byteAry = content.GetByteAry();

            try
            {
                Console.WriteLine(
                    $"{Thread.CurrentThread.Name} Saving to [{fileName}]");

                using(var fs = new FileStream(path, FileMode.Create))
                using(var writer = new StreamWriter(fs, Encoding.UTF8))
                {
                    writer.WriteLine("<!-- ");
                    for (int i = 0; i < byteAry.Length; i++)
                    {
                        writer.Write((char) byteAry[i]);
                    }//for
                    writer.Write("\n -->");

                    writer.Close();
                    fs.Close();
                }//using
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }//SaveToFile()
    }//class 
}

/*
Main() BEGIN
MainThread Saving to [yahoo.html]
MainThread Saving to [google.html]
MainThread Saving to [hyuki.html]
Cost Time: 9299 msec
Cost Time: 3661 msec 〔２回目以降: Cacheで速い〕
Main() END
 */