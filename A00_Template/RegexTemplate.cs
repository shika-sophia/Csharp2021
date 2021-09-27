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
 *   //---- HTTPタグ <.+> <.+?> ----
 *   <.+> 最長一致
 *   <.+?> 最短一致
 *   
 *   //---- Multiline, Singleline ----
 *   RegexOptions.Multiline
 *   RegexOptions.Singleline
 *   
 *   //---- Replace() ----
 *   string regex.Replace(string input, [string replace, int count, int start])
 *   string regex.Replace(string input, [MatchEvaluator, int count, int start])
 *       $0 全体一致
 *       $1, $2... 部分一致
 *       ?<名前> サブマッチに名前を付ける
 *       ${名前} 名前のサブマッチを取得
 *       
 *   //---- Split() ----
 *   string[] regex.Split(string separator,[int count, int start])
 *   
 * @author shika
 * @date 2021-09-17, 9-18
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
        Regex regexMailNamed = new Regex(
            @"(?<local>[a-z0-9.!#$%&'+*/=?^_{|}-]+)@(?<domain>[a-z0-9-]+(?:\.[a-z0-9-]+)*)",
            RegexOptions.IgnoreCase);
        Regex regexUrl = new Regex(@"http(s)?://.*");
        Regex regexHtmlMax = new Regex(@"<.+>");  //最長一致
        Regex regexHtmlMin = new Regex(@"<.+?>"); //最短一致
        Regex regexNormal = new Regex(@"^.+");    //改行を越えてMatch不可
        Regex regexMulti = new Regex(@"^.+", RegexOptions.Multiline);
        Regex regexSingle = new Regex(@"^.+", RegexOptions.Singleline);
        Regex regexCouple = new Regex(@"^.+", RegexOptions.Multiline | RegexOptions.IgnoreCase);   

        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            var here = new RegexTemplate();
            var dataAry = new[] { "090-0000-0000", "045-000-0000", "184-0000" };

            //---- IsMatch() ----
            foreach (var data in dataAry)
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

                foreach (Group group in match.Groups)
                {
                    Console.WriteLine(group.Value);
                }
            }//if

            //---- Matches() ----
            var data3 = "自宅は 06-0000-0000です。携帯は 090-0000-0000です。";
            MatchCollection matches = here.regexTel.Matches(data3);

            Console.WriteLine("Count: " + matches.Count);
            Console.WriteLine("matches[0]: " + matches[0]);
            ShowMatches(matches, nameof(matches));

            //---- HTTPタグ <.+> <.+?> ----
            var data4 = "<p><strong>WINGS</strong>サイト" +
                "<a href='index.html'><img src=''wings.jpg' /></a></p>";
            MatchCollection matchHtmlMax = here.regexHtmlMax.Matches(data4);
            ShowMatches(matchHtmlMax, nameof(matchHtmlMax));

            MatchCollection matchHtmlMin = here.regexHtmlMin.Matches(data4);
            ShowMatches(matchHtmlMin, nameof(matchHtmlMin));

            //---- regexMail ----
            var data5 = "会社: wings@example.com、個人: YAMADA@example.com";
            MatchCollection matchMail = here.regexMail.Matches(data5);
            ShowMatches(matchMail, nameof(matchMail));

            //---- Multiline, Singleline ----
            var data6 = "初めまして、\nよろしくお願いします。";
            MatchCollection matchNormal = here.regexNormal.Matches(data6);
            ShowMatches(matchNormal, nameof(matchNormal));

            MatchCollection matchSingle = here.regexSingle.Matches(data6);
            ShowMatches(matchSingle, nameof(matchSingle));

            MatchCollection matchMulti = here.regexMulti.Matches(data6);
            ShowMatches(matchMulti, nameof(matchMulti));

            //---- Replace() ----
            var data7 = "サイト: http://www.wings.msn.to/";
            Console.WriteLine(here.regexUrl.Replace(data7,
                "<a href='$0'>$0</a>"));

            var data8 = "メールアドレス: wings@example.com";
            Console.WriteLine(here.regexMailNamed.Replace(data8,
                "ドメイン: ${domain} アドレス: ${local}"));
            Console.WriteLine(here.regexMail.Replace(data8,
                m => m.Value.ToUpper()));

            //---- Split() ----
            var data9 = "にわには3わうらにわには52わにわとりがいる";
            Regex regexDecimal = new Regex(@"\d{1,}わ"); //１桁以上の数字+「わ」で分割
            string[] splitDecimal = regexDecimal.Split(data9);
            MatchCollection matchDecimal = regexDecimal.Matches(data9);

            //「数字+"わ"」で分割されるので、結合時に「数字+"わ"」は消えてしまう。
            //マッチしているものが Splitの要素にあれば、マッチ文字列を挿入する。
            for (int i = 0; i < splitDecimal.Length; i++)
            {
                if (i < matchDecimal.Count && matchDecimal[i].Success)
                {
                    splitDecimal[i] = splitDecimal[i] + matchDecimal[i].Value;
                }
            }//for
            Console.WriteLine(String.Join("、", splitDecimal));
        }//Main()

        private static void ShowMatches(MatchCollection matches, string matchName)
        {
            Console.WriteLine("matchName: " + matchName);
            foreach (Match m in matches)
            {
                Console.WriteLine(
                    $"位置: {m.Index} / 文字数: {m.Length} / マッチ文字列: {m.Value}");
            }
        }
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

//---- HTTPタグ <.+> <.+?> ----
matchName: matches
位置: 4 / 文字数: 12 / マッチ文字列: 06-0000-0000
位置: 23 / 文字数: 13 / マッチ文字列: 090-0000-0000

matchName: matchHtmlMax
位置: 0 / 文字数: 81 / マッチ文字列: <p><strong>WINGS</strong>サイト
    <a href='index.html'><img src=''wings.jpg' /></a></p>

matchName: matchHtmlMin
位置: 0 / 文字数: 3 / マッチ文字列: <p>
位置: 3 / 文字数: 8 / マッチ文字列: <strong>
位置: 16 / 文字数: 9 / マッチ文字列: </strong>
位置: 28 / 文字数: 21 / マッチ文字列: <a href='index.html'>
位置: 49 / 文字数: 24 / マッチ文字列: <img src=''wings.jpg' />
位置: 73 / 文字数: 4 / マッチ文字列: </a>
位置: 77 / 文字数: 4 / マッチ文字列: </p>

//---- regexMail ----
matchName: matchMail
位置: 4 / 文字数: 17 / マッチ文字列: wings@example.com
位置: 26 / 文字数: 18 / マッチ文字列: YAMADA@example.com

//---- Multiline, Singleline ----
matchName: matchNormal
位置: 0 / 文字数: 6 / マッチ文字列: 初めまして、

matchName: matchSingle
位置: 0 / 文字数: 18 / マッチ文字列: 初めまして、
よろしくお願いします。

matchName: matchMulti
位置: 0 / 文字数: 6 / マッチ文字列: 初めまして、
位置: 7 / 文字数: 11 / マッチ文字列: よろしくお願いします。

//---- Replace() ----
Replace(data7,"<a href='$0'>$0</a>"));
サイト: <a href='http://www.wings.msn.to/'>http://www.wings.msn.to/</a>

Replace(data8,"ドメイン: ${domain} アドレス: ${local}")
メールアドレス: ドメイン: example.com アドレス: wings

Replace(data8, m => m.Value.ToUpper())
メールアドレス: WINGS@EXAMPLE.COM

//---- Split() ----
にわには3わ、うらにわには52わ、にわとりがいる
 */