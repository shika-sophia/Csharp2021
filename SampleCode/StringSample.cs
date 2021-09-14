/**
 * @title CsharpBegin / SampleCode / StringSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第５章 標準ライブラリ / p147 / List 5-1 ～ 5-6
 *          ◆String
 *          int string.Length
 *          int stringInfo.LengthInTextElements サロゲートペアの文字数を正しく表示
 *          bool string.Equals(string, [StringComparison])
 *          int static String.Compare(string, string, [StringComparison])
 *          bool String.IsNullOrEmpty(string)
 *          bool String.IsNullOrWhiteSpace(string)   
 *          
 *          ◆CultureInfo.CurrentCulture.CompareInfo 〔new不可〕
 *          CompareOptions.IgnoreCase 大文字・小文字を区別しない
 *          CompareOptions.IgnoreSymbols 空白・記号を区別しない
 *          CompareOptions.IgnoreWidth 全角・小文字を区別しない
 *          CompareOptions.IgnoreKanaType ひらがな・カタカナを区別しない
 *          
 * @author shika
 * @date 2021-09-14
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class StringSample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            //---- string.Length ----
            var str1 = "WINGSプロジェクト";
            Console.WriteLine("str1.Length: " + str1.Length);

            var str2 = "叱る";
            Console.WriteLine("str2.Length: " + str2.Length);

            StringInfo str2Info = new StringInfo(str2);
            Console.WriteLine("str2Info.Length: " + str2Info.LengthInTextElements);

            //---- string.Compare() ----
            //大文字・小文字の同一視
            var str3 = "wings";
            var str4 = "WINGS";
            StringComparison compaIgn = StringComparison.OrdinalIgnoreCase;
            Console.WriteLine(str3.Equals(str4, compaIgn));
            Console.WriteLine(String.Compare(str3, str4, compaIgn));

            //---- CultureInfo ----
            //全角・半角の同一視
            var full = "ＷＩＮＧＳ";
            var half = "WINGS";
            var culture = CultureInfo.CurrentCulture.CompareInfo;
            Console.WriteLine(culture.Compare(full, half));
            Console.WriteLine(culture.Compare(full, half, CompareOptions.IgnoreWidth));

            //ひらがな・カタカナの同一視
            var hira = "ぷろじぇくと";
            var kata = "プロジェクト";
            //var culture = CultureInfo.CurrentCulture.CompareInfo;
            Console.WriteLine(culture.Compare(hira, kata));
            Console.WriteLine(culture.Compare(hira, kata, CompareOptions.IgnoreKanaType));

            //---- null・空文字の判定 ----
            string strNull = null;
            var empty = "";
            var space = "   ";
            Console.WriteLine(empty == null || empty == "");
            Console.WriteLine(String.IsNullOrEmpty(strNull));
            Console.WriteLine(String.IsNullOrEmpty(empty));
            Console.WriteLine(String.IsNullOrEmpty(space));
            Console.WriteLine(String.IsNullOrWhiteSpace(space));
        }//Main()
    }//class
}

/*
str1.Length: 11
str2.Length: 2

【考察】サロゲートペア
「叱」は４バイトで表すサロゲートペア文字。
「叱る」で Length: 3を期待したコードだが、2と出ている。
自動でサロゲートペアを検出している可能性もある。

str2Info.Length: 2

//---- string.Compare() ----
True //Equals()
0    //Compare()

//---- CultureInfo ----
//全角・半角の同一視
1   //異なる (全角は辞書順で後)
0   //同じ

//ひらがな・カタカナの同一視
1  //異なる (カタカナは辞書順で後)
0  //同じ

//---- null・空文字の判定 ----
True //empty == null || empty == ""
True //IsNullOrEmpty(strNull)
True //IsNullOrEmpty(empty)
False//IsNullOrEmpty(space)
True //IsNullOrWhiteSpace(space)
 */
