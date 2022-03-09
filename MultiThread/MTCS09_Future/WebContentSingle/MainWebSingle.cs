/** 
 *@title CsharpBegin / MultiThread / MTCS09_Future / WebContentSingle / MainWebSingle.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第９章 Future / 練習問題 9-3 / p317, p566 / List 9-8 ～ 9-11
 *         練習問題 9-3の問題文
 *         Web コンテンツのテキストを SingleThreadで取得
 *         取得したテキストを FileStreamで 新規ファイルに保存
 *         実行完了までの時間を計測するプログラム
 *         
 *         題意: これをマルチスレッドで非同期処理するよう修正せよ。
 *         => 別フォルダ〔WebContentAsync〕
 *
 *@subject ◆Current Directory
 *         現在クラスのDirectoryを動的に取得することを試みたが、
 *         コンパイル時に作成される「.exe」ファイルの配置先Directoryを抽出するので、
 *         生成txtファイルの配置先として、静的に 絶対パスを記述。
 *         
 *         ＊[C#] Directory.GetCurrentDirectory();
 *          => C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\bin\Debug
 *          
 *         ＊string dir = @"C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\MultiThread\MTCS09_Future\WebContentSingle\HtmlFile\";
            
 *@subject FileStream / StreamWriter
 *         using() { }
 *         var fs = new FileStream(string path, FileMode.Create))
 *             FileMode.CreateNew: Fileを新規作成、既存なら 例外 IOException
 *             FileMode.Create:    Fileを新規作成、既存なら 上書き
 *             
 *         var writer = new StreamWriter(
 *                      FileStream [, bool append] [, Encoding] [, int bufferSize])
 *             Encoding.UTF8
 *             Encoding.GetEncoding("Shift-JIS")
 *             
 *@NOTE [yahoo.html][hyuki.html]に
 *     「<!-- -->」が含まれており、コメントアウト不可。
 *     文字化けもしているので、実行後削除。
 *     => ファイル拡張子を「.txt」に変更すると解決
 *     
 *     文字化けは StreamWriter()の Encordeを UTF8 / Shift-JISにしても、
 *     どちらも解決せず。
 *     WebClientの読み込み時の問題と思われる。
 *       wc.Encoding = Encoding.UTF8; 
 *       wc.Encoding = Encoding.GetEncoding("Shift-JIS");
 *     どちらも解決せず。
 *     
 */
#region -> StreamWiter / StreamReader / FileStream
/*
*@subject【COPY】SampleCode / StreamWriterReaderSample.cs
*@reference CS 第５章 標準ライブラリ File / p187 / List 5-41 ～ 5-42
*   ◆using (オブジェクト生成式) { }
*   ◆System.IO.StreamWriter
* new StreamWriter(
*string path, [bool append, [Encoding, [int bufferSize]]]);
*Encoding Encoding.UTF - 8  //default値(省略時の既定値)
* Encoding Encoding.GetEncoding(string);
*Encoding new UTF8Encoding() //BOMなしのUTF-8
*
*void virtual streamWriter.WriteLine(T)
* void File.WriteAllLines(string path, string[])
*
*   ◆System.IO.StreamReader
* new StreamReader(
*string path, [Encoding, [bool bom, [int bufferSize]]]);
*void streamReader.ReadToEnd()
* bool streamReader.EndOfStream //while文
* void streamReader.ReadLine()  //while文内
*
*   ◆System.IO.FileStream
* new FileStream(string path, FileMode); //データをバイト列として扱う
*
*/
#endregion
/*
 *@see SampleCode / StreamWriterReaderSample.cs
 *@see ../ WebClientSample.cs
 *
 *@author shika 
 *@date 2022-03-09 
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
            AbsContentMT09 content2 = WebReadMT09.ReadSiteSync("http://www.google.com/");
            AbsContentMT09 content3 = WebReadMT09.ReadSiteSync("http://www.hyuki.com/");

            here.SaveToFile("yahoo.txt", content1);
            here.SaveToFile("google.txt", content2);
            here.SaveToFile("hyuki.txt", content3);

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
                using (var writer = new StreamWriter(
                    fs, Encoding.UTF8))
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

Main() BEGIN
MainThread Saving to [yahoo.txt]
MainThread Saving to [google.txt]
MainThread Saving to [hyuki.txt]
Cost Time: 4684 msec
Main() END
 */