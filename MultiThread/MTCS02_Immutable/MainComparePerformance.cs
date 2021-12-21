/** 
 *@title CsharpBegin / MultiThread / MTCS02_Immutable / MainComparePerformance.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第２章 Immutable / p108 / 練習問題 2-3
 *         [Java] synchronized() / [C#] lock()の利用と、Immutableの利用で
 *         どのぐらいパフォーマンスに違いがあるかを計測するプログラム。
 *         
 *@class MainComparePerformance
 *       ◆[C#] Stopwatchクラス (System.Diagnostics.Stopwatch)
 *       Stopwatch sw = new Stopwatch();
 *       void sw.Start();
 *       void sw.Stop();
 *       void sw.Reset(); //差分 Elapsed = 0 にリセット
 *       TimeSpan sw.Elapsed;
 *       long     sw.ElapsedMilliseconds;
 *       
 *@result ---- Immutable ----
 *        [NotSync] Start
 *        [NotSync] End
 *        CostTime: 2808 msec.
 *
 *        ---- synchronized() / lock() ----
 *        [Sync] Start
 *        [Sync] End
 *        CostTime: 24153 msec.
 *        
 *@author shika 
 *@date 2021-12-21 
*/
using System; 
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS02_Immutable
{ 
    class MainComparePerformance 
    {
        private const long COUNT = 1_000_000_000L; // 1 Billion (10億回)

        //static void Main(string[] args)
        public void Main(string[] args) 
        {
            var here = new MainComparePerformance();
            here.TrialWork(new NotSync());
            here.TrialWork(new Sync());
        }//Main()

        private void TrialWork(Object obj)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
                string name = obj.ToString();
                Console.WriteLine($"{name} Start");

                for(int i = 0; i < COUNT; i++)
                {
                    obj.ToString();
                }//for

                Console.WriteLine($"{name} End");
            sw.Stop();
            long span = sw.ElapsedMilliseconds;
            Console.WriteLine($"CostTime: {span} msec.");
        }//TrialWork()
    }//class 

    sealed class NotSync //Immutable
    {
        private const string name = nameof(NotSync);
        public override sealed string ToString()
        {
            return $"[{name}]";
        }
    }//class NotSync

    class Sync 
    {
        private const string name = nameof(Sync);
        public override string ToString()
        {
            lock (this)
            {
                return $"[{name}]";
            }//lock()
        }
    }//class Sync
}

/*
---- Immutable ----
[NotSync] Start
[NotSync] End
CostTime: 2808 msec.

---- synchronized() / lock() ----
[Sync] Start
[Sync] End
CostTime: 24153 msec.
 */

