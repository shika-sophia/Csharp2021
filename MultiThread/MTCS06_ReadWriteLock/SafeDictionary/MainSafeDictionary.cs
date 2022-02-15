/** 
 *@title CsharpBegin / MultiThread / MTCS06_ReadWriteLock / Dictionary / MainDictionary.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第６章 Read-Write Lock / 練習問題 6-4 / p221, p525 / List 6-9
 *         Dictionary<K,V> as Thread unsafe Collection
 *         DatabaseMT06 as Thread safe 
 *         by [Java] syncronized / [C#] lock()
 *           ↓
 *         DatabaseMT06 as Thread safe 
 *         by [Java] java.util.concurrent.locks.ReentrantReadWriteLock
 *            / [C#] System.Threading.ReaderWriterLockSlim
 *            
 *@subject 排他的インクリメント (atomicな演算)
 *         [Java] java.util.concurrent.atomic.AtomicInteger
 *         int incrementAndGet()
 *         
 *         [C#] System.Threading.InterLocked
 *         int Increment(int)
 *
 *@note【考察】
 *      [Java] HashMap<K,V>.put(K key)は keyの重複で value上書き
 *      [C#]   Dictionary<K,V>.Add(K, V)は keyの重複で ArgumentException
 *      テキストの解答コードそのままでは、動作せず、工夫が必要。
 *      
 *@author shika 
 *@date 2022-02-14, 02-15
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.SafeDictionary 
{ 
    class MainSafeDictionary 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var here = new MainSafeDictionary();
            var db = new DatabaseMT06<int, char>();
            
            WriteDicThread[] writeAry = new WriteDicThread[6];
            for (int i = 0; i < writeAry.Length; i++)
            {
                writeAry[i] = new WriteDicThread(db, $"writer{i}");
                new Thread(writeAry[i].Run).Start();
            }//for

            for(int i = 0; i < 10; i++)
            {
                new Thread(
                    new ReadDicThread(db, $"reader{i}").Run
                    ).Start();
            }//for
        }//Main() 
    }//class 
}

/*
writer0: Assign [0:A]
writer1: Assign [1:B]
writer2: Assign [2:C]
reader5: Retreive [0:A],
reader6: Retreive [0:A],
reader8: Retreive [0:A],
reader1: Retreive [0:A],
reader4: Retreive [0:A],
reader0: Retreive [0:A],
reader3: Retreive [0:A],
reader2: Retreive [0:A],
reader9: Retreive [0:A],
reader7: Retreive [0:A],
writer3: Assign [3:D]
reader4: Retreive [1:B],
reader7: Retreive [1:B],
reader9: Retreive [1:B],
reader1: Retreive [1:B],
reader0: Retreive [1:B],
reader3: Retreive [1:B],
reader5: Retreive [1:B],
reader8: Retreive [1:B],
reader6: Retreive [1:B],
reader2: Retreive [1:B],
writer4: Assign [4:E]
reader8: Retreive [2:C],
reader6: Retreive [2:C],
reader1: Retreive [2:C],
reader5: Retreive [2:C],
reader3: Retreive [2:C],
reader4: Retreive [2:C],
reader2: Retreive [2:C],
reader0: Retreive [2:C],
reader7: Retreive [2:C],
reader9: Retreive [2:C],
writer5: Assign [5:F]
reader0: Retreive [3:D],
reader9: Retreive [3:D],
reader1: Retreive [3:D],
reader5: Retreive [3:D],
reader2: Retreive [3:D],
reader8: Retreive [3:D],
reader6: Retreive [3:D],
reader3: Retreive [3:D],
reader4: Retreive [3:D],
reader7: Retreive [3:D],
writer0: Assign [6:G]
reader9: Retreive [4:E],
reader1: Retreive [4:E],

 * 
//---- Test BuildDic(), NextAlphabet(), db.ToString() ----
//static void Main(string[] args) 
//public void Main(string[] args) 
//{
    //var db = new DatabaseMT06<int, char>();
    //here.BuildDic(db.dic, 30);
    //Console.WriteLine(db.ToString());  
//}//Main() 

//private void BuildDic(Dictionary<int,char> dic, int size)
//{
//    if(size < 0)
//    {
//        throw new ArgumentException(
//            "<!> Dictionary size should be set the number over zero.");
//    }

//    for(int i = 1; i <= size; i++)
//    {
//        dic.Add(i, NextAlphabet(i - 1));
//    }
//}//BuildDic

//private char NextAlphabet(int index)
//{
//    return (char) ('A' + (index % 26));
//}
bld.Length: 267
[1: A], [2: B], [3: C], [4: D], [5: E],
[6: F], [7: G], [8: H], [9: I], [10: J],
[11: K], [12: L], [13: M], [14: N], [15: O],
[16: P], [17: Q], [18: R], [19: S], [20: T],
[21: U], [22: V], [23: W], [24: X], [25: Y],
[26: Z], [27: A], [28: B], [29: C], [30: D],
 */