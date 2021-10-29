/** 
 *@title CsharpBegin / SampleCode / PartialSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content PartialSample / p438 / List 9-38 ～ 9-42
 *
 *@content //====== partial method ======
 *         メソッド宣言と本体定義の分離
 *@class partial PartialSample / ◆Main() new MyPartial
 *       void partial Print(MyPartial); //宣言のみ
 *@class partial PartialSample
 *       void partial Print(MyPartial) { Console.WriteLine() }
 *       
 *@content //====== partial class ======
 *         フィールド / プロパティの共有
 *@class partial MyPartial
 *       / string FirstName { }
 *         string LastName { } /
 *         + string ShowName()
 *@class partial MyPartial
 *         + string Greet()
 *         
 *@author shika 
 *@date 2021-10-29 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    //====== partial method ======
    partial class PartialSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var integral = new MyPartial
            {
                LastName = "山田",
                FirstName = "太郎"
            };

            var here = new PartialSample();
            here.Print(integral);
        }//Main()

        partial void Print(MyPartial integral);
    }//class

    partial class PartialSample
    {
        partial void Print(MyPartial integral)
        {
            Console.WriteLine($"ShowName(): {integral.ShowName()}");
            Console.WriteLine($"Greet(): {integral.Greet()}");
        }
    }//class

    //====== partial class ======
    partial class MyPartial
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ShowName()
        {
            return $"名前は {LastName}{FirstName}です。";
        }
    }//class MyPartial ShowName()

    partial class MyPartial
    {
        public string Greet()
        {
            return $"Hello {LastName}{FirstName}さん。";
        }
    }//class MyPartial Greet()
}

/*
ShowName(): 名前は 山田太郎です。
Greet(): Hello 山田太郎さん。
 */
