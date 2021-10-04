/**
 * @title CsharpBegin / SampleCode / TupleSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第７章 オブジェクト基本 Tuple / p305 / List 7-45
 *   ◆Tuple タプル / チュープル
 *   (T name1, T name2) T:値型, 構造体のみ
 *   
 *   ◆無名タプル (T, T)と型名のみで定義
 *   ここでは tupleをリテラルで定義
 *   内部的に struct System.TupleValue を生成
 *   TupleValueのフィールド Item1, Item2, ... にアクセス。
 *   可読性の観点から、利用すべきではない。
 *       
 * @author shika
 * @date 2021-10-05
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class TupleSample
    {
        
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            var here = new TupleSample();
            int x = 15;
            int y = 13;

            var tupleReturn = here.GetMaxMin(x, y);
            //(int max, int min) tupleReturn = here.GetMaxMin(x, y);
            Console.WriteLine($"Max: {tupleReturn.max}");
            Console.WriteLine($"Min: {tupleReturn.min}");

            var (resultMax, resultMin) = here.GetMaxMin(5, 3);
            //(var resultMax, var resultMin) = here.GetMaxMin(5, 3);
            //(int resultMax, int resultMin) = here.GetMaxMin(5, 3);
            //var (_, resultMin) = here.GetMaxMin(5, 3);
            Console.WriteLine($"{nameof(resultMax)}: {resultMax}");
            Console.WriteLine($"{nameof(resultMin)}: {resultMin}");

            //無名タプル
            var tuple = (16, 105); 
            //(int, int) tuple = (11, 24);
            Console.WriteLine($"tuple: {tuple.Item1}");
            Console.WriteLine($"tuple: {tuple.Item2}");
        }//Main()

        private (int max, int min) GetMaxMin(int x, int y)
        {
            return x >= y ? (x, y) : (y, x);
        }//GetMaxMin()
    }//class
}

/*
Max: 15
Min: 13
resultMax: 5
resultMin: 3
tuple: 16
tuple: 105
 */