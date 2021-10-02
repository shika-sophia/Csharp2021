/**
 * @title CsharpBegin / SampleCode / RefArgsSample.cs
 * @reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017
 * @content 第７章 オブジェクト基本 引数・戻り値 / p296 / List 7-37 ～ 7-42
 *   ◆引数 ref
 *   //---- ValueArgs / 値型の値渡し ----
 *   //---- AryArgs / 参照型の値渡し ----
 *   //---- AryArgs / 参照型の値渡し new ----
 *   //---- RefArgs / 値型の参照渡し ----
 *   //---- RefAryArgs / 参照型の参照渡し ----
 *   //---- RefAryArgs / 参照型の参照渡し new ----
 *       
 * @author shika
 * @date 2021-10-03
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class RefArgsSample
    {
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            var here = new RefArgsSample();
            //---- ValueArgs / 値型の値渡し ----
            int data = 1;
            Console.WriteLine($"initial {nameof(data)}: {data}");
            Console.WriteLine($"{nameof(ValueArgs)}: {here.ValueArgs(data)}");
            Console.WriteLine($"{nameof(data)}: {data}");
            Console.WriteLine();

            //---- AryArgs / 参照型の値渡し ----
            int[] dataAry = new[] { 2, 4, 6 };
            //here.ShowAry(dataAry, nameof(dataAry));
            //Console.WriteLine($"{nameof(AryArgs)}[0]: {here.AryArgs(dataAry)[0]}");
            //Console.WriteLine($"{nameof(dataAry)}[0]: {dataAry[0]}");
            //here.ShowAry(dataAry, nameof(dataAry));
            //Console.WriteLine();

            //---- AryArgs / 参照型の値渡し new ----
            //here.ShowAry(dataAry, nameof(dataAry));
            //Console.WriteLine($"{nameof(AryArgsNew)}[0]: {here.AryArgsNew(dataAry)[0]}");
            //Console.WriteLine($"{nameof(dataAry)}[0]: {dataAry[0]}");
            //here.ShowAry(dataAry, nameof(dataAry));
            //Console.WriteLine();

            //---- RefArgs / 値型の参照渡し ----
            Console.WriteLine($"initial {nameof(data)}: {data}");
            Console.WriteLine($"{nameof(RefArgs)}: {here.RefArgs(ref data)}");
            Console.WriteLine($"{nameof(data)}: {data}");
            Console.WriteLine();

            ////---- RefAryArgs / 参照型の参照渡し ----
            //here.ShowAry(dataAry, nameof(dataAry));
            //Console.WriteLine($"{nameof(RefAryArgs)}[0]: {here.RefAryArgs(ref dataAry)[0]}");
            //Console.WriteLine($"{nameof(dataAry)}[0]: {dataAry[0]}");
            //here.ShowAry(dataAry, nameof(dataAry));
            //Console.WriteLine();

            //---- RefAryArgsNew / 参照型の参照渡し new ----
            here.ShowAry(dataAry, nameof(dataAry));
            Console.WriteLine($"{nameof(RefAryArgsNew)}[0]: {here.RefAryArgsNew(ref dataAry)[0]}");
            Console.WriteLine($"{nameof(dataAry)}[0]: {dataAry[0]}");
            here.ShowAry(dataAry, nameof(dataAry));
            Console.WriteLine();
        }//Main()

        private int ValueArgs(int data)
        {
            data++;
            return data;
        }

        private int[] AryArgs(int[] dataAry)
        {
            dataAry[0] = 5;
            return dataAry;
        }

        private int[] AryArgsNew(int[] dataAry)
        {
            dataAry = new[] { 10, 20, 30 };
            return dataAry;
        }

        private int RefArgs(ref int data)
        {
            data++;
            return data;
        }

        private int[] RefAryArgs(ref int[] dataAry)
        {
            dataAry[0] = 5;
            return dataAry;
        }

        private int[] RefAryArgsNew(ref int[] dataAry)
        {
            dataAry = new[] { 10, 20, 30 };
            return dataAry;
        }

        //====== 表示用 ======
        private void ShowAry(int[] ary, string name)
        {
            Console.Write(name + ": ");
            foreach(int v in ary)
            {
                Console.Write(v + ", ");
            }
            Console.WriteLine();
        }//ShowAry()

    }//class
}

/*
//---- ValueArgs / 値型の値渡し ----
initial data: 1
ValueArgs: 2
data: 1

//---- AryArgs / 参照型の値渡し ----
dataAry: 2, 4, 6,
AryArgs[0]: 5
dataAry[0]: 5
dataAry: 5, 4, 6,

//---- AryArgs / 参照型の値渡し new ----
dataAry: 2, 4, 6,
AryArgsNew[0]: 10
dataAry[0]: 2
dataAry: 2, 4, 6,

//---- RefArgs / 値型の参照渡し ----
initial data: 1
RefArgs: 2
data: 2

//---- RefAryArgs / 参照型の参照渡し ----
//「AryArgs / 参照型の値渡し」と同挙動
dataAry: 2, 4, 6,
RefAryArgs[0]: 5
dataAry[0]: 5
dataAry: 5, 4, 6,

//---- RefAryArgs / 参照型の参照渡し new ----
dataAry: 2, 4, 6,
RefAryArgsNew[0]: 10
dataAry[0]: 10
dataAry: 10, 20, 30,
 */
