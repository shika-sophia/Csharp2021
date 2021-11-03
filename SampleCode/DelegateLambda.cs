/** 
 *@title CsharpBegin / SampleCode / DelegateLambda.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content DelegateLambda / p483 / List 10-8, 10-9
 *@subject 匿名メソッド delegateの匿名型による定義
 *         deledate(引数, ...) { 匿名メソッド };
 *           デリゲート型の引数は後続の匿名メソッドの戻り値を渡す
 *         delegate T Func<in T, out T>(T input)
 *           標準ライブラリ提供 Func型ジェネリックデリゲート
 *           
 *@subject ラムダ式 匿名メソッド部分を代替
 *@subject ラムダ式 省略記法による簡素化
 * 
 *@author shika 
 *@date 2021-11-03 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class DelegateLambda 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            string[] dataAry = new[] {
                "いろはにほへと", "ちりぬるを", "わかよたれそ","つねならむ" };
            var dm = new DelegateAnonymous();
           
            //---- delegate直接定義, 匿名メソッド ----
            //dm.AryWalk(dataAry, delegate (string data)
            //{
            //    return $"[{data}]";
            //});

            //---- ラムダ式に代替 ----
            //dm.AryWalk(dataAry, (string data) =>
            //{
            //    return $"[{data}]";
            //});

            //---- ラムダ式の省略記法による簡素化 ----
            dm.AryWalk(dataAry, data => $"[{data}]");
        }//Main() 
    }//class 

    class DelegateAnonymous
    {
        public void AryWalk(string[] dataAry, Func<string,string> outFunc)
        {
            foreach (string data in dataAry)
            {
                Console.WriteLine(outFunc(data));
            }
        }
    }//class
}

/*
[いろはにほへと]
[ちりぬるを]
[わかよたれそ]
[つねならむ]
 */