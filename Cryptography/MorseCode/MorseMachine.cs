/** 
 *@title CsharpBegin / Cryptography / MorseCode / MorseMachine.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩 『暗号技術入門 第３版』SB Creative, 2015 
 *@content MorseMachine
 *
 *@class MorseDictionary
 * 
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
        private readonly MorseDictionary dic
            = new MorseDictionary();
        private string message;
        private int id;
        private string header;
        private string footer;

        public MorseMachine(int id, string message)
        {
            this.id = id;
            this.message = message.ToUpper();
        }

        public string StartSignal()
        {
            header = "《 start 》";
            string startSignal = dic.GetControlSignal("start");
            startSignal = startSignal.Replace("0", "・");
            startSignal = startSignal.Replace("1", "ー");

            return $"{startSignal}";
        }//StartSignal()

        public string EndSignal(int id, string mesType = "over")
        {
            footer = $"《 end of message | ID:{id} | {mesType} | close 》";

            var bld = new StringBuilder(100);
            bld.Append("]");
            bld.Append(dic.GetControlSignal("messageend"));
            bld.Append("／");
            
            char[] idAry = $"ID:{id}".ToCharArray();
            foreach(char idBit in idAry)
            {
                bld.Append(dic.GetValue(idBit));
                bld.Append("|");
            }
            bld.Append("／");

            bld.Append(dic.GetControlSignal(mesType));            
            bld.Append("／");
            bld.Append(dic.GetControlSignal("close"));

            bld.Replace("0", "・");
            bld.Replace("1", "ー");

            return bld.ToString();
        }//EndMessage()

        public bool PreConnect(int id)
        {
            Console.WriteLine("◆PreConnect()");
            Console.WriteLine("＊pre-Request:");

            var bld = new StringBuilder(30);
            bld.Append(StartSignal());
            bld.Append(EndSignal(id, "over"));
            WriteWithBeepMorse(bld.ToString(), isControl: true);
            bld.Clear();

            Console.WriteLine("＊pre-Response:");
            string response = "over";
            //string response = "error";
            bld.Append(StartSignal());
            bld.Append(EndSignal(id, response));
            WriteWithBeepMorse(bld.ToString(), isControl: true);            
            bld.Clear();

            if (response == "over")
            {
                return true;
            }
            else
            {
                return false;
            }
        }//PreConnect()

        public string RecievedSignal(int id)
        {
            var bld = new StringBuilder(30);
            bld.Append(StartSignal());
            bld.Append(EndSignal(id ,"recieved"));
            bld.Replace('0', '・');
            bld.Replace('1', 'ー');

            return bld.ToString();
        }//RecievedSignal()

        public string SendMorse(string message)
        {
            char[] mesAry = message.ToUpper().ToCharArray();

            var bld = new StringBuilder(message.Length * 6);
            bld.Append($"{StartSignal()}[");

            foreach (char c in mesAry)
            {
                string value = dic.GetValue(c);
                bld.Append(value);
                bld.Append("|");
            }//foreach c
            bld.Append(EndSignal(id, "over"));

            string signal = bld.ToString();
            signal = signal.Replace("0", "・");
            signal = signal.Replace("1", "ー");

            return signal;
        }//SendMorse()
        
        private void WriteWithBeepMorse(string signal, bool isControl = false)
        {
            char[] charAry = signal.ToCharArray();
            string[] wordAry = message.Split(
                new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                   
            int wordCount = 0;
            bool wordInit = false;
            bool isHeader = true;

            foreach (char c in charAry)
            {
                if(wordCount == 0 && isHeader)
                {
                    Console.Write($"{header} => ");
                    isHeader = false;
                }

                if (wordInit && !isControl)
                {
                    Console.Write($"[{wordAry[wordCount]}] => ");
                    wordInit = false;
                }

                switch (c)
                {
                    case '・':
                        Console.Write(c);
                        Console.Beep(800, 150);
                        Thread.Sleep(80);
                        break;
                    case 'ー':
                        Console.Write(c);
                        Console.Beep(800, 400);
                        Thread.Sleep(80);
                        break;
                    case '|':
                        Console.Write(c);
                        Thread.Sleep(200);
                        break;
                    case '／':
                        Console.WriteLine(c);
                        Thread.Sleep(400);
                        if (!isControl)
                        {
                            wordCount++;
                            wordInit = true;
                        }
                        break;
                    case '[':
                        Console.WriteLine(c);
                        if (!isControl)
                        {
                            wordInit = true;
                        }
                        break;
                    case ']':
                        Console.WriteLine();
                        Console.WriteLine($"{footer} => ");
                        isControl = true;
                        break;
                    default:
                        Console.WriteLine("<?>");
                        break;
                }//switch               

            }//foreach charAry

            Console.WriteLine();
        }//WriteWithBeepMorse()

        //public string ReciveMorse(string signal)
        //{
        //    signal = signal.Replace("・", "0");
        //    signal = signal.Replace("ー", "1");
        //    signal = signal.Replace("／", " /");

        //    string[] signalAry = signal.Split(
        //        new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        //    var bld = new StringBuilder(signal.Length);
        //    foreach (string bin in signalAry)
        //    {

        //        if (index < 0)
        //        {
        //            if (index == -99)
        //            {
        //                bld.Append(" ");
        //            }
        //            else
        //            {
        //                bld.Append("<?>");
        //            }
        //        }
        //        else
        //        {
        //            c = morseDic.Keys.ElementAt(index);
        //            bld.Append(c);
        //        }
        //    }//foreach bin
        //    return bld.ToString().ToUpper();
        //}//ReciveMorse()

        static void Main(string[] args)
        //public void Main(string[] args) 
        {
            string message = "This is a pen. I am a girl.";
            var here = new MorseMachine(1124, message);

            Console.WriteLine($"Text: {message}");            

            //---- PreConnect ----
            bool isReady = here.PreConnect(here.id);
            if (!isReady)
            {
                Console.WriteLine("PreConnect() return false.");
            }

            //---- Morse Send ----
            Console.WriteLine("◆Morse Send");
            string signal = here.SendMorse(here.message);
            Console.WriteLine(
                $"Message: {here.header}{here.message}{here.footer}");
            here.WriteWithBeepMorse(signal);

            //---- Morse Recieved ----
            Console.WriteLine("◆Morse Recieved");
            here.WriteWithBeepMorse(here.RecievedSignal(here.id), isControl: true);

            //Console.WriteLine("◆Morse Recieve");
            //string reText = here.ReciveMorse(signal);
            //SConsole.WriteLine($"reText: {reText}");
        }//Main() 
    }//class
}

/*
Text: This is a pen. I am a girl.

◆PreConnect()
＊pre-Request:
《 start 》 => ー・ー・ー
《 end of message | ID:1124 | over | close 》 =>
・ー・ー・／
・・|ー・・|ーーー・・・|・ーーーー|・ーーーー|・ ・ーーー|・・・・ー|／
ー・ー／
・・・ー・ー

＊pre-Response:
《 start 》 => ー・ー・ー
《 end of message | ID:1124 | over | close 》 =>
・ー・ー・／
・・|ー・・|ーーー・・・|・ーーーー|・ーーーー|・ ・ーーー|・・・・ー|／
ー・ー／
・・・ー・ー

◆Morse Send
Message: 
《 start 》THIS IS A PEN. I AM A GIRL.《 end of message | ID:1124 | over | close 》

《 start 》 => ー・ー・ー[

[THIS] => ー|・・・・|・・|・・・|／
[IS] => |・・|・・・|／
[A] => |・ー|／
[PEN.] => |・ーー・|・|ー・|・ー・ー・ー|／
[I] => |・・|／
[AM] => |・ー|ーー|／
[A] => |・ー|／
[GIRL.] => |ーー・|・・|・ー・|・ー・・|・ー・ー・ー|

《 end of message | ID:1124 | over | close 》 =>
・ー・ー・／
・・|ー・・|ーーー・・・|・ーーーー|・ーーーー|・ ・ーーー|・・・・ー|／
ー・ー／
・・・ー・ー

◆Morse Recieved
《 start 》 => ー・ー・ー
《 end of message | ID:1124 | recieved | close 》 =>
・ー・ー・／
・・|ー・・|ーーー・・・|・ーーーー|・ーーーー|・ ・ーーー|・・・・ー|／
・ー・／
・・・ー・ー

 */
