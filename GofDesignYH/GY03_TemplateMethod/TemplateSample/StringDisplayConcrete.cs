using System;
using System.Globalization;
using System.Text;

namespace CsharpBegin.GofDesignYH.GY03_TemplateMethod.TemplateSample
{
    class StringDisplayConcrete : AbsDisplayTemplate
    {
        private string str;
        private int width;
        
        public StringDisplayConcrete(string str)
        {
            this.str = str;
            this.width = BuildWidth(str);
        }

        private int BuildWidth(string str)
        {
            int width = 0;
            char[] charAry = str.ToCharArray();
            
            foreach (char c in charAry)
            {
                if ((int) c > '\u007E') //width: 半角'~'以上は 2文字
                {
                    width += 2;
                }
                else
                {
                    width += 1;
                }
            }//foreach

            return width;
        }//BuildWidth()

        public override void Open()
        {
            ShowLine();
        }

        public override void Show()
        {
            Console.WriteLine($"| {str} |");
        }

        public override void Close()
        {
            ShowLine();
        }

        private void ShowLine()
        {
            var bld = new StringBuilder(width + 4);
            bld.Append("+-");

            for (int i = 0; i < width; i++)
            {
                bld.Append("-");
            }//for

            bld.Append("-+");

            Console.WriteLine(bld.ToString());
        }//ShowLine()
    }//class
}
