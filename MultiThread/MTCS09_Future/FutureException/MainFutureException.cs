/** 
 *@title CsharpBegin / MultiThread / MTCS09_Future / FutureException / MainFutureException.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第９章 Future / 練習問題 9-4 / p321, p571 / List 9-12, A9-5, A9-7
 *         || Future ||での例外発生
 *         host.RequestData(-1, 'N');によって意図的に例外を起こす。
 *         new RealData(-1, 'N')を呼び出す new Threadによって例外発生。
 *         MainThreadが呼び出す Request(), GetContent()を
 *         try-catchしても例外を捕捉できない。
 *         つまり、例外発生時もMainThreadは動作し続けることになる。
 *         
 *         RealDataインスタンス生成時の例外発生でも、
 *         MainThreadを含むプログラム全体を終了するように修正したプログラム。
 *
 *@NOTE ただし、[C#]では修正の必要がない。
 *      元のままの MainFutureSampleでも、プログラム全体が終了する。
 *
 *@class MainFutureException
 * 
 *@author shika 
 *@date 2022-03-11 
*/
using CsharpBegin.MultiThread.MTCS09_Future.FutureSample;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS09_Future.FutureException 
{ 
    class MainFutureException 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            Console.WriteLine("Main BEGIN");
            try
            {
                var host = new HostException();
                AbsDataMT09 data = host.RequestData(-1, 'N');
                Console.WriteLine($"data = {data.GetResult()}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.GetType());
            }

        }//Main() 
    }//class 
}

/*
Main BEGIN
  RequestData(-1, N) BEGIN
  RequestData(-1, N) END
    making RealData(-1, N) BEGIN

ハンドルされていない例外: System.OverflowException: 算術演算の結果オーバーフローが発生しました。
   場所 CsharpBegin.MultiThread.MTCS09_Future.FutureSample.RealDataMT09..ctor(Int32 count, Char c)  場所 C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\MultiThread\MTCS09_Future\FutureSample\RealDataMT09.cs:行 15
   場所 CsharpBegin.MultiThread.MTCS09_Future.FutureException.HostException.<>c__DisplayClass0_0.<RequestData>b__0() 場所 C:\Users\sophia\source\repos\CsharpBegin\CsharpBegin\MultiThread\MTCS09_Future\FutureException\HostException.cs:行 22
   場所 System.Threading.ThreadHelper.ThreadStart_Context(Object state)
   場所 System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
   場所 System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
   場所 System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
   場所 System.Threading.ThreadHelper.ThreadStart()

 */