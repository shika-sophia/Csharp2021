/** 
 *@title CsharpBegin / SampleCode / ListLambda.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 10.1.7 ListLambda / p488 / List 10-12 ～ 10-18
 *  ◆List<T>のラムダ式メソッド
 *  void       list.ForEach(Action<T>)
 *  List<Tout> list.ConvertAll(Converter<T, Tout>)
 *  T       list.Find(Predicate<T>)
 *  List<T> list.FindAll(Predicate<T>)
 *  int     list.FindIndex([int start, [int count]], Predicate<T>)
 *  int     list.FindLastIndex([int start, [int count]], Predicate<T>)
 *  bool    list.Exists(Predicate<T>)
 *  bool    list.TrueForAll(Predicate<T>)
 *  int     list.RemoveAll(Predicate<T>)
 *  
 *@author shika 
 *@date 2021-11-04 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class ListLambda 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            //---- ForEach(Action<T>) ----
            var listInt = new List<int> { 1, 3, 6, 9 };
            listInt.ForEach(v => Console.Write($"{v * v}, "));
            Console.WriteLine();

            //---- ConvertAll(Converter<T, Tout>) ----
            var listStr = new List<string>
            {
                "いろはにほへと","ちりぬるを","わかよたれそ","つねならむ",
                "うゐのおくやま","けふこえて","あさきゆめみし","ゑひもせす"
            };
            List<string> resultList = listStr.ConvertAll(str => str.Substring(0, 3));
            resultList.ForEach(re => Console.Write($"{re}, "));
            Console.WriteLine();

            //---- Find(), FindAll() ----
            var listStr2 = new List<string>
            {
                "からすなぜ鳴くの", "からすは山に", "かわいい七つの", "子があるからよ" 
            };
            string result = listStr2.Find(str => str.StartsWith("からす"));
            Console.WriteLine(result);
            List<string> resultList2 = listStr2.FindAll(str => str.StartsWith("からす"));
            resultList2.ForEach(re => Console.Write($"{re}, "));
            Console.WriteLine();

            //---- FindIndex(), FindLastIndex() ----
            var listInt2 = new List<int> { 1, -15, 30, 60, -50, 40 };
            Console.WriteLine($"FindIndex(): {listInt2.FindIndex(v => v < 0)}");
            Console.WriteLine($"FindIndex(): {listInt2.FindIndex(2, 3, v => v < 0)}");
            Console.WriteLine($"FindLastIndex(): {listInt2.FindLastIndex(v => v < 0)}");

            //---- Exists(), TrueForAll() ----
            Console.WriteLine($"Exists(): {listStr2.Exists(str => str.Length < 7)}");
            Console.WriteLine($"TrueForAll(): {listStr2.TrueForAll(str => str.Length < 7)}");
            Console.WriteLine($"TrueForAll(): {listStr2.TrueForAll(str => str.Length < 10)}");

            //---- RemoveAll() ----
            int removedNum = listInt2.RemoveAll(v => v < 0);
            Console.WriteLine($"removed num: {removedNum}");
            listInt2.ForEach(v => Console.Write($"{v}, "));
            Console.WriteLine();
        }//Main() 
    }//class 
}

/*
//---- ForEach() ----
1, 9, 36, 81,

//---- ConvertAll() ----
いろは, ちりぬ, わかよ, つねな, うゐの, けふこ, あさき, ゑひも,

//---- Find() ----
からすなぜ鳴くの

//---- FindAll() ----
からすなぜ鳴くの, からすは山に,

//---- FindIndex(), FindLastIndex() ----
FindIndex(): 1
FindIndex(): 4
FindLastIndex(): 4

//---- Exists(), TrueForAll() ----
Exists(): True
TrueForAll(): False
TrueForAll(): True

//---- RemoveAll() ----
removed num: 2
1, 30, 60, 40,
 */