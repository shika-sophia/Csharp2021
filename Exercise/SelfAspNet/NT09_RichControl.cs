/** 
 *@title CsharpBegin / Exercise / SelfAspNet / NT09_RichControl.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020 
 *@content NT 第９章 RichControl / p448, p460, p465, p471, p481
 *
 *@subject 練習問題 9-1, 9-2, 9-3, 9-4, 
 * 
 *@author shika 
 *@date 2022-06-01 
*/ 
/*==== Appendix ==== 
 *@date: 2022-06-01 (水) 
 *@time: 16:17 ～ 16:26 (9分) 
 *@rate: 57.89％ (○ 11 問 / 全 19 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.Exercise.SelfAspNet 
{ 
    class NT09_RichControl 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
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
