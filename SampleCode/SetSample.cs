/**
 * @title CsharpBegin / SampleCode / SetSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第６章 コレクション / p230 / List 6-7
 *          Set, HashSet
 *       
 * @author shika
 * @date 2021-09-07
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class SetSample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            var here = new SetSample();
            HashSet<int> set = new HashSet<int> { 1, 20, 30, 60, 10, 15 };
            set.Add(10);
            set.Add(5);
            here.ShowValue(set, nameof(set));

            Console.WriteLine("Count: " + set.Count);
            Console.WriteLine("Contains(10): " + set.Contains(10));

            var set2 = new HashSet<int> { 10, 15, 30 };
            here.ShowValue(set2, nameof(set2));
            Console.WriteLine("IsSupersetOf(): " + set.IsSupersetOf(set2));
            Console.WriteLine("IsProperSupersetOf(): " + set.IsProperSupersetOf(set2));
            Console.WriteLine("IsSubsetOf(): " + set.IsSubsetOf(set2));
            Console.WriteLine("IsProperSubSetOf(): " + set.IsProperSubsetOf(set2));
            Console.WriteLine("Overlaps(): " + set.Overlaps(set2));
            Console.WriteLine("SetEquals(): " + set.SetEquals(set2));

            var set3 = new HashSet<int> { 1, 10, 20, 30, 60 };
            here.ShowValue(set3, nameof(set3));
            Console.Write("積集合: ");
            set.IntersectWith(set3);
            here.ShowValue(set, nameof(set));

            var set4 = new HashSet<int> { 15, 30 };
            here.ShowValue(set4, nameof(set4));
            Console.Write("差集合: ");
            set.ExceptWith(set4);
            here.ShowValue(set, nameof(set));

            Console.Write("和集合: ");
            set.UnionWith(set2); 
            here.ShowValue(set, nameof(set));

        }//Main()

        private void ShowValue(HashSet<int> set, string setName)
        {
            Console.Write(setName + ": ");
            foreach (int v in set)
            {
                Console.Write(v + ", ");
            }
            Console.WriteLine();
        }
    }//class
}

/*
set: 1, 20, 30, 60, 10, 15, 5,
Count: 7
Contains(10): True

set2: 10, 15, 30,
IsSupersetOf(): True
IsProperSupersetOf(): True
IsSubsetOf(): False
IsProperSubSetOf(): False
Overlaps(): True
SetEquals(): False

set3: 1, 10, 20, 30, 60,
積集合: set: 1, 20, 30, 60, 10,

set4: 15, 30,
差集合: set: 1, 20, 60, 10,

和集合: set: 1, 20, 15, 60, 10, 30,
 */
