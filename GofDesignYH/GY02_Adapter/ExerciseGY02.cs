/** 
 *@title CsharpBegin / GofDesignYH / GY02_Adapter / ExerciseGY02.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩 『デザインパターン入門 Java言語 [増補改訂版]』SB Creative, 2004 
 *@content 第２章 Adapter 練習問題 2-1, 2-2 / p27, p383 
 * 
 *@author shika 
 *@date 2022-04-09 
*/ 
/*==== Appendix ==== 
 *@date: 2022-04-09 (土) 
 *@time: 09:43 ～ 09:49 (6分) 
 *@rate: 87.50％ (○ 7 問 / 全 8 問) 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.GofDesignYH.GY02_Adapter 
{ 
    class ExerciseGY02 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        { 
            new CsharpBegin.Exercise.ExerciseEditor(""); 
        }//Main()  
    }//class 
} 
/* 
2022-04-09 (土)
==== Exercise Result ==== 
◆〔1〕第２章 練習問題 2-1 
○ (1) IPrint print = new PrintBanner();とする理由 
○ (2) サンプルでは Adapterが１つだけだが、 
○ (3) 複数のAdapterを切り替える場合に 
○ (4) IPrint, AbsPrintで同一視させておくと 
○ (5) 新しいAdapter追加時もMainを修正する必要がない。 
× (6) 拡張可能性を考慮してポリモーフィズムを利用している 
  => ○: 【解答】IPrint, AbsPrintのメソッドだけを用いるという
        「プログラムの意図」を明示するためもある 

◆〔2〕2-2 
○ (1) Propertiesクラスを ファイルに書き込むコード 
○ (2) => 別フォルダ〔AdapterProperties〕 
*/ 
/*==== Appendix ==== 
 *@date: 2022-04-09 (土) 
 *@time: 09:43 ～ 09:49 (6分) 
 *@rate: 87.50％ (○ 7 問 / 全 8 問) 
*/ 
