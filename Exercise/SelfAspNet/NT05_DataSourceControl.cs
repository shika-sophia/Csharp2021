/** 
 *@title CsharpBegin / Exercise / SelfAspNet / NT05_DataSourceControl.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020 
 *@content 第５章 DataSourceControl / 練習問題 5-1, 5-2, 
 * 
 *@author shika 
 *@date 2022-05-14 
*/ 
/*==== Appendix ==== (例外発生のため再試行) => 対応済
 *@date: 2022-05-14 (土) 
 *@time: 12:23 ～ 12:24 (1分) 
 *@rate: 50.00％ (○ 1 問 / 全 2 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.Exercise.SelfAspNet 
{ 
    class NT05_DataSourceControl 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
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
