/** 
 *@title CsharpBegin / Cryptography / MorseCode / MorseMachine.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference CR 結城 浩 『暗号技術入門 第３版』SB Creative, 2015 
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
        private readonly MorseDictionary dic;            
        private readonly PreCommunication pre;           
        private string message;
        private int id;
        

        public MorseMachine(int id, string message)
        {
            this.id = id;
            this.message = message.ToUpper();
            this.dic = new MorseDictionary();
            this.pre = new PreCommunication(dic);
        }

        public void Run()
        {
            //---- signal as morse ----
            string headerSignal = ToMorse(pre.HeaderSignal(id));
            string footerSignal = ToMorse(pre.FooterSignal(id));
            string bodySignal =  ToMorse(BodySignal(message));

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
                    Console.Write($"{pre.header} => ");
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
                        Console.Beep(800, 100);
                        Thread.Sleep(80);
                        break;
                    case '－':
                        Console.Write(c);
                        Console.Beep(800, 300);
                        Thread.Sleep(80);
                        break;
                    case '|':
                        Console.Write(c);
                        Thread.Sleep(200);
                        break;
                    case '／':
                        Console.WriteLine(c);
                        Thread.Sleep(300);
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
                        Console.WriteLine($"{pre.footer} => ");
                        isControl = true;
                        break;
                    default:
                        Console.WriteLine("<?>");
                        break;
                }//switch               

            }//foreach charAry

            Console.WriteLine();
        }//WriteWithBeepMorse()

        public string ReadMorse(string signal)
        {
            signal = ToBinary(signal);
            string headerSignal = signal.Substring(0, signal.IndexOf("["));
            string footerSignal = signal.Substring(signal.LastIndexOf("]"));
            signal = signal.Remove(0, signal.IndexOf("["));
            signal = signal.Remove(signal.LastIndexOf("]"));

            string reHeader = $"《 {TransWord(headerSignal, isControl: true)} 》";
            string body = TransWord(signal).ToUpper();
            string reFooter = $"《 {TransWord(footerSignal, isControl: true)} 》";

            return $"{reHeader}\n{body}\n{reFooter}";
        }//ReadMorse()

        private string TransWord(string signal, bool isControl = false)
        {
            string[] wordlAry = signal.Split(
                new char[] { '／' }, StringSplitOptions.RemoveEmptyEntries);

            var bld = new StringBuilder(signal.Length);
            foreach (string word in wordlAry)
            {
                string[] charSignalAry = word.Split(
                    new char[] { '[', '|', ']' }, StringSplitOptions.RemoveEmptyEntries);
 
                foreach(string charSignal in charSignalAry)
                {
                    int index = dic.GetMorseIndex(charSignal);
                    if (index < 0)
                    {
                        int controlIndex = dic.GetControlIndex(charSignal);
                        if (controlIndex < 0)
                        {
                            bld.Append("<?>");
                        }
                        else
                        {
                            bld.Append(dic.GetControlName(controlIndex));
                        }
                    }
                    else
                    {
                        char c = dic.GetKey(index);

                        if (isControl)
                        {
                            switch (c)
                            {
                                case '+':
                                    bld.Append("end of message");
                                    break;
                                case 'K':
                                    bld.Append("over");
                                    break;
                                default:
                                    bld.Append(c);
                                    break;
                            }//switch
                        }
                        else
                        {
                            bld.Append(c);
                        }
                    }
                }//foreach charSignal

                if (isControl)
                {
                    bld.Append(" ／ ");
                }
                else
                {
                    bld.Append(" ");
                }                   
            }//foreach word

            return bld.ToString();
        }

        //==== Test Main() ====
        static void Main(string[] args)
        //public void Main(string[] args) 
        {
            string message = "This is a pen. I am a girl.";
            var here = new MorseMachine(15, message);

            Console.WriteLine($"Text: {message}");

            //---- PreConnect ----
            bool isReady = here.pre.PreConnect(here.id);
            if (!isReady)
            {
                Console.WriteLine("PreConnect() return false.");
            }

            //---- Morse Send ----
            Console.WriteLine("◆Send Morse ");
            string signal = here.BodySignal(here.message);
            Console.WriteLine(
                $"Message: {here.pre.header}{here.message}{here.pre.footer}");
            here.WriteWithBeepMorse(signal);
            Console.WriteLine();

            //---- Morse Recieved ----
            Console.WriteLine("◆Recieved Morse ");
            here.WriteWithBeepMorse(here.pre.RecievedSignal(here.id), isControl: true);

            Console.WriteLine("◆Read Morse ");
            string reText = here.ReadMorse(signal);
            Console.WriteLine($"reText: {reText}");
        }//Main() 
    }//class
}

/*
Text: This is a pen. I am a girl.

◆PreConnect()
＊pre-Request:
《 start 》 => －・－・－
《 end of message ／ ID:15 ／ over ／ close 》 => 
・－・－・／
・・|－・・|－－－・・・|・－－－－|・・・・・|／
－・－／
・・・－・－

＊pre-Response:
《 start 》 => －・－・－
《 end of message ／ ID:15 ／ over ／ close 》 => 
・－・－・／
・・|－・・|－－－・・・|・－－－－|・・・・・|／
－・－／
・・・－・－

◆Send Morse
Message: 
《 start 》THIS IS A PEN. I AM A GIRL.《 end of message ／ ID:15 ／ over ／ close 》

《 start 》 => －・－・－[
[THIS] => －|・・・・|・・|・・・|／
[IS] => |・・|・・・|／
[A] => |・－|／
[PEN.] => |・－－・|・|－・|・－・－・－|／
[I] => |・・|／
[AM] => |・－|－－|／
[A] => |・－|／
[GIRL.] => |－－・|・・|・－・|・－・・|・－・－・－|
《 end of message ／ ID:15 ／ over ／ close 》 => 
・－・－・／
・・|－・・|－－－・・・|・－－－－|・・・・・|／
－・－／
・・・－・－

◆Recieved Morse
《 start 》 => －・－・－
《 end of message ／ ID:15 ／ recieved ／ close 》 =>
・－・－・／
・・|－・・|－－－・・・|・－－－－|・・・・・|／
・－・／
・・・－・－

◆Read Morse
reText: 《 start ／  》
THIS IS A PEN. I AM A GIRL.
《 end of message ／ ID:15 ／ over ／ close ／  》
 */
