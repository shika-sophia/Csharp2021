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
        private readonly MorsePreConnect pre;
        private string[] wordAry;
        private char[] charAry;

        internal MorseSend(MorsePreConnect pre)
        {
            this.pre = pre;
        }

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

        internal void BeepWriteControl(string message, string signal)
        {
            BuildArray(message, signal);
            var bld = new StringBuilder(message.Length * 10);
            bld.Append("《");
            BeepWrite(ref bld);            
            bld.Append("》");

            Console.WriteLine(bld.ToString());
            Console.WriteLine();
        }//BeepWriteControl()

        internal void BeepWriteBody(string message, string signal)
        {
            BuildArray(message, signal);
            BeepWrite();
        }

        internal void BeepWrite(ref StringBuilder bld)
        {
            int wordCount = 0;
            bool wordInit = true;

            foreach (char c in charAry)
            {
                if (wordInit)
                {
                    bld.Append($"[{wordAry[wordCount]}] => ");
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
