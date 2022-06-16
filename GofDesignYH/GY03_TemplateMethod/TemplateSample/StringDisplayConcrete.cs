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
            this.width = str.Length;
        }

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
