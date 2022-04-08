using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.GofDesignYH.GY02_Adapter.AdapterInherit
{
    class PrintBannerGY02 : BannerGY02, IPrintGY02
    {
        public PrintBannerGY02(string text) : base(text) { }

        public void PrintStrong()
        {
            base.ShowAster();
        }

        public void PrintWeak()
        {
            base.ShowParen();
        }
    }//class
}
