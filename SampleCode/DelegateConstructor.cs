/** 
 *@title CsharpBegin / SampleCode / DelegateConstructor.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 10.1 DelegateConstructor / p474 / List 10-1
 *         デリゲートのコンストラクタにメソッドを渡す。
 *         
 *@author shika 
 *@date 2021-11-01 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{
    delegate void DelegateBasic(string str);

    class DelegateConstructor 
    { 
        internal void Show(string s)
        {
            Console.WriteLine($"Show(): {s}");
        }

        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var here = new DelegateConstructor();

            //デリゲートに Show()を渡す
            DelegateBasic del = new DelegateBasic(here.Show);

            //Show(string)を実行
            del("デリゲート引数"); 
        }//Main() 
    }//class 
}

/*
Show(): デリゲート引数
 */
