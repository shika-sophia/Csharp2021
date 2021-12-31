/** 
 *@title CsharpBegin / MultiThread / MTCS04_Balking / GuardedTimeout / MainTimeout.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第４章 補講１ GuardedTimeout / p151 / List 4-6, 4-7
 *         GuardedTimeoutは、GuardedSuspensionと Balkingの中間
 *         〔'GuardedTimeout' is between 'GuardedSuspension' and 'Balking'.〕
 *         
 *         ||GuradedSuspention|| 条件が合致するまで、ずっと待機
 *              It continues to wait eternally until ready of the Guard Condition.
 *                
 *         ||GuardedTimeout||    条件が合致するまで、指定時間だけ待機
 *              It waits ONLY the specified time or until ready.
 *                
 *         ||Balking||           条件が合致しないと帰る
 *              It returns, when unready.
 *                
 *@subject [Java][C#] 
 *         Thread.SpinWait()のTimeout と Thread.Yield()の
 *         どちらが作用して、Threadが再起動したかは区別できない。
 *         TimeoutExceptionによってデバッグ表示をするプログラム。
 *         
 *         〔Usually, they cannot distinguish, 
 *             which 'Thread.SpinWait()' was Timeout,
 *             or 'Thread.Yield()' waked up the other Thread.
 *           So this program shows Debug-Print by 'TimeoutException'.〕
 *         
 *@class MainTimeout
 *@class ExeTimeout
 *       / - readonly long TIMEOUT;
 *         - volatile bool ready;  /
 *       + ExeTimeout(long timeout)
 *       + void CheckExe() { Execute() }
 *       - void Execute()
 *       + void SetOn(bool)
 *       
 *@author shika 
 *@date 2021-12-31 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS04_Balking.GuardedTimeout 
{ 
    class MainTimeout 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var exe = new ExeTimeout(5000L);
            
            try 
            {
                Console.WriteLine($"Execute(): BEGIN");
                exe.CheckExe();
            } 
            catch(TimeoutException e)
            {
                Console.WriteLine($"{e.GetType()}({e.Message})");
            }
        }//Main() 
    }//class 
}

/*
Execute(): BEGIN
  :
(5000 msec waiting)
  :
System.TimeoutException(Timeout: 5001 msec.)
 */