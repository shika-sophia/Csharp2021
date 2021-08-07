/**
 * @title CsharpBegin / SampleCode / GotoSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第４章 制御構文 / p138 / List 4-29, 4-30
 *          goto命令, for + goto, switch + goto
 *          
 * @author shika
 * @date 2021-08-07
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class GoToSample
    {
        //static void Main(string[] args)
        internal void Main(string[] args)
        {
            //    goto THERE;
            //    Console.WriteLine("Here is skipped.");
            //    Console.WriteLine("Here?");

            //THERE:
            //    Console.WriteLine("Code is over.");

            //BEGIN:
            //    Console.WriteLine("Loop");
            //    goto BEGIN;

            //---- for + goto ----
            for(int i = 1; i <= 9; i++)
            {
                for(int j = 1; j <= 9; j++)
                {
                    int result = i * j;
                    if (result > 50)
                    {
                        goto END;
                    }
                    Console.Write($"{result, 2} ");
                }//for j
                Console.WriteLine();
            }//for i

        END:
            Console.WriteLine("finished");

            //---- switch + goto ----
            string rank = "甲";
            switch (rank)
            {
                case "甲":
                    Console.WriteLine("大変、良いです。");
                    goto case "丙";

                case "乙":
                    Console.WriteLine("良いです。");
                    goto case "丙";

                case "丙":
                    Console.WriteLine("合格です。");
                    break;

                case "丁":
                    Console.WriteLine("不合格です。");
                    break;

                default:
                    Console.WriteLine("？？？");
                    break;
            }//switch

        }//Main()
    }//class
}

/*
 * Code is over.
 * Loop
 * Loop
 * Loop
 *  :
 //---- for + goto ----
 1  2  3  4  5  6  7  8  9
 2  4  6  8 10 12 14 16 18
 3  6  9 12 15 18 21 24 27
 4  8 12 16 20 24 28 32 36
 5 10 15 20 25 30 35 40 45
 6 12 18 24 30 36 42 48 finished

//---- switch + goto ----
大変、良いです。
合格です。
 */
