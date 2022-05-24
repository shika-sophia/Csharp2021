
/**  
 *@title CsharpBegin / Exercise / SelfAspNet / NT07_StateVariable.cs  
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020  
 *@content NT 第７章 StateVariable / p342, p351, p355, p373 
 * 
 *@subject 練習問題 7-1, 7-2, 7-3,  
 *@subject 章末問題 １, ２, ３, ４, ５, 
 *
 *@author shika  
 *@date 2022-05-23  
*/
/*==== Appendix ====  
 *@date: 2022-05-23 (月)  
 *@time: 13:22 ～ 13:30 (8分)  
 *@rate: 50.00％ (○ 4 問 / 全 8 問)  
*/
/*==== Appendix ==== 
 *@date: 2022-05-24 (火) 
 *@time: 16:35 ～ 16:51 (16分) 
 *@rate: 56.25％ (○ 18 問 / 全 32 問) 
*/

namespace CsharpBegin.Exercise.SelfAspNet 
{ 
    class NT07_StateVariable  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
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
/* 
2022-05-24 (火)
==== Exercise Result ==== 
◆〔1〕章末問題 １ 
○ (1) Application 
× (2) Cache => ○: データキャッシュ 
○ (3) Request 
○ (4) Response 
× (5) Page.Server => ○: Web Server 
○ (6) Session 
○ (7) Trace 
○ (8) User 
○ (9) ViewState 

◆〔2〕２ 
○ (1) × HTTPはステートレス。状態を保存しないので、Cookie, Sessionなどを用いて状態維持。 
○ (2) × Cookieはクライアントで保持し、削除・改竄の危険があり、ネット上をデータが流れるのでSessionより危険 
× (3) × Applicationを DB保存する意味はない？
  => ○: Application変数は メモリに保存される 
○ (4) × Session.Abandon() / <sessionSetteing> timeout="" 
○ (5) × ViewStateはポストバック間で保持。Redirect間では保持不可。 

◆〔3〕３ 
○ (1) クライアント 
○ (2) 文字列 
× (3) サーバー => ○: クライアント 
○ (4) クライアント 
× (5) 同一デバイス => ○: 現在のユーザー 
○ (6) オブジェクト 
× (7) Profile => ○: Application変数 

◆〔4〕４ 
× (1) ? => ○: InProc インプロセス 
○ (2) 不向き 
× (3) ？ => ○: 異なるプロセス 
○ (4) 掛かり 
× (5) StateSql => ○: SQLServer 
○ (6) 掛かる 

◆〔5〕５ 
× (1) system.web => ○: caching
× (2) Caches => ○: outputCacheProfiles 
× (3) Duration => ○: duration 
× (4) Cache  => ○: OutputCache 
× (5) Cache => ○: CacheProfile 
*/ 
/*==== Appendix ==== 
 *@date: 2022-05-24 (火) 
 *@time: 16:35 ～ 16:51 (16分) 
 *@rate: 56.25％ (○ 18 問 / 全 32 問) 
*/ 
