/** 
 *@title CsharpBegin / GofDesignYH / GDYH01_Iterator / MainIteratorSample.cs 
 *@reference CS 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference YG 結城 浩 『デザインパターン入門 Java言語 [増補改訂版]』SB Creative, 2004 
 *@content 第１章 Iterator / p2 / List 1-1 ～ 1-6
 *         || Design Pattern || 全体
 *         ・具体的なクラスだけでコーディングすると、クラス間の結合が強くなり再利用が難しくなる
 *           abstract(=抽象) - concreat(=具体) に分割することでクラス間の結合を緩和する。
 *           => 部品としてクラスの再利用性を上げる
 *           
 *         || Iterator || ～ひとつひとつ数え上げる～
 *         ・[Java] Iterator / [C#] Enumerator 言語仕様の標準ライブラリにも採用されたパターン
 *         ・|| Composite || 再帰的な構造を持つプログラムには適用しずらい
 *         ・Aggregate(集合体)と Iterator(数え上げ)のクラス群を分離
 *           => Bookの配列/List機能の変更が Iteratorクラス群には影響を与えない。
 *           => 互いに独立しているので、変更時には部分的な修正をすれば済む。
 *              (全体を修正する必要がない)
 *              
 *@class MainIteratorSample
 *       ◆Main()
 *       new BookShelf(int)
 *       shelf.Append(new BookGY01(string))
 *       shelf.Iterator()
 *@class AbsAggregate
 *       // + abstract AbsIteratorGY01 Iterator();
 *         ↑
 *@class BookShelfGY01 : AbsAggregate
 *       / - BookGY01[] bookAry
 *         - int last /
 *       + BookShelfGY01(int max)
 *       + override AbsIteratorGY01 Iterator()
 *       + void AppendBook(BookGY01)
 *       + string GetBook(int index)
 *       + int GetLength()
 *       
 *@class AbsIteratorGY01
 *       // + abstract bool HasNext();
 *          + abstract BookGY01 Next(); 
 *        ↑
 *@class BookShelfIterator : AbsIteratorGY01
 *       / - ◇BookShelfGY01 shelf 
 *         - int index /
 *      + BookShelfIterator(BookShelfGY01)
 *      + bool HasNext()
 *      + BookGY01 Next()
 *      
 *@class BookGY01
 *       / - string name /
 *       + BookGY01(string name)
 *       + string GetName()
 *
 *@author shika 
 *@date 2022-04-05 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.GofDesignYH.GY01_Iterator.IteratorSample
{ 
    class MainIteratorSample 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            const int MAX = 4; //max size of BookShelf
            var shelf = new BookShelfGY01(MAX);
            shelf.AppendBook(
                new BookGY01("Around the World in 80 Days"));
            shelf.AppendBook(
                new BookGY01("Bible"));
            shelf.AppendBook(
                new BookGY01("Cinderella"));
            shelf.AppendBook(
                new BookGY01("Daddy-Long-Legs"));

            AbsIteratorGY01 itr = shelf.Iterator();
            while (itr.HasNext())
            {
                var book = (BookGY01) itr.Next();
                Console.WriteLine(book.GetName());
            }//while

        }//Main() 
    }//class 
}

/*
Around the World in 80 Days
Bible
Cinderella
Daddy-Long-Legs
 */