/**
 *@title CsharpBegin / Utility / ScannerAdaptor.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content [Java] Scannarクラスを [C#]で再現する。
 * 
 *@author shika 
 *@date 2021-10-13 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Utility
{
    class ScannerAdaptor
    {
        static void Main(string[] args)
        //public void Main(string[] args)
        {
            var scan = new Scanner();
            string input = scan.NextLine("string: ");
            Console.WriteLine($"input: {input}");
            Console.WriteLine();

            int inputInt = scan.NextInt("int: ");
            Console.WriteLine($"inputInt: {inputInt}");
        }//Main()
    }//class

    class Scanner
    {
        public string NextLine()
        {
            string input = Console.ReadLine();
            return input;
        }

        public string NextLine(string text)
        {
            Console.Write(text);
            return NextLine();
        }

        public int NextInt()
        {
            string input = Console.ReadLine();
            int inputInt;
            try
            {
                inputInt = int.Parse(input);
            } 
            catch (FormatException e)
            {
                throw new FormatException(
                    "InputMismatchException");
            }

            return inputInt;
        }

        public int NextInt(string text)
        {
            Console.Write(text);
            return NextInt();
        }
    }//class
}

/*
string: あいう
input: あいう

int: 12
inputInt: 12

int: 数字

ハンドルされていない例外:
System.FormatException: InputMismatchException
識別された項目のうち 1 つが無効な形式です。
 */