using CsharpBegin.GofDesignYH.GY02_Adapter.AdapterInherit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.GofDesignYH.GY02_Adapter.AdapterAggregate
{
    class PrintBannerAggregate : AbsPrintGY02
    {
        private readonly BannerGY02 banner;

        public PrintBannerAggregate(string text)
        {
            this.banner = new BannerGY02(text);
        }

        public override void PrintStrong()
        {
            banner.ShowAster();
        }

        public override void PrintWeak()
        {
            banner.ShowParen();
        }
    }//class
}
