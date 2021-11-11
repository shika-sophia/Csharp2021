/** 
 *@title CsharpBegin / MultiThread / AsyncSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content Asyncメソッド / C# p530 / List 11-5, 11-6
 *         非同期実行: メソッド呼出と実行の分離
 *                    仮の戻り値だけ返す。
 *                    呼出側のスレッドは他の処理に移れる。
 *         
 *         同期処理: 通常のメソッド呼出は、呼出と同時に実行。
 *                  呼出側は実行完了まで待たされる。
 *     
 *@subject ◆[C#5-] async修飾子, await演算子
 *         async修飾子の付いたメソッド内でのみ、
 *         await演算子の付く処理を非同期実行。
 *         仮の戻り値だけ返す。
 *         呼出側のスレッドは他の処理に移れる。
 *         その間に別スレッドで await処理を実行中。
 *         => 下記【考察】参照
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
 *         
 *@subject ◆System.Diagostics.StopWatchクラス
 *         StopWatch StopWatch.StartNew() //new + Start()
 *         StopWatch new StopWatch()      //コンストラクタ
 *         void      stopwatch.Start()
 *         void      stopwatch.Stop()
 *         TimeSpan  stopwatch.Elapsed    //時間差を取得
 *         
 *@subject ◆System.Threading.Threadクラス
 *         void Thread.Sleep(long millisecond) //現在のスレッドを待機
 *         
 *@author shika 
 *@date 2021-11-11 
*/
using System; 
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread 
{ 
    class AsyncSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            Console.WriteLine("Main(): start");
            //==== 戻り値がない場合 ====
            //---- insatance ----
            var here = new AsyncSample();
            Task t = here.RunAsync();

            //---- static ---- 
            //各メソッドに staticを付与して実行
            //Task t = RunAsync();

            Console.WriteLine($"Main(): another operation");
            t.Wait();

            Console.WriteLine("Main(): end");
            Console.WriteLine();

            //==== 戻り値がある場合 ====
            Task<TimeSpan> taskRe = here.RunReturnAsync();
            
            //Main()での別の処理
            while (!taskRe.IsCompleted)
            {
                Console.Write(".");
                taskRe.Wait(200);
            }

            //Task<TimeSpan>完了時の処理
            Console.WriteLine(
                $"Result Millisecond: {taskRe.Result.TotalMilliseconds}");
            Console.WriteLine("Main(): end");
        }//Main() 

        //====== 戻り値がない場合 ======
        private async Task RunAsync()
        {
            Console.WriteLine($"{nameof(RunAsync)}(): called");
            await Task.Run(() => ShowCount(1));
            Console.WriteLine($"{nameof(RunAsync)}(): operation end");
        }
        
        private void ShowCount(int num)
        {
            for(int i = 0; i < 50; i++)
            {
                Console.WriteLine($"Task{num}: {i}");
            }
        }

        //====== 戻り値がある場合 ======
        private async Task<TimeSpan> RunReturnAsync()
        {
            Console.WriteLine($"{nameof(RunReturnAsync)}(): called");
            Stopwatch sw = Stopwatch.StartNew();
            await Task.Run(() =>
            {
                //重い処理
                Thread.Sleep(2000);
            });
            sw.Stop();
            Console.WriteLine($"\n{nameof(RunReturnAsync)}(): operation end");

            return sw.Elapsed;
        }//RunReturnAsync()

    }//class 
}

/*
【考察】async, await
メソッド call時に即時 制御を Main()に戻すわけではなくて
少しだけ await処理も行う。
途中でやめて、Main()に制御を戻し、
task.Wait()時に また await処理を再開する。

いつ Main()に戻すかは毎回違う。
instanceメソッドと staticメソッドの違いは、ほとんどない。

【実行結果】
//==== 戻り値がない場合 ====
//---- instance async ----
Main(): start
RunAsync(): called
Task1: 0
Task1: 1
Task1: 2
Task1: 3
Task1: 4
Task1: 5
Task1: 6
Task1: 7
Task1: 8
Task1: 9
Task1: 10
Main(): another operation.
Task1: 11
Task1: 12
Task1: 13
  :
Task1: 47
Task1: 48
Task1: 49
RunAsync(): operation end
Main(): end

//---- static async ----
Main(): start
RunAsync(): called
Task1: 0
Task1: 1
Task1: 2
Task1: 3
Task1: 4
Task1: 5
Task1: 6
Task1: 7
Main(): another operation.
Task1: 8
Task1: 9
Task1: 10
Task1: 11
Task1: 12
  :
Task1: 47
Task1: 48
Task1: 49
RunAsync(): operation end
Main(): end

//==== 戻り値がある場合 ====
RunReturnAsync(): called
..........        ← Main()での処理
RunReturnAsync(): operation end
Result Millisecond: 2003.21
Main(): end
 */