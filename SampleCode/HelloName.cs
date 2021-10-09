/**
 *@title CsharpBegin / SampleCode / HelloName.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content  
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
    class HelloName
    {
        public void Main(string[] args)
        //static void Main(string[] args)
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
 */
