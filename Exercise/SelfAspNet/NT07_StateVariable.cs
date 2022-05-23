/** 
 *@title CsharpBegin / Exercise / SelfAspNet / NT07_StateVariable.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020 
 *@content NT 第７章 StateVariable / p342, p351, p355, p373
 *
 *@subject 練習問題 7-1, 7-2, 7-3, 
 * 
 *@author shika 
 *@date 2022-05-23 
*/
/*==== Appendix ==== 
 *@date: 2022-05-23 (月) 
 *@time: 13:22 ～ 13:30 (8分) 
 *@rate: 50.00％ (○ 4 問 / 全 8 問) 
*/

namespace CsharpBegin.Exercise.SelfAspNet
{
    class NT07_StateVariable 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
    }//class 
} 
/* 
2022-05-23 (月)
==== Exercise Result ==== 
◆〔1〕第７章 StateVariable / 練習問題 7-1 
× (1) Cookie: クライアント側で保存する接続情報の文字列 => ○: 一度入力した内容やアクセス回数などを保存 
○ (2) var cookie = new HttpCookie("name", "value"); 
○ (3) cookie.Expires = Datatime.Now.AddMonths( 1 ); 
○ (4) Response.AppendCookie(cookie); 

◆〔2〕7-2 
× (1) Cookieはクライアント側で保存するので漏洩などの危険性がある。
  => ○: ユーザーによる改竄・削除も 
  => ○: データがネット上を流れるので、漏洩の可能性 
× (2) Cookieは文字列のみ、Sessionはオブジェクト
  => Sessionはサーバー側で管理し、ネット上で渡すのは sessionIDのみ

× (3) ２. Session.Abandon() / Session.Timeout
  => ○: <sessionState> timeout="" 

◆〔3〕7-3 
○ (1) ViewState < Session < Application 
*/ 
/*==== Appendix ==== 
 *@date: 2022-05-23 (月) 
 *@time: 13:22 ～ 13:30 (8分) 
 *@rate: 50.00％ (○ 4 問 / 全 8 問) 
*/ 
