using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Cryptography.MorseCode
{
    class MorseTranslate
    {
        private readonly MorseDictionary dic;

        public MorseTranslate(MorseDictionary dic)
        {
            this.dic = dic;
        }

        public string ReadMorse(string signal)
        {
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
        }
    }//class
}
