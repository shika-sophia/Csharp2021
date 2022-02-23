/** 
 *@title CsharpBegin / MultiThread / MTCS07_ThreadPerMessage / ExerciseMT07.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第７章 ThreadPerMessage / p252, p533
 *@subject 練習問題 7-1, 7-2, 7-3, 7-4, 7-5, 7-6, 7-7, 7-8, 
 * 
 *@author shika 
 *@date 2022-02-20 
*/
/*==== Appendix ==== 
 *@date: 2022-02-20 (日) 
 *@time: 15:45 ～ 16:08 (23分) 
 *@rate: 85.00％ (○ 17 問 / 全 20 問) 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage 
{ 
    class ExerciseMT07 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor("MT 第７章 ThreadPerMessage / "); 
        }//Main()  
    }//class 
}
/* 
2022-02-20 (日)
==== Exercise Result ==== 
◆〔1〕練習問題 7-1 
○ (1) ○ request()のたびに新しいThreadが起動 
○ (2) × new HelperMT07()は RequestMT07インスタンス生成時の一度だけ 
○ (3) × request()中のnew Threadで helper.handle()を呼出 
○ (4) × handle()の文字表示は 各request()で生成した new Thread 
○ (5) × Helper.Slowly()は new Threadが待機、request()を呼び出したMain Threadはすぐに戻る。 

◆〔2〕7-2 
○ (1) ThreadPerMessageを利用しないコード 
○ (2) => 別フォルダ 〔SingleThreadHostHelper/HostSingle.cs〕

◆〔3〕7-3 
○ (1) new Thread{ run() }.run(); 
× (2) ThreadはStart()しない。Thread.run()はメソッドを呼び出しただけであるから
  => ○: SingleThreadと同様に MainThreadで処理される 
  => 〔SingleThreadHostHelper/HostThreadRun.cs〕

◆〔4〕7-4 
○ (1) 匿名クラス(= 無名インナークラス)を使わずに、 
○ (2) HelperThreadを記述。 
○ (3) => 別フォルダ 〔SingleThreadHostHelper/HostThreadRun.cs〕 

◆〔5〕7-5 
○ (1) Swing利用の問題 
× (2) C#でどう再現しようか考える
  => 別フォルダ 〔ResponseGUI/MainResponseGUI.cs〕

◆〔6〕7-6 
○ (1) MultiThread対応の Server programに修正 
○ (2) => 別フォルダ 〔MiniServer/MainMiniServer.cs〕

◆〔7〕7-7 
○ (1) BlackHole.magic()の記述 
○ (2) => 別フォルダ 

◆〔8〕7-8 
○ (1) Executor(){ execute(Runnable) }.execute(Runnable){ run() } 
× (2) これで、どちらが実行されるのだろう？ => ○: 解 それぞれが実行される。別解プログラムを参照 
*/
/*==== Appendix ==== 
 *@date: 2022-02-20 (日) 
 *@time: 15:45 ～ 16:08 (23分) 
 *@rate: 85.00％ (○ 17 問 / 全 20 問) 
*/
