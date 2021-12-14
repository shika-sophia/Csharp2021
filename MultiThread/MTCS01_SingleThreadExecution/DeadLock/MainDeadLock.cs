/** 
 *@title CsharpBegin / MultiThread / MTCS01_SingleThreadExecution / DeadLock / MainDeadLock.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content Practice 1-6 DeadLock / p80 / List 1-14, 1-15, 1-16
 *         意図的にデッドロックを起こさせるプログラム
 *         
 *         【デッドロック発生の要件】
 *          これのどれかを崩せばデッドロックを回避できる => MainAvoidDeadLock.cs
 *         ① 複数の SharedResource(=共有資源) がある
 *         ② Threadが あるSharedResourceのロックをとったまま、
 *           他の SharedResourceのロックを取りに行く
 *         ③ SharedResorceが対称的 
 *           (= SharedResorceのロックを取りに行く順番が一定ではない)
 *           
 *@see MainAvoidDeadLock.cs
 *@author shika 
 *@date 2021-12-14 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.DeadLock 
{ 
    class MainDeadLock 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            Console.WriteLine($"Testing EaterThread");
            var spoon = new ToolDeadLock("Spoon");
            var fork = new ToolDeadLock("Fork");
            var eaterA= new EaterThread("Alice", spoon, fork);
            var eaterB = new EaterThread("Bobby", fork, spoon);

            Thread thA = new Thread(eaterA.Run);
            thA.Start();
            Thread.Sleep(10);
            Thread thB = new Thread(eaterB.Run);
            thB.Start();
        }//Main() 
    }//class 
}

/*
Testing EaterThread
Alice takes up [Spoon] (left).
Alice takes up [Fork] (right).
[0] Alice is eating now, yum yum!
Alice put down [Fork] (right).
Alice put down [Spoon] (reft).
Alice takes up [Spoon] (left).
Alice takes up [Fork] (right).
[1] Alice is eating now, yum yum!
Alice put down [Fork] (right).
Alice put down [Spoon] (reft).
Alice takes up [Spoon] (left).
Alice takes up [Fork] (right).
  :
[14] Alice is eating now, yum yum!
Alice put down [Fork] (right).
Alice put down [Spoon] (reft).
Alice takes up [Spoon] (left).
Bobby takes up [Fork] (left).

( -- DeadLock -- )
 
 */
