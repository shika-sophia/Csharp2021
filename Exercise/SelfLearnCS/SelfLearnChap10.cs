/**  
 *@title CsharpBegin / Exercise / SelfLearnCS / SelfLearnChap10.cs  
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@content 第10章 delegate, ラムダ式, LINQ / p439, p517
 *@subject 練習問題 10-1,  
 *@subject 章末問題 １, ２, ３, 
 *
 *@author shika  
 *@date 2021-11-29  
*/
/*==== Appendix ====  
 *@date: 2021-11-29 (月)  
 *@time: 06:24 ～ 06:31 (7分)  
 *@rate: 100.00％ (○ 2 問 / 全 2 問)  
*/
/*==== Appendix ==== 
 *@date: 2021-11-29 (月) 
 *@time: 06:34 ～ 07:15 (41分) 
 *@rate: 77.42％ (○ 24 問 / 全 31 問) 
*/
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
  
namespace CsharpBegin.Exercise.SelfLearnCS  
{  
    class SelfLearnChap10  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()   
  
    }//class  
}  
/*  
2021-11-29 (月) 
==== Exercise Result ====  
◆〔1〕第10章 ラムダ式, LINQ / 練習問題 10-1  
○ (1) (int i) => { return i * i; } / i => i * i  
○ (2) if( list.TrueForAll( str => str.Length <= 5)){ }  
*/  
/*==== Appendix ====  
 *@date: 2021-11-29 (月)  
 *@time: 06:24 ～ 06:31 (7分)  
 *@rate: 100.00％ (○ 2 問 / 全 2 問)  
*/  
/* 
2021-11-29 (月)
==== Exercise Result ==== 
◆〔1〕章末問題 １ 
○ (1) × 匿名メソッドをラムダ式に代替すべき 
○ (2) × 引数なし () =>  
○ (3) × LINQ クエリ構文は、メソッド構文にコンパイル時に変換されるので、
        クエリ構文でできることは必ずメソッド構文でも可能。 
○ (4) ○ LINQはプロバイダを自動選択 
○ (5) × selectしないと表示にならないので、そうすべきだが、必須ではない。
        groupbyも可。

◆〔2〕２ 
○ (1) delegate bool Hoge(string str); 
× (2) delegate <R> Foo<T, T, R> (T v1, T v2); 
    => ○: delegate R Foo<T, R>(T v1, T v2); 
○ (3) List<string> list = new List<string> {"ABCDE", "OPQR", "WXYZ", "HIJK"}; 
× (4) List<string> listPre3 = list.FindAll(str => (str => str.Length <= 3)); 
    => ○: list.ConvertAll(Func<T, R>) 
       FindAll()も可
○ (5) IEnumerable<Book> bookItr = AppTables.Books 
○ (6)   .Where( b => b.Title.EndsWith("入門")) 
× (7)   .OrderBy( b => b.Price ) 
    => ○: OrderByDescending() 
○ (8)   .Select( b => new { 
○ (9)     Title = b.Title, PriceTaxed = b.Price * 1.08 }); 
○ (10) IEnumerable<Book> bookQuery = from b in AppTables.Books 
○ (11)   where b.Title.EndsWith("入門") 
× (12)   orderby b.Price 
    => ○: orderby b.Price descending 
○ (13)   select new { }; 
○ (14) ④ IEnumerable<Book> bookItr = AppTables.Books 
× (15)   .Where( b => b.PublishDate <= "2016-12-01") 
    => ○: b.PublishDate < new DateTime(2016, 12, 01) 
    * PublisheDateの型 DateTime,
    * "2016-12-01"の型 Stringのため、必ず false
    * 型を合わせて比較するには new DateTime()が必要
    
○ (16)   .OrderBy( b => b.Publisher) 
× (17)   .Then(b => b.Title) 
    => ○: ThenBy() 
○ (18)   .Select( b => new { 
○ (19)     Title = b.Title.Substring(0, 5), 
○ (20)     Price = b.Price, Publisher = b.Publisher }); 

◆〔3〕３ 
○ (1) <T> 
○ (2) Predicate<T> 
× (3) value.Exacts(condition) 
    => ○: if(condition(value)) //Predicate<T>
    *  自回答でもいけそうだが、 
    *  conditionを使っていないし condition(value)が必要
    
○ (5) ToArray() 
○ (6) v % 2 == 0 
*/ 
/*==== Appendix ==== 
 *@date: 2021-11-29 (月) 
 *@time: 06:34 ～ 07:15 (41分) 
 *@rate: 77.42％ (○ 24 問 / 全 31 問) 
*/ 
