/** 
 *@title CsharpBegin / SampleCode / LinqObjJoin.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content LinqObjJoin / p515 / List 10-41
 *@subject ◆join / Join()
 *         ＊Query
 *         from [元の範囲変数] in [元のデータソース]
 *         join [結合範囲変数] in [結合データソース]
 *           on [結合key1] equals [結合key2]
 *           
 *         ＊Method
 *         IEnumerable<TResult> IE<T>.Join<TOut,TIn,TKey,TResult>(
 *             Inumerable<TIn> 結合するデータソース,
 *             Func<Tout,TKey> 元データの結合key,
 *             Func<TIn,TKey> 結合データの結合key,
 *             Func<TOut,TIn,TResult> 結合結果を取得するメソッド,
 *         )
 *
 *@see LinqObjSample.cs
 *@see LinqObjOrder.cs
 *@see LinqObjGroup.cs
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
    class LinqObjJoin 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            var here = new LinqObjJoin();
            BookData data = new BookData();

            //---- join / Join() ----
            //＊Query
            IEnumerable<string> bsQjoin =
                from b in data.BookItr
                join r in data.ReviewItr
                on b.Isbn equals r.Isbn
                select $"{b.Title}\n{r.Name}\n{r.Body}";
            here.ShowItrator(bsQjoin, "//---- join / Join() ----\n＊Query");

            //＊Method
            var bsMjoin = data.BookItr
                .Join(data.ReviewItr, 
                    b => b.Isbn, 
                    r => r.Isbn,
                    (b, r) => new
                    {
                        Title = b.Title,
                        Name = r.Name,
                        Body = r.Body,
                    });
            here.ShowItrator(bsMjoin, "＊Method");
        }//Main() 

        private void ShowItrator<T>(IEnumerable<T> itr, string name)
        {
            Console.WriteLine(name);
            foreach(T value in itr)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
        }//ShowIterator<T>()
    }//calss 
}

/*
//---- join / Join() ----
＊Query
独習 PHP
山田太郎
PHPの言語仕様を学習できます。

独習 ASP.NET
鈴木花子
.NET環境のWebフォームの作り方

Angularアプリプログラミング
山田太郎
データ操作の教科書です。

C#ポケットレファレンス
佐藤久美
C#のAPIレファレンス

デザインパターン入門 マルチスレッド編
加藤次郎
マルチスレッドのことを理解できます。

＊Method
{ Title = 独習 PHP, Name = 山田太郎, Body = PHPの 言語仕様を学習できます。 }
{ Title = 独習 ASP.NET, Name = 鈴木花子, Body = .NET環境のWebフォームの作り方 }
{ Title = Angularアプリプログラミング, Name = 山田太郎, Body = データ操作の教科書です。 }
{ Title = C#ポケットレファレンス, Name = 佐藤久美, Body = C#のAPIレファレンス }
{ Title = デザインパターン入門 マルチスレッド編, 
    Name = 加藤次郎, 
    Body = マルチスレッドのことを理解 できます。 }
 */