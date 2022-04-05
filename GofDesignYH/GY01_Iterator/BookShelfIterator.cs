namespace CsharpBegin.GofDesignYH.GY01_Iterator
{
    internal class BookShelfIterator : AbsIteratorGY01
    {
        private BookShelfGY01 shelf;
        private int index;

        public BookShelfIterator(BookShelfGY01 shelf)
        {
            this.shelf = shelf;
            this.index = 0;
        }

        public override bool HasNext()
        {
            if(index < shelf.GetLength())
            {
                return true;
            }
            else
            {
                return false;
            }
        }//HasNext()

        public override object Next()
        {
            BookGY01 book = shelf.GetBook(index);
            index++;

            return book;
        }//Next()
    }//class
}