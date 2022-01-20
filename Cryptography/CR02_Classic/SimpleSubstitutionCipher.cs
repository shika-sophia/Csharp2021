/** 
 *@title CsharpBegin / Cryptography / CR02_Classic / SimpleSubstitutionCipher.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩 『暗号技術入門 第３版』SB Creative, 2015 
 *@content Simple Substitution Cipher 単一換字暗号 / p26
 *         アルファベットの a,b,c,...に一対一で、他の文字を対応させる暗号。
 *         元のアルファベットと同じ文字になる場合もある。
 *         
 *@subject exchange chart: 換字表
 *         Dictionary<char,char>で再現
 *         
 *@keyspace [英] factorial: 階乗
 *          26! = 26 * 25 * 24 * ... * 2 * 1
 *          26! = 403291461126605635584000000 (= 4兆の 1000倍)
 *          1秒に 10億個を調べても 120億年、平均 60億年。
 *          Brute-Force Attackでは調べられない。
 *          
 *@analize ◆頻度分析
 *         暗号文の各charごとの出現回数を調べ、
 *         英語の高頻度「e, t, a, o, i...」低頻度「q」を仮定してみて、
 *         次々と推理していく暗号解読方法。
 *         暗号文が長いほど推理しやすい。
 *         暗号文の charは、全て一対一で対応する平文 charなので、
 *         どの仮定で英語の単語になるかを調べていく。
 */
#region -> ==== class chart ====
/*
 *@class SimpleSubstitutionCipher
 *       / - readonly ◇ExchangeDictionary ex; /
 *       + SimpleSubstitutionCipher(ExchangeDictionary ex)
 *       ◆Main()
 *       { new ExchangeDictionary()
 *         new AskTextCR() }
 *       + Encrypt(char[])
 *       + Decrypt(char[])
 *       
 *@class ExchangeDictionary
 *       / - const char lowerInit = 'a'; //= 97
 *         - const char upperInit = 'A'; //= 65
 *         - char[] alphabetAry;
 *         ~ char[] subAry;
 *         ~ Dictionary<char, char> exDic; /
 *       + ExchangeDictionary() 
 *         { this.alphabetAry = BuildAlphabet();
 *           this.subAry = BuildSubAry(alphabetAry);
 *           this.exDic = BuildExDictionary(); }
 *       - char[] BuildAlphabet()
 *       - char[] BuildSubAry(char[])
 *       - Dictionary<char,char> BuildExDictionary()
 *       - char[] ToUpper(char[])
 *       - char[] ToLower(char[])
 *       + string ToString(char[])
 */
#endregion
/*
 *@author shika 
 *@date 2022-01-20 
*/
using System; 
using System.Collections.Generic; 
using System.Linq;
using System.Numerics;
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.Cryptography.CR02_Classic 
{ 
    class SimpleSubstitutionCipher 
    {
        private readonly ExchangeDictionary ex;

        public SimpleSubstitutionCipher(ExchangeDictionary ex)
        {
            this.ex = ex;
        }

        public char[] Encrypt(char[] plainAry)
        {
            char[] cipherAry = new char[plainAry.Length];

            for (int i = 0; i < plainAry.Length; i++)
            {
                ex.exDic.TryGetValue(plainAry[i], out cipherAry[i]);
            }//for

            return cipherAry;
        }//EnCrypt()

        public char[] Decrypt(char[] cipherAry)
        {
            char[] rePlainAry = new char[cipherAry.Length];

            for (int i = 0; i < cipherAry.Length; i++)
            {
                int index = 0;
                for (int j = 0; j < ex.subAry.Length; j++)
                {
                    if(ex.subAry[j] == cipherAry[i])
                    {
                        index = j;
                        break;
                    }
                }//for j

                char c = ex.exDic.Keys.ElementAt(index);
                rePlainAry[i] = c;
            }//for i

            return rePlainAry;
        }//DeCrypt()

        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var ex = new ExchangeDictionary();
            var here = new SimpleSubstitutionCipher(ex);

            //==== AskText ====
            var ask = new AskTextCR();
            char[] inputAry = ask.ReadText(
                "◆Alphabet ONLY \n[plain: lower] [cipher: upper] > ");
            Console.WriteLine($"inputAry[]  : {ex.ToString(inputAry)}");

            if (inputAry.All(c => Char.IsLower(c)))
            {
                char[] cipherAry = here.Encrypt(inputAry);
                char[] rePlainAry = here.Decrypt(cipherAry);
                Console.WriteLine($"cipherAry[] : {ex.ToString(cipherAry)}");
                Console.WriteLine($"rePlainAry[]: {ex.ToString(rePlainAry)}");
            }
            else if (inputAry.All(c => Char.IsUpper(c)))
            {
                char[] rePlainAry = here.Decrypt(inputAry);
                Console.WriteLine($"rePlainAry[]: {ex.ToString(rePlainAry)}");
            }
        
            Console.WriteLine();
            Console.WriteLine("Exchange-Dictionary<char,char>:");
            int count = 0;
            foreach (KeyValuePair<char, char> entry in ex.exDic)
            {
                Console.Write($"({entry.Key}: {entry.Value}), ");
                count++;

                if (count % 6 == 0 && count != 0)
                {
                    Console.WriteLine();
                }
            }//foreach
            Console.WriteLine();

            //---- Appendix: Key Space ----
            BigInteger factorial = 1;
            for(int i = 26; i > 1; i--)
            {
                factorial *= i;
            }

            Console.WriteLine($"26! = {factorial}");
        }//Main() 
    }//class 
}

/*
//==== AskText ====
◆Alphabet ONLY
[plain: lower] [cipher: upper] >  yoshiko
inputAry[]  : y, o, s, h, i, k, o
cipherAry[] : O, N, X, F, K, S, N
rePlainAry[]: y, o, s, h, i, k, o

Exchange-Dictionary<char,char>:
(a: A), (b: J), (c: G), (d: T), (e: C), (f: P),
(g: Y), (h: F), (i: K), (j: H), (k: S), (l: R),
(m: Z), (n: M), (o: N), (p: W), (q: Q), (r: E),
(s: X), (t: V), (u: I), (v: U), (w: L), (x: B),
(y: O), (z: D),

◆Alphabet ONLY
[plain: lower] [cipher: upper] >  ASPNET
inputAry[]  : A, S, P, N, E, T
rePlainAry[]: n, b, e, a, p, y

Exchange-Dictionary<char,char>:
(a: N), (b: S), (c: D), (d: X), (e: P), (f: J),
(g: L), (h: C), (i: U), (j: F), (k: Q), (l: I),
(m: B), (n: A), (o: K), (p: E), (q: V), (r: M),
(s: R), (t: Y), (u: O), (v: Z), (w: W), (x: G),
(y: T), (z: H),

26! = 403291461126605635584000000
 */