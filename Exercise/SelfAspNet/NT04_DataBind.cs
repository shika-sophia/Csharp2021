/**  
 *@title CsharpBegin / Exercise / SelfAspNet / NT04_DataBind.cs  
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020  
 *@content NT 第４章 DataBind / p129, p142, p174, p184, p640
 *@subject 練習問題 4-1, 4-2, 4-3, 4-4,  
 *@subject 章末問題 １, ２, ３, ４, ５, ６, 
 * 
 *@see SelfAspNet / SampleCode / NT04_DataBind / 
 *@author shika  
 *@date 2022-04-20  
*/
/*==== Appendix ====  
 *@date: 2022-04-20 (水)  
 *@time: 12:49 ～ 13:07 (18分)  
 *@rate: 71.43％ (○ 10 問 / 全 14 問)  
*/
/*==== Appendix ==== 
 *@date: 2022-04-20 (水) 
 *@time: 13:30 ～ 13:48 (17分) 
 *@rate: 85.71％ (○ 18 問 / 全 21 問) 
*/
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
  
namespace CsharpBegin.Exercise.SelfAspNet  
{  
    class NT04_DataBind  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()   
    }//class  
}  
/*  
2022-04-20 (水) 
==== Exercise Result ====  
◆〔1〕NT 第４章 DataBind / 練習問題 4-1  
○ (1) DBの種類:  
Reletional DB, Key-Value, Card, Network, Tree, ObjectEntity  
× (2) RDBの製品:  
SQL Server, MySQL, MariaDB, OracleDB, SQLite etc  
=> ○: PostgreSQL, DB2, Microsoft Access  
 
◆〔2〕4-2  
○ (1) Album_tbを作成 => 既に完了  
○ (2) SELECT category, comment, updated FROM Album  
× (3) WHERE (updated >=  '2020-01-01');  
=> ○: category = 'その他' AND  
 
◆〔3〕4-3  
○ (1) Book_tbの GridView作成 => 別プロジェクト  
○ (2) 29,785.550  
○ (3) 29,785.55  
× (4) 029,785.5  
  => ○: 小数点以下の桁不足は四捨五入されて「.6」  
○ (5) yyyy年MM月dd日(ddd)  
× (6) HH時mm分ss秒 => ○: {0: } 内に記述 0は index 
 
◆〔4〕4-4  
○ (1) FormViewは比較的、自由な形式の単票 
○ (2) DetailViewは定型的な単票  
○ (3) FormViewのカスタマイズ => 別プロジェクト  
*/  
/*==== Appendix ====  
 *@date: 2022-04-20 (水)  
 *@time: 12:49 ～ 13:07 (18分)  
 *@rate: 71.43％ (○ 10 問 / 全 14 問)  
*/  
/* 
2022-04-20 (水)
==== Exercise Result ==== 
◆〔1〕章末問題 １ 
○ (1) GridView: 登録×, 更新/削除○ 
○ (2) DetailView: 登録○, ソート× 
○ (3) FormView: 登録○, ページング○ 
× (4) ListView: ???? => ○: 登録○, 更新/削除○, ページング○, ソート〇 

◆〔2〕２ 
× (1) ○ DropDownFieldは選択ボックス 
  => ○: 選択ボックスには TemplateFieldを利用する必要がある 
○ (2) × HtmlEncode=""は HTMLエスケープするかどうか 
× (3)   BoundFieldのデータがHTMLで変形しないよう Trueにしておくのが望ましい 
  => ○: XSSの危険回避のためにも必要 
○ (4) ○ XxxxxFormatString=""にプレースホルダと書式文字列を指定できる 
  => １以上のindex番号は HyperLinkField.DataNavigate.UrlFormatString=""のみ
○ (5) × 小数点以下３桁で揃えるなら「.###」だとデータによって桁が足りない可能性がある。 
○ (6)   -> 「.000」にしておくと桁不足じでも 0を表示 
○ (7) ×TemplateFieldで Header, Footerのカスタマイズは可能 
○ (8)   テキストの表示だけならプロパティでも可 

◆〔3〕３ 
○ (1) Connection Pooling: 
○ (2) DBなどの外部接続をメモリ上に保持しておく仕組み 
○ (3) これにより、一度接続したものを再度利用する場合に
      接続に要するオーバーヘッドを軽減できる 

◆〔4〕４ 
○ (1) Evalメソッド: readonlyで更新が反映されない 
○ (2) Bindメソッド: 双方向バインドで更新がDataSourceControlに反映 (DBにではない) 

◆〔5〕５ 
○ (1) if(e.Exception != null) 
○ (2) {
           e.ExceptionHandler = true; 
○ (3)      Response.Write(e.Exception.Message);
      }

◆〔6〕６ 
○ (1) Album_tbの FormView => 別プロジェクト 
*/ 
/*==== Appendix ==== 
 *@date: 2022-04-20 (水) 
 *@time: 13:30 ～ 13:48 (17分) 
 *@rate: 85.71％ (○ 18 問 / 全 21 問) 
*/ 
