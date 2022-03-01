/** 
 *@title CsharpBegin / MultiThread / MTCS08_WorkerThread / ExerciseMT08.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第８章 WorkerThread / 練習問題 8-1, 8-2, 8-3, 8-4, 8-5, 8-6, 
 * 
 *@author shika 
 *@date 2022-03-01 
*/ 
/*==== Appendix ==== 
 *@date: 2022-03-01 (火) 
 *@time: 15:17 ～ 15:33 (16分) 
 *@rate: 76.47％ (○ 13 問 / 全 17 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS08_WorkerThread 
{ 
    class ExerciseMT08 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
    }//class 
} 
/* 
2022-03-01 (火)
==== Exercise Result ==== 
◆〔1〕第８章 WorkerThread / 練習問題 8-1 
× (1) ○ Requestが 1つもないとき Workerは Sleep() => ○: Channelインスタンス上で Wait()〔×Sleep()ではない〕 
× (2) ○ Channel.queueへのアクセスは lock() => ○: ClientThreadの Execute()は複数Threadで起こりうる。 
○ (3) ○ PutRequest()を呼び出すのは ClientThreadのみ 
○ (4) ○ TakeRequest()を呼び出すのは WorkerThreadのみ 
× (5) ○ Channelをlock()しているので、Request.Execute()を lock()する必要はない。 => ○: Request.Execute()するのは lock()内なので、常に１つのThread 

◆〔2〕8-2 
○ (1) Channelを Thread per Messageに修正 
○ (2) => 略 

◆〔3〕8-3 
○ (1) ||Thread per Message||と||WorkerThread||で ThroughPut(=起動時のOverhead)の違いを計測 
○ (2) => 別フォルダ 

◆〔4〕8-4 
○ (1) SwingUtilities.invokeAndWait()を EventDispatchingThreadから呼んではいけない理由 
○ (2) invokeAndWait()はメソッド呼出・実行完了まで制御は戻らない同期実行のためのメソッド 
× (3) EventDispatchingThreadは非同期実行メソッドを呼び出して、
      EventQueueの停滞を防ぐ必要がある。
      => ○: 生存性が失われる。= 単なる停滞ではない。
         EventQueueの全てを処理してからでないと、
         EventDispatchingThreadは invokeAndWait()から戻れず、
         java.lang.Errorを throwされる。

◆〔5〕8-5 
○ (1) GUI - Swingへの応用 
○ (2) => System.Windows.Forms.Formクラス 
○ (3) => 別フォルダ〔〕 

◆〔6〕8-6 
○ (1) WorkerThreadの停止コード 
○ (2) => 別フォルダ〔〕 
*/ 
/*==== Appendix ==== 
 *@date: 2022-03-01 (火) 
 *@time: 15:17 ～ 15:33 (16分) 
 *@rate: 76.47％ (○ 13 問 / 全 17 問) 
*/ 
