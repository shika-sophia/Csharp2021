/**
 * @title CsharpBegin / introduction / MultiplyMatrix.cs
 * @reference 山田祥寛 『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第４章 制御構文 / 九九表を表示(C#版)
 * @content nested for文
 * @content string.Format()
 *          {0,2:##} 0番目, 2文字(右詰め) : ## 数値2桁(空白補完せず)
 * @see Eclipse:  MultiplyMatrix.java
 * @author shika
 * @date 2021-07-15
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class MulitiplyMatrix
    {
        //static void Main(string[] args)
        private void Main(string[] args)
        {
            for(int i = 1; i <= 9; i++)
            {
                for(int j = 1; j <= 9; j++) 
                {
                    Console.Write(string.Format("{0,2:##} ", i * j));
                }//for j

                Console.WriteLine();
            }//for i
        }//Main()
    }//class
}

/*
 1  2  3  4  5  6  7  8  9
 2  4  6  8 10 12 14 16 18
 3  6  9 12 15 18 21 24 27
 4  8 12 16 20 24 28 32 36
 5 10 15 20 25 30 35 40 45
 6 12 18 24 30 36 42 48 54
 7 14 21 28 35 42 49 56 63
 8 16 24 32 40 48 56 64 72
 9 18 27 36 45 54 63 72 81
 */
