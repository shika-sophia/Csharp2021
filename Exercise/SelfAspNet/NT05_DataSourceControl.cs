/**  
 *@title CsharpBegin / Exercise / SelfAspNet / NT05_DataSourceControl.cs  
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020  
 *@content 第５章 DataSourceControl / p231, p252, p297
 *@subject 練習問題 5-1, 5-2
 *@subject 章末問題 １, ２, ３, ４, 
 *  
 *@author shika  
 *@date 2022-05-14, 05-21
*/
/*==== Appendix ==== (例外発生のため再試行) => 対応済 
 *@date: 2022-05-14 (土)  
 *@time: 12:23 ～ 12:24 (1分)  
 *@rate: 50.00％ (○ 1 問 / 全 2 問)  
*/
/*==== Appendix ==== 
 *@date: 2022-05-21 (土) 
 *@time: 16:49 ～ 17:03 (14分) 
 *@rate: 81.48％ (○ 22 問 / 全 27 問) 
*/

namespace CsharpBegin.Exercise.SelfAspNet
{
    class NT05_DataSourceControl  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()   
  
    }//class  
}  
  
/*  
==== Question ====  
◆Quest: [-99: to Answer] [-88: Return]  
〔1〕第５章 DataSourceContorol / 練習問題 5-1  
〔2〕5-2  
〔3〕-99  
<?> Quest(2)で終了します。  
終了 よろしいですか？ [ Y / N ]: y  
  
==== Answer ====  
◆〔1〕第５章 DataSourceContorol / 練習問題 5-1  
◇Answer: [-99: QuestEnd] [-88: Return]  
(1) OptimisticConcurrent  
(2) protected void sds_Updated(object sender, SqlDataSourceStatusEventArgs e)  
(3) {  
(4)   if(e.AffectedRows == 0)  
(5)   {  lblError.Text = "Data Conflict is occured. It cannot update on database."; }  
(6) }  
(7) -99  
<?> Answer(6)で終了します。  
終了 よろしいですか？ [ Y / N ]: y  
  
◆〔2〕5-2  
◇Answer: [-99: QuestEnd] [-88: Return]  
(1) 接続型: DB接続を SqlConnectionオブジェクトとして保持し、プロジェクト中で接続・切断を制御する  
(2) 非接続型: DBに接続するのは１回のみで、結果セットを DataSetに保持し、それへ処理を行う。  
(3) ２．(1) ConnectionStrings[]  
(4) SqlAdapter?  
(5) settings.ConnectionString  
(6) DataSet()  
(7) adapter.Fill()  
(8) Rows.Count  
(9) Rows[].["title"]  
(10) -99  
<?> Answer(9)で終了します。  
終了 よろしいですか？ [ Y / N ]: y  
  
==== Judge Correct ====  
◇正誤入力: [0: ○ ] [1: × ] [-88: Return]  
◆〔1〕第５章 DataSourceContorol / 練習問題 5-1  
(1) OptimisticConcurrent: 0  
(2) protected void sds_Updated(object sender, SqlDataSourceStatusEventArgs e): 0  
(3) {: 0  
(4)   if(e.AffectedRows == 0): 0  
(5)   {  lblError.Text = "Data Conflict is occured. It cannot update on database."; }: 0  
(6) }: 0  
  
◆〔2〕5-2  
(1) 接続型: DB接続を SqlConnectionオブジェクトとして保持し、プロジェクト中で接続・切断を制御する: 0  
(2) 非接続型: DBに接続するのは１回のみで、結果セットを DataSetに保持し、それへ処理を行う。: 1  
 => ○: DataSetはメモリ上に保持し、読み書き時のみDBアクセス。DB上の操作はメモリ上で可能  
(3) ２．(1) ConnectionStrings[]  
×(4) SqlAdapter?  
  => SqlDataAdapter  
  
×(5) settings.ConnectionString  
  => AddWithValue()  
  
△(6) DataSet()  
△(7) adapter.Fill()  
△(8) Rows.Count  
△(9) Rows[].["title"]  
  
△:テキスト参照 => 要復習  
 */  
/*  
2022-05-14 (土) 
==== Exercise Result ====  
◆〔1〕第５章 DataSourceControl / 練習問題 5-1  
○ (1) a  
 
◆〔2〕5-2  
× (1) b => ○: c  
*/  
/*==== Appendix ====  
 *@date: 2022-05-14 (土)  
 *@time: 12:23 ～ 12:24 (1分)  
 *@rate: 50.00％ (○ 1 問 / 全 2 問)  
*/  
/* 
2022-05-21 (土)
==== Exercise Result ==== 
◆〔1〕章末問題１ 
○ (1) SqlDataSource 
○ (2) サイトマップ情報、パンくずリスト 
○ (3) XmlDataSource? 
○ (4) ObjectDataSource 

◆〔2〕２ 
○ (1) SQL injection: 入力フォームから、SQL文の一部を挿入し、 
○ (2) DBへ意図しない動作を起こさせる脆弱性のこと。 
○ (3) 対策として、SQLエスケープ: 「'」を単なる文字列として認識させる加工が必要。 
○ (4) 入力値を直接、SQL文に代入するのではなく、 
× (5) SqlCommandクラスと AddValueWithValue()を通して行うと、
      内部的にSQLエスケープ処理をしてくれる。
  => ○: command.Parameters.AddWithValue("@category, category); 

◆〔3〕３ 
○ (1) ConnectionStrings 
○ (2) using 
○ (3) SqlConnection 
○ (4) SqlCommand 
○ (5) db 
× (6) AddParamWithValue() => ○: AddWithValue() 
○ (7) Open() 
× (8) ExecuteQuery() => ○: ExecuteNonQuery() 

◆〔4〕４ 
○ (1) namespace 
○ (2) partial 
○ (3) DataObjectMethod 
○ (4) ConfigurationManager 
○ (5) SqlConnection 
× (6) SqlCommand 
  => ○: string comm.CommandText = "";
○ (7) DataSet 
× (8) TableAdapter? 
  => ○: SqlDataAdapter 
○ (9) Fill()
○ (10) ds 
*/ 
/*==== Appendix ==== 
 *@date: 2022-05-21 (土) 
 *@time: 16:49 ～ 17:03 (14分) 
 *@rate: 81.48％ (○ 22 問 / 全 27 問) 
*/ 
