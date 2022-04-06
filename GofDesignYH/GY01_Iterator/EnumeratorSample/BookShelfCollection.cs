using CsharpBegin.GofDesignYH.GY01_Iterator.IteratorSample;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CsharpBegin.GofDesignYH.GY01_Iterator.EnumeratorSample
{
    internal class BookShelfCollection
    {
        private List<string> titleList;
        private List<BookGY01> bookList;

        public BookShelfCollection(string[] titleAry)
        {
            BuildTitleList(titleAry);
            BuildBookList(titleList);
        }//constructor

        private void BuildTitleList(string[] titleAry)
        {
            this.titleList = titleAry.Select(title => title)
                             .Distinct()
                             .ToList();
        }

        private void BuildBookList(List<string> titleList)
        {
            this.bookList = new List<BookGY01>();
            foreach(string title in titleList)
            {
                bookList.Add(new BookGY01(title));
            }
        }//BuildBookList()

        public void AppendBook(string title)
        {
            //titleListに titleが含まれていないときのみListに登録
            if (!titleList.Contains(title))
            {
                titleList.Add(title);
                bookList.Add(new BookGY01(title));
            }
        }//AppendBook()
      
        public void AppendBookList(string[] titleAry)
        {
            foreach(string title in titleAry)
            {
                AppendBook(title);
            }//foreach
        }//AppendBookList()

        public BookGY01 GetBook(int index)
        {
            return bookList.ElementAt(index);
        }//GetBook()

        public int GetLength()
        {
            return bookList.Count;
        }//GetLength()

        public List<string> GetTitleList()
        {
            return titleList;
        }

        public List<BookGY01> GetBookList()
        {
            return bookList;
        }
    }//class
}