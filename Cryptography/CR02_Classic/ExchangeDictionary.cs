/** 
 *@see SimpleSubstitutionCipher.cs
 *
 *@NOTE int Random.Next()は while(true)内では機能せず、
 *      for内だと ちゃんと機能した。
 *      
 */
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.Cryptography.CR02_Classic 
{ 
    class ExchangeDictionary 
    {
        private const char lowerInit = 'a'; //= 97
        private const char upperInit = 'A'; //= 65
        private char[] alphabetAry;
        internal char[] subAry;
        internal Dictionary<char, char> exDic;

        public ExchangeDictionary()
        {
            this.alphabetAry = BuildAlphabet();
            this.subAry = BuildSubAry(alphabetAry);
            this.exDic = BuildExDictionary();
        }

        private char[] BuildAlphabet()
        {
            alphabetAry = new char[26];

            for (int i = 0; i < 26; i++)
            {
                alphabetAry[i] = (char) (i + lowerInit);
            }//for

            return alphabetAry;
        }//BuildAlphabet()

        private char[] BuildSubAry(char[] seedAry)
        {
            char[] subAryLow = new char[seedAry.Length];
            Random random = new Random();

            for (int i = 0; i < seedAry.Length;)
            {
                char c = seedAry[random.Next(seedAry.Length)];

                if (subAryLow.Contains(c))
                {
                    continue;
                }
                else
                {
                    subAryLow[i] = c;
                    i++;
                }
            }//for

            subAry = ToUpper(subAryLow);
            return subAry;
        }//BuildSubAry()

        private Dictionary<char, char> BuildExDictionary()
        {
            exDic = new Dictionary<char, char>();

            for (int i = 0; i < alphabetAry.Length; i++)
            {
                exDic.Add(alphabetAry[i], subAry[i]);
            }//foreach

            return exDic;
        }//BuildExDictionary()

        private char[] ToUpper(char[] lowerAry)
        {
            char[] upperAry = new char[lowerAry.Length];

            for (int i = 0; i < lowerAry.Length; i++)
            {
                upperAry[i] = (char) (lowerAry[i] + upperInit - lowerInit);
            }//for

            return upperAry;
        }//ToUpper(char[])

        private char[] ToLower(char[] upperAry)
        {
            char[] lowerAry = new char[upperAry.Length];

            for (int i = 0; i < upperAry.Length; i++)
            {
                lowerAry[i] = (char) (upperAry[i] + lowerInit - upperInit);
            }//for

            return lowerAry;
        }//ToLower(char[])

        public string ToString(char[] charAry)
        {
            return String.Join(", ", charAry);
        }//ToString(char[])

        ////==== Test Main() ====
        //static void Main(string[] args) 
        ////public void Main(string[] args) 
        //{
        //    var here = new ExchangeDictionary();

        //    //---- Test BuildAlphabet() ----
        //    here.BuildAlphabet();
        //    Console.WriteLine(
        //        $"alphabetAry[]: [{here.ToString(here.alphabetAry)}]");

        //    //---- Test ToUpper() ----
        //    char[] upperAry = here.ToUpper(here.alphabetAry);
        //    Console.WriteLine(
        //        $"upperAry[]: [{here.ToString(upperAry)}]");

        //    //---- Test ToLower() ----
        //    char[] lowerAry = here.ToLower(upperAry);
        //    Console.WriteLine(
        //        $"lowerAry[]: [{here.ToString(lowerAry)}]");

        //    //---- Test BuildSubAry() ----
        //    here.BuildSubAry(here.alphabetAry);
        //    Console.WriteLine(
        //        $"subAry[]: [{here.ToString(here.subAry)}]");

        //    //---- Test BuildExDictionary() ----
        //    here.BuildExDictionary();

        //    Console.WriteLine("Exchange-Dictionary<char,char>:");
        //    int count = 0;
        //    foreach (KeyValuePair<char, char> entry in here.exDic)
        //    {
        //        Console.Write($"({entry.Key}: {entry.Value}), ");
        //        count++;

        //        if (count % 6 == 0 && count != 0)
        //        {
        //            Console.WriteLine();
        //        }
        //    }//foreach
        //    Console.WriteLine("\n");
        //}//Main() 
    }//class 
}

/*
//---- Test BuildAlphabet() ----
alphabetAry[]: 
[a, b, c, d, e, f, g, h, i, j, k, l, m, 
 n, o, p, q, r, s, t, u, v, w, x, y, z]

//---- Test ToUpper() ----
upperAry[]:
[A, B, C, D, E, F, G, H, I, J, K,  L, M,
 N, O, P, Q, R, S, T, U, V, W, X, Y, Z]

//---- Test ToLower() ----
lowerAry[]: 
[a, b, c, d, e, f, g, h, i, j, k, l, m,
 n, o, p, q, r, s, t, u, v, w, x, y, z]

//---- Test BuildSubAry() ----
subAry[]: 
[K, Y, C, D, R, X, Z, F, T, P, W, Q, E, 
 A, L, J, G, B, N, H, O, V, U, M, S, I]

//---- Test BuildExDictionary() ----
Exchange-Dictionary<char,char>:
(a: Y), (b: N), (c: R), (d: S), (e: P), (f: A),
(g: U), (h: E), (i: L), (j: G), (k: Q), (l: Z),
(m: X), (n: K), (o: T), (p: F), (q: M), (r: V),
(s: H), (t: I), (u: J), (v: W), (w: O), (x: D),
(y: B), (z: C),

 */