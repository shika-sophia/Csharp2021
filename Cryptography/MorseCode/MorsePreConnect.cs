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
            var bld = new StringBuilder(50);
            bld.Append(HeaderSignal(id));
            bld.Append(FooterSignal(id, "recieved"));

            return bld.ToString();//as binary
        }//RecievedSignal()

        //public bool PreConnect(int id)
        //{
        //    Console.WriteLine("◆PreConnect()");
        //    Console.WriteLine("＊pre-Request:");

        //    var bld = new StringBuilder(30);
        //    bld.Append(HeaderSignal(id));
        //    bld.Append(FooterSignal(id, "over"));
        //    WriteWithBeepMorse(bld.ToString(), isControl: true);
        //    bld.Clear();

        //    Console.WriteLine("＊pre-Response:");
        //    string response = "over";
        //    //string response = "error";
        //    bld.Append(HeaderSignal(id));
        //    bld.Append(FooterSignal(id, response));
        //    WriteWithBeepMorse(bld.ToString(), isControl: true);
        //    bld.Clear();

        //    if (response == "over")
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}//PreConnect()
    }//class
}
