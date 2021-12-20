/** 
 *@title CsharpBegin / MultiThread / MTCS02_Immutable / ListUnsafe / MainListUnsafe.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第２章 補講２ Collection in MultiThread / p99 / List 2-4, 2-5, 2-6
 *@subject List<T> is Thread-unsafe
 *         Therefore, to modify list in repeat syntax Enumerator 
 *           like for(), foreach(), while();
 *         must be thrown the Exception.
 *           [Java] ConcurrentModificatonException
 *           [C#]   InvalidOperationException
 *           
 *@see ListThreadSafe / MainListSafe.cs
 *@author shika 
 *@date 2021-12-20 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading; 
 
namespace CsharpBegin.MultiThread.MTCS02_Immutable.ListUnsafe
{ 
    class MainListUnsafe 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var list = new List<int>();
            new Thread(new WriteListThread(list).Run).Start();
            new Thread(new ReadListThread<int>(list).Run).Start();
        }//Main() 
    }//class 
}

/*
ハンドルされていない例外: 
System.InvalidOperationException:
コレクションが変更されました。列挙操作は実行されない可能性があります。
場所:
CsharpBegin.MultiThread.MTCS02_Immutable
  .ArrayListUnsafe.ReadListThread`1.Run()

 */