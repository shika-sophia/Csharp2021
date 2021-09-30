/**
 * @title CsharpBegin / SampleCode / IteratorPrimeClass.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第７章 オブジェクト基本 Iterator / p315 / List 7-50
 *    Iteratorクラスを実装。内容は IteratorPrimeNum.csと同じ。
 *    「class PrimeClass : IEnumerable<int>」により、
 *    「var prime = new PrimeClass(max);」の primeがすでに Iterator化している。
 *    「foreach (int value in prime)」と、そのまま foreach
 *    
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
 * @see IteratorPrimeNum.cs
 * @author shika
 * @date 2021-10-01
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class IteratorPrimeClass
    {
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            int max = 100; //この数までの素数を表示
            var prime = new PrimeClass(max);

            Console.WriteLine($"{max}までの素数:");
            int count = 1;
            foreach (int value in prime)
            {
                Console.Write(value + ", ");

                //13個ごとに改行
                if(count % 13 == 0)
                {
                    Console.WriteLine();
                }
                count++;
            }
            Console.WriteLine();
        }//Main()
    }//class

    class PrimeClass : IEnumerable<int>
    {
        const int PrimeMin = 2;
        int max = PrimeMin;

        public PrimeClass(int max)
        {
            this.max = max;
        }

        public IEnumerator<int> GetEnumerator()
        {
            if (max < PrimeMin)
            {
                Console.WriteLine($"引数 maxは {PrimeMin}以上の値を設定してください。");
                yield break;
            }

            //judge Prime Number / 素数判定
            for (var num = PrimeMin; num <= max; num++)
            {
                if (IsPrime(num))
                {
                    yield return num;
                }
            }//for

            bool IsPrime(int value)
            {
                var isPrime = true;
                for (var i = PrimeMin; i <= Math.Floor(Math.Sqrt(value)); i++)
                {
                    if (value % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }//for

                return isPrime;
            }//IsPrime()
        }//GetEnumerator()

        //非ジェネリック IEnumerator用の GetEnumerator()
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }//class PrimeClass
}

/*
100までの素数:
2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43,
47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97,
 */