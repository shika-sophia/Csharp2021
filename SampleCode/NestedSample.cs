/** 
 *@title CsharpBegin / SampleCode / NestedSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content ◆NestedSample / p432 / List 9-36, 9-37
 *         ＊インスタンス
 *         Outer -> Inner: new Inner();
 *         Inner -> Outer: new Outer();
 *         foreign (外部クラス) -> Inner: new Outer.Inner();
 * 
 *@author shika 
 *@date 2021-10-28 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class NestedSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            OuterSample outer = new OuterSample();
            outer.Show();

            OuterSample.InnerSample inner = 
                new OuterSample.InnerSample();
            inner.Show();
        }//Main() 
    }//class NestedSample

    class OuterSample
    {
        string str1 = "Outer/instance";  //default: internal
        private string str2 = "Outer/private";
        static string str3 = "Outer/static";

        public void Show()
        {
            InnerSample inner = new InnerSample();
            Console.WriteLine("Outer.Show() -> Inner");
            Console.WriteLine($"str4: {inner.str4}");
            //以下、いずれもアクセス不可
            //Console.WriteLine($"str5: {inner.str5}");
            //Console.WriteLine($"str6: {inner.str6}");
            //Console.WriteLine($"str7: {InnerSample.str7}");
        }

        public class InnerSample
        {
            internal string str4 = "Inner/internal";
            string str5 = "Inner/instance";      //default: private
            private string str6 = "Inner/private";
            static string str7 = "Inner/static"; //default: private

            public void Show()
            {
                OuterSample outer = new OuterSample();
                Console.WriteLine("Inner.Show() -> Outer");
                Console.WriteLine($"str1: {outer.str1}");
                Console.WriteLine($"str2: {outer.str2}");
                Console.WriteLine($"str3: {OuterSample.str3}");

                Console.WriteLine("Inner.Show() -> Inner");
                Console.WriteLine($"str4: {str4}");
                Console.WriteLine($"str5: {str5}");
                Console.WriteLine($"str6: {str6}");
                Console.WriteLine($"str7: {str7}");
            }
        }//class Inner
    }//class Outer
}
/*
Outer.Show() -> Inner
str4: Inner/internal

Inner.Show() -> Outer
str1: Outer/instance
str2: Outer/private
str3: Outer/static

Inner.Show() -> Inner
str4: Inner/internal
str5: Inner/instance
str6: Inner/private
str7: Inner/static
 */