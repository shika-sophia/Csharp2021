/** 
 *@title CsharpBegin / MultiThread / MTCS09_Future / WebContentAsync / MainWebAsync.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第９章 Future / 練習問題 9-3 / p317, p566 / List 9-8 ～ 9-11
 *         練習問題 9-3の回答: MultiThread非同期通信で
 *         Webページをファイルに保存。
 *         
 *         処理時間は たいして変わらないが、
 *         制御がMain()に戻るので、
 *         待機中にMainで他の処理を行える点は非同期処理の強み。
 *
 *         [C#] WebClientクラスのおかげで、Webページ読み込みのコードは
 *         とてもシンプルにすることができる点にも注目。
 *         
 *@based MainWebSingle
 *@based WebClientSample
 *@class MainWebAsync
 *
 *@see ../WebClientSample.cs
 *@author shika 
 *@date 2022-03-09 
*/
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS09_Future.WebContentAsync
{
    class MainWebAsync 
    { 
        //static async Task Main(string[] args) 
        public async Task Main(string[] args) 
        {
            var here = new MainWebAsync();
            Console.WriteLine("Main() BEGIN");
            Thread.CurrentThread.Name = "MainThread";

            var sw = new Stopwatch();
            sw.Start();

            try
            {
                using(var web = new WebClient())
                {
                    web.Encoding = Encoding.UTF8;
                    string content1 =
                        await web.DownloadStringTaskAsync("http://www.yahoo.com/");
                    string content2 =
                        await web.DownloadStringTaskAsync("http://www.google.com/");
                    string content3 =
                        await web.DownloadStringTaskAsync("http://www.hyuki.com/");
                    web.Dispose();

                    Console.WriteLine($"{Thread.CurrentThread.Name}: AnotherJob");

                    here.SaveToFile("yahoo.txt", content1);
                    here.SaveToFile("google.txt", content2);
                    here.SaveToFile("hyuki.txt", content3);
                }//using
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
                
            sw.Stop();
            Console.WriteLine($"Cost Time: {sw.ElapsedMilliseconds} msec");
            Console.WriteLine("Main() END");
        }//Main() 

        private void SaveToFile(string fileName, string content)
        {
            string dir = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\MultiThread\MTCS09_Future\WebContentAsync\HtmlFile\";
            string path = $@"{dir}{fileName}";

            try
            {
                Console.WriteLine(
                    $"{Thread.CurrentThread.Name} Saving to [{fileName}]");

                using (var fs = new FileStream(path, FileMode.Create))
                using (var writer = new StreamWriter(
                    fs, Encoding.UTF8))
                {
                    writer.WriteLine(content);
                    writer.Close();
                    fs.Close();
                }//using
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }//SaveToFile()
    }//class 
}

/*
Main() BEGIN
: AnotherJob
 Saving to [yahoo.txt]
 Saving to [google.txt]
 Saving to [hyuki.txt]
Cost Time: 3627 msec
Main() END
 */