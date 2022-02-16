/** 
 *@title CsharpBegin / MultiThread / MTCS07_ThreadPerMessage / HostHelper / MainHostHelper.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第７章 Thread per Message / p228 / List 7-1, 7-2, 7-3
 *         ～ 「この仕事、やっといてね」～
 *         メッセージ(= 仕事、要求)ごとに 新たな Threadを割り当て、
 *         その Threadが仕事を処理する。
 *         
 *         文末、実行結果を見ると、
 *         仕事を依頼したThreadは、実行処理を待たずに終了している。
 *         Request()の応答性は Handle()の処理時間に影響されない。
 *         
 *@subject || Thread per Message || パターン
 *         ＊応答性を上げ、遅延時間を下げる目的で利用するパターン
 *           GUIアプリケーションに応用可
 *         ＊仕事ごとに new Thread()するので、
 *           Thread起動に掛かる時間と、実行処理に掛かる時間のトレードオフで
 *           利用の可否を判断。
 *         ＊Thread 起動の時間節約には || Worker Thread ||パターンを利用〔MT 第８章〕
 *         ＊処理順序を気にしない時に利用。
 *         ＊戻り値が不要な時に利用。
 *           戻り値が必要な場合は || Future ||パターン〔MT 第９章〕
 *         ＊サーバーの応答性を上げるために応用される。
 *         ＊「メソッド呼出」と「メソッドの実行処理」を分離した非同期通信
 */
#region -> [Java] 匿名クラス / [C#] 匿名メソッド
/*
 *@subject [Java] 匿名クラス
 *         new Thread(){
 *             public void run() { }
 *         }.start();
 *         
 *@subject [C#] 匿名メソッド 〔CS 81 | p474〕
 *         ＊Threadクラスの構造
 *         new Thread(ThreadStart()).Start()
 *           └ delegate void ThreadStart()
 *               └ XxxxxThread.Run(){ }
 *           ↓
 *         ＊XxxxThreadクラス Run()を匿名メソッドとして delegate()で定義
 *         new Thread(
 *             new ThreadStart(
 *                 delegate()
 *                 {
 *                     //Run()内の処理
 *                 }
 *             )
 *         ).Start();
 *         
 *@class MainHostHelper
 *      //◆Main()
 *          new HostMT07()
 *          host.RequestMT07(int count, char c); * 3
 */
#endregion
#region -> [HostHelper] Class Chart
/*
 *@class HostMT07
 *       / - readonly ◇HelperMT07 helper /
 *       + RequestMT07(int count, char c)
 *         { new Thread(
 *             new ThreadStart(
 *               delegate() {
 *                   helper.Handle(int count, char c)
 *               } 
 *             )
 *           ).Start()
 *          }
 *          
 *class HelperMT07
 *      //
 *      + Handle(int count, char c)
 *      - Slowly()
 */
#endregion
/*
 *@author shika 
 *@date 2022-02-17 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.HostHelper 
{ 
    class MainHostHelper 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            Console.WriteLine("Main BEGIN");

            var host = new HostMT07();
            host.RequestMT07(10, 'A');
            host.RequestMT07(20, 'B');
            host.RequestMT07(30, 'C');

            Console.WriteLine("Main END");
        }//Main() 
 
    }//class 
}

/*
Main BEGIN
Request [10, A] BEGIN
Request [10, A] END    <- Handle [10, A] BEGINより先に終了
Request [20, B] BEGIN
Handle [10, A] BEGIN
Request [20, B] END
Request [30, C] BEGIN
Handle [20, B] BEGIN
Request [30, C] END
Main END               <- Mainは仕事を頼んで終了
Handle [30, C] BEGIN
CBAABCABCBACCABBCACABABCCABCBA <- 3 Threadの出力が混在
Handle [10, A] END
BCCBBCCBCBBCBCBCCBCB <- 2 Threadの出力が混在
Handle [20, B] END
CCCCCCCCCC           <- last Threadの出力
Handle [30, C] END
 */