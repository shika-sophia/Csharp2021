/** 
 *@title CsharpBegin / Cryptography / MorseCode / MorseMachine.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference CR 結城 浩 『暗号技術入門 第３版』SB Creative, 2015 
 *@content Morse Machine Simulation
 */
#region -> Class Chart [ MorceCode ]
/*
 *@based MorseMachineArchive //as old version
 *
 *@class MorseMachine // as new version
 *       / - readonly ◇MorseDictionary dic;
 *         - readonly ◇MorsePreConnect pre;
 *         - readonly ◇MorseSend sender;
 *         - readonly ◇MorseTranslate trans;
 *         - int id;
 *         - string message; /
 *       + MorseMachine(int id, string message)
 *       + void ◆Run() //as ◆Main()
 *       - string ToMorse(string)
 *       - string ToBinary(string)
 *       - void ValidId(int id)
 *       - void ValidMessage(string message)
 *         { dic.ValidMessage(string); }
 *         
 *@class MorseDictionary
 *       / - readonly Dictionary<char,string> morseDic;
 *         - readonly Dictionary<string,string> controlDic; /
 *       + bool   ValidMessage(string)
 *       + string GetValue(string)
 *                  { GetValue(char) }
 *       + string GetValue(char)
 *       + int    GetMorseIndex(string)
 *       + char   GetKey(int index)
 *       + string GetControlSignal(string)
 *       + int    GetContolIndex(string)
 *       + string GetControlName(int)
 *       
 *@class MorsePreConnect
 *       / - readonly ◇MorseDictionary dic;
 *         ~ string header;
 *         ~ string footer; /
 *       ~ MorsePreConnect(MorseDictionary)
 *       + string HeaderSignal(int id)
 *       + string FooterSignal(int id, string mesType = false)
 *       + string RecivedSignal(int id)
 *       
 *@class MorseSend
 *       / - string[] wordAry;
 *         - char[] charAry; /
 *       - void BuildArray(string message, string signal)
 *         { wordAry = message.Split(' ');
 *           charAry = signal.ToCharArray(); }
 *       ~ void BeepWriteControl(string text, string signal)
 *       ~ void BeepWriteBody(string message, string signal)
 *       - void BeepWrite()
 *       
 *@class MorseTranslate
 *       / - readonly ◇MorseDictionary dic /
 *       ~ MorseTranslate(MorseDictionary)
 *       ~ TransWord(string signal, bool isControl = false)
 */       
#endregion
/*
 *@author shika 
 *@date 2022-01-22 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.Cryptography.MorseCode
{
    class MorseMachine
    {
        private readonly MorseDictionary dic;            
        private readonly MorsePreConnect pre;
        private readonly MorseSend sender;
        private readonly MorseTranslate trans;
        private int id;
        private string message;
        

        public MorseMachine(int id, string message)
        {
            this.dic = new MorseDictionary();
            this.pre = new MorsePreConnect(dic);
            this.sender = new MorseSend();
            this.trans = new MorseTranslate(dic);

            message = message.ToUpper();
            ValidId(id);
            ValidMessage(message);
            this.id = id;
            this.message = message;
        }

        public void Run()
        {
            //---- build signal as morse ----
            string headerSignal = ToMorse(pre.HeaderSignal(id));
            string footerSignal = ToMorse(pre.FooterSignal(id));
            string bodySignal =  ToMorse(BodySignal(message));

            //---- send Morse ----
            sender.BeepWriteControl(pre.header, headerSignal);
            sender.BeepWriteBody(message, bodySignal);
            sender.BeepWriteControl(pre.footer, footerSignal);

            //---- recived Morse ----
            string recievedSignal = ToMorse(pre.RecievedSignal(id));
            sender.BeepWriteControl(pre.footer, recievedSignal);

            //---- read Morse ----
            string reHeader = 
                $"《 {trans.TransWord(ToBinary(headerSignal), isControl: true)} 》";
            string reBody = trans.TransWord(ToBinary(bodySignal));
            string reFooter = 
                $"《 {trans.TransWord(ToBinary(footerSignal), isControl: true)} 》";
            string reText = $"{reHeader}{reBody}{reFooter}";
            Console.WriteLine($"reText: {reText}");
        }//Run()

        private string ToMorse(string signal)
        {
            signal = signal.Replace("0", "・");
            signal = signal.Replace("1", "－");
            return signal;
        }//ToMorse()

        private string ToBinary(string signal)
        {
            signal = signal.Replace("・", "0");
            signal = signal.Replace("－", "1");
            return signal;
        }

        public string BodySignal(string message)
        {
            return dic.GetValue(message.ToUpper());//as binary
        }//BodySignal()

        private void ValidId(int id)
        {
            Regex regexId = new Regex("[0-9]*");
            bool isValid = regexId.IsMatch(id.ToString());

            if (!isValid)
            {
                Console.Beep();
                throw new ArgumentException(
                    "<!> ID should be input with numbers ONLY.");
            }
        }//ValidId()

        private void ValidMessage(string message)
        {
            bool isValid = dic.ValidMessage(message);

            if (!isValid)
            {
                Console.WriteLine(
                    "<!> There is unadaptable character \n" +
                    $"in your message -- \'{message}\'. \n");
                Console.Beep();
            }
        }//ValidMessage()

        ////==== Test Main() ====
        //static void Main(string[] args)
        ////public void Main(string[] args)
        //{
        //    int id = 16;
        //    string message = "Hello world";
        //    var here = new MorseMachine(id, message);
        //    here.Run();
        //}//Main()

    }//class
}
/*
《 start ／ ID:16 》 =>
[start] => －・－・－／
[ID:16] => ・・|－・・|－－－・・・|・－－－－|－ ・・・・|

Body: HELLO WORLD
[HELLO] => ・・・・|・|・－・・|・－・・|－－－|／
[WORLD] => |・－－|－－－|・－・|・－・・|－・・|

《 end ／ ID:16 ／ over 》 =>
[end] => ・－・－・／
[ID:16] => ・・|－・・|－－－・・・|・－－－－|－ ・・・・|／
[over] => －・－

《 end ／ ID:16 ／ recieved 》 =>
[end] => ・－・－・／
[ID:16] => ・・|－・・|－－－・・・|・－－－－|－ ・・・・|／
[recieved] => ・－・

reText:
《 start ／ ID:16 ／  》
HELLO WORLD 
《 end of message ／ ID:16 ／ over ／  》


//==== Test ValidMessage() ====
<!> There is unadaptable character
in your message -- 'HELLO WORLDあ'

Body: HELLO WORLDあ
[HELLO] => ・・・・|・|・－・・|・－・・|－－－|／
[WORLDあ] => |・－－|－－－|・－・|・－・・|－・・|－・・・・－|・・－－・・|－・・・・－|

reText: 
《 start ／ ID:16 ／  》
HELLO WORLD-?- 
《 end of message ／ ID:16 ／ over ／  》

 */
