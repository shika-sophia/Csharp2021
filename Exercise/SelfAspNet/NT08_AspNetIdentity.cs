/** 
 *@title CsharpBegin / Exercise / SelfAspNet / NT08_AspNetIdentity.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020 
 *@content 第８章 ASP.NET Identity / p384, p423
 *
 *@subject 練習問題 8-1, 
 * 
 *@author shika 
 *@date 2022-05-27 
*/ 
/*==== Appendix ==== 
 *@date: 2022-05-27 (金) 
 *@time: 03:01 ～ 03:06 (5分) 
 *@rate: 80.00％ (○ 4 問 / 全 5 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.Exercise.SelfAspNet 
{ 
    class NT08_AspNetIdentity 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
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
