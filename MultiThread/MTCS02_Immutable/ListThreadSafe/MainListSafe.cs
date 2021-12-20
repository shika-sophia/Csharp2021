/** 
 *@title CsharpBegin / MultiThread / MTCS02_Immutable / ListThreadSafe / MainListSafe.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content Appendix 2: Thread-Safe Collection / p103 / List 2-7, 2-8, 2-9
 *         [Java] Collection.SynchronizedList(IList),
 *                CopyOnWriteArrayList<T> java.util.concurrent.
 *         [C#]   BlockingCollection<T>   System.Collections.Concurrent.
 *         
 *@subject ◆BlockingCollection<T>
 *           //The Collection is locked by itself, when list is read and written.
 *         
 *         ◆Modification of these constructor from ListUnsafe
 *         new WriteListThread(ICollection<T>) 
 *           -> WriteListBlocked(BlockingCollection<T>
 *         new ReadListThread(ICollection<T>)
 *           -> ReadListBlocked(BlockingCollection<T>)
 *           
 *         //Both classes Run() contents are same.
 *         
 *@【NOTE】-- Inheritance of ICollection --
 *         Though it is discribed that
 *             "class BlockingCollection<T> : IEnumerable<T>, IEnumerable,
 *              ICollection, IDisposable, IReadOnlyCollection<T>",
 *         'Console.WriteLine(list is ICollection<int>);'
 *         the result is 'False'.
 *         I don't find why it can't do cast '(ICollection)'.
 *
 *@see ListUnsafe / MainListUnsafe.cs
 *@author shika 
 *@date 2021-12-20 
*/
using CsharpBegin.MultiThread.MTCS02_Immutable.ListUnsafe;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS02_Immutable.ListThreadSafe
{
    class MainListSafe
    {
        static void Main(string[] args) 
        //public void Main(string[] args)
        {
            var list = new BlockingCollection<int>();
            //Console.WriteLine(list is ICollection<int>); //False
            new Thread(new WriteListBlocked(list).Run).Start();
            new Thread(new ReadListBlocked<int>(list).Run).Start();
        }//Main() 
    }//class
}

/*
 :
696
697
698
699
700
701
702
703
 :
(Thread Safe)
 */
