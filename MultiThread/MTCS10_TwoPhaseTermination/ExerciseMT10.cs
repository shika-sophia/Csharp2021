/** 
 *@title CsharpBegin / MultiThread / MTCS10_TwoPhaseTermination / ExerciseMT10.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第10章 TwoPhaseTermination / p352, p575
 *         練習問題 10-1, 10-2, 10-3, 10-4, 10-5, 10-6, 10-7, 10-8, 
 * 
 *@author shika 
 *@date 2022-03-17 
*/ 
/*==== Appendix ==== 
 *@date: 2022-03-17 (木) 
 *@time: 13:34 ～ 13:55 (21分) 
 *@rate: 75.00％ (○ 12 問 / 全 16 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS10_TwoPhaseTermination 
{ 
    class ExerciseMT10 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
    }//class 
} 
/* 
2022-03-17 (木)
==== Exercise Result ==== 
◆〔1〕第10章 TwoPhaseTermination / 練習問題 10-1 
○ (1) ○ Shutdown()を呼び出しているのは MainThread 
○ (2) × DoWork()は各Threadから何回も呼び出している 
○ (3) ○ Interrupt()時も finally節中の DoShutdown()は必ず呼出 
× (4) ○ Shutdown()内の Interrupt()は MainThreadの停止であるから、
    Thread.CurrentThread.Interrupt()も同義
    => ○: this.Interrupt()と同義 
    どのThreadが呼び出しても、このインスタンスに Interrupt()が掛かる

◆〔2〕10-2 
× (1) Interrupt状態の変化 => [C#]適用不可

◆〔3〕10-3 
○ (1) ファイル保存 => 別フォルダ 

◆〔4〕10-4 
○ (1) TempleteMethod => 別フォルダ 

◆〔5〕10-5 
○ (1) GUIへの応用 => 後日 

◆〔6〕10-6 
○ (1) volatileの意味 
○ (2) bool shutdownedReq がvolatileなのは 
○ (3) メモリキャッシュに残る従前の値を参照することなく 
○ (4) 常に新しい値をメモリからロードして、値の変更に敏感に反応するため 

◆〔7〕10-7 
○ (1) ハノイの塔 => 別フォルダ 

◆〔8〕10-8 
○ (1) パズル 
× (2) ５秒間「.」が続き、Interrput()時に「*」が表示され、 => ○: ... 
× (3) Interrupt状態は解消し、再び「.」が続く
    => ○: [Java] isInterrupted()は Interrupt状態をクリアにしない
       「........*********」となる。
*/ 
/*==== Appendix ==== 
 *@date: 2022-03-17 (木) 
 *@time: 13:34 ～ 13:55 (21分) 
 *@rate: 75.00％ (○ 12 問 / 全 16 問) 
*/ 
