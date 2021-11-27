/**  
 *@title CsharpBegin / Exercise / SelfLearnCS / SelfLearnChap09.cs  
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@content 第９章 オブジェクト / p416, p432, p451, p469 
 *         練習問題 9-1, 9-2, 9-3, 章末問題 １, ２, ３, ４, 
 *@subject 名前空間, 例外処理, enum, struct, ジェネリック, Object 
 *@author shika  
 *@date 2021-11-28  
*/
/*==== Appendix ====  
 *@date: 2021-11-28 (日)  
 *@time: 05:24 ～ 05:38 (14分)  
 *@rate: 63.64％ (○ 7 問 / 全 11 問)  
*/
/*==== Appendix ==== 
 *@date: 2021-11-28 (日) 
 *@time: 06:10 ～ 06:34 (24分) 
 *@rate: 54.55％ (○ 12 問 / 全 22 問) 
*/
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
  
namespace CsharpBegin.Exercise.SelfLearnCS  
{  
    class SelfLearnChap09  
    {  
        //static void Main(string[] args)   
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()    
    }//class 
} 
/*  
2021-11-28 (日) 
==== Exercise Result ====  
◆〔1〕第９章 オブジェクト / 名前空間, 例外処理, ジェネリック / 練習問題 9-1  
○ (1) catchブロックの複数並記: Exceotionクラスの継承関係で  
      subを先に superを後ろに配置。  
○ (2) Exceptionだけの catchは原因特定が難しくなるので避ける。  
× (3) 2. 例外の再throw: 例外を catchしたが同じ例外を再び起こすこと。 
○ (4) catchに捕捉されると、コンソールには現れないので、例外発生を通知する目的で行う。  
○ (5) また、その場では例外の原因を処理できない場合など、他メソッド/クラスに例外処理を委譲する場合にも  
    => ○: throw ex;ではなく、throw;とすること。  
    *  さもないと、StackTraceが上書きされてしまう。 
     
◆〔2〕9-2  
○ (1) 別紙  
       enum Weekday 
       { 
           Monday = 1, 
           Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, 
           All = 99 
       }//enum Weekday 
 
○ (2) 構造体の制約: 値型、stringのみでしか定義できない。  
× (3) ..あと２つ  
    =>【構造体 structの制約】 
    *  継承は利用できない。 
    *  abstruct, virtual, override, sealed 継承関係の修飾子不可。 
    *  引数なしのコンストラクタ不可。default()で利用しているため。 
    *  デストラクタ不可。 
    *  structに static不可。(staticメンバーは可) 
 
◆〔3〕9-3  
○ (1) ジェネリックを new T()するのはコンパイルエラー。  
× (2) T obj = new T();を正しいコードに修正。  
× (3) ...  
    => 型パラメータにコンストラクタ制約を追加すれば可能。 
    *  class MyGenerics<T> where T : new() { 
    *    T obj = new T(); 
    *  } 
*/ 
/*==== Appendix ====  
 *@date: 2021-11-28 (日)  
 *@time: 05:24 ～ 05:38 (14分)  
 *@rate: 63.64％ (○ 7 問 / 全 11 問)  
*/ 
/* 
2021-11-28 (日)
==== Exercise Result ==== 
◆〔1〕章末問題 １ 
○ (1) × 発生した例外の superと一致しても実行される。 
× (2) ○ class/interface/structは Nested可。 
    => ○: interfaceは Nested不可。class/structは ３つとも Nestedを持てる。 
× (3) × structの継承不可。 
    => ○: struct : interfaceは可 
× (4) × stringも可？ 
    => ○: enum は　整数型のみ可。 
○ (5) × 演算子のオーバーロードで再定義可。 

◆〔2〕２ 
× (1) using static Math; 
    => ○: using static System.Math; 
× (2) global : MyClass.Process(); 
    => ○: global :: MyClass.Process(); 
× (3) catch (Exception e where e = IOException || e = ArgumentException) 
    => ○: catch(Exception ex) when( ex is IOE || ex is ArgsException) { } 
○ (4) i > 0 ? Math.Sqrt(i) : throw new Exception(); 
○ (5) internal string PrintList<T> (List<T> list) { 
× (6)   list.ForEach(v => Console.Write( v + ", ")); } 
    => ○: String.Join(",", list.ToArray());も可。 
    
◆〔3〕３ 
○ (1) sealed -> structに不可、削除。 
○ (2) MyStruct() -> structは 引数なしコンストラクタ不可。 
○ (3) MyStruct(string message = "", int value = 0) { 
○ (4)  this.value = value;も追加 
    => structのフィールドは直接初期化できない。
    *  すべてのフィールドをコンストラクタで初期化する必要がある。
    => ローカル変数として宣言した structは
    *  配下のフィールドを全て初期化してからでないと、利用できない。
    
◆〔4〕４ 
○ (1) this 
○ (2) this(1.0, 1.0) 
○ (3) $ 
× (4) operator + 
    => ○: static Point operator + 
× (5) Point 
    => ○: new Point 
× (6) cast?
    => ○: static explicit operator double 
○ (7) Math.Sqrt() 
*/ 
/*==== Appendix ==== 
 *@date: 2021-11-28 (日) 
 *@time: 06:10 ～ 06:34 (24分) 
 *@rate: 54.55％ (○ 12 問 / 全 22 問) 
*/ 
