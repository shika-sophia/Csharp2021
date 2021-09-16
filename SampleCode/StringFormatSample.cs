/**
 * @title CsharpBegin / SampleCode / StringFormatSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第５章 標準ライブラリ / p158 / List 5-15
 *   ◆String.Format
 *   string String.Format([IFormatProvider], string, [object, ...])
 *   string $" "構文
 *   書式指定子 {index, [align,] : formatType[prec]}
 *       
 * @author shika
 * @date 2021-09-16
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class StringFormatSample
    {
        static void Main(string[] args)
        //internal void Main(string[] args)
        {
            Console.WriteLine(
                String.Format("{0}は{1}、{2}歳です。",
                "さくら", "女の子", 1));

            Console.WriteLine(
                String.Format("名前は{0}、{0}は元気です。",
                "さくら", "女の子"));

            Console.WriteLine(
                String.Format("名前は{0, 5}です。","さくら"));

            Console.WriteLine(
                String.Format("名前は{0, -5}です。", "さくら"));

            Console.WriteLine(
                String.Format("10進数で８桁: {0:d8}", 12345));
            Console.WriteLine(
                String.Format("指数表現(小文字): {0:e2}", 12345));
            Console.WriteLine(
                String.Format("指数表現(大文字): {0:E2}", 12345));

            CultureInfo culture = new CultureInfo("da-DK");
            Console.WriteLine(String.Format(
                culture, "通貨(デンマーク): {0:C}", 12345));

            Console.WriteLine(
                String.Format("カスタム(0補完): {0:0,000.000}", 1234.56));
            Console.WriteLine(
                 String.Format("カスタム(補完なし): {0:#,###.###}", 1234.56));
            Console.WriteLine(
                String.Format("カスタム(複合): {0,13:0,000.000}", 1234.56));

            DateTime now = DateTime.Now;
            Console.WriteLine(String.Format("日付: {0:D}", now));

            var price = 1000;
            Console.WriteLine($"価格: {price:C}");
        }//Main()
    }//class
}

/*
さくらは女の子、1歳です。
名前はさくら、さくらは元気です。
名前は  さくらです。
名前はさくら  です。
10進数で８桁: 00012345
指数表現(小文字): 1.23e+004
指数表現(大文字): 1.23E+004
通貨(デンマーク): 12.345,00 kr.
カスタム(0補完): 1,234.560
カスタム(補完なし): 1,234.56
カスタム(複合):     1,234.560
日付: 2021年9月16日
価格: ¥1,000
 */