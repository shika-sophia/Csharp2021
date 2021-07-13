using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class HelloName
    {
        private void Main(string[] args)
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
