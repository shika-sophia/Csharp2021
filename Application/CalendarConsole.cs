/**
 *@title CsharpBegin / Application / CalendarConsole.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content カレンダー表示 / コンソール用
 * 
 *@author shika 
 *@date 2021-10-12 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Application
{
    class CalendarConsole
    {
        private DateTime now = DateTime.Now;
        private readonly string[] weekJp = 
            new[] { "日", "月", "火", "水", "木", "金", "土" };
        private string weekJpStr;

        public CalendarConsole()
        {           
            this.weekJpStr = BuildWeek();
            MonthCalen(now.Year, now.Month);
            YearCalen(now.Year);
        }

        public void YearCalen(int year)
        {
            for(int month = 1; month <= 12; month++)
            {
                MonthCalen(year, month);                
            }
        }//YearCalen()

        public void MonthCalen(int year, int month)
        {
            DateTime dtFirst = new DateTime(year, month, 1);
            int firstWeek = (int) dtFirst.DayOfWeek;
            int lastDay = dtFirst.AddMonths(1).AddDays(-1).Day;

            var bld = new StringBuilder(160);
            bld.Append($"{year}年 / {month}月 \n");
            bld.Append(weekJpStr);

            //月初空白
            for(int i = 0; i < firstWeek; i++)
            {
                bld.Append("　").Append(" ");
            }

            //日付
            for(int i = 1; i <= lastDay; i++)
            {
                bld.Append($"{i, 2} ");

                if((7 - (firstWeek + i)) % 7 == 0)
                {
                    bld.Append("\n");
                }
            }//for
            
            Console.WriteLine(bld.ToString());
            Console.WriteLine();
        }//MonthCalen()

        private string BuildWeek()
        {    
            var bld = new StringBuilder(30);
            foreach (string str in weekJp)
            {
                bld.Append($"{str} ");
            }
            bld.Append("\n");
                      
            return bld.ToString();
        }//BuildWeek()

        //static void Main(string[] args)
        public void Main(string[] args)
        {
            new CalendarConsole();
        }//Main()
    }//class
}

/*
//---- MonthCalen() ----
2021年 / 10月
日 月 火 水 木 金 土
 　 　 　 　 　  1  2
 3  4  5  6  7  8  9
10 11 12 13 14 15 16
17 18 19 20 21 22 23
24 25 26 27 28 29 30
31

※１週目のズレは
コンソールだと、ちゃんと表示されているのでOK

//---- YearCalen() ----
2021年 / 1月
日 月 火 水 木 金 土
 　 　 　 　 　  1  2
 3  4  5  6  7  8  9
10 11 12 13 14 15 16
17 18 19 20 21 22 23
24 25 26 27 28 29 30
31

2021年 / 2月
日 月 火 水 木 金 土
　  1  2  3  4  5  6
 7  8  9 10 11 12 13
14 15 16 17 18 19 20
21 22 23 24 25 26 27
28

2021年 / 3月
日 月 火 水 木 金 土
　  1  2  3  4  5  6
 7  8  9 10 11 12 13
14 15 16 17 18 19 20
21 22 23 24 25 26 27
28 29 30 31

2021年 / 4月
日 月 火 水 木 金 土
 　 　 　 　  1  2  3
 4  5  6  7  8  9 10
11 12 13 14 15 16 17
18 19 20 21 22 23 24
25 26 27 28 29 30

2021年 / 5月
日 月 火 水 木 金 土
 　 　 　 　 　 　  1
 2  3  4  5  6  7  8
 9 10 11 12 13 14 15
16 17 18 19 20 21 22
23 24 25 26 27 28 29
30 31

2021年 / 6月
日 月 火 水 木 金 土
　 　  1  2  3  4  5
 6  7  8  9 10 11 12
13 14 15 16 17 18 19
20 21 22 23 24 25 26
27 28 29 30

2021年 / 7月
日 月 火 水 木 金 土
　 　 　 　  1  2  3
 4  5  6  7  8  9 10
11 12 13 14 15 16 17
18 19 20 21 22 23 24
25 26 27 28 29 30 31


2021年 / 8月
日 月 火 水 木 金 土
 1  2  3  4  5  6  7
 8  9 10 11 12 13 14
15 16 17 18 19 20 21
22 23 24 25 26 27 28
29 30 31

2021年 / 9月
日 月 火 水 木 金 土
　 　 　  1  2  3  4
 5  6  7  8  9 10 11
12 13 14 15 16 17 18
19 20 21 22 23 24 25
26 27 28 29 30

2021年 / 10月
日 月 火 水 木 金 土
　 　 　 　 　  1  2
 3  4  5  6  7  8  9
10 11 12 13 14 15 16
17 18 19 20 21 22 23
24 25 26 27 28 29 30
31

2021年 / 11月
日 月 火 水 木 金 土
　  1  2  3  4  5  6
 7  8  9 10 11 12 13
14 15 16 17 18 19 20
21 22 23 24 25 26 27
28 29 30

2021年 / 12月
日 月 火 水 木 金 土
　 　 　  1  2  3  4
 5  6  7  8  9 10 11
12 13 14 15 16 17 18
19 20 21 22 23 24 25
26 27 28 29 30 31


【参考】enum DatOfWeek
namespace System
{
    [ComVisible(true)]
    public enum DayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6
    }
}
 */
