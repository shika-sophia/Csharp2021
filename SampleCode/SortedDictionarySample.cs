/**
 * @title CsharpBegin / SampleCode / SortedDictionarySample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第６章 コレクション / p237 /  6-10, 6-11
 *          ◆SortedDictionary
 *          ◆IComparer<T>継承クラスを定義して、ソート基準を自己定義
 * 
 * @see ComparerSample.cs
 * @author shika
 * @date 2021-09-08
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class SortedDictionarySample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            var sd = new SortedDictionary<string, string>()
            {
                ["Rose"] = "バラ",
                ["Lily"] = "ゆり",
                ["Sunflower"] = "ひまわり",
            };

            //sdの key,valueを表示
            foreach (string key in sd.Keys)
            {
                Console.WriteLine($"{key}: {sd[key]}");
            }
            Console.WriteLine();

            //---- コンストラクタに Comararerを渡す ----
            var sd2 = new SortedDictionary<string,string>(new LengthComparer())
            {
                ["Rose"] = "バラ",
                ["MornigGlory"] = "あさがお",
                ["Sunflower"] = "ひまわり",
            };
            //sd2の key,valueを表示
            foreach (string key in sd2.Keys)
            {
                Console.WriteLine($"{key}: {sd2[key]}");
            }
        }//Main()
    }//class

    class LengthComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x.Length - y.Length;
        }
    }

}

/*
Lily: ゆり
Rose: バラ
Sunflower: ひまわり

【考察】
一度生成した Keyの配列を再び生成はできないのか
例外の原因は不明。
//sd -> sd2に、key,valueの代入
foreach(KeyValuePair<string,string> entry in sd)
{
    sd2.Add($"entry.Key", $"entry.Value");
}
//System.ArgumentException: 同じキーのエントリが既に存在します。

//---- コンストラクタに Comararerを渡す ----
Rose: バラ
Sunflower: ひまわり
MornigGlory: あさがお
 */