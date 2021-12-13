/** 
 *@title CsharpBegin / MultiThread / MTCS01_SingleThreadExecution / UnsafeGate / MainUnsafeGate.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第１章 SingleThreadExecution / p50 /
 *         ～ 「この橋を渡れるのは、たった一人」
 *@subject UnsafeGate / List 1-1, 1-2, 1-3
 *         排他制御をしていないので、conflict(=競合, データレース)を起こすクラス群。
 *         
 *         【設定】name, addressの頭文字を同じ文字に設定することで、
 *          conflictが起きたことを判定する仕組み。
 *
 *@class MainUnsafeGate /
 *       ◆Main()
 *          new UnsafeGate(),
 *          new PassengerThread,
 *          new Thread(ThreadStart)
 *            ┗ ps.Run -> delegate void ThreadStart()
 *@class ../AbsMT01Gate / 
 *       + abstract PassGate(string, string)
 *       ~ abstract CheckGate()
 *@class UnsafeGate : AbsMT01Gate
 *       /- int count,
 *        - string name,
 *        - string address /
 *        + void PassGate(string, string) //Field set
 *        ~ void CheckGate() 
 *          { if(! name.StartsWith(address.Substring(0,1))) }
 *        + string ToString()
 *@class PassengerThread
 *       / - readonly AbsMT01Gate gate;
 *         - readonly string passName;
 *         - readonly string passAddress; /
 *       + void PassengerThread(AbsMT01Gate, string, string)
 *       + void Run() -> delegate void ThreadStart()
 *       
 *@see SafeGate / MainSafeGate.cs
 *@see MultiThreadSample.cs
 *@author shika 
 *@date 2021-12-12 
*/
using System;
using System.Threading;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.UnsafeGate
{
    class MainUnsafeGate 
    { 
        //tatic void Main(string[] args) 
        public void Main(string[] args)  
        {
            Console.WriteLine("Testing Gate");
            AbsMT01Gate gate = new UnsafeGate();
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
                $"{nameof(MainUnsafeGate)} Main(): END");
        }//Main()  
    }//class 
}

/*
//==== Result ====
Testing Gate, Hit [Ctrl] + [C] to EXIT
Alice BEGIN
Bobby BEGIN
Chris BEGIN
**** BROKEN **** [5697] Chris, Canada
**** BROKEN **** [8747] Bobby, Brazil
**** BROKEN **** [74354] Bobby, Brazil
**** BROKEN **** [74429] Chris, Brazil
**** BROKEN **** [74429] Chris, Brazil
**** BROKEN **** [150545] Chris, Canada
**** BROKEN **** [151913] Chris, Canada
**** BROKEN **** [158644] Bobby, Brazil
      :
      :
//==== Result until 100_000 ====
Testing Gate
Alice BEGIN
Bobby BEGIN
Chris BEGIN
**** BROKEN **** [14835] Chris, Canada
**** BROKEN **** [14750] Alice, Alaska
**** BROKEN **** [24644] Chris, Canada
Bobby END
Chris END
Alice END
MainUnsafeGate Main(): END

//==== Result until 500_000 ====
Testing Gate
Alice BEGIN
Bobby BEGIN
Chris BEGIN
**** BROKEN **** [24769] Bobby, Brazil
**** BROKEN **** [25915] Bobby, Brazil
**** BROKEN **** [78227] Bobby, Brazil
**** BROKEN **** [88819] Alice, Alaska
**** BROKEN **** [96515] Chris, Canada
**** BROKEN **** [110053] Alice, Alaska
**** BROKEN **** [230401] Bobby, Brazil
**** BROKEN **** [230404] Alice, Alaska
**** BROKEN **** [359377] Chris, Canada
**** BROKEN **** [362314] Chris, Canada
**** BROKEN **** [365347] Bobby, Brazil
**** BROKEN **** [362314] Chris, Canada
**** BROKEN **** [409829] Bobby, Brazil
**** BROKEN **** [412868] Alice, Alaska
**** BROKEN **** [467423] Bobby, Brazil
**** BROKEN **** [490741] Chris, Canada
**** BROKEN **** [494232] Alice, Alaska
**** BROKEN **** [490826] Bobby, Brazil
Chris END
Alice END
Bobby END
MainUnsafeGate Main(): END
*/
