/** 
 *@title CsharpBegin / MultiThread / MTCS07_ThreadPerMessage / Blackholl / BlackhollSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content 第７章 Thread per Message / 
 *         練習問題 7-7 / p258, p545 / List 7-21
 *
 *@subject 【パズル】BlackhollSampleの記述は所与、
 *          Magic()を記述し、Step 1, Step 2のみ表示せよ。
 *          
 *          【回答】My Answer
 *          Magic()内で new Threadを定義し、
 *          その new Threadが objの lockを取り、
 *          そのまま ずっと眠る。(lockは解放されない)
 *          Magic()を呼び出したMainThreadの制御は呼出元に戻り、続きを実行。
 *          「Step 2」を表示して、lock()で ずっと待つので「Step 3」以降は表示されない。

 *@author shika 
 *@date 2022-02-25 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS07_ThreadPerMessage.Blackholl 
{ 
    class BlackhollSample 
    { 
        public void Enter(object obj) 
        {
            Console.WriteLine("BEGIN");
            Console.WriteLine("Step 1"); 
            Magic(obj); 
            Console.WriteLine("Step 2"); 
 
            lock (obj) 
            { 
                Console.WriteLine("Step 3 (Never Reached)"); 
            }

            Console.WriteLine("END");
        }//Enter() 
 
        private void Magic(object obj) 
        { 
            new Thread(() => 
                { 
                    lock (obj) 
                    { 
                        Thread.Sleep(Timeout.Infinite); 
                    } 
                } 
            ).Start();

            Thread.Sleep(50);//上記new Threadが lockを取るまで待機
        }//Magic() 
 
        static void Main(string[] args) 
        //public void Main(string[] args) 
        {
            new BlackhollSample().Enter(new Object());
        }//Main() 
    }//class 
}

/*
BEGIN
Step 1
Step 2
  :
(CTRL + C)
 */
