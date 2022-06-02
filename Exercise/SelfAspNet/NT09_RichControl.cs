/**  
 *@title CsharpBegin / Exercise / SelfAspNet / NT09_RichControl.cs  
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020  
 *@content NT 第９章 RichControl / p448, p460, p465, p471 / p481
 * 
 *@subject 練習問題 9-1, 9-2, 9-3, 9-4,  
 *@subject 章末問題 １, ２, ３, ４, 
 *
 *@author shika  
 *@date 2022-06-01, 06-02
*/
/*==== Appendix ====  
 *@date: 2022-06-01 (水)  
 *@time: 16:17 ～ 16:26 (9分)  
 *@rate: 57.89％ (○ 11 問 / 全 19 問)  
*/
/*==== Appendix ==== 
 *@date: 2022-06-02 (木) 
 *@time: 14:54 ～ 15:11 (17分) 
 *@rate: 63.64％ (○ 7 問 / 全 11 問) 
*/

namespace CsharpBegin.Exercise.SelfAspNet
{
    class NT09_RichControl  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()   
    }//class  
}
/*  
2022-06-01 (水) 
==== Exercise Result ====  
◆〔1〕第９章 RichControl / 練習問題 9-1  
× (1) name => ○: defaultProvider  
○ (2) MySiteMap  
○ (3) type  
× (4) Web.sitemap => ○: My.sitemap  
 
◆〔2〕9-2  
○ (1) e.Exception  
○ (2) true  
× (3) SiteMapNode => ○: MailMessage  
○ (4) SmtpClient  
○ (5) Send()  
 
◆〔3〕9-3  
× (1) PrevousView => ○: PrevView  
× (2) SwitchViewById(string id) => ○: SwitchViewByID  
○ (3) index値  
 
◆〔4〕9-4  
○ (1) DataView  
○ (2) Select  
× (3) e.Day.DateString => ○: e.Day.Date  
× (4) schedule.Row? => ○: schedule  
○ (5) ltr.Text  
○ (6) e.Cell.Controrls.Add(ltr);  
× (7) ??  
  => ○: break; 
  １つでも「●」が出力されたら、foreachループを抜ける 
  さもないと、すべてのスケジュールの数だけ「●」を出力 
*/
/*==== Appendix ====  
 *@date: 2022-06-01 (水)  
 *@time: 16:17 ～ 16:26 (9分)  
 *@rate: 57.89％ (○ 11 問 / 全 19 問)  
*/
/* 
2022-06-02 (木)
==== Exercise Result ==== 
◆〔1〕章末問題 １ 
○ (1) × Calendarクラスのイベント: DayRender, SelectionChanged, VisibuleMonthChanged 
× (2) ×?? => ○: ページ上のサーバーコントロールと同様にアクセス可 
○ (3) × ActiveViewIndex=0;で先頭ページ 
○ (4) × TreeViewの説明 
○ (5) ○ サイトマップはDBも可 

◆〔2〕２ 
○ (1) SiteMapDataSource〔p434参照して回答〕 
× (2) ShowStartingNode="false" 
      MaximamDynamicDisplayLevels="1" ?? 
  => ○: Maximum- はMenuViewのプロパティ。 
      StartFromCurrentNode="true"

◆〔3〕３ 
○ (1) new string[] 
× (2) calen.Cell.Text => ○: Caption 
× (3) e.Date => ○: e.NewDate 

◆〔4〕４ 
○ (1) 別プロジェクト 
  =>〔SelfAspNet / SampleAsp / NT09_RichControl / MultiViewControl〕
*/
/*==== Appendix ==== 
 *@date: 2022-06-02 (木) 
 *@time: 14:54 ～ 15:11 (17分) 
 *@rate: 63.64％ (○ 7 問 / 全 11 問) 
*/
