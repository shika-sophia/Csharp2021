/** 
 *@title CsharpBegin / MultiThread / MTCS01_SingleThreadExecution / Mutex / MainMutex.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 練習問題 1-7 / p84, p478 / List 1-17, A1-9
 *@subject ◆Mutex: Mutual Exclusion (= 相互排他)
 *         lock()を用いずに、排他制御を行うプログラム。
 *         
 *         ◆MutexSampleクラス
 *         Lock(), Unlock()というメソッドを定義し、
 *         bool lockFlag = true / false によって　ロック状態か否かを判定。
 *         
 *         [Java] synchronizedにあたる [C#] lock()と volatileを併用しているので、
 *         Gateに lock()を利用した SageGateのほうがパフォーマンスがいいし、
 *         コードもシンプルである。
 *           ↓
 *@subject ◆MutexAnswerクラス
 *         int locks ロック数を Flagとし、LockしたThreadを ownerとするよう改良。
 *         [Java] synchronizedにあたる [C#] lock()と volatileを併用した上に、
 *         Lock()した ownerしか、Unlock()できないため、非常に時間が掛かるが、
 *         Lock() とUnlock()が同じThreadで callされることは確保できる。
 *         しかし、やはりGateに lock()を利用した SageGateのほうがパフォーマンスがいいし、
 *         コードもシンプルである。
 *         
 *@author shika 
 *@date 2021-12-15
*/
using CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.UnsafeGate;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.Mutex 
{ 
    class MainMutex 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            Console.WriteLine("Testing Gate");
            //AbsMutex mutex = new MutexSample(thMax: 3);
            AbsMutex mutex = new MutexAnswer(thMax: 3);
            AbsGateMT01 gate = new MutexGate(mutex);
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
                $"{nameof(MainMutex)} Main(): END");
        }//Main() 
    }//class
}

/*
//==== MutexSample act 1 ====
Testing Gate
Alice BEGIN
Bobby BEGIN
Chris BEGIN
**** BROKEN **** [1376] Alice, Alaska
**** BROKEN **** [1813] Alice, Alaska
**** BROKEN **** [2107] Alice, Brazil
**** BROKEN **** [5373] Chris, Alaska
**** BROKEN **** [6336] Bobby, Brazil
  : 
(-- DeadLock --)

【NOTE】
DataRace: I don't find why.
DeadLock: All Thread are waiting in MutexSample.Lock(){ while(lockFlag) }.

//==== MutexSample act 2 ====
//modified to less waiting Thread than thread-max. 
Testing Gate
Alice BEGIN
Bobby BEGIN
Chris BEGIN
**** BROKEN **** [3] Chris, Brazil
**** BROKEN **** [302] Alice, Alaska
**** BROKEN **** [14040] Bobby, Brazil
**** BROKEN **** [14361] Alice, Canada
**** BROKEN **** [15083] Bobby, Brazil
**** BROKEN **** [19676] Alice, Alaska
**** BROKEN **** [22497] Bobby, Brazil
**** BROKEN **** [30259] Alice, Alaska
Bobby END
Chris END
Alice END

Tested 50,000 times.
MainMutex Main(): END

【NOTE】Why DataRace?
I try to comment-out ToString()-mutex.Lock() and Unlock().
the result is same as before.

【Answer】MT p478
Answer code 'List A1-9' [Java] is same as me [C#],
except using 'synchronized' [Java].

But he said following --
＊Can't re-entry: 再入不可
    A Thread can't entry ToString(), because itself locked in PassGate().
    自分自身で PassGate()をロックしたため、ToString()で再入できない。

＊Any Thread can Unlock(): 
    even which didn't call Lock() by itself.
    自分で Lock()を呼び出していなくても、どのThreadでも Unlock()可。

=> Modification Point:
    He yield two fields of [Thread count], [locked owner] in Mutex class.
    I modified so too.

//==== MutexSample act 3 ====
//modified to add 'lock(){ }' as synchronized [Java] in Mutex.Lock()
Testing Gate
Alice BEGIN
Bobby BEGIN
Chris BEGIN
Bobby END
Alice END
Chris END

Tested 1,000,000 times.
MainMutex Main(): END

【NOTE】
It's success. But it use 'lock()'.
That don't make sense as this Quest.

Also it use both 'lock()' as synchronized and 'volatile',
which reduce this program performance than before.

【Analysis】
The reason of this success is that
another Thread inserted at 'while()' judging and change 'lockFlag'.
Finally it need 'lock()', in order to excluse another Thread insert. 

*/