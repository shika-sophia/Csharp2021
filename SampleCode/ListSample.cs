/**
 * @title CsharpBegin / SampleCode / ListSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第６章 コレクション / p215 /  6-1, 6-2, 6-3
 *          List, Enumerator, ListMember, list[0]
 *       
 * @author shika
 * @date 2021-09-05
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class ListSample
    {
        //internal void Main(string[] args)
        static void Main(string[] args)
        {
            //---- List ----
            var list = new List<string>
            {
                "バラ","ひまわり","チューリップ"
            };

            foreach(var s in list)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            list.Add("あさがお");

            //---- Enumerator ----
            List<string>.Enumerator enu = list.GetEnumerator();

            while (enu.MoveNext())
            {
                string str = enu.Current;
                Console.WriteLine(str);
            }//while
            Console.WriteLine();

            //---- ListMember ----
            var list2 = new List<int> { 10, 15, 30, 60 };
            var list3 = new List<int> { 1, 5, 3, 6 };

            list2.Insert(2, 7);
            list2.Add(120);
            ShowListInt(list2);

            Console.WriteLine("Count: " + list2.Count);
            Console.WriteLine("list[0]: " + list2[0]);
            Console.WriteLine("Contains(30): " + list2.Contains(30));
            Console.WriteLine("IndexOf(30): " + list2.IndexOf(30));
            Console.WriteLine("LastIndexOf(120): " + list2.LastIndexOf(120));
            Console.WriteLine("Remove(60): " + list2.Remove(60));
            ShowListInt(list2);

            //---- AddRange(IEnumerable<T>), GetRange(int, int), Reserve() ----
            list2.AddRange(list3);
            ShowListInt(list2);
            ShowListInt(list2.GetRange(2, 4));

            list2.Reverse();
            ShowListInt(list2);

            //---- CopyTo(int index, T[], int aryStart, int aryCount) ----
            var ary2 = new int[3];
            list2.CopyTo(2, ary2, 0, 3);
            Console.WriteLine("ary2: " + String.Join(", ", ary2));
            Console.WriteLine();
        }//Main()

        private static void ShowListInt(List<int> list)
        {
            foreach (var v in list)
            {
                Console.Write(v + ", ");
            }
            Console.WriteLine("\n");
        }
    }//class
}

/*
//---- List ----
バラ
ひまわり
チューリップ

//---- Enumerator ----
バラ
ひまわり
チューリップ
あさがお

//---- ListMember ----
10, 15, 7, 30, 60, 120,

Count: 6
list[0]: 10
Contains(30): True
IndexOf(30): 3
LastIndexOf(120): 5
Remove(60): True
10, 15, 7, 30, 120,

//---- AddRange(IEnumerable<T>) ----
10, 15, 7, 30, 120, 1, 5, 3, 6,

//---- GetRange(int, int) ----
7, 30, 120, 1,

//----  Reserve() ----
6, 3, 5, 1, 120, 30, 7, 15, 10,

//---- CopyTo(int index, T[], int aryStart, int aryCount) ----
ary2: 5, 1, 120
 */
