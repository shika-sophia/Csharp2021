/**  
 *@title CsharpBegin / Exercise / SelfLearnCS / SelfLearnChap03.cs  
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@content 第３章 演算子 / 練習問題 3-1, 3-2, 章末問題 
 *  
 *@author shika  
 *@date 2021-11-17  
*/  
/*==== Appendix ====  
 *@date: 2021-11-17 (水)  
 *@time: 06:35 ～ 06:54 (19分)  
 *@rate: 76.19％ (○ 16 問 / 全 21 問)  
*/  
/*==== Appendix ==== 
 *@date: 2021-11-17 (水) 
 *@time: 07:07 ～ 07:12 (5分) 
 *@rate: 66.67％ (○ 4 問 / 全 6 問) 
*/ 
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
  
namespace CsharpBegin.Exercise.SelfLearnCS  
{  
    class SelfLearnChap03  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()   
    }//class  
}
/*  
2021-11-17 (水) 
==== Exercise Result ====  
◆〔1〕練習問題 3-1  
○ (1) 前置演算: 演算を先に行い、演算後の値を利用  
○ (2) 後置演算: 演算前の値を利用し、その後に演算  
 
◆２ 
○ (1) "2" + "3" -> 23  
× (2) 1++ -> 1 => ○: リテラルのインクリメント不可  
○ (3) 6 / 5 -> 1  
× (4) 1.0 / 0 -> ArithemetricException 
  => ○: ∞ float, double 
  => 整数型の０除算は例外スロー 
○ (5) 9 % 5 -> 4  

◆3-2 下記

◆〔3〕章末問題  
○ (1) 算術演算子  
○ (2) 代入演算子  
○ (3) 条件式 ? true処理 : false処理  
○ (4) 条件式 ?? default値  
○ (5) 論理演算子  
○ (6) |, &, ^, >>, <<,  
    => ^:排他的論理和, ~:否定  
○ (7) ２. x: 2, y: 5, bld1: abcdef, bld2: abcdef  
× (8) ３. str = null -> str.EndsWith()  
 strがnullのため、null値のメソッド呼出不可 
    => ○: str != null ? A : B or if(str != null)  
× (9) string str = ""; or "".EndsWith(str) => ○: 上記  
○ (10) ４.1 優先順位  
× (11) 2 => ○: 結合則  
○ (12) 3 高い  
○ (13) 4 等しい  
○ (14) 5 代入演算子  
*/
/*==== Appendix ====  
 *@date: 2021-11-17 (水)  
 *@time: 06:35 ～ 06:54 (19分)  
 *@rate: 76.19％ (○ 16 問 / 全 21 問)  
*/
/* 
2021-11-17 (水)
==== Exercise Result ==== 
◆〔1〕3-2追補 
○ (1) value == null "規定値" : value 
○ (2) value ?? "規定値" 
× (3) ２. "123".Equals(123) -> エラー => ○: false 
    => 「==」既定で参照同一性を判定。型違いは無条件で false

× (4) "123" == 123 -> false => ○: エラー 
    => stringの「==」は文字列の一致、二項目は　intなので 引数 stringに渡せない

○ (5) new StringBuilder == new StringBuilder -> false 
    => newにより別インスタンス
○ (6) (new[]).Equals(new[]) -> false 
    => 配列の要素比較に Equals()不可
    => SequenceEquals()を使う
*/
/*==== Appendix ==== 
 *@date: 2021-11-17 (水) 
 *@time: 07:07 ～ 07:12 (5分) 
 *@rate: 66.67％ (○ 4 問 / 全 6 問) 
*/
