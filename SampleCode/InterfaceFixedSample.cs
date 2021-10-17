/**
 *@title CsharpBegin / SampleCode / InterfaceFixedSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 第８章 / インターフェイス / p376 / List 8-29
 *  ◆明示的なインターフェイス実装
 *
 *@class InterfaceFixedSample / ◆Main() new ImplementSample()
 *interface IHogeSample / +Foo(string) abstract
 *interface IHoge2Sample / +Foo(string) abstract
 *class ImplementSample : IHogeSample, IHoge2Sample
 *      / + Foo(string),
 *        - IHogeSampl.Foo(string),
 *        - IHoge2Sampl.Foo(string)
 *        
 *@author shika 
 *@date 2021-10-17 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class InterfaceFixedSample
    {
        static void Main(string[] args)
        //public void Main(string[] args)
        {
            ImplementSample impl = new ImplementSample();
            impl.Foo("あ");

            IHogeSample hoge = (IHogeSample)impl;
            hoge.Foo("い");

            IHoge2Sample hoge2 = (IHoge2Sample)impl;
            hoge2.Foo("う");
        }//Main()
    }//class

    interface IHogeSample
    {
        void Foo(string str);
    }

    interface IHoge2Sample
    {
        void Foo(string str);
    }

    class ImplementSample : IHogeSample, IHoge2Sample
    {
        //暗黙的な実装
        public void Foo(string str)
        {
            Console.WriteLine($"暗黙的: {str}");
        }

        //明示的な実装 IHoge
        void IHogeSample.Foo(string str)
        {
            Console.WriteLine($"IHoge: {str}");
        }

        //明示的な実装 IHoge2
        void IHoge2Sample.Foo(string str)
        {
            Console.WriteLine($"IHoge2: {str}");
        }
    }//class
}

/*
暗黙的: あ
IHoge: い
IHoge2: う

 */
