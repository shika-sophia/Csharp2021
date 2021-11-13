/** 
 *@title CsharpBegin / SampleCode / EventSamlpe.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 11.4 Event / p565 / List 11-24, 11-25
 *         eventは同クラス内でのみ呼出可能だが、
 *         delegateで 他クラスの EventHandlerを切り出し、
 *         イベント発生時にその処理を行う。
 *         
 *@author shika 
 *@date 2021-11-14 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    delegate void EventHandlar(string data);

    class EventSamlpe 
    {

        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var here = new EventSamlpe();
            var ev = new EventInput();
            ev.KeyInput += here.KeyEventHandler;
            ev.Run();
        }//Main() 

        //delegate void EventHandlar(string data)に登録
        private void KeyEventHandler(string data)
        {
            switch(data){
                case "c":
                    Console.WriteLine($"Now Time: {DateTime.Now}");
                    break;

                case "x":
                    Random rdm = new Random();
                    Console.WriteLine($"Rundom Number: {rdm.Next(1000)}");
                    break;

                case "h":
                    Console.WriteLine("◆Input any Commands: [enter] End");
                    Console.WriteLine("[c] Now Time / [x] Randam Number / [h] Help");
                    break;

                default:
                    throw new ArgumentException(
                        "at EventSample.KeyEventHandlar(string data): \'data\' is illegal value.");
            }//switch
        }
    }//class 

    class EventInput
    {
        public event EventHandlar KeyInput = (v => { });

        public void Run()
        {
            Console.WriteLine("◆Input any Commands: [enter] End");
            Console.WriteLine("[c] Now Time / [x] Randam Number / [h] Help");

            while (true)
            {
                Console.Write("Command:");
                string input = Console.ReadLine();

                if (String.IsNullOrEmpty(input))
                {
                    Console.WriteLine("-- Finished --");
                    break;
                }

                input = input.ToLower();
                if( ! (input.Equals("c")
                    || input.Equals("x")
                    || input.Equals("h")))
                {
                    Console.WriteLine("<!> Please Input [c],[x],[h] ONLY.");
                    continue;
                }

                //KeyEvent発生
                KeyInput(input);
            }//while
        }//Run()
    }//class
}

/*
◆Input any Commands: [enter] End
[c] Now Time / [x] Randam Number / [h] Help
Command:Q
<!> Please Input [c],[x],[h] ONLY.

Command:7
<!> Please Input [c],[x],[h] ONLY.

Command:c
Now Time: 2021/11/14 1:43:35

Command:x
Rundom Number: 250

Command:h
◆Input any Commands: [enter] End
[c] Now Time / [x] Randam Number / [h] Help
Command:
-- Finished --
 */
