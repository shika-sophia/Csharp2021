/**  
 *@title CsharpBegin / Exercise / SelfLearnCS / SelfLearnChap06.cs  
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@content 第６章 コレクション / 練習問題 6-1, 6-2, 6-3,章末問題
 *@subject <T>, List, Set, Stack, Queue, Dictionary 
 *  
 *@author shika  
 *@date 2021-11-24  
*/  
/*==== Appendix ====  
 *@date: 2021-11-24 (水)  
 *@time: 03:52 ～ 04:10 (18分)  
 *@rate: 80.00％ (○ 8 問 / 全 10 問)  
*/  
/*==== Appendix ==== 
 *@date: 2021-11-24 (水) 
 *@time: 04:24 ～ 04:39 (15分) 
 *@rate: 100.00％ (○ 15 問 / 全 15 問) 
*/ 
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
  
namespace CsharpBegin.Exercise.SelfLearnCS  
{  
    class SelfLearnChap06  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()   
  
    }//class  
}  
/*  
2021-11-24 (水) 
==== Exercise Result ====  
◆〔1〕第６章 コレクション / 練習問題 6-1  
× (1) ジェネリック: コンパイル時に型を決めず、実行時に型を特定する仕組み。 
    => ○: 実行時に決まるのは dynamic  
○ (2) コレクションで利用する利点: List<object>だと、 
    代入時のどの型も受け入れることができるが、型安全ではなく、 
    取り出し時に例外発生の可能性があるため、キャストが必要。 
    ジェネリックを利用した List<T>なら、 
    実行時に型を決められる汎用性を維持しながらも、 
    初期値で規定した型以外は受け付けず、型安全が保証される。 
 
○ (3) ２．List<int> list = new List<int> { 15, 23, 29, 37 };  
 
◆〔2〕6-2  
○ (1) <int>  
○ (2) [3]  
○ (3) Remove()  
× (4) Add()  
    => ○: Insert(int, T) 要素の入れ替え 
○ (5) v  
 
◆〔3〕6-3  
○ (1) リストは順序を伴って要素を保存するが、セットは集合に関心があり、順序は保存しない。 
    リストは重複要素も可だが、セットの重複要素は既存の集合が存在するなら無視される。 
 
○ (2) SortedSet, HashSet: Setの要素をソートした状態で保存しているのが前者。 
    順序なく集合だけに関心がある場合は後者を利用する。  
*/  
/*==== Appendix ====  
 *@date: 2021-11-24 (水)  
 *@time: 03:52 ～ 04:10 (18分)  
 *@rate: 80.00％ (○ 8 問 / 全 10 問)  
*/  
/* 
2021-11-24 (水)
==== Exercise Result ==== 
◆〔1〕章末問題１ 
○ (1) × -> Listの挿入・削除は末尾ほど速く処理される 
○ (2) × -> LinkedListは要素のコピー・ペーストが起こらず、Listより高速で挿入・削除が可能。 
○ (3) × -> HashSetは重複はないが、順序は保存していない。 
○ (4) ○ -> Dictionaryは一意のkeyとvalue。keyの並び順は保証されない。 
○ (5) × -> Stack: FILO, Queue: FIFO  

◆〔2〕２ 
○ (1) <string,string> 
○ (2) ["cucumber"] 
○ (3) Add() 
○ (4) Remove() 
○ (5) m.Key 
○ (6) m.Value 

◆〔3〕３ 
○ (1) () -> <int> 
○ (2) list[5]の要素は存在しないため、IndexOutOfBoundsException => list[2] 
○ (3) foreach(string v -> int 
○ (4) Remove(60)の要素は存在しないが、falseが返るのみで例外とならず。 
*/ 
/*==== Appendix ==== 
 *@date: 2021-11-24 (水) 
 *@time: 04:24 ～ 04:39 (15分) 
 *@rate: 100.00％ (○ 15 問 / 全 15 問) 
*/ 
