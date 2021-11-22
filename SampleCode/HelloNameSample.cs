/**
 *@title CsharpBegin / SampleCode / HelloNameSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 名前を聞いて、固定文字列に名前を入れて出力
 *         string Console.ReadLine();      //コンソール入力
 *         void Console.WriteLine(string); //コンソール出力
 * 
 *@author shika 
 *@date 2021-08-07 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class HelloNameSample
    {
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            Console.WriteLine("あなたの名前は？");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, {0}さん", name);
        }//Main()

    }//class
}

/*
// 実行結果
あなたの名前は？
shika
Hello, shikaさん
続行するには何かキーを押してください . . .

//==== execute from Command Prompt ====
//static Main()でないとコンパイル不可
>cd C:\Users\sophia\source\repos\CsharpBegin
\CsharpBegin\SampleCode

>csc HelloNameSample.cs

>HelloNameSample
あなたの名前は？
Lily
Hello, Lilyさん

 */
