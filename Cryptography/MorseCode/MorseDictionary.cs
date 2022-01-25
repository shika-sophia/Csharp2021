
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading.Tasks; 
 
namespace CsharpBegin.Cryptography.MorseCode 
{ 
    class MorseDictionary 
    {
        private readonly Dictionary<char, string> morseDic
            = new Dictionary<char, string>()
            {
                ['A'] = "01", ['B'] = "1000", ['C'] = "1010",
                ['D'] = "100", ['E'] = "0", ['F'] = "0010",
                ['G'] = "110", ['H'] = "0000", ['I'] = "00",
                ['J'] = "0111", ['K'] = "101", ['L'] = "0100",
                ['M'] = "11", ['N'] = "10", ['O'] = "111",
                ['P'] = "0110", ['Q'] = "1101", ['R'] = "010",
                ['S'] = "000", ['T'] = "1", ['U'] = "001",
                ['V'] = "0001", ['W'] = "0111", ['X'] = "1001",
                ['Y'] = "1011", ['Z'] = "1100",
                ['1'] = "01111", ['2'] = "00111",
                ['3'] = "00011", ['4'] = "00001",
                ['5'] = "00000", ['6'] = "10000",
                ['7'] = "11000", ['8'] = "11100",
                ['9'] = "11110", ['0'] = "11111",
                ['.'] = "010101", [','] = "110011",
                ['?'] = "001100", ['!'] = "101011",
                ['('] = "10110", [')'] = "101101",
                ['&'] = "01000", ['='] = "10001",
                [':'] = "111000", [';'] = "101010",
                ['+'] = "01010", ['-'] = "100001",
                ['*'] = "1001", ['/'] = "10010",
                ['_'] = "001101", ['^'] = "000000",
                ['\"'] = "010010", ['\''] = "011110",
                ['@'] = "011010", ['$'] = "0001001",             
                ['Ä'] = "0101",  ['À'] = "01101",
                ['Ç'] = "10100", ['Ð'] = "00110",
                ['È'] = "01001", ['É'] = "001100",
                ['Ĝ'] = "11010", ['Ĵ'] = "01110",
                ['Ñ'] = "11011", ['Ö'] = "1110",
                ['Š'] = "00010", ['Þ'] = "01100",
                ['Ü'] = "0011",  ['ß'] = "0001100",
                [' '] = "／", ['['] = "[", [']'] = "]",
            };

        private readonly Dictionary<string, string> controlDic
            = new Dictionary<string, string>() 
            {
                ["start"] = "10101", 
                ["messageend"] = "01010", //= ['+']
                ["close"] = "000101",
                ["error"] = "00000000", 
                ["copythat"] = "00010",
                ["wait"] = "01000", 
                ["over"] = "101",        //= ['K']
                ["recieved"] = "010",
                ["sos"] = "000111000",
            };
        //==== Getter ====
        public char GetKey(int index)
        {
            return morseDic.Keys.ElementAt(index);
        }//GetKey()

        public string GetValue(char c)
        {           
            bool isSignal = morseDic.TryGetValue(key: c, out string value);

            if (!isSignal)
            {
                morseDic.TryGetValue('-', out string dash);
                morseDic.TryGetValue('?', out string unknown);

                value = $"{dash}{unknown}{dash}"; // "-?-" as binary
            }

            return value;
        }//GetValue()

        public int GetMorseIndex(string value)
        {
            int index = -1;
            for (int i = 0; i < morseDic.Count; i++)
            {
                if (morseDic.ContainsValue(value))
                {
                    if (value == morseDic.Values.ElementAt(i))
                    {
                        index = i;
                        break;//for j
                    }
                }
            }//for 

            return index;
        }//GetMorseIndex()

        public string GetControlSignal(string controlName)
        {
            controlDic.TryGetValue(
                key: controlName, out string controlSignal);

            return controlSignal;
        }//GetControlSignal()

        public int GetControlIndex(string signal)
        {
            int index = -1;
            for (int i = 0; i < controlDic.Values.Count; i++)
            {
                if (signal == controlDic.Values.ElementAt(i))
                {
                    index = i;
                    break;
                }
            }//for

            return index;
        }//GetControlIndex()

        public string GetControlName(int index)
        {
            return controlDic.Keys.ElementAt(index);
        }//GetControlName()

    }//class 
}

/*
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