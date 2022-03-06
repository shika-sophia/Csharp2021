/** 
 *@title CsharpBegin / MultiThread / MTCS09_Future / FutureTask / MainFutureTask.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第９章 Future 補講 concurrent / p311 / List 9-1, 9-2, 9-7
 *         [Java] Callable<T>
 *                Future<T>
 *                FutureTask<T>
 *         [C#]   delegate void ThreadStart()
 *                Task<T>
 *
 *@subject new Threadで行っていた処理を
 *         async修飾子 / await演算子によって再現
 *
 *@subject 非同期処理は Main()において Task.Wait()しているので
 *         FutureDataMT09クラスで、|| Balking ||する必要が無くなる。
 *         FutureDataTaskクラスは 
 *         事前に Task.Wait()してから実行結果を取得することを前提とすると
 *         bool readyDataが不要なので削除。
 *         状態を表す fieldがなくなるので、FutureDataの排他処理も不要。
 *         Multi-Threadを意識したコードが無くなり、シンプルになる。
 */
#region -> (COPY) AsyncSample.cs
/*
 *@subject ◆[C#5-] async修飾子, await演算子
 *         async修飾子の付いたメソッド内でのみ、
 *         await演算子の付く処理を非同期実行。
 *         仮の戻り値だけ返す。
 *         呼出側のスレッドは他の処理に移れる。
 *         その間に別スレッドで await処理を実行中。
 *         
 *         [修飾子] async Task XxxxAsync()
 *         {
 *             await Task.Run(Action<T>);
 *         }
 *         
 *@subject 戻り値がある場合
 *         asyncメソッドの戻り値は Taskなので、
 *         戻り値の型 Tを Task<T>として戻す。
 *         
 *         bool task.IsCompleted Taskが完了しているか
 *         T    task.Result      Task<T>の Tを取得
 */
#endregion
/*
 *@class MainFutureTask
 *       new HostTask()
 *       Task<AbsDataMT09> task1 = host.RequestAsync(int count, char c);
 *       void task.Wait()
 *       AbsDataMT09 task.Result
 *       
 *@class HostTask
 *       + async Task<AbsDataMT09> RequestAsync(int count, char c)
 *       { 
 *         //var future = new FutureDataMT09();
 *         var future = new FutureDataTask();
 *       
 *         await Task.Run(Action<AbsDataMT09>)
 *       }
 *       
 *@class FutureDataTask : AbsDataMT09
 *       / - RealData realData /
 *       GetResult()
 *       SetRealData(RealData)
 *       
 *@see AsyncSample.cs
 *@author shika 
 *@date 2022-03-06
*/
using CsharpBegin.MultiThread.MTCS09_Future.FutureSample;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS09_Future.FutureTask
{
    class MainFutureTask 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            Console.WriteLine("Main() BEGIN");

            //---- RequestAsync ----
            var host = new HostTask();
            Task<AbsDataMT09> task1 = host.RequestAsync(10, 'A');
            Task<AbsDataMT09> task2 = host.RequestAsync(20, 'B');
            Task<AbsDataMT09> task3 = host.RequestAsync(30, 'C');

            //---- Another job ---
            Console.WriteLine("Main() AnotherJob BEGIN");
            try
            {
                Thread.Sleep(2000);
            }
            catch (ThreadInterruptedException) { }
            Console.WriteLine("Main() AnotherJob END");

            //---- Get Reault ----
            task1.Wait();
            Console.WriteLine($"data1 = {task1.Result.GetResult()}");
            task2.Wait();
            Console.WriteLine($"data2 = {task2.Result.GetResult()}");
            task3.Wait();
            Console.WriteLine($"data3 = {task3.Result.GetResult()}");

            Console.WriteLine("Main() END");
        }//Main() 
    }//class 
}

/*
//---- FutureDataMT09 ----
Main() BEGIN
  RequestAsync(10, A) BEGIN
  RequestAsync(20, B) BEGIN
  RequestAsync(30, C) BEGIN
    making RealData(20, B) BEGIN
    making RealData(30, C) BEGIN
Main() AnotherJob BEGIN
    making RealData(10, A) BEGIN
    making RealData(10, A) END
  RequestAsync(10, A) END
Main() AnotherJob END
data1 = AAAAAAAAAA
    making RealData(20, B) END
  RequestAsync(20, B) END
data2 = BBBBBBBBBBBBBBBBBBBB
    making RealData(30, C) END
  RequestAsync(30, C) END
data3 = CCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
Main() END

//---- FutureDataTask ----
Main() BEGIN
  RequestAsync(10, A) BEGIN
  RequestAsync(20, B) BEGIN
  RequestAsync(30, C) BEGIN
    making RealData(20, B) BEGIN
    making RealData(10, A) BEGIN
    making RealData(30, C) BEGIN
Main() AnotherJob BEGIN
    making RealData(10, A) END
  RequestAsync(10, A) END
Main() AnotherJob END
data1 = AAAAAAAAAA
    making RealData(20, B) END
  RequestAsync(20, B) END
data2 = BBBBBBBBBBBBBBBBBBBB
    making RealData(30, C) END
  RequestAsync(30, C) END
data3 = CCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
Main() END
 */
