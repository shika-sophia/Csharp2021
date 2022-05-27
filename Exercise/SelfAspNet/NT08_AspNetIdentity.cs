/**  
 *@title CsharpBegin / Exercise / SelfAspNet / NT08_AspNetIdentity.cs  
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020  
 *@content NT 第８章 ASP.NET Identity / p384, p423
 * 
 *@subject 練習問題 8-1,  
 *@subject 章末問題 １, ２, ３, 
 *
 *@author shika  
 *@date 2022-05-27, 05-28
*/
/*==== Appendix ====  
 *@date: 2022-05-27 (金)  
 *@time: 03:01 ～ 03:06 (5分)  
 *@rate: 80.00％ (○ 4 問 / 全 5 問)  
*/

/*==== Appendix ==== 
 *@date: 2022-05-27 (金) 
 *@time: 03:30 ～ 03:40 (10分) 
 *@rate: 64.29％ (○ 9 問 / 全 14 問) 
*/
namespace CsharpBegin.Exercise.SelfAspNet 
{ 
    class NT08_AspNetIdentity  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()   
    }//class  
}
/*  
2022-05-27 (金) 
==== Exercise Result ====  
◆〔1〕第８章 ASP.NET Identity / 練習問題 8-1  
○ (1) PasswordValidator:  
○ (2) ８文字以上、特殊記号とアルファベット大文字を１文字以上  
○ (3) RequireLength="8"  
× (4) RequireNonLetterOrDigit="true" 
  => ○:  テキスト参照して回答 
○ (5) RequireUpperCase="true"  
 
【解答の解説】 
プロパティを全て記憶する必要はないが、 
パスワード認証にどのような制約を課すことができるかを知っておくことは大事。 
*/
/*==== Appendix ====  
 *@date: 2022-05-27 (金)  
 *@time: 03:01 ～ 03:06 (5分)  
 *@rate: 80.00％ (○ 4 問 / 全 5 問)  
*/
/* 
2022-05-27 (金)
==== Exercise Result ==== 
◆〔1〕章末問題 １ 
○ (1) ASP.NET Identityの特徴: 
× (2) Mail機能, => ○: 後述 
○ (3) ２段階認証 
○ (4) SNS連携ユーザー登録に対応 
○ (5) Membership Frameworkの後身: LoginContorolなど 

◆ASP.NET Identity の特徴
・Twitter/Facebook/MicrosoftAccount などのソーシャルアカウントと連携可
・２段階認証/アカウント確認に対応。
・ASP.NET MVC, ASP.NET Web API でも同じコードで利用可
・インターフェイスで構成され、スタブ／モックによる差し替えも可
・Entity Frameworkに対応していれば、SQL Server以外のDB, DataStoreも利用可
・データモデルの修正だけで、プロファイル情報を拡張可

=> COPY to〔SelfAspNet\NT08_AspNetIdentity\SampleUser\SampleUser.txt〕

◆〔2〕２ 
× (1) ○ Identityでは LoginControlを利用不可 
  => ○: Login, PasswordRecoveryなどは利用不可だが、
     LoginName, LoginView, LoginStatusなどは利用可 
× (2) × ApplicationUserクラスに Urlプロパティを追加
  => ○: IdentityUserクラス 
× (3) ？アカウント確認の挙動 
  => ◆アカウント確認機能:
     Users_tbに、EmailConfirmedのフラグを立てるだけでいい。
     アカウントの有無で動作を分岐させるには、
     bool IsEmailConfirmed を利用

○ (4) × ２段階認証では TEL番(= SMS) or メールアドレスが必要 
○ (5) × Profile機能は事前にデータモデルを決めておく必要があるので、
        不特定項目には不向き 

◆〔3〕３ 
○ (1) location 
× (2) files 
  => ○: path="" 
○ (3) allow roles="Admin" 
○ (4) deny users="*" 
*/
/*==== Appendix ==== 
 *@date: 2022-05-27 (金) 
 *@time: 03:30 ～ 03:40 (10分) 
 *@rate: 64.29％ (○ 9 問 / 全 14 問) 
*/
