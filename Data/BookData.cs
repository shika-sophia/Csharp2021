/** 
 *@title CsharpBegin / Data / BookData.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content BookData / p495 / List 10-19
 *         LINQ to Objects用のサンプルデータ
 * 
 *@author shika 
 *@date 2021-11-04 
*/ 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.Data 
{ 
    public class BookData 
    { 
        public IEnumerable<Book> BookEnum { get; private set; }
        public IEnumerable<Review> ReviewEnum { get; private set; }

        public BookData()
        {
            this.BookEnum = new List<Book>
            {
                new Book
                {
                    Isbn = "978-4-7981-3547-2",
                    Title = "独習 PHP",
                    Author = "山田祥寛",
                    Price = 3200,
                    Publisher = "翔泳社",
                    PublishDate = new DateTime(2016, 4, 8)
                },
                new Book
                {
                    Isbn = "978-4-7981-4402-3",
                    Title = "独習 ASP.NET",
                    Author = "山田祥寛",
                    Price = 3200,
                    Publisher = "翔泳社",
                    PublishDate = new DateTime(2016, 1, 21)
                },
                new Book
                {
                    Isbn = "978-4-7741-9130-0",
                    Title = "Angularアプリプログラミング",
                    Author = "山田祥寛",
                    Price = 3200,
                    Publisher = "技術評論社",
                    PublishDate = new DateTime(2017, 8, 4)
                },
                new Book
                {
                    Isbn = "978-4-7741-9030-3",
                    Title = "C#ポケットレファレンス",
                    Author = "山田祥寛",
                    Price = 1640,
                    Publisher = "技術評論社",
                    PublishDate = new DateTime(2016, 6, 20)
                },
                new Book
                {
                    Isbn = "978-4-7973-3162-3",
                    Title = "デザインパターン入門 マルチスレッド編",
                    Author = "結城 浩",
                    Price = 4700,
                    Publisher = "SB Create",
                    PublishDate = new DateTime(2006, 3, 31)
                },
            };//List<Book>

            this.ReviewEnum = new List<Review>
            {
                new Review
                {
                    Isbn = "978-4-7981-3547-2",
                    Name = "山田太郎",
                    Body = "PHPの言語仕様を学習できます。"
                },
                new Review
                {
                    Isbn = "978-4-7981-4402-3",
                    Name = "鈴木花子",
                    Body = ".NET環境のWebフォームの作り方"
                },
                new Review
                {
                    Isbn = "978-4-7741-9130-0",
                    Name = "山田太郎",
                    Body = "データ操作の教科書です。"
                },
                new Review
                {
                    Isbn = "978-4-7741-9030-3",
                    Name = "佐藤久美",
                    Body = "C#のAPIレファレンス"
                },
                new Review
                {
                    Isbn = "978-4-7973-3162-3",
                    Name = "加藤次郎",
                    Body = "マルチスレッドのことを理解できます。"
                },
            };//List<Review>
        }//constructor

        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var here = new BookData();
            foreach(Book book in here.BookEnum)
            {
                Console.WriteLine(book);
                Review review = null;
                foreach (Review rev in here.ReviewEnum)
                {
                    if (rev.Isbn == book.Isbn)
                    {
                        review = rev;
                        break;
                    }
                }//foreach Review

                if (review == null)
                {
                    review = new Review
                    {
                        Isbn = "",
                        Name = "",
                        Body = "(Reveiw なし)"
                    };
                }

                Console.WriteLine(review);
            }//foreach Book
        }//Main() 
    }//class 

    public class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }

        public override string ToString()
        {
            return $"{Author}『{Title}』{Publisher}, {PublishDate.Year}\n"
                 + $"Price: {Price}円";
        }
    }//class

    public class Review
    {
        public string Isbn { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }

        public override string ToString()
        {
            return $"Reviewer: {Name}\nReview: {Body}";
        }
    }//class 
}

/*
山田祥寛『独習 PHP』翔泳社, 2016
Price: 3200円
Reviewer: 山田太郎
Review: PHPの言語仕様を学習できます。

山田祥寛『独習 ASP.NET』翔泳社, 2016
Price: 3200円
Reviewer: 鈴木花子
Review: .NET環境のWebフォームの作り方

山田祥寛『Angularアプリプログラミング』技術評論社, 2017
Price: 3200円
Reviewer: 山田太郎
Review: データ操作の教科書です。

山田祥寛『C#ポケットレファレンス』技術評論社, 2016
Price: 1640円
Reviewer: 佐藤久美
Review: C#のAPIレファレンス

結城 浩『デザインパターン入門 マルチスレッド編』SB Create, 2006
Price: 4700円
Reviewer: 加藤次郎
Review: マルチスレッドのことを理解できます。
 
 */