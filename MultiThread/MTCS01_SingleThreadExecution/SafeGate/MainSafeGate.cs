/** 
 *@title CsharpBegin / MultiThread / MTCS01_SingleThreadExecution / SafeGate / MainSafeGate.cs 
 *@reference CS: 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT: 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第１章 SingleThreadExecution / p50 /
 *         ～ 「この橋を渡れるのは、たった一人」
 *@subject SafeGate / List 1-4
 *    ---- ONLY modification point from UnsafeGate ----
 *@class MainSafeGate /◆Main() new UnsafeGate() -> new SafeGate()
 *@class SafeGate
 *         PassGate(){ lock(){ } }
 *
 *@see UnsafeGate / MainUnsafeGate.cs
 *@see ../../ LockSample.cs
 *@author shika 
 *@date 2021-12-13 
*/
using CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.UnsafeGate;
using System;
using System.Threading;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.SafeGate
{
    class MainSafeGate 
    {
        //static void Main(string[] args)
        public void Main(string[] args) 
        {
            Console.WriteLine("Testing Gate");
            AbsGateMT01 gate = new SafeGate();
            var psA = new PassengerThread(gate, "Alice", "Alaska");
            var psB = new PassengerThread(gate, "Bobby", "Brazil");
            var psC = new PassengerThread(gate, "Chris", "Canada");

            Thread thA = new Thread(psA.Run);
            Thread thB = new Thread(psB.Run);
            Thread thC = new Thread(psC.Run);
            thA.Start();
            thB.Start();
            thC.Start();
            thA.Join();
            thB.Join();
            thC.Join();

            Console.WriteLine();
            Console.WriteLine(
                $"Tested {PassengerThread.TEST_TIMES:###,###,###} times.");
            Console.WriteLine(
                $"{nameof(MainSafeGate)} Main(): END");
        }//Main() 
    }//class 
}

/*
//==== Result as locked PassGate() ONLY ====
【NOTE】SafeGate.cs
 *  CheckGate() is called by locking PassGate(). 
 *  ToString()  is called by locking CheckGate(). 
 *  I need not lock CheckGate() and ToString().
 *  
 *  But [MT Chap1 / Practice Answer 1-3 / p470] said 
 *    "If another program use ToString(), it can occur to the data conflict.
 *     ToString() need be locked. 
 *     In this program only, it need not be locked."
 *  I modified so.

Testing Gate
Alice BEGIN
Bobby BEGIN
Chris BEGIN
Alice END
Bobby END
Chris END

Tested 1,000,000 times.
MainSafeGate Main(): END

//==== Result as locked CheckGate() & ToString() ====
【NOTE】These locks were mistakes. Need lock PassGate().
Testing Gate
Alice BEGIN
Bobby BEGIN
Chris BEGIN
**** BROKEN **** [206692] Alice, Alaska
**** BROKEN **** [262868] Bobby, Brazil
Alice END
Bobby END
Chris END
MainSafeGate Main(): END
 */