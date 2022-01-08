/** 
 *@title CsharpBegin / MultiThread / MTCS05_ProducerComsumer / ClearThread / MainClearCake.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content Practice 5-5 / p194, p512 / List A5-2, A5-3, A5-5
 *
 *@base CakeTable / MainCakeTable.cs
 *@chart ==== Modification Point ONLY ====
 *@class MainClearCake
 *       new ClearThreadMT05(string thName, AbsCakeTable)
 *       new Thread(clear.Run)
 *       
 *@class AbsCakeTable / CakeTabeMT05
 *       + ClearCake()
 *
 *@class ClearThreadMT05
 *       / - readonly ◇AbsCakeTable table;
 *         - raedonly string thName; /
 *       + ClearThreadMT05(string thName, AbsCakeTable)
 *       + void Run() { table.ClearCake(); }
 * 
 *@author shika 
 *@date 2022-01-09 
*/
using CsharpBegin.MultiThread.MTCS05_ProducerComsumer.CakeTable;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.ClearThread 
{ 
    class MainClearCake 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            AbsCakeTable table = new CakeTableMT05(10);
            var maker1 = new MakerThreadMT05("Maker1", table, 31415);
            var maker2 = new MakerThreadMT05("Maker2", table, 92653);
            var maker3 = new MakerThreadMT05("Maker3", table, 58979);
            var eater1 = new EaterThreadMT05("Eater1", table, 32384);
            var eater2 = new EaterThreadMT05("Eater2", table, 62643);
            var eater3 = new EaterThreadMT05("Eater3", table, 38327);
            var clear = new ClearThreadMT05("Clear", table);

            new Thread(maker1.Run).Start();
            new Thread(maker2.Run).Start();
            new Thread(maker3.Run).Start();
            new Thread(eater1.Run).Start();
            new Thread(eater2.Run).Start();
            new Thread(eater3.Run).Start();
            new Thread(clear.Run).Start();
        }//Main() 
    }//class 
}

/*
 :
Count 4: PutCake([Cake No.13 by Maker2])
Count 3: TakeCake() [Cake No.10 by Maker3]
Count 2: TakeCake() [Cake No.11 by Maker3]
Count 2: ClearCake()
Clear: Cleared
Count 1: PutCake([Cake No.14 by Maker3])
Count 0: TakeCake() [Cake No.14 by Maker3]
  :
 */