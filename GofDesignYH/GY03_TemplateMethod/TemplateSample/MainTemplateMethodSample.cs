/** 
*@title CsharpBegin / GofDesignYH / GY03_TemplateMethod / TemplateSample / MainTemplateSample.cs 
*@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
*@reference GY 結城 浩 『デザインパターン入門 Java言語 [増補改訂版]』SB Creative, 2004 
*@content MainTemplateSample
*
*@subject System.Grlbalization.StringInfoクラス 〔CS17〕
*         ・サロゲートペア: Unicode 2byte文字で表現できる 65536文字を越える 4byte文字
*         ・String.Lengthは 4byte文字も ２文字としてカウント
*         ・new StringInfo(string).LengthInTextElements 4byte文字を 1文字としてカウント
*         
*@author shika 
*@date 2022-06-16 
*/
using System;

namespace CsharpBegin.GofDesignYH.GY03_TemplateMethod.TemplateSample
{
    class MainTemplateMethodSample 
    { 
        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            AbsDisplayTemplate d1
                = new CharDisplayConcrete('A');
            AbsDisplayTemplate d2
                = new StringDisplayConcrete("Hello World");
            AbsDisplayTemplate d3
                = new StringDisplayConcrete("こんにちは");

            d1.Display();
            d2.Display();
            d3.Display();

            Console.WriteLine("Main() END");
        }//Main() 
    }//class 
} 
