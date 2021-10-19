/**
 *@title CsharpBegin / Utility / ScanDiv / CorrectScan.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 「○×」入力 /「×」なら解答入力 / 正答率
 * 
 *@author shika 
 *@date 2021-10-19 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Utility.ScanDiv
{
    class CorrectScan
    {
        private IntScan intScan;
        private MultiScan multi;
        public List<string> correctAnsList { get; private set; }
        public List<bool> correctList { get; private set; }
        private readonly string[] correctMark = new[] { "○", "×" };

        public CorrectScan(MultiScan multi)
        {
            this.intScan = new IntScan(0, 1);
            this.multi = multi;
            this.correctAnsList = 
                new List<string>(multi.answerList.Count);
            this.correctList =
                new List<bool>(multi.answerList.Count);
        }

        public void InputCorrect()
        {            
            Console.WriteLine("==== Judge Correct ====");
            Console.WriteLine("◇正誤入力: [0: ○ ] [1: × ] [-88: Return]");

            int count = 0;
            foreach(string answer in multi.answerList)
            {
                if (answer.Contains("(1)"))
                {
                    Console.WriteLine($"{multi.questList[count]}");
                    count++;
                }//if                   
                int inputInt = intScan.JudgeInt($"{answer}");

                string modify = "";
                if (inputInt == 1)
                {
                    modify = InputModify();
                }//if

                correctAnsList.Add($"{correctMark[inputInt]} {answer}{modify}");
                correctList.Add(inputInt == 0 ? true : false);
            }//foreach answer         
        }//InputCorrect()

        public string CalcCorrectRate()
        {
            int questNum = correctList.Count;
            int correctNum = 0;
            foreach (bool correct in correctList)
            {
                if (correct) { correctNum++; }
            }

            double correctRate = (double)correctNum / questNum * 100;

            return $"@correctRate {correctRate:f} ％ " +
                   $"(○ {correctNum} 問 / 全 {questNum} 問)";
        }//CalcCorrectRate()

        private string InputModify()
        {
            Console.Write(" => ○: ");
            string modify = Console.ReadLine();
            return " => ○: " + modify;
        }//InputModify()

        //static void Main(string[] args)
        public void Main(string[] args)
        {
            var multi = new MultiScan();
            multi.BuildQuest();
            multi.BuildAnswer();

            var here = new CorrectScan(multi);
            here.InputCorrect();
            
            //---- Test print ----
            multi.ShowList(
                here.correctAnsList, nameof(correctAnsList));

            Console.Write($"{nameof(correctList)}: ");
            foreach(bool isCorrect in here.correctList)
            {
                Console.Write($"{(isCorrect ? "○" : "×")}, ");
            }
            Console.WriteLine();
            Console.WriteLine(here.CalcCorrectRate());
        }//Main()
    }//class
}

/*
==== Judge Correct ====
◇正誤入力: [0: ○ ] [1: × ] [-88: Return]
〔1〕Q1
(1) A1-1: 0
(2) A1-2: 1
 => ○: modi
(3) A1-3: 0
〔2〕Q2
(1) A2-1: 1
 => ○: modi
(2) A2-2: 0
(3) A2-3: 0
bld.Length: 127
correctAnsList:
〔1〕Q1
○ (1) A1-1
× (2) A1-2 => ○: modi
○ (3) A1-3

〔2〕Q2
× (1) A2-1 => ○: modi
○ (2) A2-2
○ (3) A2-3

correctList: ○, ×, ○, ×, ○, ○,
@correctRate 66.67 ％ (○ 4 問 / 全 6 問)
 */