/**
 * @title CsharpBegin / SampleCode / StringSearchSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第５章 標準ライブラリ / p147 / List 5-7 ～ 5-10
 *          ◆String
 *          //---- index ----
 *          int string.IndexOf(T, [int start, int count])
 *          int string.LastIndexOf(T, [int start, int count])
 *          
 *          //---- bool ----
 *          bool string.Contains(string)
 *          bool string.StartsWith(string)
 *          bool string.EndsWith(string)
 *          
 *          //---- Any(), All() ----
 *          bool string.Any(Predicate<T>)
 *          bool string.All(Predicate<T>)
 *          bool IEnumerable<char>.Any<char>(Func<char,bool>)
 *          bool IEnumerable<char>.All<char>(Func<char,bool>)
 *          
 * @author shika
 * @date 2021-09-15
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class StringSearchSample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            //---- index ----
            var str1 = "にわにはにわにわとりがいる";
            Console.WriteLine(str1.IndexOf("にわ"));
            Console.WriteLine(str1.IndexOf("にも"));
            Console.WriteLine(str1.LastIndexOf("にわ"));
                
            Console.WriteLine(str1.IndexOf("にわ", 3));
            Console.WriteLine(str1.LastIndexOf("にわ", 3));

            Console.WriteLine(str1.IndexOf("にわ", 2, 5));
            Console.WriteLine(str1.LastIndexOf("にわ", 5, 3));
            //Console.WriteLine(str1.IndexOf("にわ", 5, 10));

            //---- bool ----
            var str2 = "WINGSプロジェクト";
            Console.WriteLine(str2.Contains("プロ"));
            Console.WriteLine(str2.StartsWith("WINGS"));
            Console.WriteLine(str2.EndsWith("WINGS"));

            //---- Any(), All() ----
            var str3 = "WINGS2号";
            Console.WriteLine(str3.Any(ch => Char.IsDigit(ch)));
            Console.WriteLine(str3.All(ch => Char.IsDigit(ch)));

        }//Main()
    }//class
}

/*
//---- index ----
0  //IndexOf("にわ")
-1 //IndexOf("にも")
6  //LastIndexOf("にわ")
4  //IndexOf("にわ", 3)
0  //LastIndexOf("にわ", 3)
4  //IndexOf("にわ", 2, 5)
4  //LastIndexOf("にわ", 5, 3)

//IndexOf("にわ", 5, 10)
System.ArgumentOutOfRangeException: 
カウントは正の数で、文字列/配列/コレクション内の場所を参照しなければなりません。 

//---- bool ----
True  //Contains("プロ")
True  //StartsWith("WINGS")
False //EndsWith("WINGS")

//---- Any(), All() ----
True  //Any(ch => Char.IsDigit(ch))
False //All(ch => Char.IsDigit(ch))

 */
