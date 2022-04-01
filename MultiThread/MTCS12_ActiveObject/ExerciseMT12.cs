/** 
 *@title CsharpBegin / MultiThread / MTCS12_ActiveObject / ExerciseMT12.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第12章 ActiveObject / 練習問題 12-1, 12-2, 12-3, 
 * 
 *@author shika 
 *@date 2022-04-01 
*/ 
/*==== Appendix ==== 
 *@date: 2022-04-01 (金) 
 *@time: 11:40 ～ 11:55 (15分) 
 *@rate: 100.00％ (○ 13 問 / 全 13 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS12_ActiveObject 
{ 
    class ExerciseMT12 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
    }//class 
} 
/* 
2022-04-01 (金)
==== Exercise Result ==== 
◆〔1〕第12章 ActiveObject / 練習問題 12-1 
○ (1) ○ Proxy, Servantは AbsAcitveObjectを継承 
○ (2) × MakerThreadの MakeString()は Proxyクラスの MakeString() 
○ (3) × DisplayString()のたびに new DisplayStringRequest 
○ (4) ○ Servantは排他制御が必要。サンプルでは１つのThreadのみが利用するので排他制御していない。 
○ (5) ○ Schedule.PutRequest()は複数Threadに呼び出される 
○ (6) × Schedule.TakeRequest()は ScheduleThreadからのみ 
○ (7) ○ ClientThreadが future.GetResultValue()時に resultが作られていない場合 Wait() 
○ (8) ○ Servant.MakeString()は文字列が長いほど時間が掛かる 
○ (9) × Futureパターンにより、countに関係なく制御はすぐに戻る 

◆〔2〕12-2 
○ (1) メソッドの追加 
○ (2) => 別フォルダ〔〕 

◆〔3〕12-3 
○ (1) GUIへの応用 
○ (2) => 後日 
*/ 
/*==== Appendix ==== 
 *@date: 2022-04-01 (金) 
 *@time: 11:40 ～ 11:55 (15分) 
 *@rate: 100.00％ (○ 13 問 / 全 13 問) 
*/ 
