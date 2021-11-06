/** 
 *@title CsharpBegin / SampleCode / LinqObjOrder.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content LinqObjOrder / p505 / List 10-29 ～ List 10-35
 *@subject ◆orderby / OrderBy() データを並べ替える
 *         ＊Query
 *          IOrderedEnumerable<T> orderby [第１Key:プロパティ名] [並べ順]
 *                                       ,[第２key:プロパティ名] [並べ順] ...
 *          並べ順: ascending 昇順 (既定) / descending 降順
 *  
 *          ＊Method
 *          IOrderedEnumerable<T> IEnumarable.OrederBy(Func<T,TKey>)
 *          IOrderedEnumerable<T> IEnumarable.OrederByDescending(Func<T,TKey>)
 *          IOrderedEnumerable<T> IEnumarable.ThenBy(Func<T,TKey>)
 *          IOrderedEnumerable<T> IEnumarable.ThenByDescending(Func<T,TKey>)
 *  
 *@subject ◆select new { } / Select( new { } ) 特定のプロパティのみ抽出
 *         => { Property1 = value1, Property2 = value2, ... } の形式で出力
 *         
 *@subject ◆Distinct() 重複要素を除去
 *         ＊Method ONLY
 *         ＊Query構文が存在しない場合の記法
 *         (クエリ構文).メソッド構文;
 *         var para = (from inPara in dataSource select inPara).Distinct();
 *
 *@subject ◆Skip(int count) / Take(int count) m ～ n番目の要素を取得
 *         ＊Method ONLY
 *
 *@subject ◆First() 最初の要素のみ取得
 *         ＊Method ONLY
 *         T IEnumerable.First()
 *         T IEnumerable.FirstOrDefault()
 *         T IEnumerable.Last()
 *         T IEnumerable.LastOrDefault()
 *         
 *          【考察】First(), Last()の戻り値が存在しないと
 *           InvalidOperationException
 *           
 *          【考察】T IEnumable.First()
 *           OrderBy()の ソートKeyが プロパティでも、
 *           First()の戻り値は Bookオブジェクトなので、
 *           出力はオブジェクトのToString() となる。
 *           
 *@see LinqObjSample.cs
 *@see LinqObjGroup.cs
 *@see Data / BookData.cs
 *@author shika 
 *@date 2021-11-06 
*/
using CsharpBegin.Data;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class LinqObjOrder 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var here = new LinqObjOrder();
            BookData data = new BookData();

            //---- orderby / OrderBy() ----
            //＊Query
            IEnumerable<Book> bsQord = from b in data.BookItr
                                   orderby b.Price descending, b.PublishDate
                                   select b;
            here.ShowIterator(bsQord, "---- orderby / OrderBy ----\n＊Query");

            //＊Method
            IEnumerable<Book> bsMord = data.BookItr
                .OrderByDescending(b => b.Price)
                .ThenBy(b => b.PublishDate)
                .Select(b => b);
            here.ShowIterator(bsMord, "＊Method");

            //---- select new { } / Select( new { } ) ----
            //＊Query
            var bsQnew = from b in data.BookItr
                         select new
                         {
                             ShortTitle = b.Title.Substring(0, 5),
                             PriceTaxed = b.Price * 1.08,
                             Released = (b.PublishDate <= DateTime.Now ? "発売中" : "発売予定")
                         };
            here.ShowIterator(bsQnew,
                "//---- select new { } / Select( new { } ) ----\n＊Query");

            //＊Method
            var bsMnew = data.BookItr
                .Select(b => new
                {
                    ShortTitle = b.Title.Substring(0, 5),
                    PriceTaxed = (int) Math.Round(b.Price * 1.08),
                    Released = (b.PublishDate <= DateTime.Now ? "発売中" : "発売予定")
                });
            here.ShowIterator(bsMnew, "＊Method");

            //---- Distinct() ----
            //＊Method ONLY
            var bsMdistinct = data.BookItr
                .Select(b => b.Publisher)
                .Distinct();
            here.ShowIterator(bsMdistinct, "---- Distinct() ----\n＊Distinct()");

            var bsMselect = data.BookItr
                .Select(b => b.Publisher);
            here.ShowIterator(bsMselect, "＊Select()のみ");

            //＊Query構文が存在しない場合
            var bsQtoM = (from b in data.BookItr select b.Publisher).Distinct();
            here.ShowIterator(bsQtoM, "＊Query構文が存在しない場合");

            //---- Skip(int count) / Take(int count) ----
            //＊Method ONLY
            var bsMskip = data.BookItr
                .Skip(3)
                .Take(5)
                .Select(b => b.Title);
            here.ShowIterator(bsMskip, "---- Skip(int count) / Take(int count) ----");

            //---- First() ----
            //＊Method ONLY
            Book first = data.BookItr
                .OrderBy(b => b.Price)
                .First();
            Console.WriteLine($"---- First() ----\n{first}");

            Book firstDef = data.BookItr
                .Where(b => b.Price > 10000)
                .OrderBy(b => b.Price)
                //.First();
                //System.InvalidOperationException: シーケンスに要素が含まれていません
                .FirstOrDefault();
            Console.WriteLine($"＊FirstOrDefault()\n" +
                $"{(firstDef == null ? "(なし)" : firstDef.ToString())}");
        }//Main() 

        private void ShowIterator<T>(IEnumerable<T> itr, string name)
        {
            Console.WriteLine($"{name}: ");
            foreach(T value in itr)
            {
                if (value.ToString().Length <= 10)
                {
                    Console.Write($"{value}, ");
                }
                else
                {
                    Console.WriteLine($"{value}");
                }
            }//foreach
            Console.WriteLine();
        }//ShowIterator<T>
    }//class 
}

/*
---- orderby / OrderBy ----
＊Query:
結城 浩『デザインパターン入門 マルチスレッド編』SB Create, 2006
Price: 4700円
山田祥寛『独習 ASP.NET』翔泳社, 2016
Price: 3200円
山田祥寛『独習 PHP』翔泳社, 2016
Price: 3200円
山田祥寛『Angularアプリプログラミング』技術評論社, 2017
Price: 3200円
山田祥寛『C#ポケットレファレンス』技術評論社, 2016
Price: 1640円

＊Method:
結城 浩『デザインパターン入門 マルチスレッド編』SB Create, 2006
Price: 4700円
山田祥寛『独習 ASP.NET』翔泳社, 2016
Price: 3200円
山田祥寛『独習 PHP』翔泳社, 2016
Price: 3200円
山田祥寛『Angularアプリプログラミング』技術評論社, 2017
Price: 3200円
山田祥寛『C#ポケットレファレンス』技術評論社, 2016
Price: 1640円

＊Array Test:
1, 2, 3,

//---- select new { } / Select( new { } ) ----
＊Query:
{ ShortTitle = 独習 PH, PriceTaxed = 3456, Released = 発売中 }
{ ShortTitle = 独習 AS, PriceTaxed = 3456, Released = 発売中 }
{ ShortTitle = Angul, PriceTaxed = 3456, Released = 発売中 }
{ ShortTitle = C#ポケッ, PriceTaxed = 1771.2, Released = 発売中 }
{ ShortTitle = デザインパ, PriceTaxed = 5076, Released = 発売中 }

＊Method:
{ ShortTitle = 独習 PH, PriceTaxed = 3456, Released = 発売中 }
{ ShortTitle = 独習 AS, PriceTaxed = 3456, Released = 発売中 }
{ ShortTitle = Angul, PriceTaxed = 3456, Released = 発売中 }
{ ShortTitle = C#ポケッ, PriceTaxed = 1771, Released = 発売中 }
{ ShortTitle = デザインパ, PriceTaxed = 5076, Released = 発売中 }

---- Distinct() ----
＊Distinct():
翔泳社, 技術評論社, SB Create,

＊Select()のみ:
翔泳社, 翔泳社, 技術評論社, 技術評論社, SB Create,

＊Query構文が存在しない場合:
翔泳社, 技術評論社, SB Create,

---- Skip(int count) / Take(int count) ----:
C#ポケットレファレンス
デザインパターン入門 マルチスレッド編

---- First() ----
山田祥寛『C#ポケットレファレンス』技術評論社, 2016
Price: 1640円

【考察】T IEnumable.First()
OrderBy()の ソートKeyが プロパティでも、
First()の戻り値は Bookオブジェクトなので、
出力はオブジェクトのToString() となる。

＊FirstOrDefault()
(なし)

*/