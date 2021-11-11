/** 
 *@title CsharpBegin / MultiThread / LockSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content Lock / C# p526 / List 11-3, 11-4
 *         ◆排他制御 [C#] lock / [java] synchronized
 *         lock(object){ }
 *         object lockObj = new Object();
 *         
 *@author shika 
 *@date 2021-11-11 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread 
{ 
    class LockSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            //var lockBad = new LockBad();
            //lockBad.MultiTask();

            var lockGood = new LockGood();
            lockGood.MultiTask();
        }//Main() 
    }//class 

    class LockBad
    {
        public int Count { get; private set; } = 0;

        internal void MultiTask()
        {
            const int TaskNum = 50000;
            var taskAry = new Task[TaskNum];
            
            //Task[i]を定義・実行
            for(int i = 0; i < TaskNum; i++)
            {
                taskAry[i] = Task.Run(() => Increment());
            }

            //Task[]全終了まで待機
            Task.WaitAll(taskAry);

            Console.WriteLine($"Count: {Count}");
        }//MultiTask()

        private void Increment()
        {
            Count++;
        }
    }//class

    class LockGood
    {
        private object lockObj = new object();
        public int Count { get; private set; } = 0;

        internal void MultiTask()
        {
            const int TaskNum = 50000;
            var taskAry = new Task[TaskNum];

            //Task[i]を定義・実行
            for (int i = 0; i < TaskNum; i++)
            {
                taskAry[i] = Task.Run(() => Increment());
            }

            //Task[]全終了まで待機
            Task.WaitAll(taskAry);

            Console.WriteLine($"Count: {Count}");
        }//MultiTask()

        private void Increment()
        {
            lock (lockObj)
            {
                Count++;
            }//lock
        }
    }//class
}

/*
//---- LockBad.MultiTask() ----
Count: 49044  //実行期待値 50000

//---- LockGood.MultiTask() ----
Count: 50000

 */
