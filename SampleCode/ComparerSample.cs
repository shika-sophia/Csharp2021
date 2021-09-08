/**
 * @title CsharpBegin / SampleCode / ComparerSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第６章 コレクション / p239 /  6-12, 6-13
 *          ◆List.Sort(IComparer<T>)
 *            List.Sort(Comparison<T>)
 *          ◆IComparer<T>継承クラスを定義して、ソート基準を自己定義
 *            Comarison<T>デリゲート
 * 
 * @see SortedDictionarySample.cs
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
    class ComparerSample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            var list = new List<string>()
            {
                "ひまわり","チューリップ","バラ","あざみ",
            };
            ShowList(list);
            Console.WriteLine();

            //---- Sort() 辞書順 ----
            list.Sort();
            ShowList(list);
            Console.WriteLine();

            //---- Sort(IComparer<T>) 文字数順 ----
            list.Sort(new LengthComparer());
            ShowList(list);
            Console.WriteLine();

            //---- Sort(Comparison<T>) 文字数逆順 ----
            list.Sort((x, y) => -(x.Length - y.Length));
            ShowList(list);
            Console.WriteLine();
        }//Main()

        private static void ShowList(List<string> list)
        {
            foreach (string v in list)
            {
                Console.Write(v + ", ");
            }
            Console.WriteLine();
        }
    }//class
}

/*
@see SortedDictionarySample.cs
class LengthComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return x.Length - y.Length;
    }
}
//---- before Sort() ----
ひまわり, チューリップ, バラ, あざみ,

//---- Sort() 辞書順 ----
あざみ, チューリップ, バラ, ひまわり,

//---- Sort(IComparer<T>) 文字数順 ----
バラ, あざみ, ひまわり, チューリップ,
 
//---- Sort(Comparison<T>) 文字数逆順 ----
チューリップ, ひまわり, あざみ, バラ,
 */
