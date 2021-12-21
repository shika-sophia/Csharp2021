/** 
 *@title CsharpBegin / MultiThread / MTCS02_Immutable / BreakThreadSafe / MainMutableImmutable.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content ■安全性が壊れるケース / p111, p487 / 練習問題 2-6 / List 2-15, 2-16, A2-5, A2-6
 *         不変性は守られるが、MultiThread環境での ThreadSafeが破られるプログラム
 *         
 *@subject ==== directly insert in PresonImmutable constructor ====
 *         PersonImmutableRVのコンストラクタで
 *         mutable.GetName(), GetAddress()
 *         呼出と、値の取得時に PersonMutableは違うオブジェクトになっており、
 *         別Threadによって、それを代入されてしまう。
 *         
 *        public PersonImmutableRV(PersonMutable mutable)
 *        {
 *           this.name = mutable.GetName();
 *           this.address = mutable.GetAddress();
 *       　}
 *         
 *@subject ==== lock(mutable) in PresonImmutable constructor ====
 *         コンストラクタ内で lock(mutable)をする必要がある。
 *         
 *        public PersonImmutableRV(PersonMutable mutable)
 *        {
 *           lock (mutable)
 *           {
 *               this.name = mutable.GetName();
 *               this.address = mutable.GetAddress();
 *           }//lock
 *       　}
 *       　
 *@class MainMutableImmutable // 
 *       ◆Main()
 *       new PersonMutable(), new CrackerThread(), 
 *       new Thread() * 3
 *       
 *@class CrackerThread
 *       / - PersonMutable
 *         - const int COUNT /
 *       + CrackerThread(PersonMutable)
 *       + Run()
 *           new PersonImmutableRV()
 *           
 *@class PersonMutable
 *@class PersonImmutable
 *       
 *@author shika 
 *@date 2021-12-21 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS02_Immutable.BreakThreadSafe
{ 
    class MainMutableImmutable 
    {
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var mutable = new PersonMutable("start", "start");
            var cracker = new CrackerThread(mutable);

            new Thread(cracker.Run).Start();
            new Thread(cracker.Run).Start();
            new Thread(cracker.Run).Start();

            //PersonMutableを改変
            for(int i = 0; true; i++)
            {
                mutable.SetPerson($"{i}", $"{i}");
            }//for loop
        }//Main() 
    }//class 

    class CrackerThread
    {
        private readonly PersonMutable mutable;
        private const int COUNT = 50_000;

        public CrackerThread(PersonMutable mutable)
        {
            this.mutable = mutable;
        }

        public void Run()
        {
            for (int i = 0; i < COUNT; i++)
            {
                var immutable = new PersonImmutableRV(mutable);

                if (!immutable.GetName().Equals(immutable.GetAddress()))
                {
                    Console.WriteLine(
                        $"{Thread.CurrentThread.Name} **** BROKEN **** {immutable}");
                }
            }//for

            Console.WriteLine($"{Thread.CurrentThread}: Tested {COUNT} times.");
        }//Run()
    }//class
}

/*
//==== directly insert in PresonImmutable constructor ====
**** BROKEN **** PersonImmutableRV: Name 11 / Address 12
**** BROKEN **** PersonImmutableRV: Name 1102 / Address 1101
**** BROKEN **** PersonImmutableRV: Name 2255 / Address 2256
      :

//==== lock(mutable) in PresonImmutable constructor ====
System.Threading.Thread: Tested 50000 times.
System.Threading.Thread: Tested 50000 times.
System.Threading.Thread: Tested 50000 times.
( No Conflict )
 */
