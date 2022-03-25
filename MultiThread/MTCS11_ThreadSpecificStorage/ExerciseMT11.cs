/** 
 *@title CsharpBegin / MultiThread / MTCS11_ThreadSpecificStorage / ExerciseMT11.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第11章 Thread Specific Storage / 練習問題 11-1, 11-2, 11-3, 11-4, 11-5, 11-6, 
 * 
 *@author shika 
 *@date 2022-03-24 
*/ 
/*==== Appendix ==== 
 *@date: 2022-03-24 (木) 
 *@time: 10:13 ～ 10:42 (29分) 
 *@rate: 83.33％ (○ 15 問 / 全 18 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS11_ThreadSpecificStorage 
{ 
    class ExerciseMT11 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
    }//class 
}
/* 
2022-03-24 (木)
==== Exercise Result ==== 
◆〔1〕第11章 Thread Specific Storage / 練習問題 11-1 
○ (1) ×ThreadLocalは staticのためインスタンスを生成しない。
○ (2) ○FileStream, StreamWriterは３つのインスタンスを生成 
○ (3) ○thLocal.Value = logWriter;は3回 
× (4) ×thLocal.Valueは6回
   => ○: WriteLog()×10×３Thread, WriteFinish()×３Thread = 計33回 
○ (5) ○LogWriterSpecificは３つのインスタンス 
× (6) ×LogLocalStorageは１つのインスタンス
  => ○: staticメソッドの利用のため１つも生成されない 

◆〔2〕11-2 
○ (1) LogWriterSpecificの WriteLog(),WriteFinish()は
      Thread固有のオブジェクトのため、ひとつのThreadからしか呼び出されない 
○ (2) LogLocalStorageの ThreadLocalフィールド内に
      排他制御が内部化されているから 

◆〔3〕11-3 
○ (1) ClientThread内で WriteFinish()を自動化 
○ (2) 別フォルダ => 〔./AutoTermination〕

◆〔4〕11-4 
○ (1) ClientThreadのコンストラクタは MainThread呼出なので、
      log_MainThreahread.txtに記入されている。 

◆〔5〕11-5 
○ (1) java.lang.Threadの固有情報 -- currentThread, Name
  => ◆java.lang.Threadの固有情報を得るメソッド
     currentThread(), getName(), 
     getPriority(), getThreadGroup(), isInterrupted(),
     isDamon(), isAlive(), getId(), getState(), 
     getUncaughtExceptionHandler()
     それぞれ対応するフィールドで保持している。

◆〔6〕11-6 
○ (1) WorkerThreadパターンとの併用不可 
○ (2) ExecutorServiceのThreadPoolは 3つのThreadで 
○ (3) 仕事が完了したら他の仕事をする仕組み 
○ (4) ThreadSpecificStorageはThreadごとの記憶領域なので 
○ (5) 3つのThreadから呼ばれて仕事をしたら close()する 
× (6) 2回目以降は...? 
  => ○: 後述 
*/
/*==== Appendix ==== 
 *@date: 2022-03-24 (木) 
 *@time: 10:13 ～ 10:42 (29分) 
 *@rate: 83.33％ (○ 15 問 / 全 18 問) 
*/
