/** 
 *@title CsharpBegin / MultiThread / MTCS05_ProducerComsumer / Exchanger / MainExchanger.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第５章 補講２ Exchangerクラス / p187 / List 5-6, 5-7, 5-8
 *         [Java] Exchanger (java.util.concurrent.)
 *         [C#]   ExchangerCS (self-definition)
 *           ２つのオブジェクトを安全に交換することで、
 *           ||Producer-Consumer||を実現するプログラム
 *          〔Two Objects exchange Thread-Safely each other, 
 *            which realize ||Producer-Consumer|| pattern. 〕
*/
#region -> Exchange() Algorism
/*
 *@subject T Exchange(T obj)
 *        【Algorism】
 *         ＊フィールドに保存してある obj が nullなら、引数 objを代入。
 *         〔If the field is null, it is inserted argument 'obj'.〕
 *         
 *         ＊引数で渡されたT型の objと 別の objを返す。
 *         〔It is given by argument 'T obj' and return another 'T obj'.〕
 *         
 *         ＊別の obj2が まだ nullならば、obj2が代入されるまで待機。
 *         〔If another 'obj2' is null, it continue to wait until it is inserted 'obj2'.〕
 *         
 *         ＊【型判定】ジェネリックの場合はコンパイルエラーとなるので不要
 *            〔Actually, this case is not necessary,
 *              because it throws 'Compile Error' in Generic class.〕
 *
 *              if (objArg.GetType() != obj1.GetType())
 *              {
 *                  throw new ArgumentException(
 *                      "<!> different Type of the argument.");
 *              }
 *
 *          ＊obj1, obj2 両方に一致しない obj (= 新しい第３の obj)が引数で渡された場合
 *          〔Case: the argument 'objArg' is not equal to both obj1 and obj2.〕
 *              T objTemp = obj1;
 *              obj1 = objArg;
 *              obj2 = objTemp;
 *
 *              //==== Example ====
 *              //---- Fhase 1 ----
 *              //obj1 = a, obj2 = b
 *              //---- Fhase 2 ----
 *              //objArg = c
 *              //objTemp = a, obj1 = c, obj2 = a
 *              //---- Fhase 3 ----
 *              //objArg = b
 *              //objTemp = c, obj1 = b, obj2 = c
 *              //---- Fhase 4 ----
 *              //objArg = a
 *              //objTemp = b, obj1 = a, obj2 = b
 */
#endregion
#region -> Exchanger Class-Chart
/*
 *@directory ==== Exchanger ====
 *@class MainExchanger
 *       //
 *       ◆Main()
 *       new ExchangerCS();
 *       new char[] buffer * 2
 *       new ProduceCharThread(ExchangerCS, char[], int seed);
 *       new ConsumeCharThread(ExchangerCS, char[], int seed);
 *       new Thread(ThreadStart)
 *         └ delegate void ThreadStart();
 *             └ XxxxCharThread.Run()
 *
 *       //+ Test Main() as Single-Thread
 *       
 *@class ExchangerCS<T>
 *       / - T obj1
 *         - T obj2 /
 *       + ExchangerCS() / ExchangerCS(T obj1, T obj2)
 *       + T Exchange<T>(T obj)
 *
 *@class ProduceCharThread
 *       / - ◇readonly ExchangerCS ex;
 *         - readonly string thName;
 *         - readonly Random random;
 *         - char[] buffer;
 *         - char index = (char) 0; /
 *       + void Run()
 *         { buffer[i] = NextChar();
 *           buffer = ex.Exchange(buffer) }
 *       - char NextChar()
 *       
*@class ConsumeCharThread
 *       / - ◇readonly ExchangerCS ex;
 *         - readonly string thName;
 *         - readonly Random random;
 *         - char[] buffer; /
 *       + void Run()
 *         { buffer = ex.Exchange(buffer) 
 *           Console.WriteLine(buffer[i]) }
 */
#endregion
/*
 *@author shika 
 *@date 2022-01-07 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS05_ProducerComsumer.Exchanger 
{ 
    class MainExchanger 
    {
        //==== Main() as Multi-Thread ====
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            const int LIMIT = 10;
            var ex = new ExchangerCS<char[]>();
            char[] buffer1 = new char[LIMIT];
            char[] buffer2 = new char[LIMIT];

            var producer = new ProduceCharThread(ex, buffer1, 314159);
            var consumer = new ConsumeCharThread(ex, buffer2, 265358);
            new Thread(producer.Run).Start();
            new Thread(consumer.Run).Start();
        }//Main()

        ////==== Test Main() as Single-Thread ====
        //static void Main()
        ////public void Main(string[] args) 
        //{
        //    string a = "a";
        //    string b = "b";
        //    var ex = new ExchangerCS<string>(a, b);

        //    string reA = ex.Exchange(a);
        //    string reB = ex.Exchange(b);
        //    Console.WriteLine($"({a}, {b}) => ({reA}, {reB})");

        //    string reC = ex.Exchange("c");
        //    Console.WriteLine($"(\"c\") => ({reC})");

        //    string reBB = ex.Exchange(b);
        //    Console.WriteLine($"({b}) => ({reBB})");

        //    string reAA = ex.Exchange(a);
        //    Console.WriteLine($"({a}) => ({reAA})");

        //    string reSame = ex.Exchange(a);
        //    Console.WriteLine($"({a}) => ({reSame})");
        //}//Test Main()
    }//class 
}

/*
//==== Main() as Multi-Thread ====
ConsumeCharThread: BEFORE Excahnge()
ProduceCharThread: A ->
ProduceCharThread: B ->
ProduceCharThread: C ->
ProduceCharThread: D ->
ProduceCharThread: E ->
ProduceCharThread: F ->
ProduceCharThread: G ->
ProduceCharThread: H ->
ProduceCharThread: I ->
ProduceCharThread: J ->
ProduceCharThread: BEFORE Excahnge()
ConsumeCharThread: AFTER  Excahnge()
ConsumeCharThread: -> A
ProduceCharThread: AFTER  Excahnge()
ConsumeCharThread: -> B
ProduceCharThread: K ->
ConsumeCharThread: -> C
ProduceCharThread: L ->
ConsumeCharThread: -> D
ProduceCharThread: M ->
ConsumeCharThread: -> E
ProduceCharThread: N ->
ConsumeCharThread: -> F
ProduceCharThread: O ->
ConsumeCharThread: -> G
ConsumeCharThread: -> H
ProduceCharThread: P ->
ConsumeCharThread: -> I
ConsumeCharThread: -> J
ProduceCharThread: Q ->
ConsumeCharThread: BEFORE Excahnge()
ConsumeCharThread: AFTER  Excahnge()
ConsumeCharThread: -> K
ProduceCharThread: R ->
  :
 */
/*
//==== Result of Test Main() ====
(a, b) => (b, a)
("c") => (b)
(b) => (c)
(a) => (b)
(a) => (b)
*/