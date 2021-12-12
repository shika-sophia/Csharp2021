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
 *@class AbsMT01Gate / 
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
 *@see MultiThreadSample.cs
 *@see SafeGate / MainSafeGate.cs
 *@author shika 
 *@date 2021-12-12 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.UnsafeGate 
{ 
    class MainUnsafeGate 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args)  
        {
            Console.WriteLine("Testing Gate, Hit [Ctrl] + [C] to EXIT");
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
*/
