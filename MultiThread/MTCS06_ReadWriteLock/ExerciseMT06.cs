/**  
 *@title CsharpBegin / MultiThread / MTCS06_ReadWriteLock / ExerciseMT06.cs  
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006  
 *@content 第６章 Read-Write Lock / p219, p522 /6-7, 
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
/*==== Appendix ==== 
 *@date: 2022-02-16 (水) 
 *@time: 04:54 ～ 04:57 (3分) 
 *@rate: 50.00％ (○ 1 問 / 全 2 問) 
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
○ (2) => 〔SafeDictionary / MainDictionary.cs〕 
 
◆〔5〕6-5  
○ (1) || Before/After ||の try{}内に lock()を入れた場合  
× (2) ...  
    => 【Interrupt()の注意点】 
　　　　try{ }内で ReadLock()すると Wait中に Interrupt()されたときに、 
       readingフラグが インクリメントされないまま、 
       finally節に飛び、ReadUnlock()され、readingフラグはデクリメントされる。 
       想定外に readingフラグが減少してしまうことになる。 
        
       Interrupt()は プログラムの応答性を改善させるために利用されるが、 
       コード順によってはプログラムの安全性を壊してしまう可能性がある。 
 
       ReadLock()中に Interrupt()されても大丈夫なように 
       ReadLock()は try-finallyの外に置く。 
       これなら、ReadLock()中に中断されても、 
       インクリメント、デクリメント両方とも起こらず、安全性は保たれる。 
 
◆〔6〕6-6  
○ (1) waitWrite, preferWriteフィールドの意味  
○ (2) Writeが待機している場合に優先的に WriteにLockをまわすためのフィールド  
× (3) これを無くすと、...  
=> ○: waitWrite: Thread数が多く、 
  排他制御がないReaderばかりになってしまう状態を防ぐため、 
  待機中のWriterを計測するフラグがある。 
   
  preferWrite: waitWriteだけだと、今度はWriteばかりが優先される。 
  WriteUnlock()後は Reader優先に戻し、 
  交互に優先度を帰る信号機のようなフラグが必要。 
 
*/  
/*==== Appendix ====  
 *@date: 2022-02-12 (土)  
 *@time: 15:39 ～ 15:55 (16分)  
 *@rate: 80.00％ (○ 12 問 / 全 15 問)  
*/  
/* 
2022-02-16 (水)
==== Exercise Result ==== 
◆〔1〕6-7 
○ (1) × WriteUnlock実行中は、Reader, Writerの両方がwait中である。 
× (2) ○ ReadUnlock()実行中は Writerのみが wait中である。 => ○: waitWriteがある場合は Readerもwait中である 

 => ちなみに、waitしているのは、lock()のあるインスタンス上ではなく、
    ReaderThread, WriterThreadのインスタンス上で一時的に実行を停止している。
    lock()直前の Wait-Setのような待機室を想像しがちだが、それは論理的な概念。

 */ 
/*==== Appendix ==== 
 *@date: 2022-02-16 (水) 
 *@time: 04:54 ～ 04:57 (3分) 
 *@rate: 50.00％ (○ 1 問 / 全 2 問) 
*/ 
