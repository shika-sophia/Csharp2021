/**
 * @title CsharpBegin / A00_Template / DateTimeTemplate.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第５章 標準ライブラリ DateTime / p177 / List 5-28 ～ 5-40
 *   ◆System.DateTime / System.Globalization.CultureInfo
 *   DateTime DateTime.Now;
 *   DateTime DateTime.Today;
 *   DateTime new DateTime(int year, month, day, hour, minute, second, millisecond);
 *   CultureInfo new CultureInfo(string locale);
 *   CultrueInfo.DateTimeFormat.Calendar =        //Calendarプロパティにセット
 *       JapaneseCalendar new JapaneseCalendar();
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
 *   //---- property ----
 *   long dateTime.Ticks; 0001年1月1日00:00:00からの経過時間
 *   
 *   //---- format ----
 *   string dateTime.ToString(string format, [IFormatProvider culture])
 *   D: ToLongDateString() / d: ToShortDateString()
 *   T: ToLongTimeString() / t: ToShortTimeString()
 *   
 *   //---- JapaneseCalendar ----
 *   CultureInfo.DateTimeFormat.Calendar = //プロパティにカレンダークラスをセット
 *       JapaneseCalendar new JapaneseCalendar()
 *   
 *   //---- AddXxxx(), Add(), Subtract() ----
 *   DateTime dateTime.AddXxxx(T);
 *       Xxxx: Years / Months / Days / Hours / Minutes / Seconds / Milliseconds / Ticks
 *       T: int / double / long
 *   DateTime dateTime.Add(TimeSpan);
 *   DateTime dateTime.Subtract(TimeSpan)
 *       new TimeSpan([int days], int hours, int minutes, int seconds, [,int milliseconds]);
 *       new TimeSpan(long ticks)
 *   TimeSpan dateTime.Subtract(DateTime);
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
        CultureInfo cultureJp = new CultureInfo("ja-JP"); //ja日本語 - JP日本
        CultureInfo cultureEn = new CultureInfo("en-US"); //en英語 - USアメリカ
        CultureInfo cultureDe = new CultureInfo("de-DE"); //deドイツ語 - DEドイツ

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
           
            Console.WriteLine("str3: " + DateTime.Parse(str3, here.cultureDe));

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

            //---- property ----
            Console.WriteLine(
                $"{dt.Year}年{dt.Month}月{dt.Day}日({dt.DayOfWeek}) " +
                $"{dt.Hour}時{dt.Minute}分{dt.Second}秒{dt.Millisecond}");
            Console.WriteLine($"経過時: {dt.Ticks} / 年初から{dt.DayOfYear}日");

            //---- format ----
            var dt6 = new DateTime(2021, 09, 20, 19, 12, 24);
            Console.WriteLine(dt6.ToString("f"));
            Console.WriteLine(dt6.ToString("yy/MM/dd(ddd) tt:mm:ss"));
            Console.WriteLine(dt6.ToString("f", here.cultureJp));
            Console.WriteLine(dt6.ToString("yy/MM/dd(ddd) tt:mm:ss", here.cultureJp));
            Console.WriteLine(dt6.ToString("f", here.cultureEn));
            Console.WriteLine(dt6.ToString("yy/MM/dd(ddd) tt:mm:ss", here.cultureEn));

            //---- JapaneseCalendar ----
            CultureInfo jpCalendar = here.cultureJp;
            jpCalendar.DateTimeFormat.Calendar = new JapaneseCalendar();
            Console.WriteLine(dt6.ToString("ggyy年MM月dd日(ddd) tt:mm:ss", jpCalendar));

        }//Main()
    }//class
}

/*
Now: 2021/09/19 19:05:33
Today: 2021/09/19 0:00:0
dateTime: 2021/09/19 18:20:35

//---- Parse() ----
str1: 2021/09/19 18:20:35
str2: 2021/09/19 19:10:23
str3: 2018/02/15 13:17:23

//---- TryParse() / ParseExact() / TryParseExact() ----
TryParse(): 2021/09/19 19:32:24
ParseExact(): 2021/09/19 19:35:24
ParseExact(): 2022/10/20 19:35:24

//---- property ----
2021年9月19日(Sunday) 19時32分24秒0
エポック時: 637676767440000000 / 年初から262日

//---- format ----
//format "f"
2021年9月20日 19:12
21/09/20(月) 午後:12:24

//cultureJp
2021年9月20日 19:12
21/09/20(月) 午後:12:24

//cultureEn
Monday, September 20, 2021 7:12 PM
21/09/20(Mon) PM:12:24

//---- JapaneseCalendar ----
令和03年09月20日(月) 午後:12:24
 */