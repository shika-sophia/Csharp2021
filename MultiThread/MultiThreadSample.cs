/** 
 *@title CsharpBegin / MultiThread / MultiThreadSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Create, 2006 
 *@content 11.1 MultiThread / C# p520 / List 11-1
 *         ※旧式 非推奨の Thread Start方法 => Taskを利用すべき
 *         Threadクラス内で定義してあるデリゲートに
 *         Threadコンストラクタを通して、
 *         そのスレッドで実行すべきメソッドを渡す。
 *         
 *@subject ◆System.Threading.Thread
 *         Thread new Tread(ThreadStart)
 *         Thread new Tread(ParameterizedThreadStart)
 *             delegate void ThreadStart()
 *             delegate void ParameterizedThreadStart(object)
 *             
 *         thread.Start(object)
 *         thread.Join() //Thread終了まで待機
 *         
 *@author shika 
 *@date 2021-11-09 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread 
{
    class MultiThreadSample 
    {   
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var here = new MultiThreadSample();
            Thread th1 = new Thread(here.ShowCount);
            Thread th2 = new Thread(here.ShowCount);
            Thread th3 = new Thread(here.ShowCount);

            th1.Start(1);
            th2.Start(2);
            th3.Start(3);

            th1.Join();
            th2.Join();
            th3.Join();
            Console.WriteLine(
                $"{nameof(MultiThreadSample)} Main(): 終了");
        }//Main() 

        private void ShowCount(object threadName)
        {
            for(int i = 0; i < 50; i++)
            {
                Console.WriteLine($"Thread {threadName}: {i}");
            }
        }
    }//class 
}

/*
Thread 1: 0
Thread 1: 1
Thread 1: 2
Thread 1: 3
 :
Thread 1: 37
Thread 1: 38
Thread 1: 39
Thread 1: 40
Thread 3: 0
Thread 2: 0
Thread 2: 1
Thread 2: 2
Thread 2: 3
 :
Thread 2: 23
Thread 2: 24
Thread 1: 41
Thread 3: 1
Thread 3: 2
Thread 3: 3
Thread 3: 4
Thread 3: 5
Thread 3: 6
Thread 3: 7
Thread 3: 8
Thread 3: 9
Thread 3: 10
Thread 2: 25
Thread 2: 26
Thread 1: 42
Thread 1: 43
Thread 1: 44
Thread 1: 45
Thread 1: 46
Thread 1: 47
Thread 1: 48
Thread 1: 49
Thread 3: 11
Thread 3: 12
Thread 3: 13
Thread 3: 14
 :
Thread 2: 37
Thread 2: 38
Thread 2: 39
Thread 2: 40
Thread 2: 41
Thread 2: 42
Thread 2: 43
Thread 2: 44
Thread 2: 45
Thread 2: 46
Thread 3: 28
Thread 3: 29
 :
Thread 3: 40
Thread 3: 41
Thread 2: 47
Thread 2: 48
Thread 2: 49
Thread 3: 42
Thread 3: 43
Thread 3: 44
Thread 3: 45
Thread 3: 46
Thread 3: 47
Thread 3: 48
Thread 3: 49
MultiThreadSample Main(): 終了
*/