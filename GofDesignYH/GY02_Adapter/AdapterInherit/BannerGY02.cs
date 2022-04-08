using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.GofDesignYH.GY02_Adapter.AdapterInherit
{
    class BannerGY02
    {
        private string text;

        public BannerGY02(string text)
        {
            this.text = text;
        }

        public void ShowAster()
        {
            Console.WriteLine($"*{text}*");
        }

        public void ShowParen()
        {
            Console.WriteLine($"({text})");
        }
    }//class
}
