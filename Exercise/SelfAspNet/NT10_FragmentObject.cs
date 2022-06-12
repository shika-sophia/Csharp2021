/**     
 *@title CsharpBegin / Exercise / SelfAspNet / NT10_FragmentObject.cs     
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017     
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020     
 *@content NT 第10章 FragmentObject / p491, p511, p537, p544, p555 / p565 
 *    
 *@subject 練習問題 10-1, 10-2, 10-3, 10-4, 10-5,  
 *@subject 章末問題 １, ２, ３, ４, ５, 
 * 
 *@author shika     
 *@date 2022-06-12, 06-13  
*/
/*==== Appendix ====     
 *@date: 2022-06-12 (日)     
 *@time: 15:15 ～ 15:18 (3分)     
 *@rate: 60.00％ (○ 3 問 / 全 5 問)     
*/
/*==== Appendix ====    
 *@date: 2022-06-13 (月)    
 *@time: 00:29 ～ 00:32 (3分)    
 *@rate: 87.50％ (○ 7 問 / 全 8 問)    
*/
/*==== Appendix ====   
 *@date: 2022-06-13 (月)   
 *@time: 00:57 ～ 00:58 (1分)   
 *@rate: 100.00％ (○ 3 問 / 全 3 問)   
*/
/*==== Appendix ====  
 *@date: 2022-06-13 (月)  
 *@time: 02:01 ～ 02:03 (2分)  
 *@rate: 100.00％ (○ 2 問 / 全 2 問)  
*/
/*==== Appendix ==== 
 *@date: 2022-06-13 (月) 
 *@time: 02:16 ～ 02:35 (19分) 
 *@rate: 81.82％ (○ 18 問 / 全 22 問) 
*/
namespace CsharpBegin.Exercise.SelfAspNet     
{     
    class NT10_FragmentObject     
    {     
        //static void Main(string[] args)     
        public void Main(string[] args)     
        {     
            new CsharpBegin.Exercise.ExerciseEditor("");     
        }//Main()      
    }//class     
}    
/*     
2022-06-12 (日)    
==== Exercise Result ====     
◆〔1〕第10章 FragmentObject / 練習問題 10-1     
○ (1) 別プロジェクト    
  =>〔SelfAspNet/SampleAsp/NT10_FlagmentObject/    
      UserControl/ChartCombinationWithSelctBrand.aspx〕    
    
◆〔2〕10-2     
○ (1) 別プロジェクト    
  => 〔SelfAspNet/SampleAsp/NT10_FragmentObject/    
       MasterPageDiv/PravticeContent.aspx〕    
    
○ (2) Image     
× (3) FindControl() => ○: Master.FindControl()     
× (4) AlteringText => ○: AlternateText     
*/    
/*==== Appendix ====     
 *@date: 2022-06-12 (日)     
 *@time: 15:15 ～ 15:18 (3分)     
 *@rate: 60.00％ (○ 3 問 / 全 5 問)     
*/    
/*    
2022-06-13 (月)   
==== Exercise Result ====    
◆〔1〕10-3    
○ (1) １．using    
○ (2) StreamWriter    
× (3) e.Exception.GetLastException   
  => ○: Server.GetLastError()    
○ (4) StringBuilder    
○ (5) Write()    
   
○ (6) ２．1 IHttpModule    
○ (7) Dispose()    
○ (8) Init()    
*/    
/*==== Appendix ====    
 *@date: 2022-06-13 (月)    
 *@time: 00:29 ～ 00:32 (3分)    
 *@rate: 87.50％ (○ 7 問 / 全 8 問)    
*/    
/*   
2022-06-13 (月)  
==== Exercise Result ====   
◆〔1〕10-4   
○ (1) IHttpHundler   
○ (2) IsReusable   
○ (3) ProcessRequest(HttpContext context)   
*/   
/*==== Appendix ====   
 *@date: 2022-06-13 (月)   
 *@time: 00:57 ～ 00:58 (1分)   
 *@rate: 100.00％ (○ 3 問 / 全 3 問)   
*/   
/*  
2022-06-13 (月) 
==== Exercise Result ====  
◆〔1〕10-5  
○ (1) <add key="Title" value="『独習 ASP.NET』" />  
○ (2) <%$ AppSetteings:Title %>  
*/  
/*==== Appendix ====  
 *@date: 2022-06-13 (月)  
 *@time: 02:01 ～ 02:03 (2分)  
 *@rate: 100.00％ (○ 2 問 / 全 2 問)  
*/  
/* 
2022-06-13 (月)
==== Exercise Result ==== 
◆〔1〕章末問題 １ 
○ (1) .ascx 
○ (2) マスターページ 
○ (3) .master 
× (4) Global.asax アプリケーション構成ファイル 
  => グローバル・アプリケーションファイル
○ (5) .asax 
○ (6) HttpHundler 
○ (7) カスタムコントロール 

◆〔2〕２ 
○ (1) × @Regiserディレクティブで ユーザーコントロールをページに登録 
○ (2) ○ 可能だが、アプリ共通なら、マスターページ, global.asaxを利用すべき 
○ (3) × イベントハンドラーの追加は HttpModuleクラス 
○ (4) ○ Page派生クラスで Page共通の処理を記述 
○ (5) × ページのスタイル/デザインは CSSに一括すべき 

◆〔3〕３ 
○ (1) 優先度 高 
      C: /Chap10の Web.config
      > A: Application Root直下
      > B: システムルート\Microdoft.NET\Framework\
           バージョン番号\config\Web.config(デフォルト)

◆〔4〕４ 
○ (1) MapPath() 
○ (2) StreamReader 
○ (3) Peek() 
○ (4) ReadLine() 

◆〔5〕５ 
× (1) MapRoute => ○: MapPageRoute 
○ (2) ~/Chap10/Article.aspx 
× (3) DifineValueDicitonary
  => ○: RouteValueDictionary 
× (4) string num = "00001";
  => ○: num = 1; 
× (5) num = @"\d[5]";
  => ○: @"\d[1,5]" 
*/ 
/*==== Appendix ==== 
 *@date: 2022-06-13 (月) 
 *@time: 02:16 ～ 02:35 (19分) 
 *@rate: 81.82％ (○ 18 問 / 全 22 問) 
*/ 
