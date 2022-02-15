/** 
 *@title CsharpBegin / MultiThread / MTCS01_SingleThreadExecution / Semaphore / MainSemaphore.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第１章 SingleThread Execution / 補講２ Semaphore / p74
 *@subject 計数 Semaohore
 *         利用できる Resource数を指定して、それを越えた場合は Wait()させるクラス
 *         
 *         [Java] java.util.concurrent.Semaphore
 *         void semaphore.acquire() //get resource if possible, or wait if impossible.
 *         void semaphore.release() //release all resorces
 *         int  availablePermits()  //get number of the available resources
 *         
 *         [C#]   System.Threading.SemaphoreSlim
 *         void semaphore.Wait()    //simillar to acquire()
 *         void semaphore.Release() //equal to release()
 *         int  semaphore.CurrentCount //get number of the using resources
 *         
 *MainSemaphore
 * 
 *@author shika 
 *@date 2022-02-16 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.Semaphore 
{ 
    class MainSemaphore 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var resource = new LimitedResourceMT01(3);
            var thUse = new UseResourceThreadMT01(resource);

            for (int i = 0; i < 10; i++)
            {
                new Thread(thUse.Run).Start();
            }//for
        }//Main() 
 
    }//class 
}

/*
BEGIN used: 1 / 3
BEGIN used: 0 / 3
BEGIN used: 0 / 3
END used:  0 / 3
BEGIN used: 0 / 3
END used:  0 / 3
BEGIN used: 0 / 3
END used:  0 / 3
BEGIN used: 0 / 3
END used:  0 / 3
BEGIN used: 0 / 3
END used:  0 / 3
BEGIN used: 0 / 3
END used:  0 / 3
BEGIN used: 0 / 3
END used:  0 / 3
BEGIN used: 0 / 3
END used:  0 / 3
BEGIN used: 0 / 3
END used:  0 / 3
BEGIN used: 0 / 3
END used:  0 / 3
BEGIN used: 0 / 3
END used:  0 / 3
BEGIN used: 0 / 3
END used:  0 / 3
BEGIN used: 0 / 3
END used:  0 / 3
END used:  1 / 3
END used:  2 / 3
BEGIN used: 2 / 3
BEGIN used: 1 / 3
END used:  1 / 3
BEGIN used: 1 / 3
END used:  1 / 3
 */