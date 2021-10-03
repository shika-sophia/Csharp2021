/**
 * @title CsharpBegin / SampleCode / RefReturnOut.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第７章 オブジェクト基本 / p302 / List 7-43, 7-44
 *   ◆ref return
 *   ◆引数 out
 *   ◆引数 ref
 *       
 * @author shika
 * @date 2021-10-04
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class RefReturnOut
    {
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            var here = new RefReturnOut();
            var dataAry = new[] { 1, 2, 3 };

            //---- RefReturn() ----
            ref int num = ref here.RefReturn(dataAry);
            Console.WriteLine($"{nameof(num)}: {num}");
            Console.WriteLine($"{nameof(dataAry)}[0]: {dataAry[0]}");

            num = 10;
            Console.WriteLine($"{nameof(num)}: {num}");
            Console.WriteLine($"{nameof(dataAry)}[0]: {dataAry[0]}");
            Console.WriteLine();

            //---- OutMaxMin() ----
            int x = 5;
            int y = 3;
            here.OutMaxMin(
                x, y, out int resultMax, out int resultMin);
            Console.WriteLine($"x = {x}, y = {y}: resultMax = {resultMax}");
            Console.WriteLine($"x = {x}, y = {y}: resultMin = {resultMin}");

            //---- ArrayMaxMin() ----
            int tempMax = dataAry[0];
            int tempMin = dataAry[0];
            Console.Write("dataAry: ");

            foreach (int v in dataAry)
            {
                Console.Write($"{v},");
                here.ArrayMaxMIn(v, ref tempMax, ref tempMin);
            }//foreach
            Console.WriteLine();
            Console.WriteLine($"dataAry max = {tempMax}");
            Console.WriteLine($"dataAry min = {tempMin}");
        }//Main()

        private ref int RefReturn(int[] dataAry)
        {
            return ref dataAry[0];
        }//RefReturn()

        private void OutMaxMin(
            int x, int y, out int max, out int min)
        {
            if(y <= x)
            {
                max = x;
                min = y;
            }
            else
            {
                max = y;
                min = x;
            }
        }//OutMaxMin()

        private void ArrayMaxMIn(
            int v, ref int tempMax, ref int tempMin)
        {
            if (tempMax <= v)
            {
                tempMax = v;
            }
            if (v <= tempMin)
            {
                tempMin = v;
            }
        }//ArrayMaxMIn()
    }//class
}

/*
//---- RefReturn() ----
num: 1
dataAry[0]: 1
num: 10
dataAry[0]: 10

//---- OutMaxMin() ----
x = 5, y = 3: resultMax = 5
x = 5, y = 3: resultMin = 3

//---- ArrayMaxMin() ----
dataAry: 10,2,3,
dataAry max = 10
dataAry min = 2

【考察】
TempMaxMIn(v, tempMax, tempMin, out tempMax, out tempMin);
のように引数で渡して、かつ outするなら refにしたほうがいい。
  ↓
TempMaxMIn(v, ref tempMax, ref tempMin);
 */
