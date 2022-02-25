/** 
 *@title CsharpBegin / MultiThread / MTCS07_ThreadPerMessage / MiniServer / MainMiniServer.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第７章 Thread per Message 
 *         練習問題 7-6 ミニサーバーのMulti-Thread対応 / p255 / List 7-18, 7-19, 7-20
 *         
 *@subject [Java]
 *         java.net.Socket
 *         java.net.ServerSocket
 *           ローカルの仮想サーバーを利用して
 *           HTMLコンテンツを表示するクラスのようだ
 *
 *@subject [C#] System.Net.Sockets.Socketクラス
 *           同名のクラスは存在するが、機能的に同じものかは不明。
 *           C#でこれを実装するのはまだ難しい
 *           Console表示するものなら記述可能だが...
 *         
 *@reference (Web) プログラミングC#
 *           ◆ローカルで使うWebサーバーを立てる
 *             https://yryr.me/programming/local-http-server.html
 *             => see 〔LocalHost / HttpLisenerReference.txt〕
 *@subject [C#] HttpListenerクラス
 *         C#では標準でWebサーバーのクラスが用意されており、
 *         ローカルのみで使用する場合はこれで十分だったりします。
 *         また、ローカルのみの場合はファイアーウォールの許可も必要なく、
 *         楽に立てることができます。
 *         
 *@class MainMiniServer 〔未完成〕
 *
 *@see ../WebClientSample.cs
 *@see HttpLisenerReference.txt
 *@author shika 
 *@date 2022-02-23
*/
using System; 
using System.Collections.Generic; 
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.MiniServer 
{ 
    class MainMiniServer 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            try
            {
                new MiniServerMT07(8888).execute();
            }
            catch (HttpListenerException e)
            {
                Console.WriteLine(e.Message);
            }
        }//Main() 
    }//class 
} 
