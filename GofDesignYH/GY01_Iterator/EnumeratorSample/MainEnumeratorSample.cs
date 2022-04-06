/** 
 *@title CsharpBegin / GofDesignYH / GY01_Iterator / EnumeratorSample / MainEnumeratorSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩 『デザインパターン入門 Java言語 [増補改訂版]』SB Creative, 2004 
 *@content 第１章 Iterator / 練習問題 1-1 / p14, 382
 *         内部配列だと要素の追加ができないので、Listに修正する。
 *         || Iterator || は[Java][C#]の言語仕様でインターフェイス, クラスとして実装化している。
 *         
 *@subject [Java]〔JG1〕java.util.Iterator<T> <<interface>>
 *         Iterator<T> collection.iterator()
 *         boolean     iterator.hasNext()
 *         E           iterator.Next()
 *         void        iterator.remove()
 *         
 *@subject [C#]〔CS41,59〕System.Collections.Generics.IEnumerator<T> / IEnumerable<T>
 *         List<T>.Enumerator list.GetEnumerator()
 *         T          enumerator.Current
 *         bool       enumerator.MoveNext()
 *         void       enumerator.Dispose()
 *         
 *@subject [C#]〔CS84〕System.Linq
 *         IEnumerable<T> bs = <dataSource>.Select(b => b)
 *                             .Distinct();
 *         List<T> bs.ToList();
 *                             
 *@class MainEnumeratorSample
 *@class BookShelfCollection
 *       内部配列を Listに変更することで、追加を可能にする。
 *       LINQ Ditinct()を用いて重複要素を一本化。
 *       
 *@author shika 
 *@date 2022-04-06 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.GofDesignYH.GY01_Iterator.EnumeratorSample 
{ 
    class MainEnumeratorSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            string[] titleAry = new[]
            {
                "Around the World in 80 Days",
                "Around the World in 80 Days", // <- element duplication 要素重複
                "Bible",
                "Cinderella",
                "Daddy-Long-Legs",
                "Economic Growth",
            };

            var shelf = new BookShelfCollection(titleAry);
            shelf.AppendBook("Foresite"); 
            shelf.AppendBook("Economic Growth"); // <- element duplication 要素重複

            List<string>.Enumerator itr = 
                shelf.GetTitleList().GetEnumerator();
            while (itr.MoveNext())
            {
                Console.WriteLine(itr.Current);
            }//while
            
            itr.Dispose();
        }//Main() 
 
    }//class 
}

/*
Around the World in 80 Days
Bible
Cinderella
Daddy-Long-Legs
Economic Growth
Foresite
 */