/**
 *@title CsharpBegin / Utility / JavaDictionary.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 山田祥寛『独習 Java [新版] 』 翔泳社, 2019 
 *@content Java - C# 対応辞書 
 * 
 *@author shika 
 *@date 2021-10-10 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Utility
{
    class JavaDictionary
    {
        private Dictionary<string, string> javaDic =
            new Dictionary<string, string>()
            {
                ["public static void main(String args)"]
                    = "static void Main(string args)",
                ["String"] = "string",
                ["System.out.print()"] = "Console.Write()",
                ["System.out.println()"] = "Console.WriteLine()",
                ["final"] = "const/readonly",
                ["super()"] = "base()",
                ["import"] = "using",

            };

        public string GetValue(string key)
        {
            if (javaDic.TryGetValue(key, out string value)) { }
            else
            {
                Console.WriteLine($"<!> key='{key}' not exist.");
            }    
                         
            return value;
        }//GetValue()

        public void ShowDic()
        {
            foreach(KeyValuePair<string,string> pair in javaDic)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }//ShowDic()

        //static void Main(string[] args)
        public void Main(string[] args)
        {
            var here = new JavaDictionary();
            here.ShowDic();
            Console.WriteLine();

            Console.WriteLine($"key='final': {here.GetValue("final")}");
            Console.WriteLine(here.GetValue("None"));
        }//Main()
    }//class
}

/*
public static void main(String args): static void Main(string args)
String: string
System.out.print(): Console.Write()
System.out.println(): Console.WriteLine()
final: const/readonly
super(): base()
import: using

key='final': const/readonly
<!> key='None' not exist.
 */
