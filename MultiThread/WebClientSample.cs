/** 
 *@title CsharpBegin / MultiThread / WebClientSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content async WebClient / C# p534 / List 11-7, 11-8
 *         asyncメソッドによる WebClientの実行
 *         
 *@subject ◆[C#7.1-] async Task Main():
 *             Main()内の戻り値を Taskにすることができる。
 *             
 *@Subject ◆Systrm.Net.WebClientクラス
 *         Task<string> webClient.DownloadTaskAsync(string url)
 *         
 *@subject ◆[C#7.0以前] void Main():
 *         //通信完了時の処理
 *         delegate void DownloadStringCompletedEventHandler(
 *             object sender, DownloadStringCompletedEventArgs e);
 * 
 *         //非同期通信を開始
 *         void webClient.DownloadStringAsync(Uri)
 *             Uri new Uri(string uri)
 *             
 *@author shika 
 *@date 2021-11-11 
*/
using System; 
using System.Collections.Generic; 
using System.Linq;
using System.Net;
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread 
{ 
    class WebClientSample 
    { 
        //==== [C#7.1-] async Task Main() ====
        //static async Task Main(string[] args)
        public async Task MainAsync(string[] args) 
        {
            string url = "http://codezine.jp/";
            Console.WriteLine($"Main(): URL {url} Connecting...");

            WebClient web = new WebClient();
            string result = 
                await web.DownloadStringTaskAsync(url);
            Console.WriteLine(result);
        }//async Task Main() 

        //==== [C#7.0以前] void Main() ====
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            string url = "http://codezine.jp/";
            Console.WriteLine($"Main(): URL {url} Connecting...");

            WebClient web = new WebClient();

            //通信完了時の処理
            web.DownloadStringCompleted += (sender, e) =>
            {
                Console.WriteLine(e.Result);
            };

            //非同期通信を開始
            web.DownloadStringAsync(new Uri(url));

            //非同期待ちのための入力待機
            Console.ReadLine();
        }//void Main()
    }//class 
}

/*
Main(): URL http://codezine.jp/ Connecting...

<!DOCTYPE html>
<!--[if lte IE 8]><html class="no-js lt-ie8" lang="ja"><![endif]-->
<!--[if gt IE 8]><!--> <html class="no-js gt-ie9" lang="ja"> <!--<![endif]-->
<head prefix="og: http://ogp.me/ns# fb: http://ogp.me/ns/fb# article: http://ogp.me/ns/article#">
  <script>
    var dataLayer = dataLayer || [];
    dataLayer.push({
        'trackPageview':'CZ/',
        'member' : 'nonmember'
    });
  </script>
<meta charset="utf-8">
<title>CodeZine</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
   :

【考察】void Main()
通信完了時: DownloadStringCompleted
非同期通信: DownloadStringAsync(Uri)
非同期待機: Console.ReadLine()

この順番でないと うまくいかない。
ReadLine()の待機中に 何か入力すると プログラム終了。
非同期通信が完了すると、自動的に HTMLコードを表示。
 */