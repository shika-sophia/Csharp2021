/**   
 *@title CsharpBegin / SampleCode / EnumFlagsSample.cs   
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017   
 *@content 第９章 EnumFlagsSample / p423 / List 9-33
 *         ２進数のビット演算によって、
 *         Enum要素の複数指定を一意の値に決定できる。
 *   
 *@author shika   
 *@date 2021-10-27   
*/   
using System;   
using System.Collections.Generic;   
using System.Linq;   
using System.Text;   
using System.Threading.Tasks;   
   
namespace CsharpBegin.SampleCode   
{   
    class EnumFlagsSample   
    {   
        [Flags]
        enum FontStyleSample
        {
            Bold = 0b_0001,     //1
            Italic = 0b_0010,   //2
            Underline = 0b_0100,//4
            NonBold = Italic | Underline,    //0110 = 6
            All = Bold | Italic | Underline, //0111 = 7
        }
        //static void Main(string[] args)   
        public void Main(string[] args)   
        {
            FontStyleSample style1 = 
                FontStyleSample.Bold | FontStyleSample.Italic;
            Console.WriteLine($"{nameof(style1)} = {style1}");

            if (style1.HasFlag(FontStyleSample.Bold))
            {
                Console.WriteLine(
                    $"{nameof(style1)}: {FontStyleSample.Bold} 太字");
            }

            if (style1.HasFlag(FontStyleSample.Bold | FontStyleSample.Italic))
            {
                Console.WriteLine(
                    $"{nameof(style1)}: {FontStyleSample.Bold} 太字 | {FontStyleSample.Italic} 斜体");
            }

            Console.WriteLine(
                $"All: {FontStyleSample.All}");

            foreach (FontStyleSample value in Enum.GetValues(typeof(FontStyleSample)))
            {
                //---- Decimal Expression ----
                //Console.Write($"{(int)value}:{value}, ");

                //---- Binary Expression ----
                string valueBin =
                    $"{Convert.ToString((int)value, 2)}";
                while(valueBin.Length < 4)
                {
                    valueBin = "0" + valueBin;
                }//while

                Console.Write($"{valueBin}:{value}, ");
            }//foreach
            Console.WriteLine();
        }//Main()   
    }//class   
}

/*
style1 = Bold, Italic
style1: Bold 太字
style1: Bold 太字 | Italic 斜体
All: All

//---- Decimal Expression ----
1:Bold, 2:Italic, 4:Underline, 6:NonBold, 7:All,

//---- Binary Expression ----
0001:Bold, 0010:Italic, 0100:Underline, 0110:NonBold, 0111:All,
 */