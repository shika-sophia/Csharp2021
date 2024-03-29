﻿/**
 *@title CsharpBegin / Utility / ScanDiv / IntScan.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content int で入力し適正判定するクラス
 * 
 *@author shika 
 *@date 2021-10-18 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Utility.ScanDiv
{
    class IntScan
    {
        private int min;
        private int max;

        public IntScan()
        {
            this.min = QuestInt($"{nameof(IntScan)} 最小値");
            this.max = QuestInt($"{nameof(IntScan)} 最大値");
            JudgeRange();
        }       

        public IntScan(int min, int max)
        {
            this.min = min;
            this.max = max;
            JudgeRange();
        }

        private void JudgeRange()
        {
            if (max < min)
            {
                Console.WriteLine(
                    "<!> 最大値と最小値を入れ替えました。");
                int tempMax = this.max;
                this.max = this.min;
                this.min = tempMax;
            }
        }//JudgeRange()

        public int JudgeInt(string quest)
        {
            reQuest:
            int inputInt = QuestInt(quest); 
            if(inputInt == -99 || inputInt == -88) { ; }
            else if (inputInt < min || max < inputInt)
            {
                Console.WriteLine(
                    "<!> 数値の範囲外です。\n" +
                    $"[{min}～{max}]の範囲で入力してください。");
                Console.WriteLine();
                goto reQuest;
            }

            return inputInt;
        }//JudgeInt()

        public int QuestInt(string quest)
        {
            int inputInt;
            reQuest:
            Console.Write($"{quest}: ");
            string input = Console.ReadLine();

            if (input.Contains("ー８８")) { return -88; }
            if (input.Contains("ー９９")) { return -99; }

            try
            {
                inputInt = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("<!> 整数で入力してください。");
                Console.WriteLine();
                goto reQuest;
            }

            return inputInt;
        }//QuestInt()

        //static void Main(string[] args)
        public void Main(string[] args)
        {
            var here = new IntScan();
            //var here = new IntScan(0, 99);
            int inputInt = here.JudgeInt("年齢");
            Console.WriteLine($"result: {inputInt}");
        }//Main()
    }//class
}

/*
//====== Result Main() ======
IntScan 最小値: 99
IntScan 最大値: 0
<!> 最大値と最小値を入れ替えました。
年齢: 100
<!> 数値の範囲外です。
[0～99]の範囲で入力してください。

年齢: -1
<!> 数値の範囲外です。
[0～99]の範囲で入力してください。

年齢: h
<!> 年齢 は 整数で入力してください。

年齢: 24
result: 24

//====== Note ======
【考察】string.All(ch => Char.IsDigit())
try-catch前に Char.IsDigit()を行ってみたが、
マイナス「-」も falseになるため、負数の入力ができなくなる。

【考察】int.TryParse(string, out int)
TryParse()だと 非整数の入力も trueを出して、
ちゃんとチェックできない様子。

【考察】int.Parse(string)
「２５」など全角数字は 数値として認識してくれない。
全角数字は Parse(string, NumberStyle)の
NumberStyleでも定義されていないので解決せず。

入力時は stringなので int.Parse()の前に
if文で全角「ー８８」「ー９９」等の特殊記号は分岐可能。
 */
