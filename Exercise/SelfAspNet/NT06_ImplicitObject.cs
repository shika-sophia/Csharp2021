/**  
 *@title CsharpBegin / Exercise / SelfAspNet / NT06_ImplicitObject.cs  
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020  
 *@content 第６章 ImplicitObject 組込オブジェクト / p310, p326, p331章末問題 １, ２, ３, ４, 
 *         [英] implicit : 暗黙的 <-> explicit: 明示的 
 *          
 *@subject 練習問題 6-1, 6-2,  
 *  
 *@author shika  
 *@date 2022-05-22  
*/
/*==== Appendix ====  
 *@date: 2022-05-22 (日)  
 *@time: 16:24 ～ 16:38 (15分)  
 *@rate: 81.82％ (○ 9 問 / 全 11 問)  
*/
/*==== Appendix ==== 
 *@date: 2022-05-22 (日) 
 *@time: 16:57 ～ 17:12 (15分) 
 *@rate: 76.47％ (○ 13 問 / 全 17 問) 
*/

namespace CsharpBegin.Exercise.SelfAspNet
{
    class NT06_ImplicitObject  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()  
    }//class  
}
/*  
2022-05-22 (日) 
==== Exercise Result ====  
◆〔1〕第６章 ImplicitObject / 練習問題 6-1  
○ (1) HttpRequest.ServerVariablesを利用すべきでない理由:  
○ (2) パフォーマンス: 内部的な Doctionaryを検索してオブジェクトを取り出すため、専用プロパティよりアクセスが遅くなる。  
○ (3) コードの簡素化: 戻り値をキャストする必要があり、文字列指定するので誤入力に気付きづらい(=開発生産性)  
○ (4) ２. Query情報: RequestUrlに付記して「?xxxx=値&yyyy=値」のようにパラメーターを送信する仕組み  
○ (5) 制約: URL欄にQuery情報が露出する。  
○ (6) POSTデータは RequestBodyに記述するため、データが露出しない。  
× (7) あと２つ...  
  => ○: 送信できる文字数に制限がある。 
        利用できない文字がある。  
 
◆〔2〕6-2  
○ (1) HTTP Status: Requestの処理状況をクライアントに通知するコード。成功/エラー。エラーならどんなエラーか  
○ (2) ResponseHeader: HTTP Statusや、ResponseContentの付随情報(Encoding, Length, ContentType)をクライアントに通知  
× (3) Response.Write()は利用すべきでない理由:  
  => ○: 出力レイアウトが、プログラムコード側でのみ決定されている。  
     レイアウトとコードが混在するのは望ましくない。 
     Literal, Labelを用いるべき 
 
○ (4) 出力はサーバーコントロールで行うことで、ASP.NETに最適化される？ 
      特にHTML自動生成など？  
  => そういう点は ありうるが、重要な理由は上記。 
 
*/
/*==== Appendix ====  
 *@date: 2022-05-22 (日)  
 *@time: 16:24 ～ 16:38 (15分)  
 *@rate: 81.82％ (○ 9 問 / 全 11 問)  
*/
/* 
2022-05-22 (日)
==== Exercise Result ==== 
◆〔1〕章末問題 １ 
○ (1) ○: Query情報には文字数制限がある。 
○ (2) ×: POSTデータは URL欄には露出しないが、Requestデータを見ると露出しているので、安全とは言えない 
○ (3) ×: Reqest.Formは HTML<form>を受け取るプロパティ。サーバーコントロールを利用すべき 
○ (4) ×: Response.Write()は 出力レイアウトがプログラム側のみにあるので、避けるべき。 
○ (5) ×: Server.Transfer()は利用すべきではない。 
○ (6) パフォーマンスはいいが、Server内の pathにしか飛べない。 

◆〔2〕２ 
× (1) Trace機能で参照できる情報: 
× (2) StackTrace, ExceptionType, ... 

*  => ◆Trace機能で参照できる情報
*     Request時間
*     Encoding
*     HTTP Status
*     StackTrace
*     Tree of Control
*     Control visual size
*     ViewState data size
*     SessionState
*     ApplicationState
*     CookieCollection
*     HeaderCollection
*     FormCollection
*     QueryString Collection
*     Server variables

◆〔3〕３ 
○ (1) Response.Redirect(Server.MapPath("Next.aspx")); 
× (2) ltr.Text = Request.QueryStrings["id"]; 
  => ○: QueryString 「s」なし
× (3) Trace... 
  => ○: Trace.Warn(string); 
○ (4) Response.ContentType = "text/xml"; 
○ (5) Server.MapPath("~/Chap06/Text.aspx"); 

◆〔4〕４ 
○ (1) Dictionary<string,string> 
○ (2) Add() 
○ (3) DataSource 
○ (4) Page.DataBind(); 
*/
/*==== Appendix ==== 
 *@date: 2022-05-22 (日) 
 *@time: 16:57 ～ 17:12 (15分) 
 *@rate: 76.47％ (○ 13 問 / 全 17 問) 
*/
