namespace CsharpBegin.GofDesignYH.GY03_TemplateMethod.TemplateSample
{
    public abstract class AbsDisplayTemplate
    {
        private const int LIMIT = 5;
        
        public abstract void Open();
        public abstract void Show();
        public abstract void Close();

        public void Display()
        {
            Open();

            for(int i = 0; i < LIMIT; i++)
            {
                Show();
            }//for

            Close();
        }//Display()
    }//class
}
