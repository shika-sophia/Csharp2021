/**
 *@title CsharpBegin / Utility / ScanDiv / MultiScan.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 複数質問 / 回答 / 戻る機能
 *
 *@class MultiScan
 *       /◇ConfirmScan confirm,
 *        List<string> questList,
 *        List<string> answerList /
 *       + void BuildQuest()
 *       + void BuildAnswer()
 *       + string ActionLogic(string, string, int ,List<string>)
 *       + string ShowList(List<string>, string)
 *
 *@see ConfirmScan.cs
 *@see CorrctScan.cs
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
    class MultiScan
    {
        private ConfirmScan confirm = new ConfirmScan();
        public List<string> questList { get; private set; }
            = new List<string>();
        public List<string> answerList { get; private set; }
            = new List<string>();

        public void BuildQuest()
        {
            Console.WriteLine("==== Question ====");
            Console.WriteLine("◆Quest: [-99: to Answer] [-88: Return]");

            //---- Quest loop ---
            int count = 1;
            nextQuest:
            Console.Write($"〔{count}〕");
            string quest = Console.ReadLine();

            //----「-99」「-88」判定 ----
            string action = ActionLogic(quest, "Quest", count, questList);            
            switch (action)
            {
                case "end": return;
                case "next": goto nextQuest;
                case "remove":
                    count--;
                    goto nextQuest;
                default: break;
            }//switch

            //---- Listに登録 ----
            questList.Add($"〔{count}〕{quest}");
            count++;
            goto nextQuest;
        }//BuildQuest()

        public void BuildAnswer()
        {
            if(questList.Count == 0) { return; }
            
            Console.WriteLine("==== Answer ====");
            foreach (string quest in questList)
            {
                Console.WriteLine($"◆{quest}");
                Console.WriteLine(
                    "◇Answer: [-99: QuestEnd] [-88: Return]");

                //---- Answer loop ----
                int count = 1;
                nextAnswer:
                Console.Write($"({count}) ");
                string answer = Console.ReadLine();

                //----「-99」「-88」判定 ----
                string action = ActionLogic(answer, "Answer", count, answerList);
                switch (action)
                {
                    case "end": continue;
                    case "next": goto nextAnswer;
                    case "remove":
                        count--;
                        goto nextAnswer;
                    default: break;
                }//switch

                //---- Listに登録 ----
                answerList.Add($"({count}) {answer}");
                count++;
                goto nextAnswer;
            }//foreach
        }//BuildAnswer()

        public string ActionLogic(
            string input, string actionName, int count, List<string> list)
        {
            if (String.IsNullOrEmpty(input)) { return "next"; }

            if (input.Contains("-99"))
            {
                if (count == 1)
                {
                    Console.WriteLine("<!> 終了機能は利用できません。");
                    return "next";
                }
                Console.WriteLine($"<?> {actionName}({count - 1})で終了します。");
                bool isConfirm = confirm.QuestConfirm("終了 よろしいですか？");
                Console.WriteLine();

                if (isConfirm) { return "end"; } else { return "next"; }
            }//if -99

            if (input.Contains("-88"))
            {
                if (count == 1)
                {
                    Console.WriteLine("<!> Return機能は利用できません。");
                    return "next";
                }
                Console.WriteLine($"<?> {actionName}({count - 1})の内容は消去されます。");
                bool isConfirm = confirm.QuestConfirm("Return よろしいですか？");
                Console.WriteLine();
                if (isConfirm)
                {
                    list.RemoveAt(list.Count - 1);
                    return "remove";
                }

                return "next";
            }//if -88

            return ""; //default -> List.Add()
        }//ActionLogic()

        public string ShowList (List<string> list, string listName)
        {
            if(list == null || list.Count == 0) 
            {
                string str = $"{listName}: <!> No List.";
                Console.WriteLine(str);
                return str;
            }

            var bld = new StringBuilder(list.Count * 20);
            bld.Append("/* \n");
            bld.Append($"{listName} \n");

            int count = 0;
            foreach(string str in list)
            {
                if (str.Contains("(1)"))
                {
                    if (count != 0) 
                    { 
                        bld.Append("\n");
                    }
                    bld.Append($"◆{questList[count]} \n");
                    count++;
                }
                bld.Append($"{str} \n");
            }//foreach
            bld.Append("*/ \n");

            Console.WriteLine($"bld.Length: {bld.Length}");
            Console.WriteLine(bld.ToString());
            return bld.ToString();
        }//ShowList()

        //static void Main(string[] args)
        public void Main(string[] args)
        {
            var here = new MultiScan();
            here.BuildQuest();
            here.BuildAnswer();

            Console.WriteLine("==== ShowList ====");
            here.ShowList(here.questList, nameof(questList));
            here.ShowList(here.answerList, nameof(answerList));
        }//Main()
    }//class
}

/*
==== Question ====
◆QuestList: [-99: to Answer]
〔1〕Q1
〔2〕Q2
〔3〕Q3
〔4〕-99

==== Answer ====
◆〔1〕Q1
◇Answer: [-99: QuestEnd][-88: Return]
(1) A1-1
(2) A1-2
(3) -99

◆〔2〕Q2
◇Answer: [-99: QuestEnd][-88: Return]
(1) A2-1
(2) -99

◆〔3〕Q3
◇Answer: [-99: QuestEnd][-88: Return]
(1) A3-1
(2) A3-2
(3) A3-3
(4) A3-4
(5) -99

==== ShowList ====
questList:
〔1〕Q1
〔2〕Q2
〔3〕Q3
answerList:
(1) A1-1
(2) A1-2
(1) A2-1
(1) A3-1
(2) A3-2
(3) A3-3
(4) A3-4

//---- Test ListNull ----
==== Question ====
◆QuestList: [-99: to Answer]
〔1〕-99
==== ShowList ====
questList: <!> No List.
answerList: <!> No List.

//---- Test ShowList() insert quest ----
==== ShowList ====
questList:
〔1〕Q1
〔2〕Q2

answerList:

〔1〕Q1
(1) A1-1
(2) A1-2

〔2〕Q2
(1) A2-1
(2) A2-2

//---- Test QuestConfirm() ----
==== Question ====
◆QuestList: [-99: to Answer]
〔1〕Q1
〔2〕Q2
〔3〕-99
<?> Quest〔2〕で終了します。
よろしいですか？ [ Y / N ]: 0
 0 は不正な入力です。
[ Y / N ]で入力してください。

よろしいですか？ [ Y / N ]: y
==== Answer ====
◆〔1〕Q1
◇Answer: [-99: QuestEnd][-88: Return]
(1) A1-1
(2) A1-2
(3) -99
<?> Answer(2)で終了します。
よろしいですか？ [ Y / N ]: n
(3) A1-3
(4) -99
<?> Answer(3)で終了します。
よろしいですか？ [ Y / N ]: y
◆〔2〕Q2
◇Answer: [-99: QuestEnd][-88: Return]
(1) A2-1
(2) -99
<?> Answer(1)で終了します。
よろしいですか？ [ Y / N ]: y
==== ShowList ====
bld.Length: 27
questList:
〔1〕Q1
〔2〕Q2


bld.Length: 71
answerList:
◆〔1〕Q1
(1) A1-1
(2) A1-2
(3) A1-3

◆〔2〕Q2
(1) A2-1

 */