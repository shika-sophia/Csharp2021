using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.Cryptography.MorseCode
{
    class MorsePreConnect
    {
        private readonly MorseDictionary dic;
        internal string header;
        internal string footer;

        internal MorsePreConnect(MorseDictionary dic)
        {
            this.dic = dic;
        }

        public string HeaderSignal(int id)
        {
            header = $"《 start ／ ID:{id} 》";

            var bld = new StringBuilder(30);
            bld.Append(dic.GetControlSignal("start"));
            bld.Append("／");
            bld.Append(dic.GetValue($"ID:{id}"));

            return bld.ToString();//as binary
        }//HeaderSignal()

        public string FooterSignal(int id, string mesType = "over")
        {
            footer = $"《 end ／ ID:{id} ／ {mesType} 》";

            var bld = new StringBuilder(100);
            bld.Append(dic.GetControlSignal("messageend"));
            bld.Append("／");
            bld.Append(dic.GetValue($"ID:{id}"));
            bld.Append("／");
            bld.Append(dic.GetControlSignal(mesType));

            return bld.ToString();//as binary
        }//FooterSignal()

        public string RecievedSignal(int id)
        {
            return FooterSignal(id, "recieved");//as binary
        }//RecievedSignal()
    }//class
}
