/**
 * @title CsharpBegin / SampleCode / LinkedListSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第６章 コレクション / p222 /  6-4
 *          LinkedList
 *       
 * @author shika
 * @date 2021-09-06
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class LinkedListSample
    {
        internal void Main(string[] args)
        //static void Main(string[] args)
        {
            var here = new LinkedListSample();
            string[] animalAry = new[] { "とら", "うさぎ", "たつ" };
            LinkedList<string> list = new LinkedList<string>(animalAry);
            here.ShowList(list);

            Console.WriteLine("Count: " + list.Count);
            Console.WriteLine("Contains(とら): " + list.Contains("とら"));
            list.AddFirst("ねずみ");
            list.AddLast("いのしし");
            list.AddBefore(list.Last, "いぬ");
            list.AddAfter(list.First, "うし");
            here.ShowList(list);

            list.Remove("たつ");
            list.RemoveLast();
            here.ShowList(list);

            LinkedListNode<string> node = list.First;
            list.Remove(node);
            list.AddLast(node);
            here.ShowList(list);

        }//Main()

        private void ShowList(LinkedList<string> list)
        {
            foreach (string v in list)
            {
                Console.Write(v + ", ");
            }
            Console.WriteLine("\n");
        }//ShowList()
    }//class
}

/*
とら, うさぎ, たつ,

Count: 3
Contains(とら): True
ねずみ, うし, とら, うさぎ, たつ, いぬ, いのしし, 

ねずみ, うし, とら, うさぎ, いぬ,

うし, とら, うさぎ, いぬ, ねずみ,
 */
