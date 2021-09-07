/**
 * @title CsharpBegin / SampleCode / SortedSetSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第６章 コレクション / p231 / List 6-8
 *          Set, SortedSet
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
    class SortedSetSample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            var here = new SortedSetSample();
            SortedSet<int> sorted = new SortedSet<int> { 30, 60, 10, 15 };
            sorted.Add(10);
            sorted.Add(5);
            sorted.Remove(60);
            here.ShowValue(sorted);

            Console.WriteLine("Count: " + sorted.Count);
            Console.WriteLine("Min: " + sorted.Min);
            Console.WriteLine("Max: " + sorted.Max);

            var sorted2 = new SortedSet<int> { 10, 15, 30 };
            Console.WriteLine("IsSuperset: " + sorted.IsSupersetOf(sorted2));

            sorted.ExceptWith(new HashSet<int> { 15, 30 });
            sorted.Remove(10);
            here.ShowValue(sorted);
        }//Main()

        private void ShowValue(SortedSet<int> sorted)
        {
            foreach(int v in sorted)
            {
                Console.Write(v + ", ");
            }
            Console.WriteLine();
        }
    }//class
}

/*
5, 10, 15, 30,
Count: 4
Min: 5
Max: 30
IsSuperset: True
5,
 */