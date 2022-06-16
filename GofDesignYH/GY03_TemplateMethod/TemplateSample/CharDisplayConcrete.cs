using System;

namespace CsharpBegin.GofDesignYH.GY03_TemplateMethod.TemplateSample
{
    class CharDisplayConcrete : AbsDisplayTemplate
    {
        private char c;

        public CharDisplayConcrete(char c)
        {
            this.c = c;
        }
        
        public override void Open()
        {
            Console.Write("<< ");
        }

        public override void Show()
        {
            Console.Write(c);
        }

        public override void Close()
        {
            Console.Write(" >> \n");
        }
    }//class
}
