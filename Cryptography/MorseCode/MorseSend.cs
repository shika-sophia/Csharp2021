using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.Cryptography.MorseCode
{
    class MorseSend
    {
        private string[] wordAry;
        private char[] charAry;

        private void BuildArray(string message, string signal)
        {
            //---- string message -> string[] wordAry ----
            if(message.Contains(" "))
            {
                wordAry = message.Split(
                    new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                wordAry = new string[] { message };
            }

            //---- string signal -> char[] charAry ----
            charAry = signal.ToCharArray();
        }//BuildArray()

        internal void BeepWriteControl(string text, string signal)
        {
            Console.WriteLine($"{text} => ");
            text = text.Replace("《", "").Replace("》", "").Replace("／", "");
            BuildArray(text, signal);
            
            BeepWrite();            
            Console.WriteLine("\n");
        }//BeepWriteControl()

        internal void BeepWriteBody(string message, string signal)
        {
            Console.WriteLine($"Body: {message}");
            BuildArray(message, signal);           
            BeepWrite();
            Console.WriteLine("\n");
        }

        private void BeepWrite()
        {
            int wordCount = 0;
            bool wordInit = true;

            foreach (char c in charAry)
            {
                if (wordInit)
                {
                    Console.Write($"[{wordAry[wordCount]}] => ");
                    wordInit = false;
                    wordCount++;
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
                        wordInit = true;                   
                        break;

                    default:
                        Console.WriteLine("<?>");
                        break;
                }//switch               
            }//foreach
 
        }//BeepWrite()

    }//class
}
