/**
 * @title CsharpBegin / SampleCode / ConstructorSample
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第７章　オブジェクト指向 基本 / p270 / List 7-17
 *          ◆Constructor
 *            Constructor初期化子
 *            Destructor
 *       
 * @author shika
 * @date 2021-09-11
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class ConstructorSample
    {
        //static void Main(string[] args)
        //{
        //    var here = new ConstructorSample();
        //    here.Main();
        //}

        internal void Main()
        {
            var p = new PersonSample();
            p.Show();
        }//Main()
    }//class

    internal class PersonSample
    {
        public string firstName;
        public string lastName;

        public PersonSample() : this("権兵衛", "名無し") { }

        public PersonSample(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            Console.WriteLine(this.ToString() + ": Constructor");
        }

        public void Show()
        {
            Console.WriteLine($"名前は{lastName}{firstName}です。");
        }

        ~PersonSample()
        {
            Console.WriteLine(this.ToString() + ": Destructor");
        }
    }//class

}

/*
CsharpBegin.SampleCode.PersonSample: Constructor
名前は名無し権兵衛です。
CsharpBegin.SampleCode.PersonSample: Destructor
 */
