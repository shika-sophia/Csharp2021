/**   
 *@title CsharpBegin / Exercise / SelfAspNet / NT02_AspNetBasic.cs   
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017   
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020   
 *@content NT 第２章 ASP.NET基本 / p57, p67, p75
 *         VSのウインドウ, ページディレクティブ <%@ Page ...%>, 
 *         「.aspx」「aspx.cs」「.aspx.designer.cs」,
 *         partial class, イベントトリブンモデル, ビューステイト
 *@subject 練習問題 2-1, 2-2,  
 *@subject 章末問題 １, ２, ３, ４, ５, 
 * 
 *@author shika   
 *@date 2021-12-10   
*/
/*==== Appendix ====  
 *@date: 2021-12-10 (金)  
 *@time: 08:50 ～ 09:02 (11分)  
 *@rate: 90.00％ (○ 9 問 / 全 10 問)  
*/
/*==== Appendix ==== 
 *@date: 2021-12-10 (金) 
 *@time: 09:08 ～ 09:28 (20分) 
 *@rate: 94.74％ (○ 18 問 / 全 19 問) 
*/
using System;   
using System.Collections.Generic;   
using System.Linq;   
using System.Text;   
using System.Threading.Tasks;   
   
namespace CsharpBegin.Exercise.SelfAspNet   
{   
    class NT02_AspNetBasic   
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()   
    }//class   
}
/*  
2021-12-10 (金) 
==== Exercise Result ====  
◆〔1〕ASP.NET基本 / 練習問題 2-1  
○ (1) 正しい  
○ (2) 先頭の記号は「_」のみ  
○ (3) 正しい  
○ (4) 先頭の数字は不可？  
○ (5) ２．lblGreet.Text = $"Good Night, {txtName.Text}.";  
 
◆〔2〕2-2  
○ (1) １．ポストバック: 自ページの Pageオブジェクトの状態を Server側に送信すること。
    これにより、ページの状態変化に応じたページ出力が可能になる。  
○ (2) ２．① -ing 事前、-ed 事後のイベントがある。  
○ (3) ② defaultでは クリックイベント時に送信される。  
× (4) ③ AutoPostback="" Trueにするとクリック前でもイベント送信される。
    => ○: AutoPostBack="" True  
○ (5) ④ ○ = ②,④  
*/
/*==== Appendix ====  
 *@date: 2021-12-10 (金)  
 *@time: 08:50 ～ 09:02 (11分)  
 *@rate: 90.00％ (○ 9 問 / 全 10 問)  
*/
/* 
2021-12-10 (金)
==== Exercise Result ==== 
◆〔1〕章末問題１ 
○ (1) Document Window 
○ (2) Design View 
○ (3) Solution Exproler 
    => スペル Explorer
○ (4) Tool Box 
○ (5) Property Window 
○ (6) Server Exproler 
    => スペル Explorer

◆〔2〕２ 
○ (1) [Ctrl] + [space]: コードのヘルプを表示。途中まで入力した状態で、
    これを行うとコードの候補が現れる 

◆〔3〕３ 
○ (1) × -> ASP.NETページの拡張子は「.aspx」
    => 「.asp」は古いASPの拡張子
○ (2) × -> runat=""のデフォルトは client 
○ (3) ○ OnClick=""にイベント呼出属性があるので削除するならこれも削除しないと、
    コンパイルエラーとなる。 
○ (4) × ディレクティブは <% ... %> イベントハンドラは別ページにあるので、
    これは Language=""のコードを記述。 

◆〔4〕４ 
○ (1) Page.Initイベント 
○ (2) 変更系 
○ (3) クリック系 
× (4) Page.?? => ○: Page.Unload 

◆〔5〕５ 
○ (1) ビューステイト: Pageの連続性を持たすための仕組み。 
○ (2) 各Pageに Serializeしたページ情報を <input type="hidden">として挿入
    => <form>内の HTMLタグ
    <input type="hidden" name="__VIEWSTATE value="..." >

○ (3) Base64でエンコードするので、デコードし、デシリアライズすると、機密情報が露見する。 
○ (4) 情報量の多いページは、巨大なビューステートが作成されるので,
    読み込み/ページ表示のパフォーマンス低下に繋がる。 
*/
/*==== Appendix ==== 
 *@date: 2021-12-10 (金) 
 *@time: 09:08 ～ 09:28 (20分) 
 *@rate: 94.74％ (○ 18 問 / 全 19 問) 
*/
