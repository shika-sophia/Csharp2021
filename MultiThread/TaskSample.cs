/** 
 *@title CsharpBegin / MultiThread / TaskSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content TaskSample / C# p524 / List11-2
 *@subject ◆[C#4-|.NET 4.5-] System.Threading.Tasks.Task
 *         Task Task.Run(Action<T>) //内部的にスレッドプールを行う
 *         void task.Wait()
 *         voud task.Wait(long milliSecond);
 *         void Task.WaitAny(Task, Task, ...) 
 *                  いずれかのTaskが終了するまで待機
 *         void Task.WaitAll(Task, Task, ...) 
 *                  すべてのTaskが終了するまで待機
 *         => see MTCS07_ThreadPerMessage / ThreadPoolSample / MainThreadPool.cs 
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
    class TaskSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var here = new TaskSample();
            Task t1 = Task.Run(() => here.ShowCount(1));
            Task t2 = Task.Run(() => here.ShowCount(2));
            Task t3 = Task.Run(() => here.ShowCount(3));

            t1.Wait();
            t2.Wait();
            t3.Wait();
            //t1.Wait(1000);
            //Task.WaitAny(t1, t2, t3);
            //Task.WaitAll(t1, t2, t3);

            Console.WriteLine($"{nameof(TaskSample)}: Main() 終了");
        }//Main() 

        private void ShowCount(int num)
        {
            for(int i = 0; i < 50; i++)
            {
                Console.WriteLine($"Task{num}: {i}");
            }
        }
    }//class 
}

/*
  :
Task1: 35
Task1: 36
Task1: 37
Task1: 38
Task1: 39
Task1: 40
Task2: 0
Task2: 1
Task2: 2
Task2: 3
Task2: 4
Task2: 5
Task2: 6
Task2: 7
Task2: 8
Task2: 9
Task2: 10
Task2: 11
Task2: 12
Task2: 13
Task2: 14
Task2: 15
Task2: 16
Task2: 17
Task2: 18
Task2: 19
Task2: 20
Task3: 0
Task3: 1
Task3: 2
Task3: 3
Task3: 4
  :
Task3: 15
Task3: 16
Task1: 49
Task2: 32
Task2: 33
Task2: 34
Task2: 35
Task2: 36
Task2: 37
Task2: 38
Task2: 39
Task2: 40
Task2: 41
Task2: 42
Task2: 43
Task2: 44
Task2: 45
Task2: 46
Task2: 47
Task2: 48
Task2: 49
Task3: 17
Task3: 18
Task3: 19
  :
Task3: 46
Task3: 47
Task3: 48
Task3: 49
TaskSample: Main() 終了
*/