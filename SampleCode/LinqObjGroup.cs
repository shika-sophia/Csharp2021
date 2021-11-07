/** 
 *@title CsharpBegin / SampleCode / LinqObjGroup.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content LinqObjGroup / p509 / List 10-36 ～ 10-40
 *         
 *@subject ◆group / GroupBy() データをグループ化する
 *         戻り値 IEnumerable<IGrouping<TKey,TOut>>
 *           TKey: グループ化Key
 *           TOut: 出力オブジェクト
 *         group TOut by TKey;
 *         GroupBy(TKey , TOut);
 *           
 *         ＊ネストforeachで出力
 *         foreach(IGrouping<K,V> group in itr)
 *           string {group.Key}: グループ化Key
 *           foreach(V v in group)
 *         
 *         ◆プロパティ指定表示: 出力オブジェクトを匿名型で定義
 *         group new { } by TKey;
 *         GroupBy(TKey, new { });
 *         
 *         ◆複数Key指定: グループ化Keyを匿名型で定義
 *         group TOut by new { };
 *         GroupBy(new { }, TOut);
 *
 *@subject ◆into: [SQL] HAVING: グループ後、更に絞り込み
 *         ＊Query ONLY
 *         group TOut by TKey into [範囲変数の再定義]
 *         where [範囲定数(再)] の条件式
 *         select [範囲定数(再)]の出力形式
 *         
 *         ＊Method 「.」でグループ化の結果が渡される
 *         
 *@subject ◆into orderby グループ後、ソート
 *
 *@see LinqObjSample.cs
 *@see LinqObjOrder.cs
 *@see LingObjJoin.cs
 *@see Data / BookData.cs
 *@author shika 
 *@date 2021-11-07 
*/
using CsharpBegin.Data;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class LinqObjGroup 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var here = new LinqObjGroup();
            BookData data = new BookData();

            //---- group / GroupBy() ----
            //＊Query
            IEnumerable<IGrouping<string,Book>> bsQgroup
                = from b in data.BookItr
                  group b by b.Publisher;
            here.ShowGroup(bsQgroup, "---- group / GroupBy() ----\n＊Query");

            //＊Method
            var bsMgroup = data.BookItr
                .GroupBy(b => b.Author);
            here.ShowGroup(bsMgroup, "＊Method");

            //◆プロパティ指定表示
            //＊Query
            var bsQcolumn = from b in data.BookItr
                            group new { Title = b.Title, Price = b.Price }
                            by b.Publisher;
            here.ShowGroup(bsQcolumn, "◆プロパティ指定表示\n＊Query");

            //＊Method
            var bsMcolumn = data.BookItr
                .GroupBy(b => b.Publisher,
                    b => new
                    {
                        Title = b.Title,
                        Publisher = b.Publisher
                    }
                );
            here.ShowGroup(bsMcolumn, "＊Method");

            //◆複数Key指定
            //＊Query
            var bsQmulti = from b in data.BookItr
                           group b by new
                           {
                               Publisher = b.Publisher,
                               PublishYear = b.PublishDate.Year,
                           };
            here.ShowGroup(bsQmulti, "◆複数Key指定\n＊Query");

            //＊Method
            var bsMmulti = data.BookItr
                .GroupBy(b => new
                {
                    Publisher = b.Publisher,
                    PublishYear = b.PublishDate.Year,
                });
            here.ShowGroup(bsMmulti, "＊Method");

            //---- into ----
            //＊Query ONLY
            var bsQinto =
                from b in data.BookItr
                group b by b.Publisher into pubs
                where pubs.Average(b => b.Price) <= 4000
                select new
                {
                    Publisher = pubs.Key,
                    AvePrice = pubs.Average(b => b.Price),
                };
            here.ShowIterator(
                bsQinto, "---- into ----\n＊Query ONLY");

            //＊Method
            var bsMinto = data.BookItr
                .GroupBy(b => b.Publisher)
                .Where(pubs => pubs.Average(b => b.Price) <= 4000)
                .Select(pubs => new
                {
                    Publisher = pubs.Key,
                    AvePrice = pubs.Average(b => b.Price),
                });
            here.ShowIterator(bsMinto, "＊Method");

            //◆into orderby
            //＊Query ONLY
            var bsQintoOrder =
                from b in data.BookItr
                group b by new
                {
                    PublishYear = b.PublishDate.Year,
                    Price = b.Price,
                } into pubs
                orderby pubs.Key.ToString()
                select pubs;
            here.ShowGroup(
                bsQintoOrder, "◆into orderby\n＊Query ONLY");

            //＊Method
            var bsMintoOrder = data.BookItr
                .GroupBy(b => new
                {
                    PublishYear = b.PublishDate.Year,
                    Price = b.Price,
                })
                .OrderBy(pubs => pubs.Key.ToString());
            here.ShowGroup(bsMintoOrder, "＊Method");
        }//Main() 

        private void ShowIterator<T>(IEnumerable<T> itr, string name)
        {
            Console.WriteLine(name);
            foreach(T value in itr)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
        }//ShowIerator<T>()

        private void ShowGroup<K,V>(IEnumerable<IGrouping<K,V>> groupItr, string name)
        {
            Console.WriteLine(name);
            foreach (IGrouping<K,V> group in groupItr)
            {
                Console.WriteLine($"Group Key:[{group.Key}]");
                foreach(V v in group)
                {
                    Console.WriteLine(v);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }//ShowGroup<K,V>()
    }//class 
}

/*
---- group / GroupBy() ----
＊Query
Group Key:[翔泳社]
山田祥寛『独習 PHP』翔泳社, 2016
Price: 3200円
山田祥寛『独習 ASP.NET』翔泳社, 2016
Price: 3200円

Group Key:[技術評論社]
山田祥寛『Angularアプリプログラミング』技術評論社, 2017
Price: 3200円
山田祥寛『C#ポケットレファレンス』技術評論社, 2016
Price: 1640円

Group Key:[SB Create]
結城 浩『デザインパターン入門 マルチスレッド編』SB Create, 2006
Price: 4700円

＊Method
Group Key:[山田祥寛]
山田祥寛『独習 PHP』翔泳社, 2016
Price: 3200円
山田祥寛『独習 ASP.NET』翔泳社, 2016
Price: 3200円
山田祥寛『Angularアプリプログラミング』技術評論社, 2017
Price: 3200円
山田祥寛『C#ポケットレファレンス』技術評論社, 2016
Price: 1640円

Group Key:[結城 浩]
結城 浩『デザインパターン入門 マルチスレッド編』SB Create, 2006
Price: 4700円

◆プロパティ指定表示
＊Query
Group Key:[翔泳社]
{ Title = 独習 PHP, Price = 3200 }
{ Title = 独習 ASP.NET, Price = 3200 }

Group Key:[技術評論社]
{ Title = Angularアプリプログラミング, Price = 3200 }
{ Title = C#ポケットレファレンス, Price = 1640 }

Group Key:[SB Create]
{ Title = デザインパターン入門 マルチスレッド編, Price = 4700 }

＊Method
Group Key:[翔泳社]
{ Title = 独習 PHP, Publisher = 翔泳社 }
{ Title = 独習 ASP.NET, Publisher = 翔泳社 }

Group Key:[技術評論社]
{ Title = Angularアプリプログラミング, Publisher = 技術評論社 }
{ Title = C#ポケットレファレンス, Publisher = 技術評論社 }

Group Key:[SB Create]
{ Title = デザインパターン入門 マルチスレッド編, Publisher = SB Create }


◆複数Key指定
＊Query
Group Key:[{ Publisher = 翔泳社, PublishYear = 2016 }]
山田祥寛『独習 PHP』翔泳社, 2016
Price: 3200円
山田祥寛『独習 ASP.NET』翔泳社, 2016
Price: 3200円

Group Key:[{ Publisher = 技術評論社, PublishYear = 2017 }]
山田祥寛『Angularアプリプログラミング』技術評論社, 2017
Price: 3200円

Group Key:[{ Publisher = 技術評論社, PublishYear = 2016 }]
山田祥寛『C#ポケットレファレンス』技術評論社, 2016
Price: 1640円

Group Key:[{ Publisher = SB Create, PublishYear = 2006 }]
結城 浩『デザインパターン入門 マルチスレッド編』SB Create, 2006
Price: 4700円


＊Method
Group Key:[{ Publisher = 翔泳社, PublishYear = 2016 }]
山田祥寛『独習 PHP』翔泳社, 2016
Price: 3200円
山田祥寛『独習 ASP.NET』翔泳社, 2016
Price: 3200円

Group Key:[{ Publisher = 技術評論社, PublishYear = 2017 }]
山田祥寛『Angularアプリプログラミング』技術評論社, 2017
Price: 3200円

Group Key:[{ Publisher = 技術評論社, PublishYear = 2016 }]
山田祥寛『C#ポケットレファレンス』技術評論社, 2016
Price: 1640円

Group Key:[{ Publisher = SB Create, PublishYear = 2006 }]
結城 浩『デザインパターン入門 マルチスレッド編』SB Create, 2006
Price: 4700円

---- into ----
＊Query ONLY
{ Publisher = 翔泳社, AvePrice = 3200 }
{ Publisher = 技術評論社, AvePrice = 2420 }

＊Method
{ Publisher = 翔泳社, AvePrice = 3200 }
{ Publisher = 技術評論社, AvePrice = 2420 }

◆into orderby
＊Query ONLY
Group Key:[{ PublishYear = 2006, Price = 4700 }]
結城 浩『デザインパターン入門 マルチスレッド編』SB Create, 2006
Price: 4700円

Group Key:[{ PublishYear = 2016, Price = 1640 }]
山田祥寛『C#ポケットレファレンス』技術評論社, 2016
Price: 1640円

Group Key:[{ PublishYear = 2016, Price = 3200 }]
山田祥寛『独習 PHP』翔泳社, 2016
Price: 3200円
山田祥寛『独習 ASP.NET』翔泳社, 2016
Price: 3200円

Group Key:[{ PublishYear = 2017, Price = 3200 }]
山田祥寛『Angularアプリプログラミング』技術評論社, 2017
Price: 3200円


＊Method
Group Key:[{ PublishYear = 2006, Price = 4700 }]
結城 浩『デザインパターン入門 マルチスレッド編』SB Create, 2006
Price: 4700円

Group Key:[{ PublishYear = 2016, Price = 1640 }]
山田祥寛『C#ポケットレファレンス』技術評論社, 2016
Price: 1640円

Group Key:[{ PublishYear = 2016, Price = 3200 }]
山田祥寛『独習 PHP』翔泳社, 2016
Price: 3200円
山田祥寛『独習 ASP.NET』翔泳社, 2016
Price: 3200円

Group Key:[{ PublishYear = 2017, Price = 3200 }]
山田祥寛『Angularアプリプログラミング』技術評論社, 2017
Price: 3200円

 */
