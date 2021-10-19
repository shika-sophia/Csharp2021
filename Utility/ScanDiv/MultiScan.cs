/**
 *@title CsharpBegin / Utility / ScanDiv / MultiScan.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 複数質問 / 回答 / 戻る機能
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
    class MultiScan
    {
        public List<string> questList { get; private set; }
            = new List<string>();
        public List<string> answerList { get; private set; }
            = new List<string>();

        public void BuildQuest()
        {
            Console.WriteLine("==== Question ====");
            Console.WriteLine("◆QuestList: [-99: to Answer]");
            int count = 1;
            nextQuest:
                Console.Write($"〔{count}〕");
                string quest = Console.ReadLine();

                if (String.IsNullOrEmpty(quest)) { goto nextQuest; }
                if (quest.Contains("-99"))
                {
                    Console.WriteLine();
                    return; 
                }

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
                    "◇Answer: [-99: QuestEnd][-88: Return]");
                int count = 1;
                nextAnswer:
                    Console.Write($"({count}) ");
                    string answer = Console.ReadLine();
                    if (String.IsNullOrEmpty(answer)) { goto nextAnswer; }
                    if (answer.Contains("-99")) 
                    {
                        Console.WriteLine();
                        continue; 
                    }
                    if (answer.Contains("-88"))
                    {
                        //戻る機能
                    }

                    answerList.Add($"({count}) {answer}");
                    count++;
                goto nextAnswer;
            }//foreach
        }//BuildAnswer()

        public string ShowList (List<string> list, string listName)
        {
            if(list == null || list.Count == 0) 
            {
                string str = $"{listName}: <!> No List.";
                Console.WriteLine(str);
                return str;
            }

            var bld = new StringBuilder(list.Count * 20);
            bld.Append($"{listName}: \n");

            int count = 0;
            foreach(string str in list)
            {
                if (str.Contains("(1)"))
                {
                    if (count != 0) 
                    { 
                        bld.Append("\n");
                    }
                    bld.Append($"{questList[count]} \n");
                    count++;
                }
                bld.Append($"{str} \n");
            }
            bld.Append("\n");

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
 */