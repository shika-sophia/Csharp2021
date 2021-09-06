/**
 * @title CsharpBegin / SampleCode / QueueSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第６章 コレクション / p226 / List 6-6
 *          Queue
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
    class QueueSample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(10);
            que.Enqueue(15);
            que.Enqueue(30);
            que.Enqueue(40);

            foreach (int v in que)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine(String.Join(",", que.ToArray()));

            Console.WriteLine("Count: " + que.Count);
            Console.WriteLine("Contains(30): " + que.Contains(30));
            Console.WriteLine("Dequeue(): " + que.Dequeue());
            Console.WriteLine("Peek(): " + que.Peek());
            Console.WriteLine("Dequeue(): " + que.Dequeue());

            Console.WriteLine(String.Join(",", que.ToArray()));
        }//Main()
    }//class
}

/*
10
15
30
40
10,15,30,40
Count: 4
Contains(30): True
Dequeue(): 10
Peek(): 15
Dequeue(): 15
30,40
 
 */
