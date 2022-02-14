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
 *MainDictionary
 * 
 *@author shika 
 *@date 2022-02-14 
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
        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            var here = new MainSafeDictionary();
            var db = new DatabaseMT06<string, string>();

            WriteDicThread[] writeAry = new WriteDicThread[]
            {
                new WriteDicThread(db, "write1", "Alice", "Alaska"),
                new WriteDicThread(db, "write2", "Bobby", "Brazil"),
                new WriteDicThread(db, "write3", "Alice", "Australia"),
                new WriteDicThread(db, "write4", "Bobby", "Bulgaria"),
            };

            foreach(var write in writeAry)
            {
                new Thread(write.Run).Start();
            }

            for(int i = 0; i < 100; i++)
            {
                new Thread(
                    new ReadDicThread(db, $"reader{i}", "Alice").Run
                    ).Start();
                new Thread(
                    new ReadDicThread(db, $"reader{i}", "Bobby").Run
                    ).Start();
            }
        }//Main() 


    }//class 
}

/*
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