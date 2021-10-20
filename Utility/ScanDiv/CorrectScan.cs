/**
 *@title CsharpBegin / Utility / ScanDiv / CorrectScan.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 「○×」入力 /「×」なら解答入力 / 正答率
 *
 *@class CorrectScan
 *       / ◇MultiScan multi,
 *         ◇IntScan intScan,
 *         List<string> correctAnsList,
 *         List<bool> correctList,
 *         string[] correctMark /
 *       + CorrectScan(MultiScan multi)
 *       + void InputCorrect()
 *       - string InputModify()
 *       + string CalcCorrectRate()
 *
 *@see ConfirmScan.cs
 *@see IntScan.cs
 *@see MultiScan.cs
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
        private readonly MultiScan multi;
        private readonly IntScan intScan;
        public List<string> correctAnsList { get; private set; }
        public List<bool> correctList { get; private set; }
        private readonly string[] correctMark = new[] { "○", "×" };

        public CorrectScan(MultiScan multi)
        {
            this.multi = multi;
            this.intScan = new IntScan(0, 1);
            this.correctAnsList = 
                new List<string>(multi.answerList.Count);
            this.correctList =
                new List<bool>(multi.answerList.Count);
        }

        public void InputCorrect()
        {
            Console.WriteLine("==== Judge Correct ====");
            Console.WriteLine("◇正誤入力: [0: ○ ] [1: × ] [-88: Return]");

            int countQuest = 0;
            bool removed = false;
            for(int i = 0; i < multi.answerList.Count; i++)
            {
                string answer = multi.answerList[i];
                if (answer.Contains("(1)") && !removed)
                {
                    if(countQuest != 0) { Console.WriteLine(); }
                    Console.WriteLine($"◆{multi.questList[countQuest]}");
                    countQuest++;
                    removed = false;
                }//if
                reCorrect:
                int inputInt = intScan.JudgeInt($"{answer}");
                
                string modify = "";
                if (inputInt == 1)
                {
                    modify = InputModify();
                }//if

                //----「-99」「-88」判定 ----
                if(inputInt == -99)
                {
                    Console.WriteLine("<!> 終了機能は利用できません。");
                    goto reCorrect;
                } 
                else if (inputInt == -88)
                {
                    string action = multi.ActionLogic(
                        inputInt.ToString(), "Correct",
                        correctAnsList.Count + 1, correctAnsList);
                    switch (action)
                    {
                        case "next": goto reCorrect;
                        case "remove":
                            correctList.RemoveAt(correctList.Count - 1);
                            i -= 2;
                            removed = true;
                            continue;
                        default: break;
                    }//switch
                }
                
                //---- Listに登録 ----
                correctAnsList.Add($"{correctMark[inputInt]} {answer}{modify}");
                correctList.Add(inputInt == 0);
            }//for answer
        }//InputCorrect()

        private string InputModify()
        {
            Console.Write(" => ○: ");
            string modify = Console.ReadLine();
            return " => ○: " + modify;
        }//InputModify()

        public string CalcCorrectRate()
        {
            if(correctList == null || correctList.Count == 0)
            {
                return "correctList: <!> No List.";
            }
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

//---- Test ActionLogic() ----
==== Judge Correct ====
◇正誤入力: [0: ○ ] [1: × ] [-88: Return]
◆〔1〕Q1
(1) A1-1: -88
<!> Return機能は利用できません。
(1) A1-1: -99
<!> 終了機能は利用できません。
(1) A1-1: 1
 => ○: modi
(2) A1-2: -88
<?> Correct(1)の内容は消去されます。
Return よろしいですか？ [ Y / N ]: y

(1) A1-1: 0
(2) A1-2: 0
(1) A2-1: 1
 => ○: modi
(2) A2-2: -88
<?> Correct(3)の内容は消去されます。
Return よろしいですか？ [ Y / N ]: y

(1) A2-1: 0
(2) A2-2: 1
 => ○: modi
bld.Length: 94
correctAnsList:
◆〔1〕Q1
○ (1) A1-1
○ (2) A1-2

◆〔2〕Q2
○ (1) A2-1
× (2) A2-2 => ○: modi


correctList: ○, ○, ○, ×,
@correctRate 75.00 ％ (○ 3 問 / 全 4 問)
 */