/**  
 *@title CsharpBegin / Exercise / SelfAspNet / NT03_ServerContorol.cs  
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020  
 *@content NT 第３章 ServerControl / p90, p94, p96, p120, p120
 *         Formコントロール、表示コントロール、
 *         ボタンコントロール、検証コントロール、正規表現
 *@subject 練習問題 3-1, 3-2, 3-3, 3-4, 
 *@subject 章末問題 １, ２, ３, ４, ５, 
 * 
 *@author shika  
 *@date 2021-12-11  
*/
/*==== Appendix ====  
 *@date: 2021-12-11 (土)  
 *@time: 16:28 ～ 16:47 (19分)  
 *@rate: 63.64％ (○ 14 問 / 全 22 問)  
*/
/*==== Appendix ==== 
 *@date: 2021-12-11 (土) 
 *@time: 17:14 ～ 17:36 (22分) 
 *@rate: 90.00％ (○ 27 問 / 全 30 問) 
*/
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
  
namespace CsharpBegin.Exercise.SelfAspNet  
{  
    class NT03_ServerContorol  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()   
  
    }//class  
}  
/*  
2021-12-11 (土) 
==== Exercise Result ====  
◆〔1〕第３章 ServerControl / 練習問題 3-1  
○ (1) PostedFile  
× (2) postfile => ○: postFile.FileName  
○ (3) ContentType  
○ (4) "text/plain"  
○ (5) uppath  
 
◆〔2〕3-2 １  
○ (1) ImageUrl  
○ (2) "https;//wings.msn.to/"  
× (3) AlternatingText => ○: Text  
    => 【HyperLinkControl】 
*       NavigateUrl="" を設定すると、<a>, <img>の両方を生成。 
*       Text="" は通常リンクテキスト。 
*       ImageUrl=""を設定すると、alt=""のテキストとなる。 
 
○ (4) ID  
× (5) NavigateUrl => ○: ImageUrl  
× (6) AlterNatingText => ○: AlternateText  
 
◆〔3〕3-2 ２  
○ (1) 上記  
 
◆〔4〕3-3  
○ (1) OnClientClick = 'return confirm("本当に実行しますか"' ) 
    => returnを省略すると confirmの戻り値が何であれ(True/Falseとも) 
*      ポストバックが実行されてしまう。 
*       
*      if(IsConfirm)のようなコードを記述しなくても、 
*      Trueならポストバック、Falseならキャンセルを行う。 
*      コードが内部化されている。 
 
◆〔5〕3-4  
○ (1) 必須  
○ (2) RangeValidation  => ○: Validator 
× (3) ComareValidation => ○: Validator  
○ (4) 正規表現  
× (5) CostumFieldValidation => ○: CustomValidator  
× (6) ValidateSummary => ○: ValidationSummary  
 
◆〔6〕3-4 ２  
× (1) 入力値検証をまずクライアント側で行い、 
    Falseの場合は送信しないことでパフォーマンスの向上を図っている。 
○ (2) クライアント側で JavaScriptを OFFにすることも出繰るので  
○ (3) クライアント/サーバーの双方で検証することによりセキュリティが確保されている。  
*/  
/*==== Appendix ====  
 *@date: 2021-12-11 (土)  
 *@time: 16:28 ～ 16:47 (19分)  
 *@rate: 63.64％ (○ 14 問 / 全 22 問)  
*/  
/* 
2021-12-11 (土)
==== Exercise Result ==== 
◆〔1〕章末問題 １ 
○ (1) <%$ -> <%@ Page 
○ (2) <asp:Button runat="server" 
○ (3) <asp:Button>は <form>～</form>内 

◆〔2〕２ 
○ (1) txtVar 
× (2) BackgroundColor="" => ○: BackColor 
○ (3) 10 
○ (4) 15 
○ (5) True 
○ (6) Password 

◆〔3〕３ (ノート参照)
○ (1) ListItem 
○ (2) Items 
○ (3) Selected 
○ (4) Value 

◆〔4〕４ 
○ (1) × 逆の説明 
○ (2) × Display="Static"の説明 
○ (3) × Client側で予備的に認証することで Page.IsValid == False時に、無駄なトラフィックを省略できる。 
× (4) ○ InitialValue=""の default値は "" => ○: 初期値とは連動していない 
○ (5) × データ型検証には CompareValidator 

◆〔5〕５ 
× (1) txtTitle => ○: txtIsbn 
○ (2) * 
○ (3) txtPrice, *, "[0-9]{3}-[0-9]{1}-[0-9]{3,5}-[0-9X]{1}" 
○ (4) RequiredFieldValidator 
○ (5) ControlToValdate 
○ (6) * 
○ (7) txtPrice 
○ (8) 10000 
○ (9) 0 
○ (10) * 
○ (11) Int32 / Integer
○ (12) True 
*/ 
/*==== Appendix ==== 
 *@date: 2021-12-11 (土) 
 *@time: 17:14 ～ 17:36 (22分) 
 *@rate: 90.00％ (○ 27 問 / 全 30 問) 
*/ 
