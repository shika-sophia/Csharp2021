/**
 *@title CsharpBegin / Application / ShuffleSeat.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 席替えアプリ
 *  ◆System.Random
 *  int random.Next(int max); //0-max未満の乱数を生成
 * 
 *@author shika 
 *@date 2021-10-11 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Application
{
    class ShuffleSeat
    {
        private static readonly int memberNum = 30;
        private readonly Random random = new Random();
        private List<string> oldList = new List<string>(memberNum);
        private List<string> newList = new List<string>(memberNum);

        public ShuffleSeat()
        {
            this.oldList = BuildOldList(oldList);
            ShuffleList(oldList); //this.newListを生成
            //ShowList();
        }

        private List<string> BuildOldList(List<string> list)
        {
            for (int i = 0; i < memberNum; i++)
            {
                char c = (char)(CharInit(i) + i);
                string str = Char.ToString(c);
                list.Add(str);
            }

            return list;
        }//BuildOldList()

        private int CharInit(int i)
        {
            int charInit = 0;
            //「26」:アルファベットの個数
            if (0 <= i && i <= 25) { charInit = 'Ａ'; }
            else if (25 < i && i <= 51) { charInit = 'ａ' - 26; }
            else if (51 < i && i <= 77) { charInit = 'A' - 52; }
            else if (77 < i && i <= 103) { charInit = 'a' - 78; }
            else if (103 < i) { charInit = 'あ' - 104; }

            return charInit;
        }//CharInit

        private List<string> ShuffleList(List<string> list)
        {
            newList.Clear();
            List<int> indexList = new List<int>(list.Count);
            bool isStack = true;

            reRandom:
            while (isStack)
            {
                int rdm = random.Next(memberNum);
                foreach (int index in indexList)
                {
                    if (rdm == index)
                    {
                        isStack = true;
                        goto reRandom;
                    }

                    break;
                }//foreach
                
                indexList.Add(rdm);                
                newList.Add(oldList[rdm]);                    

                if(newList.Count == oldList.Count)
                {
                    isStack = false;
                }
            }//while

            return newList;
        }//ShuffleList()

        private void ShowList(List<string> list, string name)
        {
            Console.Write(name + ":[");
            foreach(string str in list)
            {
                Console.Write(str + ", ");
            }
            Console.WriteLine("]");
        }//ShowList()

        //static void Main(string[] args)
        public void Main(string[] args)
        {
            var here = new ShuffleSeat();
            here.ShowList(here.oldList, nameof(oldList));
            here.ShowList(here.newList, nameof(newList));
        }//Main()
    }//class
}

/*
//====== Test Main() ======
//---- BuildOldList(), CharInit() ----
oldList:[Ａ, Ｂ, Ｃ, Ｄ, Ｅ, Ｆ, Ｇ, Ｈ, Ｉ, Ｊ, 
    Ｋ, Ｌ, Ｍ, Ｎ, Ｏ, Ｐ, Ｑ, Ｒ, Ｓ, Ｔ, Ｕ,
    Ｖ, Ｗ, Ｘ, Ｙ, Ｚ, ａ, ｂ, ｃ, ｄ,]

//---- ShuffleList() ----
oldList:[Ａ, Ｂ, Ｃ, Ｄ, Ｅ, Ｆ, Ｇ, Ｈ, Ｉ, Ｊ, 
    Ｋ, Ｌ, Ｍ, Ｎ, Ｏ, Ｐ, Ｑ, Ｒ, Ｓ, Ｔ, Ｕ, 
    Ｖ, Ｗ, Ｘ, Ｙ, Ｚ, ａ, ｂ, ｃ, ｄ, ]
newList:[Ｓ, Ｃ, Ａ, Ｄ, Ｖ, Ｍ, ｂ, ｃ, Ｇ, Ｕ,
    Ｕ, Ｐ, Ｄ, Ｘ, ａ, ｃ, Ｘ, Ｗ, Ｈ, Ｌ, Ｉ, 
    Ｎ, Ｌ, Ｚ, Ｗ, Ｂ, Ｆ, Ｋ, Ｔ, Ｐ, ]
*/