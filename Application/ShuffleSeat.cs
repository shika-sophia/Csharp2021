/**
 *@title CsharpBegin / Application / ShuffleSeat.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 席替えアプリ
 *  ◆System.Random
 *  int random.Next(int max); //0-max未満の乱数を生成
 *  
 *  ◆ShuffleSeat
 *  ShuffleList(List<string) //listのシャッフル、同席判定
 *  BuildResultList(List<string>) 
 *    固定席 Dictionary<int,string>) fixDicと
 *    新席順 List<string> newListを統合し
 *    結果 resultListを生成。
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
        private static readonly int memberNum = 18;
        private readonly Random random = new Random();
        private List<string> oldList = new List<string>(memberNum);
        private List<string> newList;
        private List<string> resultList;
        private Dictionary<int, string> 
            fixDic = new Dictionary<int, string>()
            {
                [1] = "□",
                [3] = "×",
                [5] = "□",
                [10] = "□",
                [16] = "■",
                [24] = "×"
            };

        public ShuffleSeat()
        {
            this.oldList = BuildOldList(oldList);
            this.newList = ShuffleList(oldList); 
            this.resultList = BuildResultList(newList);
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
            List<string> newList = new List<string>(list.Count);
            List<int> indexList = new List<int>(list.Count);
            bool isStack = true;
            while (isStack)
            {
            reRandom:
                int rdm = random.Next(memberNum);
                foreach (int index in indexList)
                {
                    if (rdm == index) { goto reRandom; }
                }//foreach

                indexList.Add(rdm);
                newList.Add(list[rdm]);

                if (newList.Count == list.Count)
                {
                    //同席判定
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (newList[i].Equals(list[i]))
                        {
                            newList.Clear();
                            indexList.Clear();
                            goto reRandom;
                        }
                    }//for

                    isStack = false;
                }//if
            }//while

            return newList;
        }//ShuffleList()

        private List<string> BuildResultList(List<string> list)
        {
            int resultSize = list.Count + fixDic.Count;
            var resultList = new List<string>(resultSize);

            int count = 0; //fixDicから取得した要素数
            for(int i = 0; i <= resultSize; i++)
            {
                if(fixDic.TryGetValue(i, out string value))
                {
                    resultList.Add(value);
                    count++;
                }
                else
                {                    
                    if(i - count < list.Count)
                    {
                        resultList.Add(list[i - count]);                       
                    }
                }                
            }//for

            return resultList;
        }//BuildResultList()

        private string ShowList(List<string> list, string name)
        {
            var bld = new StringBuilder(memberNum * 6);
            bld.Append($"{name}:[ \n");
            int count = 0; //出力した要素数
            foreach(string str in list)
            {
                bld.Append($"{str}, ");
                count++;

                if(count % 4 == 0 && count != 0)
                {
                    bld.Append("\n");
                }
            }
            bld.Append("] \n");

            Console.WriteLine($"bldLength: {bld.Length}");
            Console.WriteLine(bld.ToString());
            return bld.ToString();
        }//ShowList()

        static void Main(string[] args)
        //public void Main(string[] args)
        {
            var here = new ShuffleSeat();
            here.ShowList(here.oldList, nameof(oldList));
            here.ShowList(here.newList, nameof(newList));
            here.ShowList(here.resultList, nameof(resultList));
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

//---- BuildResultList() ----
bldLength: 72
oldList:[
Ａ, Ｂ, Ｃ, Ｄ,
Ｅ, Ｆ, Ｇ, Ｈ,
Ｉ, Ｊ, Ｋ, Ｌ,
Ｍ, Ｎ, Ｏ, Ｐ,
Ｑ, Ｒ, ]

bldLength: 72
newList:[
Ｑ, Ｏ, Ｄ, Ｃ,
Ｆ, Ｒ, Ｊ, Ｂ,
Ｇ, Ｐ, Ｈ, Ｎ,
Ｅ, Ｉ, Ｋ, Ａ,
Ｍ, Ｌ, ]

bldLength: 95
resultList:[
Ｑ, □, Ｏ, ×,
Ｄ, □, Ｃ, Ｆ,
Ｒ, Ｊ, □, Ｂ,
Ｇ, Ｐ, Ｈ, Ｎ,
■, Ｅ, Ｉ, Ｋ,
Ａ, Ｍ, Ｌ, ×,
]
*/