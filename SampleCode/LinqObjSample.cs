/** 
 *@title CsharpBegin / SampleCode / LinqObjSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content LINQ to Objects / p496 / List 10-20 ～ 10-28
 *         [Java] Stream<T>というより、
 *         [SQL]の感覚で Listなどのデータソースを加工する手法
 *
 *@subject Query構文とMethod構文
 *@subject 遅延実行 / Delay Execute
 *         Array IEnumerable<T>.ToArray() //データソースの確定
 *         IEnumerable<T>は、配列、Listとも実装しているインターフェイス
 *         なので両方とも収納可
 *@subject ---- where / Where(Predicate<T>) ----
           ◆部分検索 / Partial Search: [SQL] LIKE演算子 
 *         ◆候補値検索 / Target Value Search
 *         ◆範囲検索 / Range Search
 *         ◆複数条件検索 / Mulitiple Condition Search
 *         ◆単一要素 / Single Element Search
 *         ＊Method ONLY
 *             T IEnumerable<T>.Single(Predicate<T>) 
 *             T IEnumerable<T>.SingleOrDefault(Predicate<T>)
 *             戻り値 Tなので IEnumerable<T>.Select()不可。
 *             出力も Iteratorではなく Console.WriteLine()で出力。
 *             
 *@see LinqObjOrder.cs
 *@see LinqObjGroup.cs
 *@see Data / BookData.cs
 *@author shika 
 *@date 2021-11-05 
*/
using CsharpBegin.Data;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class LinqObjSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var here = new LinqObjSample();
            BookData data = new BookData();

            //----LINQ Query----
            IEnumerable<string> bsQ =
                from b in data.BookItr
                where b.Price < 2000
                select b.Title;
            here.ShowIterator(bsQ, "LINQ Query");

            //---- LINQ Method ----
            IEnumerable<string> bsM =
                data.BookItr
                .Where(b => b.Price > 4000)
                //.Select(b => b);
                .Select(b => b.Title);
            here.ShowIterator(bsM, "LINQ Method");

            //---- LINQ Delay / 遅延実行 ----
            //var bsDelay = from b in data.BookItr select b.Title;

            //ToArray()で確定
            var bsDelay =
                (from b in data.BookItr select b.Title).ToArray();
            here.ShowIterator(bsDelay, "LINQ Original");

            //0番目のタイトルを事前に保存
            string temp0 = data.BookItr.ElementAt(0).Title;

            //0番目のタイトルを変更
            data.BookItr.ElementAt(0).Title = "独習 PHP 第6版";
            here.ShowIterator(bsDelay, "LINQ Delay");

            //事前に保存したものを元に戻す
            data.BookItr.ElementAt(0).Title = temp0;

            //---- where / Where() ----
            //◆部分検索 / Partial Search: [SQL] LIKE演算子 
            //＊Query
            var bsQsub = from b in data.BookItr
                         where b.Title.Contains("独習")
                         select b.Title;
            here.ShowIterator(bsQsub, "部分検索 Query");

            //＊Method
            var bsMsub = data.BookItr
                .Where(b => b.Title.Contains("独習"))
                .Select(b => b.Title);
            here.ShowIterator(bsQsub, "部分検索 Method");

            //◆候補値検索 / Target Value Search
            int[] targetAry = new[] { 3, 8 };
            here.ShowIterator(targetAry, "targetAry");

            //＊Query
            var bsQmon =
                from b in data.BookItr
                where targetAry.Contains(b.PublishDate.Month)
                select b;
            here.ShowIterator(bsQmon, "候補値検索 Query");

            //＊Method
            var bsMmon = data.BookItr
                .Where( b => targetAry.Contains(b.PublishDate.Month))
                .Select(b => b);
            here.ShowIterator(bsMmon, "候補値検索 Method");

            //◆範囲検索 / Range Search
            //＊Query
            var bsQrng = from b in data.BookItr
                         where (1500 < b.Price && b.Price < 2000)
                         select (b.Title, b.Price);
            here.ShowIterator(bsQrng, "◆範囲検索＊Query");

            //＊Method
            var bsMrng = data.BookItr
                .Where(b => (1500 < b.Price && b.Price < 2000))
                .Select(b => $"Title: {b.Title}, Price: {b.Price}");
            here.ShowIterator(bsMrng, "＊Method");

            //◆複数条件検索 / Mulitiple Condition Search
            //＊Query 略
            //＊Method 
            var bsMmulti = data.BookItr
                .Where(b => (1500 < b.Price && b.Price < 4000))
                .Where(b => b.Publisher == "技術評論社")
                .Select(b => $"Title: {b.Title}\nPublisher: {b.Publisher}\nPrice: {b.Price}");
            here.ShowIterator(bsMmulti, "◆複数条件検索");

            //◆単一要素 / Single Element Search
            //＊Method ONLY
            Book single = data.BookItr
                .SingleOrDefault(b => b.Isbn == "978-4-7973-3162-3");
            //  .Select(b => b.Title);  //戻り値Bookなので不可
            //ShowIterator(single, ""); //Bookオブジェクトなので不可
            Console.WriteLine($"Title: {single.Title}\nISBN: {single.Isbn}");
        }//Main() 

        private void ShowIterator<T>(IEnumerable<T> itr, string name)
        {
            Console.WriteLine($"{name}: ");
            foreach(T value in itr)
            {
                Console.WriteLine($"{value}");
            }
            Console.WriteLine();
        }//ShowEnum<T>
    }//class 
}

/*
//---- LINQ Query ----
LINQ Query: C#ポケットレファレンス,

//---- LINQ Method ----
＊Select(b => b)
LINQ Method: 結城 浩『デザインパターン入門 マルチ スレッド編』SB Create, 2006
Price: 4700円,

＊Select(b => b.Title)
LINQ Method: デザインパターン入門 マルチスレッド編,

【考察】
◆LINQ Query
bsの型は selectで出力する最終の型 stringに合わせて
IEnumerable<string>となる。
selectで指定したものだけ出力

◆LINQ Method
Select(b => b)
bsの型は select bなので Bookオブジェクト
IEnumerable<Book>となる。
出力は BookDate.ToString()が呼ばれて他要素も出力。

Select(b => b.Title)とすると
IEnumerable<string>となる。
selectで指定したものだけ出力

//---- LINQ Delay / 遅延実行 ----
◆LINQ Original: 変更前
独習 PHP
独習 ASP.NET
Angularアプリプログラミング
C#ポケットレファレンス
デザインパターン入門 マルチスレッド編

◆LINQ Delay: 変更後
独習 PHP 第6版 <- bs取得後に変更しても反映されている
独習 ASP.NET
Angularアプリプログラミング
C#ポケットレファレンス
デザインパターン入門 マルチスレッド編

◆LINQ Delay: ToArray()で確定後に変更
独習 PHP      <- ToArray()時のまま、変更は反映されない。
独習 ASP.NET
Angularアプリプログラミング
C#ポケットレファレンス
デザインパターン入門 マルチスレッド編

//---- where / Where() ----
◆部分検索
＊Query:
独習 PHP
独習 ASP.NET

＊Method:
独習 PHP
独習 ASP.NET

◆候補値検索
＊targetAry: 3, 8

＊Query:
山田祥寛『Angularアプリプログラミング』技術評論社, 2017
Price: 3200円
結城 浩『デザインパターン入門 マルチスレッド編』SB Create, 2006
Price: 4700円

＊Method:
山田祥寛『Angularアプリプログラミング』技術評論社, 2017
Price: 3200円
結城 浩『デザインパターン入門 マルチスレッド編』SB Create, 2006
Price: 4700円

◆範囲検索
＊Query:
(C#ポケットレファレンス, 1640)

＊Method:
Title: C#ポケットレファレンス, Price: 1640

【考察】２つ以上のカラム(=列) / プロパティ値を表示したいとき
select以下を()でくくると、()も表示される。
$""にそのまま放り込まれて文字列が返ると思われる。
もちろん、変数部分は { }でくくられる。

select以下に、出したい形式の stringを $""で記述し、
２つ以上のプロパティ値は { }で並記すればよい。

◆複数条件検索:
Title: Angularアプリプログラミング
Publisher: 技術評論社
Price: 3200

Title: C#ポケットレファレンス
Publisher: 技術評論社
Price: 1640

◆単一要素
＊Method ONLY
Title: デザインパターン入門 マルチスレッド編
ISBN: 978-4-7973-3162-3
 */
