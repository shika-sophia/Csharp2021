/** 
 *@title CsharpBegin / MultiThread / MTCS09_Future / ExerciseMT09.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第９章 Future / 練習問題 9-1, 9-2, 9-3, 9-4, 
 * 
 *@author shika 
 *@date 2022-03-07 
*/ 
/*==== Appendix ==== 
 *@date: 2022-03-07 (月) 
 *@time: 13:14 ～ 13:32 (18分) 
 *@rate: 86.67％ (○ 13 問 / 全 15 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS09_Future 
{ 
    class ExerciseMT09 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
 
    }//class 
} 
/* 
2022-03-07 (月)
==== Exercise Result ==== 
◆〔1〕第９章 Future / 練習問題 9-1 
○ (1) ○ Request()で new Threadが起動 
○ (2) ○ Request()の戻り値型は AbsDataMT09だが、 
○ (3) 実際の戻り値は FutureDataインスタンスである。 
○ (4) × SetRealData()を呼び出すのは MainThreadではなく、Request()で生成した new Threadである。 
× (5) × MainThreadは future.GetResult()  => ○: 実行するのは MainThreadである。 
○ (6) -> future.GetResult()が RealData.GetResult()を呼出。 
× (7) × Request()は MainThreadからしか呼び出されないので lock()不要。
   => ○: クラスの状態を表すFieldを持たないため、lock()不要。
         int count, char cは ローカル変数のため、
         Request()を呼び出したMainThreadしかアクセスできない。

◆〔2〕9-2 
○ (1) MainThread以外に、３つのThreadが作成される。 
○ (2) new Threadは RealDataインスタンスを生成し、 
○ (3) RealDataのコンストラクタで resultの生成開始、 
○ (4) FutureDataに realDataインスタンスを登録す。 

◆〔3〕9-3 
○ (1) URLからWebコンテンツを取得するプログラム 
○ (2) => 別フォルダ 

◆〔4〕9-4 
○ (1) Futureパターンでの例外処理 
○ (2) => 別フォルダ 
*/ 
/*==== Appendix ==== 
 *@date: 2022-03-07 (月) 
 *@time: 13:14 ～ 13:32 (18分) 
 *@rate: 86.67％ (○ 13 問 / 全 15 問) 
*/ 
