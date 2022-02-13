/** 
 *@title CsharpBegin / MultiThread / MTCS06_ReadWriteLock / ExerciseMT06.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第６章 Read-Write Lock / p219, p522 /
 *@subject 練習問題 6-1, 6-2, 6-3, 6-4, 6-5, 6-6, 6-7
 * 
 *@author shika 
 *@date 2022-02-12 
*/ 
/*==== Appendix ==== 
 *@date: 2022-02-12 (土) 
 *@time: 15:39 ～ 15:55 (16分) 
 *@rate: 80.00％ (○ 12 問 / 全 15 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock 
{ 
    class ExerciseMT06 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
    }//class 
} 
/* 
2022-02-12 (土)
==== Exercise Result ==== 
◆〔1〕第６章 Read-Write Lock / 練習問題 6-1 
○ (1) ○ DoWrite()は１つのThreadのみ実行 
○ (2) × DoRead()は複数Threadで実行可 
○ (3) ○ DoWrite()中は readingReadersは 0 
× (4) × DoRead()中は waitWrite は 0でない
      => ○: DoRead()中に 書く処理を行うThreadはいない 

◆〔2〕6-2 
○ (1) lock()を利用しないとデータレースを起こし、 
○ (2) AAAAcccccなど途中で charが変わってしまう可能性がある。 

◆〔3〕6-3 
○ (1) synchronizedを利用した場合とのパフォーマンス比較 
○ (2) => 〔Performance / MainPerformance.cs〕

◆〔4〕6-4 
○ (1) Databaseクラスに Concurrentの ReaderWriterLockクラスを導入 
○ (2) => 別紙 

◆〔5〕6-5 
○ (1) || Before/After ||の try{}内に lock()を入れた場合 
× (2) ... => ○: 後述 

◆〔6〕6-6 
○ (1) waitWrite, preferWriteフィールドの意味 
○ (2) Writeが待機している場合に優先的に WriteにLockをまわすためのフィールド 
× (3) これを無くすと、... => ○: 後述 
*/ 
/*==== Appendix ==== 
 *@date: 2022-02-12 (土) 
 *@time: 15:39 ～ 15:55 (16分) 
 *@rate: 80.00％ (○ 12 問 / 全 15 問) 
*/ 
