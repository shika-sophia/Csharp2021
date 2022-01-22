/** 
 *@title CsharpBegin / Cryptography / MorseCode / MorseDictionary.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩 『暗号技術入門 第３版』SB Creative, 2015 
 *@content MorseDictionary
 * 
 *@author shika 
 *@date 2022-01-22 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.Cryptography.MorseCode 
{ 
    class MorseDictionary 
    {
        private char[] textAry;
        private Dictionary<char, string> morseDic 
            = new Dictionary<char, string>()
            {
                ['A'] = "01",  ['B'] = "1000", ['C'] = "1010",
                ['D'] = "100", ['E'] = "0",    ['F'] = "0010",
                ['G'] = "110", ['H'] = "0000", ['I'] = "00",
                ['J'] = "0111",['K'] = "101",  ['L'] = "0100",
                ['M'] = "11",  ['N'] = "10",   ['O'] = "111",
                ['P'] = "0110",['Q'] = "1101", ['R'] = "010",
                ['S'] = "000", ['T'] = "1",    ['U'] = "001",
                ['V'] = "0001",['W'] = "0111", ['X'] = "1001",
                ['Y'] = "1011", ['Z'] = "1100",
                ['1'] = "01111", ['2'] = "00111", 
                ['3'] = "00011", ['4'] = "00001",
                ['5'] = "00000", ['6'] = "10000", 
                ['7'] = "11000", ['8'] = "11100", 
                ['9'] = "11110", ['0'] = "11111",
                ['.'] = "010101", [','] = "110011", 
                ['?'] = "001100", ['!'] = "101011", 
                ['/'] = "10010",  ['('] = "10110",
                [')'] = "101101", ['&'] = "01000",
                [':'] = "111000", [';'] = "101010",
                ['='] = "10001",  ['+'] = "01010",
                ['-'] = "100001", ['_'] = "001101",
                ['\"'] = "010010",['\''] = "011110",
                ['@'] = "011010", ['$'] = "0001001",
                [' '] = "   ",
            };

        public string SendMorse(string text)
        {
            textAry = text.ToUpper().ToCharArray();
            var bld = new StringBuilder(text.Length * 4);

            foreach (char c in textAry)
            {
                morseDic.TryGetValue(c, out string value);
                bld.Append(value);
                bld.Append(" ");
            }//foreach c

            string signal = bld.ToString();
            signal = signal.Replace("0", "・");
            signal = signal.Replace("1", "ー");            
            signal = signal.Replace("   ","／");
            return signal;
        }//SendMorse()

        private void WriteWithBeepMorse(string signal)
        {
            signal = signal.Replace("／", " /");

            char[] charAry = signal.ToCharArray();

            foreach (char c in charAry)
            {
                if (c == '・')
                {
                    Console.Write(c);
                    Console.Beep(800, 150);
                    Thread.Sleep(100);
                }
                else if (c == 'ー')
                {
                    Console.Write(c);
                    Console.Beep(800, 400);
                    Thread.Sleep(100);
                }
                else if(c == ' ')
                {
                    Console.Write("|");
                    Thread.Sleep(100);
                }
                else if (c == '/')
                {
                    Console.WriteLine(c);
                    Thread.Sleep(300);
                }

            }//foreach charAry

            Console.WriteLine();
        }//WriteWithBeepMorse()

        public string ReciveMorse(string signal)
        {
            signal = signal.Replace("・", "0");
            signal = signal.Replace("ー", "1");
            signal = signal.Replace("／", " /");

            string[] signalAry = signal.Split(
                new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bld = new StringBuilder(signal.Length);
            foreach (string bin in signalAry)
            {
                int index = -1;
                char c;
                for (int j = 0; j < morseDic.Count; j++)
                {
                    if (morseDic.ContainsValue(bin))
                    {
                        if (bin == morseDic.Values.ElementAt(j))
                        {
                            index = j;
                            break;//for j
                        }
                    }
                    else
                    {
                        if (bin == "/")
                        {
                            index = -99;
                            break;//for j
                        }
                    }
                }//for j

                if (index < 0)
                {
                    if (index == -99)
                    {
                        bld.Append(" ");
                    }
                    else
                    {
                        bld.Append("<?>");
                    }
                }
                else
                {
                    c = morseDic.Keys.ElementAt(index);
                    bld.Append(c);
                }
            }//foreach bin

            return bld.ToString().ToUpper();
        }//ReciveMorse()

        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            var here = new MorseDictionary();

            string text = "This is a pen. I am a girl.";
            string signal = here.SendMorse(text);
            string reText = here.ReciveMorse(signal);

            Console.WriteLine($"Text  : {text.ToUpper()}");
            here.WriteWithBeepMorse(signal);            
            Console.WriteLine($"reText: {reText}");
        }//Main() 
    }//class 
}

/*
Text  : THIS IS A PEN. I AM A GIRL.
ー ・・・・ ・・ ・・・ /
  ・・ ・・・ /
  ・ー /
  ・ーー・ ・ ー・ ・ー・ー・ー /
  ・・ /
  ・ー ーー /
  ・ー /
  ーー・ ・・ ・ー・ ・ー・・ ・ー・ー・ー
reText: THIS IS A PEN. I AM A GIRL.
//==== Appendix ====
private string BuildDicFormat(int valueNum) 
{ 
    var bld = new StringBuilder(100); 
    bld.Append("{\n"); 
    bld.Append("    "); 
    for(int i = 0; i < valueNum; i++) 
    { 
        if(i < 26) 
        { 
            char c = (char)('A' + i); 
            bld.Append($"[\'{c}\'] = \"\", "); 
        } 
        else 
        { 
            bld.Append("[\'\'] = \"\", "); 
        } 
 
        if(i != 0 && (i + 1) % 3 == 0) 
        { 
            bld.Append("\n"); 
            bld.Append("    "); 
        } 
    }//for 
    bld.Append("\n};"); 
 
    return bld.ToString(); 
}//BuildDicFormat() 

{
    ['A'] = "", ['B'] = "", ['C'] = "",
    ['D'] = "", ['E'] = "", ['F'] = "",
    ['G'] = "", ['H'] = "", ['I'] = "",
    ['J'] = "", ['K'] = "", ['L'] = "",
    ['M'] = "", ['N'] = "", ['O'] = "",
    ['P'] = "", ['Q'] = "", ['R'] = "",
    ['S'] = "", ['T'] = "", ['U'] = "",
    ['V'] = "", ['W'] = "", ['X'] = "",
    ['Y'] = "", ['Z'] = "", [''] = "",
    [''] = "", [''] = "", [''] = "",
    [''] = "", [''] = "", [''] = "",
    [''] = "", [''] = "", [''] = "",
    [''] = "", [''] = "", [''] = "",
    [''] = "", [''] = "", [''] = "",
    [''] = "", [''] = "", [''] = "",
    [''] = "",
};

Text : This is a pen. I am a girl.
 ー ・・・・ ・・ ・・・／  ・・ ・・・／
・ー／  ・ーー・ ・ ー・ ・ー・ー・ー／  
・・／   ・ー ーー／  ・ー／
ーー・ ・・ ・ー・ ・ー・・  ・ー・ー・ー
 */