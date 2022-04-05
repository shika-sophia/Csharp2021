using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.GofDesignYH.GY01_Iterator
{
    class BookShelfGY01 : AbsAggregateGY01
    {
        private BookGY01[] bookAry;
        private int last = 0;

        public BookShelfGY01(int max)
        {
            this.bookAry = new BookGY01[max];
        }

        public override AbsIteratorGY01 Iterator()
        {
            return new BookShelfIterator(this);
        }//Iterator()

        public void AppendBook(BookGY01 book)
        {
            bookAry[last] = book;
            last++;
        }//AppendBook()

        public BookGY01 GetBook(int index)
        {
            if(index < 0 || bookAry.Length <= index)
            {
                Console.WriteLine("<!> Invalid index");
                return null;
            }

            return bookAry[index];
        }//GetBook()
      
        public int GetLength()
        {
            return last;
        }//GetLength()
    }//class
}
