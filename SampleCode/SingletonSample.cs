/**
 * @title CsharpBegin / SampleCode / SingletonSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第７章 オブジェクト指向 基本 / p280 / List 7-23
 *          ◆Singleton [GOF]
 *          
 * @class SingletonSample
 * @class MultiInstance
 * @class SingletonUser / ◆Main()
 * 
 * @author shika
 * @date 2021-09-13
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class SingletonSample
    {
        private static SingletonSample instance = new SingletonSample();
        private static int Number;
        
        private SingletonSample()
        {
            Number++;
        } //constructor

        public static SingletonSample Instance
        {
            get
            {
                return instance;
            }
        }//Instance

        public static int GetNumber()
        {
            return Number;
        }

    }//class

    class MultiInstance
    {
        private static int Number;
        public MultiInstance() 
        {
            Number++;
        }
        public static int GetNumber()
        {
            return Number;
        }
    }//class

    class SingletonUser
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            //var instance = new SingletonSample(); //privateコンストラクタのため不可
            var instance1 = SingletonSample.Instance;
            var instance2 = SingletonSample.Instance;
            Console.WriteLine("instance1 == instance2: " + (instance1 == instance2));
            Console.WriteLine("SingletonSample.Number: " + SingletonSample.GetNumber());

            var instance3 = new MultiInstance();
            var instance4 = new MultiInstance();
            Console.WriteLine("instance3 == instance4: " + (instance3 == instance4));
            Console.WriteLine("MultiInstance.Number: " + MultiInstance.GetNumber());
        }//Main()
    }//class
}

/*
//====== Result ======
instance1 == instance2: True
SingletonSample.Number: 1

instance3 == instance4: False
MultiInstance.Number: 2
 */