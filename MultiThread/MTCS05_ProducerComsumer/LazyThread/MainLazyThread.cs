/** 
 *@title CsharpBegin / MultiThread / MTCS05_ProducerComsumer / LazyThread / MainLazyThread.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content Practice 5-8 / p196, p521 / List A5-10, A5-11
 *@subject LazyThread
 *         CakeTableの lockを持ったまま、Join() = 他Threadの終了を待つ。
 *         
 *         [Java] テキストコードでは、table.wait();
 *         [C#] ずっと待機するメソッドがないため、
 *           Thread.SpinWait(Timeout.Infinite); を利用
 *             class System.Threading.Timeout 
 *             const int Timeout.Infinite = -1;
 *
 *         結果を見ると、Thread.Yield()は [Java] notifyAll()の機能がある。
 *         LazyThreadは、何も仕事をしないので、かなりジャマをしているが、
 *         notifyAll()機能なら、DeadLockとまではならない様子。
 *         
 *@class MainLazyThread
 * 
 *@author shika 
 *@date 2022-01-09 
*/
using CsharpBegin.MultiThread.MTCS05_ProducerComsumer.CakeTable;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.LazyThread 
{ 
    class MainLazyThread 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            AbsCakeTable table = new CakeTableMT05(3);
            var maker1 = new MakerThreadMT05("Maker1", table, 31415);
            var maker2 = new MakerThreadMT05("Maker2", table, 92653);
            var maker3 = new MakerThreadMT05("Maker3", table, 58979);
            var eater1 = new EaterThreadMT05("Eater1", table, 32384);
            var eater2 = new EaterThreadMT05("Eater2", table, 62643);
            var eater3 = new EaterThreadMT05("Eater3", table, 38327);

            new Thread(maker1.Run).Start();
            new Thread(maker2.Run).Start();
            new Thread(maker3.Run).Start();
            new Thread(eater1.Run).Start();
            new Thread(eater2.Run).Start();
            new Thread(eater3.Run).Start();

            const int LAZY_NUM = 10;
            var lazyAry = new LazyThreadMT05[LAZY_NUM];

            for (int i = 0; i < lazyAry.Length; i++)
            {
                lazyAry[i] = new LazyThreadMT05($"Lazy-{i}", table);
                new Thread(lazyAry[i].Run).Start();
            }
        }//Main() 
    }//class 
}

/*
//==== Use Join() ====
Count 1: PutCake([Cake No.0 by Maker1])
Count 0: TakeCake()[Cake No.0 by Maker1]
Count 1: PutCake([Cake No.1 by Maker3])
Count 0: TakeCake()[Cake No.1 by Maker3]
  :
( -- Dead Lock -- )

//==== Use SpinWait(Timeout.Infinite) ====
Count 1: PutCake([Cake No.0 by Maker1])
Count 0: TakeCake() [Cake No.0 by Maker1]
Count 1: PutCake([Cake No.1 by Maker3])
Count 0: TakeCake() [Cake No.1 by Maker3]
Lazy-1: wake up by Thread.Yield().
Lazy-0: wake up by Thread.Yield().
Count 1: PutCake([Cake No.2 by Maker2])
Lazy-7: wake up by Thread.Yield().
Lazy-5: wake up by Thread.Yield().
Lazy-3: wake up by Thread.Yield().
Lazy-6: wake up by Thread.Yield().
Lazy-9: wake up by Thread.Yield().
Lazy-4: wake up by Thread.Yield().
Lazy-8: wake up by Thread.Yield().
Lazy-2: wake up by Thread.Yield().
Count 0: TakeCake() [Cake No.2 by Maker2]
Count 1: PutCake([Cake No.3 by Maker3])
Count 0: TakeCake() [Cake No.3 by Maker3]
Count 1: PutCake([Cake No.4 by Maker1])
Count 0: TakeCake() [Cake No.4 by Maker1]
Count 1: PutCake([Cake No.5 by Maker3])
Count 0: TakeCake() [Cake No.5 by Maker3]
Count 1: PutCake([Cake No.6 by Maker1])
Count 0: TakeCake() [Cake No.6 by Maker1]
Count 1: PutCake([Cake No.7 by Maker3])
Count 2: PutCake([Cake No.8 by Maker2])
Lazy-1: wake up by Thread.Yield().
Lazy-4: wake up by Thread.Yield().
Lazy-2: wake up by Thread.Yield().
Lazy-8: wake up by Thread.Yield().
Lazy-7: wake up by Thread.Yield().
Lazy-6: wake up by Thread.Yield().
Lazy-3: wake up by Thread.Yield().
Lazy-0: wake up by Thread.Yield().
Lazy-5: wake up by Thread.Yield().
Lazy-9: wake up by Thread.Yield().
Count 3: PutCake([Cake No.9 by Maker2])
Count 2: TakeCake() [Cake No.7 by Maker3]
Count 1: TakeCake() [Cake No.8 by Maker2]
Count 2: PutCake([Cake No.10 by Maker3])
Count 3: PutCake([Cake No.11 by Maker3])
Count 2: TakeCake() [Cake No.9 by Maker2]
Count 3: PutCake([Cake No.12 by Maker1])
Count 2: TakeCake() [Cake No.10 by Maker3]
Count 3: PutCake([Cake No.13 by Maker2])
Lazy-3: wake up by Thread.Yield().
Count 2: TakeCake() [Cake No.11 by Maker3]
Lazy-9: wake up by Thread.Yield().
Lazy-2: wake up by Thread.Yield().
Lazy-7: wake up by Thread.Yield().
  :
*/