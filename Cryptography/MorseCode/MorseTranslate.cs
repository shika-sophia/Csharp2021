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

        internal string TransWord(string signal, bool isControl = false)
        {
            string[] wordlAry = signal.Split(
                new char[] { '／' }, StringSplitOptions.RemoveEmptyEntries);

            var bld = new StringBuilder(signal.Length);
            foreach (string word in wordlAry)
            {
                string[] charSignalAry = word.Split(
                    new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

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
