/** 
 *@title CsharpBegin / GofDesignYH / GY02_Adapter / AdapterProperties / MainAdapterProperties.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference JG 結城 浩 『デザインパターン入門 Java言語 [増補改訂版]』SB Creative, 2004 
 *@content JG 第２章 Adapter / 練習問題 2-2 / p27, p383 / List 2-7 ～ 2-10
 *         問 JavaPropertiesクラスを AbsPropertiesGY02に適応させる Adapterを作成せよ。
 *         
 *         Client: Main
 *         Target: AbsFilePropertiesGY02
 *         Adapter: FilePropertyGY02 : AbsFilePropertiesGY02
 *         Adaptee: JavaProperties
 *
 *@----- Class Chart -----
 *@class MainAdapterProperties
 *         ↓ use
 *@class AbsFilePropertiesGY02
 *         △
 *         ｜ extends
 *@class FilePropertyGY02 : AbsFilePropertiesGY02
 *         ◇◇ aggregate
 *         ↓ ↓
 *@class JavaProperties
 *@class SeekPath
 *
 *@file loadFileGY02.txt
 *@file saveFileGY02.txt
 *
 *@see CshrapBegin / Utility / JavaPropertiesDiv / JavaProperties.cs
 *@see CshrapBegin / Utility / SeekPath.cs
 *@author shika 
 *@date 2022-04-12 
*/
using System; 
using System.Collections.Generic;
using System.IO;
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.GofDesignYH.GY02_Adapter.AdapterProperties 
{ 
    class MainAdapterProperties 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            AbsPropertyFileGY02 pf = new FilePropertiesGY02();
            string loadFile = "loadFileGY02.txt";
            string saveFile = "saveFileGY02.txt";
            try
            {
                pf.ReadFile(loadFile);
                Console.WriteLine(
                    pf.ToStringAll("JavaProperties after ReadFile()."));
                
                pf.SetProperty("year", "2000");
                pf.SetProperty("month", "01");
                pf.SetProperty("day", "15");
                pf.WriteFile(saveFile);
                Console.WriteLine(
                    $"It wrote Properties Dictionary to [{saveFile}].");
                Console.WriteLine(
                    pf.ToStringAll("JavaProperties after WriteFile()."));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }//Main() 
    }//class 
}

/*
# JavaProperties after ReadFile().
year = 2022

It wrote Properties Dictionary to [saveFileGY02.txt].

# JavaProperties after WriteFile().
year = 2000
month = 01
day = 15

//==== saveFileGY02.txt ====
# written by FilePropertiesGY02
# 2022/04/12 12:38:20
year = 2000
month = 01
day = 15

 */ 