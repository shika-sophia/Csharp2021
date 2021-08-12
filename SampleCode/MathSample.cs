/**
 * @title CsharpBegin / SampleCode / GotoSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第５章 標準ライブラリ / p202 /  5-48
 *          Mathクラスの staticメソッド
 *          
 * @author shika
 * @date 2021-08-12
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class MathSample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            Console.WriteLine(Math.Abs(-100));
            Console.WriteLine(Math.Max(6, 3));
            Console.WriteLine(Math.Min(6, 3));
            Console.WriteLine(Math.Ceiling(1234.56));
            Console.WriteLine(Math.Floor(1234.56));
            Console.WriteLine(Math.Round(1234.56, MidpointRounding.AwayFromZero));

            Console.WriteLine(Math.Sqrt(10000));
            Console.WriteLine(Math.Pow(2, 4));
            Console.WriteLine(Math.Sign(-100));

            Console.WriteLine(Math.Cos(Math.PI / 180 * 60));
            Console.WriteLine(Math.Sin(Math.PI / 180 * 30));
            Console.WriteLine(Math.Tan(Math.PI / 180 * 45));

            Console.WriteLine(Math.Log(125, 5));
            Console.WriteLine(Math.Log10(100));
            Console.WriteLine(Math.Exp(10));

        }//Main()
    }//class
}

/*
100
6
3
1235
1234
1235
100
16
-1
0.5
0.5
1
3
2

 */