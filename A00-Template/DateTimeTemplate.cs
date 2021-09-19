/**
 * @title CsharpBegin / A00_Template / DateTimeTemplate.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第５章 標準ライブラリ DateTime / p177 / List 5-28 ～
 *   ◆System.DateTime / System.Globalization.CultureInfo
 *   DateTime DateTime.Now;
 *   DateTime DateTime.Today;
 *   DateTime new DateTime(int year, month, day, hour, minute, second);
 *   
 *   //---- Parse() ----
 *   DateTime DataTime.Parse(string, [IFormatProvider culture, [,DateTimeStyles]]);
 *       DateTimeStyles.None
 *       DateTimeStyles.AdjustToUniversal UTC(=Universal Time Coodinated 世界協定時)に変換
 *       DateTimeStyles.AllowWhiteSpaces 文字列内の余分な空白を無視
 *       DateTimeStyles.AssumeLocal 無指定のとき、現地時間を返す
 *       DateTimeStyles.AssumeUniversal 無指定のとき、UTCを返す
 *       DateTimeStyles.NonCurrentDateDefault 文字列に日付がない場合　西暦1年1月1日
 *   
 *   //---- TryParse() / ParseExact() / TryParseExact() ----
 *   bool DateTime.TryParse(string, [out DateTime]);
 *   bool DateTime.TryParse(string, 
 *       [IFormatProvider culture, [,DateTimeStyles [,out DateTime]]]);
 *   DateTime DateTime.ParseExact(string input, string format,
 *       IFormatProvider culture, [,DateTimeStyles]);
 *   bool DateTime.TryParseExact(string input, string format,
 *       IFormatProvider culture, DateTimeStyles ,out DateTime);
 *         
 * @author shika
 * @date 2021-09-19
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.A00_Template
{
    class DateTimeTemplate
    {
        DateTime now = DateTime.Now;
        DateTime today = DateTime.Today;
        DateTime dateTime = new DateTime(2021, 09, 19, 18, 20, 35);
        static void Main(string[] args)
        //internal void Main(string[] args)
        {
            var here = new DateTimeTemplate();
            Console.WriteLine("Now: " + here.now);
            Console.WriteLine("Today: " + here.today);
            Console.WriteLine("dateTime: " + here.dateTime);

            //---- Parse() ----
            string str1 = "2021/09/19 18:20:35";
            Console.WriteLine("str1: " + DateTime.Parse(str1));

            string str2 = "令和3年9月19日 19時10分23秒";
            Console.WriteLine("str2: " + DateTime.Parse(str2));

            string str3 = "Donnerstag, 15. Februar 2018 13:17:23";
            CultureInfo culture = new CultureInfo("de-DE"); //deドイツ語 - DEドイツ
            Console.WriteLine("str3: " + DateTime.Parse(str3, culture));

            //---- TryParse() / ParseExact() / TryParseExact() ----
            DateTime dt;
            if (DateTime.TryParse("2021-09-19 19:32:24", out dt))
            {
                Console.WriteLine("TryParse(): " + dt);
            }

            string str4 = "20210919193524";
            DateTime dt4 = DateTime.ParseExact(
                str4, "yyyyMMddHHmmss", new CultureInfo("ja-JP"));
            Console.WriteLine("ParseExact(): " + dt4);

            string str5 = "2022/10/20 193524";
            string[] formatAry = new[] { "yyyyMMddHHmmss", "yyyy/MM/dd HHmmss" };
            DateTime dt5 = DateTime.ParseExact(
                str5, formatAry, new CultureInfo("ja-JP"), DateTimeStyles.None);
            Console.WriteLine("ParseExact(): " + dt5);
        }//Main()
    }//class
}

/*
Now: 2021/09/19 19:05:33
Today: 2021/09/19 0:00:00
dateTime: 2021/09/19 18:20:35

//---- Parse() ----
str1: 2021/09/19 18:20:35
str2: 2021/09/19 19:10:23
str3: 2018/02/15 13:17:23

//---- TryParse() / ParseExact() / TryParseExact() ----
TryParse(): 2021/09/19 19:32:24
ParseExact(): 2021/09/19 19:35:24
ParseExact(): 2022/10/20 19:35:24
 */