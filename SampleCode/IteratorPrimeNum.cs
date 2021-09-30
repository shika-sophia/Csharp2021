/**
 * @title CsharpBegin / SampleCode / IteratorPrimeNum.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第７章 オブジェクト基本 Iterator / p313 / List 7-49
 *    ◆System.Collections.Generic
 *    IEnumerable<T> / IEnumerator<T>
 *    yield return T;
 *    yield break;
 *    
 *    ◆エラトステネスの篩(ふるい)
 *    素数の判定は、２から順にすべての整数の倍数を除外していく。
 *    
 *    ◆素数判定２
 *    約数の有無判定は「2 ～ Math.Sqrt(value)」で割り切れるかを調べれば良い。
 * 
 * @see IteratorPrimeClass.cs
 * @author shika
 * @date 2021-10-01
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class IteratorPrimeNum
    {
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            int max = 100; //この数までの素数を表示
            var prime = new PrimeNumber();

            Console.WriteLine($"{max}までの素数:");
            foreach(int value in prime.GetPrimes(max))
            {
                Console.Write(value + ", ");
            }
            Console.WriteLine();
        }//Main()
    }//class
    
    class PrimeNumber
    {
        public IEnumerable<int> GetPrimes(int max)
        {
            const int PrimeMin = 2;
            if(max < PrimeMin)
            {
                Console.WriteLine($"引数 maxは {PrimeMin}以上の値を設定してください。");
                yield break;
            }

            //judge Prime Number / 素数判定
            for(var num = PrimeMin; num <= max; num++)
            {
                if (IsPrime(num))
                {
                    yield return num;
                }
            }

            bool IsPrime(int value)
            {
                var isPrime = true;
                for(var i = PrimeMin; i <= Math.Floor(Math.Sqrt(value)); i++)
                {
                    if(value % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }//for

                return isPrime;
            }//IsPrime()

        }//GetPrimes()
    }//class PrimeNumber
}

/*
100までの素数:
2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41,
43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97,

500までの素数:
2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41,
43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97,
101, 103, 107, 109, 113, 127, 131, 137, 139, 149,
151, 157, 163, 167, 173, 179, 181, 191, 193, 197,
199, 211, 223, 227, 229, 233, 239, 241, 251, 257,
263, 269, 271, 277, 281, 283, 293, 307, 311, 313,
317, 331, 337, 347, 349, 353, 359, 367, 373, 379,
383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 
443, 449, 457, 461, 463, 467, 479, 487, 491, 499,

-1までの素数:
引数 maxは 2以上の値を設定してください。
 */
