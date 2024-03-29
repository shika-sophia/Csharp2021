﻿/** 
 *@title CsharpBegin / Cryptography / MorseCode / MorseMachineArchive.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩 『暗号技術入門 第３版』SB Creative, 2015 
 *@content Morse Machine Archive
 *         - Old Version -
 *         
 *@see MorseMachine.cs //as New Version
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
    class MorseMachineArchive
    {
        private readonly MorseDictionary dic
            = new MorseDictionary();
        private string message;
        private int id;
        private string header;
        private string footer;

        public MorseMachineArchive(int id, string message)
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
            startSignal = startSignal.Replace("1", "－");

            return $"{startSignal}";
        }//StartSignal()

        public string EndSignal(int id, string mesType = "over")
        {
            footer = $"《 end of message ／ ID:{id} ／ {mesType} ／ close 》";
            var bld = new StringBuilder(100);
            bld.Append("]");
            bld.Append(dic.GetControlSignal("messageend"));
            bld.Append("／");

            char[] idAry = $"ID:{id}".ToCharArray();
            foreach (char idBit in idAry)
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
            bld.Replace("1", "－");

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
            bld.Append(EndSignal(id, "recieved"));
            bld.Replace('0', '・');
            bld.Replace('1', 'ー');
            bld.Replace('1', '－');

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
            signal = signal.Replace("1", "－");

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
                if (wordCount == 0 && isHeader)
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
                        Console.Beep(800, 100);
                        Thread.Sleep(80);
                        break;
                    case 'ー':
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


        public string ReadMorse(string signal)
        {
            signal = signal.Replace("・", "0");
            signal = signal.Replace("ー", "1");
            signal = signal.Replace("－", "1");
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

                foreach (string charSignal in charSignalAry)
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
        }//TransWord()

        //==== Test Main() ====
        //static void Main(string[] args)
        public void Main(string[] args) 
        {
            string message = "This is a pen. I am a girl.";
            var here = new MorseMachineArchive(15, message);

            Console.WriteLine($"Text: {message}");

            //---- PreConnect ----
            bool isReady = here.PreConnect(here.id);
            if (!isReady)
            {
                Console.WriteLine("PreConnect() return false.");
            }

            //---- Morse Send ----
            Console.WriteLine("◆Send Morse ");
            string signal = here.SendMorse(here.message);
            Console.WriteLine(
                $"Message: {here.header}{here.message}{here.footer}");
            here.WriteWithBeepMorse(signal);
            Console.WriteLine();

            //---- Morse Recieved ----
            Console.WriteLine("◆Recieved Morse ");
            here.WriteWithBeepMorse(here.RecievedSignal(here.id), isControl: true);

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