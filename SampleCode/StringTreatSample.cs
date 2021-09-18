/**
 * @title CsharpBegin / SampleCode / StringTreatSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第５章 標準ライブラリ / p153 / List 5-11 ～ 5-14
 *          ◆String
 *          string string.Trim()
 *          string string.Substring(int start, [int length])
 *          
 *          @" "構文
 *          []ブラケット構文
 *          foreach(char ch in string)
 *          
 *          //---- Split() ----
 *          string[] string.Split(param char[])
 *          string[] string.Split(char[] separators, [int, StringSplitOptions])
 *          
 *          //---- Join() ----
 *          string String.Join(string separator, string[])
 *          
 *          //---- Replace() ----
 *          string string.Replace(char old, char new)
 *          string string.Replace(string old, string new)
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
    class StringTreatSample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            //---- Substring() ----
            var str1 = "WINGSプロジェクト";
            Console.WriteLine(str1.Substring(5));
            Console.WriteLine(str1.Substring(5, 2));

            //---- @" "構文 ----
            string path = @"C:\data\wings.jpg";
            Console.WriteLine(path.Substring(0, path.LastIndexOf(".")));
            Console.WriteLine(path.Substring(path.LastIndexOf(".") + 1));

            //---- []ブラケット構文 ----
            Console.WriteLine(str1[5]);
            Console.WriteLine(path[0]);

            //---- foreach ----
            string sub = str1.Substring(0, 5);
            foreach (char ch in sub)
            {
                Console.WriteLine(ch);
            }

            //---- Split(), Join() ----
            var str2 = "うめ, もも, さくら";
            string[] result2 = str2.Split(',');
            Trimer(result2);
            Console.WriteLine(String.Join("&", result2));

            var str3 = "うめ, もも, さくら | あんず";
            string[] result3 = str3.Split(',', '|');
            Trimer(result3);
            Console.WriteLine(String.Join("&", result3));

            var str4 = "うめ　もも\tさくら\n あんず";
            string[] result4 = str4.Split(); //下記【考察】
            Console.WriteLine(String.Join("&", result4));

            var str5 = "うめ, もも, さくら, あんず";
            string[] result5 = str5.Split(new[] {','}, 2);
            Trimer(result5);
            Console.WriteLine(String.Join("&", result5));

            var str6 = "うめ\t\nもも\tさくら\n あんず";
            string[] result6 = str6.Split(new[] { '\t', '\n' },
                StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(String.Join("&", result6));

            string[] result7 = str6.Split(new[] { '\t', '\n' });
            Console.WriteLine(String.Join("&", result7));
        }//Main()

        //string[]各要素の空白を除去
        private static void Trimer(string[] ary)
        {
            for (int i = 0; i < ary.Length; i++)
            {
                ary[i] = ary[i].Trim();
            }
        }//Trimer()
    }//class
}

/*
//---- Substring() ----
プロジェクト //Substring(5)
プロ        //Substring(5, 2)

//---- @" "構文 ----
C:\data\wings
jpg

//---- []ブラケット構文
プ //str1[5]
C  //path[0]

//---- foreach ----
W
I
N
G
S

//---- Split(), Join() ----
うめ&もも&さくら
うめ&もも&さくら&あんず
うめ&もも&さくら&&あんず
【考察】str4.Split();
引数なしSplit()は空白(全角半角),タブ「\t」,改行「\n」で分割。
「\n_」は改行と空白があるので、「\n」と「" "」の間に""の要素が生成される。
Join()で結合すると「&&」となる。

うめ&もも, さくら, あんず
【考察】str5.Split(new[] {','}, 2);
Length 2の配列に分割、
最終要素に分割していない残りの要素が 1つのstringとして格納。
「もも, さくら, あんず」が 1つのstringなので、Trim()は間の空白には効かず。

うめ&もも&さくら& あんず
【考察】
var str6 = "うめ\t\nもも\tさくら\n あんず";
string[] result6 = str6.Split(new[] { '\t', '\n' },
    StringSplitOptions.RemoveEmptyEntries);
「\t\n」で間に""の要素が生成されるが
StringSplitOptions.RemoveEmptyEntriesによって除去される。
「\n_」は「_あんず」の空白であるため、Trim()をしないと除去されない。

うめ&&もも&さくら& あんず
【考察】
string[] result7 = str6.Split(new[] { '\t', '\n' });
上記 str6を StringSplitOptionsなしで分割した場合。
「\t\n」 -> 「&&」となる。
 */