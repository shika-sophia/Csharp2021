/** 
 *@title CsharpBegin / GofDesignYH / GY02_Adapter / AdapterAggregate / MainAdapterAggregate.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩 『デザインパターン入門 Java言語 [増補改訂版]』SB Creative, 2004 
 *@content 第２章 Adapter / サンプル２ / p20 / 2-5, 2-6
 *         サンプル１: クラスによる Adapter      => inherit 継承
 *         サンプル２: インスタンスによる Adapter => aggregate 集約/委譲
 */
#region Class Chart 〔AdapterAggregate〕
/*
  *class MainAdapterAggregate
 *         ↓ use    //PrintStrong(), PrintWeak()を利用したい
 *@class AbsPrintGY02 
 *         △
 *         | 　implements 同一視
 *@class PrintBannerAggregate : AbsPrintGy02 //適合させるための Adapter  
 *         ◇  aggregate 集約/委譲
 *         ↓        
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
 
namespace CsharpBegin.GofDesignYH.GY02_Adapter.AdapterAggregate 
{ 
    class MainAdapterAggregate 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            AbsPrintGY02 print = new PrintBannerAggregate("Hello");
            print.PrintStrong();
            print.PrintWeak();
        }//Main() 
    }//class 
}

/*
*Hello*
(Hello)
 */
