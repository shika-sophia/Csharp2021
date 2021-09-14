/**
 * @title CsharpBegin / SampleCode / StringSearchSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第５章 標準ライブラリ / p147 / List 5-7 ～ 5-
 *          ◆String
 *          int string.IndexOf(T, [int start, int count])
 *          int string.LastIndexOf(T, [int start, int count])
 *          
 * @author shika
 * @date 2021-09-14
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
        static void Main(string[] args)
        //internal void Main(string[] args)
        {
            var str1 = "にわにはにわにわとりがいる";
            Console.WriteLine(str1.IndexOf("にわ"));
            Console.WriteLine(str1.IndexOf("にも"));
            Console.WriteLine(str1.LastIndexOf("にわ"));
                
            Console.WriteLine(str1.IndexOf("にわ", 3));
            Console.WriteLine(str1.LastIndexOf("にわ", 3));

            Console.WriteLine(str1.IndexOf("にわ", 2, 5));
            Console.WriteLine(str1.LastIndexOf("にわ", 5, 3));
            Console.WriteLine(str1.IndexOf("にわ", 5, 10));
        }//Main()
    }//class
}

/*
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
 */
