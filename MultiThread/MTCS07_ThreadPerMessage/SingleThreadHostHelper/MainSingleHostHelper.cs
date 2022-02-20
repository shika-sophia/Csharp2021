/** 
 *@title CsharpBegin / MultiThread / MTCS07_ThreadPerMessage / SingleThreadHostHelper / MainSingleHostHelper.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 練習問題 7-2, 7-3, 7-4 / p252, p533
 *@subject 練習問題 7-2 HostSingle 
 *         new Threadをせずに、Request()内で直接 helper.Handle()を呼出
 *         => Single Threadと同様にすべてMainThreadで処理される。
 *
 *@subject 練習問題 7-3 HostThreadRun
 *         本来 new Thread().Start();とするところを
 *         誤って Run()と記述すると、new Threadはスタートせず、
 *         MainThreadが Run()を呼び出し、Single Threadと同様の結果となる。
 *         
 *@subject 練習問題 7-4 HostThreadMT07
 *         [Java] new Thread(){ 
 *                  public void run() { } 
 *                }.run();
 *                という記述が可能だが、C#では不可。
 *                
 *         [C#]  new Thread(ThreadStart())
 *         Threadコンストラクタの引数は delegate void ThreadStart()のため、
 *         新たに HostThread.Run()を定義して、
 *         その Run()を呼び出して題意を再現した。        
 *
 *@class MainSingleHostHelper
 * 
 *@author shika 
 *@date 2022-02-20 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.SingleThreadHostHelper 
{ 
    class MainSingleHostHelper 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            Console.WriteLine("MainSingle: BEGIN");
            //var host = new HostSingle();
            var host = new HostThreadRun();
            host.RequestMT07(10, 'A');
            host.RequestMT07(20, 'B');
            host.RequestMT07(30, 'C');
            
            Console.WriteLine("MainSingle: END");
        }//Main() 
    }//class 
}

/*
//---- HostSingle ----
MainSingle: BEGIN
Request [10, A]: BEGIN
Handle [10, A] BEGIN
AAAAAAAAAA
Handle [10, A] END
Request [10, A]: END
  <- 前のRequest(),Handle()が終了してから次のRequest()
Request [20, B]: BEGIN
Handle [20, B] BEGIN
BBBBBBBBBBBBBBBBBBBB
Handle [20, B] END
Request [20, B]: END
Request [30, C]: BEGIN
Handle [30, C] BEGIN
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
Handle [30, C] END
Request [30, C]: END
MainSingle: END

//---- HostThreadRun ----
//実行結果は SingleThreadと同様となる
MainSingle: BEGIN
Request [10, A]: BEGIN
Handle [10, A] BEGIN
AAAAAAAAAA
Handle [10, A] END
Request [10, A]: END
Request [20, B]: BEGIN
Handle [20, B] BEGIN
BBBBBBBBBBBBBBBBBBBB
Handle [20, B] END
Request [20, B]: END
Request [30, C]: BEGIN
Handle [30, C] BEGIN
CCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
Handle [30, C] END
Request [30, C]: END
MainSingle: END
 */