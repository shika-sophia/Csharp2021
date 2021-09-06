/**
 * @title CsharpBegin / SampleCode / StackSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第６章 コレクション / p224 /  6-5
 *          Stack
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
    class StackSample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Push(15);
            stack.Push(30);
            stack.Push(40);

            foreach(int v in stack)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine(String.Join(",", stack.ToArray()));

            Console.WriteLine("Count: " + stack.Count);
            Console.WriteLine("Contains(30): " + stack.Contains(30));
            Console.WriteLine("Pop(): " + stack.Pop());
            Console.WriteLine("Peek(): " + stack.Peek());
            Console.WriteLine("Pop(): " + stack.Pop());

            Console.WriteLine(String.Join(",", stack.ToArray()));
        }//Main()
    }//class
}

/*
40
30
15
10
40,30,15,10
Count: 4
Contains(30): True
Pop(): 40
Peek(): 30
Pop(): 30
15,10
 * 
 */