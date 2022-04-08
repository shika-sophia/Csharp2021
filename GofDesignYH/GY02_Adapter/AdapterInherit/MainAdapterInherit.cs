/** 
 *@title CsharpBegin / GofDesignYH / GY02_Adapter / AdapterInherit / MainAdapterInherit.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩 『デザインパターン入門 Java言語 [増補改訂版]』SB Creative, 2004 
 *@content 第２章 Adapter / サンプル１ / p16 / List 2-1 ～ 2-4
 *         [別名] Wrapper
 *         [英] adapt 適合する, [英] wrap 包む
 *         [英] inherit 継承  , [英] aggregate 集める
 *         [英] banner 広告の垂れ幕, [英] aster「*」, [英] paren かっこ
 *         
 *         サンプル１: クラスによる Adapter      => inherit 継承
 *         サンプル２: インスタンスによる Adapter => aggregate 集約/委譲
 *         
 *         || Adapter ||  ～ 一皮かぶせて再利用 ～
 *         
 */
#region Class Chart 〔AdapterInherit〕
/*
 *@class MainAdapterInherit
 *         ↓ use    //PrintStrong(), PrintWeak()を利用したい
 *@class IPrintGY02 <<interface>>
 *         △
 *         : 　implements 同一視
 *@class PrintBanner : BannerGY02, IPrintGY02
 *         |        //適合させるための Adapter
 *         ▽  extends 継承
 *@class BannerGY02 //元からあるクラス
 */
#endregion
/*
 *@author shika 
 *@date 2022-04-08 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.GofDesignYH.GY02_Adapter.AdapterInherit 
{ 
    class MainAdapterInherit 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            IPrintGY02 print = new PrintBannerGY02("Hello");
            print.PrintStrong();
            print.PrintWeak();
        }//Main() 
 
    }//class 
}

/*
*Hello*
(Hello)
 */
