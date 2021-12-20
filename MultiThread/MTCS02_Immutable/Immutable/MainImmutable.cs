/** 
 *@title CsharpBegin / MultiThread / MTCS02_Immutable / Immutable / MainImmutable.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference MT 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content MT 第２章 Immutable / p86 / List 2-1, 2-2, 2-3
 *         ～ 壊したくても壊せない ～
 *         -- If anyone would want to break the object, it can't be broken. --
 *         
 *@subject 不変オブジェクト immutable object
 *         [Java] final class 
 *                   //unable to inheritance 継承不可
 *                - private final field コンストラクタ,初期化子のみで初期化可能
 *                   // initializable ONLY by constructor, initializer
 *                   
 *         [C#]   sealed class 
 *                   //unable to inheritance 継承不可
 *                - private readonly field コンストラクタ,初期化子のみで初期化可能
 *                   // initializable ONLY by constructor, initializer
 *                + public  Property { get; }
 *                   // initializable ONLY by constructor, initializer
 *                   // getter ONLY
 *         
 *@subject 不変オブジェクトの利用
 *         オブジェクトが不変なら、マルチスレッドでもスレッドセーフは保たれる。
 *         排他制御の必要がない。
 *         If the object were immutable, it certainly will be Thread-Safe
 *         even in Multi-Thread,
 *         which isn't needed [Java] synchronized / [C#] lock().
 *         
 *@class MainImmutable / 
 *       ◆Main() 
 *         new PersonImmutable(string, string)
 *         new ShowPersonThread(PersonImmutable)
 *         new Thread(ThreadStart) * 3
 *               └ delegate void ThreadStart();
 *                  └ showPersonThread.Run()
 *                  
 *@class PersonImmutable / sealed class
 *       / - readonly string name
 *         - readonly string address /
 *       + PersonImmutable(string name, string address)
 *       + override string ToString()
 *         
 *@class ShowPersonThread
 *       / - readonly PersonImmutable /
 *       + ShowPersonThread(PersonImmutable)
 *       + Run()
 *          Thread Thread.CurrentThread;
 *          string Thread.CurrentThread.Name;
 *          
 *@author shika 
 *@date 2021-12-20 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS02_Immutable.Immutable 
{ 
    class MainImmutable 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var person = new PersonImmutable("Alice", "Alaska");
            var thPerson = new ShowPersonThread(person);
            new Thread(thPerson.Run).Start();
            new Thread(thPerson.Run).Start();
            new Thread(thPerson.Run).Start();
        }//Main() 
    }//class 
}

/*
 [PersonImmutable: Name Alice, Address Alaska]
 [PersonImmutable: Name Alice, Address Alaska]
 [PersonImmutable: Name Alice, Address Alaska]
 [PersonImmutable: Name Alice, Address Alaska]
    :
*/