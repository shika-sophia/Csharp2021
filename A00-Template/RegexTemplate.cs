/**
 * @title CsharpBegin / A00_Template / RegexTemplate.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第５章 標準ライブラリ / 正規表現 / p165 / List 5-16 ～
 *   ◆System.Text.RegularExpressions.Regex
 *   コンストラクタ Regex(string, [RegexOptions])
 *   bool regex.IsMatch(string input, [int start])
 *   bool Regex.IsMatch(string input, [string pattern, RegexOptions])//static
 *   
 *   //---- Match() ---- マッチ文字列を最初の１つだけ取得
 *   Match regex.Match(string input, [int start, int length])
 *   Match Regex.Match(string input, [string pattern, RegexOptions]) //static
 *   bool match.Success
 *   int match.Index
 *   inr match.Length
 *   string match.Value
 *   GroupCollection match.Groups マッチした部分文字列のコレクション
 *   foreach(Group group in match.Groups)
 *   
 *   //---- Matches() ---- マッチ文字列を複数取得する場合
 *   MatchCollection regex.Matches(string input, [int start])
 *   int matches.Count
 *   Match matches[0]
 *   foreach(Match match in matches)
 *   
 * @author shika
 * @date 2021-09-17
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsharpBegin.A00_Template
{
    class RegexTemplate
    {
        Regex regexPost = new Regex(@"(\d{3,4})-(\d{4})");
        Regex regexTel = new Regex(@"(\d{2,4})-(\d{2,4})-(\d{4})");
        Regex regexMail = new Regex(
            @"[a-z0-9.!#$%&'+*/=?^_{|}-]+@[a-z0-9-]+(?:\.[a-z0-9-]+)*",
            RegexOptions.IgnoreCase);
        Regex regexHttp = new Regex(@"http(s)?://.*");

        static void Main(string[] args)
        //internal void Main(string[] args)
        {
            var here = new RegexTemplate();
            var dataAry = new[] { "090-0000-0000", "045-000-0000", "184-0000" };
            
            //---- IsMatch() ----
            foreach(var data in dataAry)
            {
                Console.WriteLine(here.regexTel.IsMatch(data) ? data : "// unmatch //");
            }

            //---- Match() ----
            var data2 = "電話番号は 090-0000-0000です。";
            Match match = here.regexTel.Match(data2);

            if (match.Success)
            {
                Console.WriteLine(
                    $"位置: {match.Index} / 文字数: {match.Length} / マッチ文字列: {match.Value}");
                
                foreach(Group group in match.Groups)
                {
                    Console.WriteLine(group.Value);
                }
            }//if

            //---- Matches() ----
            var data3 = "自宅は 06-0000-0000です。携帯は 090-0000-0000です。";
            MatchCollection matches = here.regexTel.Matches(data3);

            Console.WriteLine("Count: " + matches.Count);
            Console.WriteLine("matches[0]: " + matches[0]);
            foreach(Match m in matches)
            {
                Console.WriteLine(
                    $"位置: {m.Index} / 文字数: {m.Length} / マッチ文字列: {m.Value}");
            }
        }//Main()
    }//class
}

/*
090-0000-0000
045-000-0000
// unmatch //

//---- Match() ----
位置: 6 / 文字数: 13 / マッチ文字列: 090-0000-0000

GroupCollection
090-0000-0000 //[0]マッチ文字列全体
090
0000
0000

//---- Matches() ----
Count: 2
matches[0]: 06-0000-0000
位置: 4 / 文字数: 12 / マッチ文字列: 06-0000-0000
位置: 23 / 文字数: 13 / マッチ文字列: 090-0000-0000
 */