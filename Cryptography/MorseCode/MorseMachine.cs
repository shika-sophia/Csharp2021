/** 
 *@title CsharpBegin / Cryptography / MorseCode / MorseMachine.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference CR 結城 浩 『暗号技術入門 第３版』SB Creative, 2015 
 *@content Morse Machine Simulation
 */
#region -> Class Chart [ MorceCode ]
/*
 *@class MorseMachine
 *       / - readonly ◇MorseDictionary dic;
 *         - readonly ◇PreComminucation pre;
 *         - int id;
 *         -string message; /
 *       + MorseMachine(int id, string message)
 *       + void ◆Run() //as ◆Main()
 *       - string ToMorse(string)
 *       - string ToBinary(string)
 *         
 *@class MorseDictionary
 *       / - readonly Dictionary<char,string> morseDic;
 *         - readonly Dictionary<string,string> controlDic; /
 *       + string GetValue(string)
 *                  { GetValue(char) }
 *       + string GetValue(char)
 *       + int    GetMorseIndex(string)
 *       + char   GetKey(int index)
 *       + string GetControlSignal(string)
 *       + int    GetContolIndex(string)
 *       + string GetControlName(int)
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
            this.sender = new MorseSend(pre);
            this.trans = new MorseTranslate(dic);

            this.id = id;
            this.message = message.ToUpper();
        }

        public void Run()
        {
            Console.WriteLine($"Text: {message}");

            //---- build signal as morse ----
            string headerSignal = ToMorse(pre.HeaderSignal(id));
            string footerSignal = ToMorse(pre.FooterSignal(id));
            string recievedSignal = ToMorse(pre.RecievedSignal(id));
            string bodySignal =  ToMorse(BodySignal(message));

            //---- send Morse ----
            sender.BeepWrite(message, headerSignal, isControl: true);
            sender.BeepWrite(message, bodySignal, isControl: false);
            sender.BeepWrite(message, footerSignal, isControl: true);
            sender.BeepWrite(message, recievedSignal, isControl: true);

            //---- read Morse ----
            string reText = trans.ReadMorse(
                $"{ToBinary(headerSignal)}{ToBinary(bodySignal)}{ToBinary(footerSignal)}");
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

        static void Main(string[] args)
        //public void Main(string[] args)
        {
            int id = 16;
            string message = "Hello world";
            var here = new MorseMachine(id, message);
            here.Run();
        }//Main()

    }//class
}

