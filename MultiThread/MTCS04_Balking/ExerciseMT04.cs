/** 
 *@title CsharpBegin / MultiThread / MTCS04_Balking / ExerciseMT04.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第４章 Balking / 練習問題 4-1, 4-2, 4-3, 4-4, 4-5, 
 * 
 *@author shika 
 *@date 2022-01-01 
*/ 
/*==== Appendix ==== 
 *@date: 2022-01-01 (土) 
 *@time: 13:39 ～ 13:53 (14分) 
 *@rate: 88.89％ (○ 8 問 / 全 9 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS04_Balking 
{ 
    class ExerciseMT04 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
    }//class 
} 
/* 
2022-01-01 (土)
==== Exercise Result ==== 
◆〔1〕第４章 Balking / 練習問題 4-1 
○ (1) × CheckSave()は SaveThread, ChangeThreadから 
○ (2) × volatileに排他制御の機能はない。 
○ (3) × どちらでも良い。このメソッド終了後に lock()が解放されるので 
○ (4) Sava()は CHeckSave()からのみ呼び出され、Flagを参照/変更しないため、 
× (5) ○ CheckSave()が lock()されている。 => ○: private Save()であることも重要 

◆〔2〕4-2 
○ (1) (in another file) => MainFileSaveBalking.cs

◆〔3〕4-3 
○ (1) (omitted) 

◆〔4〕4-4 
○ (1) (in another directory) 

◆〔5〕4-5 
○ (1) Thread.Start()は１回のみ。すでにStart()させているThreadを再スタートさせているから 
*/ 
/*==== Appendix ==== 
 *@date: 2022-01-01 (土) 
 *@time: 13:39 ～ 13:53 (14分) 
 *@rate: 88.89％ (○ 8 問 / 全 9 問) 
*/ 
