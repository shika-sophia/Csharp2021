/**  
 *@title CsharpBegin / Exercise / SelfLearnCS / SelfLearnChap07.cs  
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017  
 *@content 第７章 オブジェクト指向 基本 / p266, p277, p289, p295, p310, p317 /
 *@subject 練習問題 7-1, 7-2, 7-3, 7-4, 7-5,  
 *@subject 章末問題 １, ２, ３, ４,
 *
 *@author shika  
 *@date 2021-11-25  
*/
/*==== Appendix ====  
 *@date: 2021-11-25 (木)  
 *@time: 00:14 ～ 00:50 (36分)  
 *@rate: 82.14％ (○ 23 問 / 全 28 問)  
*/
/*==== Appendix ==== 
 *@date: 2021-11-25 (木) 
 *@time: 01:23 ～ 01:38 (14分) 
 *@rate: 86.36％ (○ 19 問 / 全 22 問) 
*/
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
  
namespace CsharpBegin.Exercise.SelfLearnCS  
{  
    class SelfLearnChap07  
    {  
        //static void Main(string[] args)  
        public void Main(string[] args)  
        {  
            new CsharpBegin.Exercise.ExerciseEditor("");  
        }//Main()   
  
    }//class  
}  
/*  
2021-11-25 (木) 
==== Exercise Result ====  
◆〔1〕第７章 オブジェクト指向 基本 / 練習問題 7-1  
○ (1) var: フィールドには利用不可 -> int data  
○ (2) if内の var data -> 引数で定義されているので二重定義 -> data = 0;でよい。  
× (3) メソッド無印は 暗黙的に private どこからも呼び出されていないためコンパイルエラー 
    => ○: classに protected不可  
○ (1) 7-1 / 2. フィールド: スコープはクラス全体、  
○ (2) ローカル変数は定義された位置より下段の同一ブロック内のみ  
 
◆〔2〕7-2  
○ (3) 7-2 class Circle {  
○ (4)   private double radius;  
× (5)   private const double PI = Math.PI; => ○: なくてもよい  
○ (6)   internal double GetArea(){  
○ (7)     return radius * radius * PI; } }//class  
○ (8)   public Circle(double radius){  
○ (9)     this.radius = radius; }  
○ (10)  public Circle() : this(1d) { }  
 
◆〔3〕7-3  
× (1) class MyClass {  
    => ○: static class このクラスは staticメソッドしか持たない  
○ (2)   private double weight;  
○ (3)   private double height;  
○ (4)   public MyClass(double weight, double height){  
○ (5)     this.weight = weight;  
○ (6)     this.height = height;  
× (7)   internal double GetBmi(){  
    => ○:  static double GetBmi (double weight, double height)  
    //staticなのでコンストラクタ不可  
○ (8)     return weight / (height * height); } }//class  
 
◆〔4〕7-4  
○ (1) public Circle(double radius = 1) {  
○ (2)   this.radius = radidius; }  
× (3) static double GetAverage (param int num) {  
    => ○: int[]  
○ (4)   if (num.Length == 0) { return 0d; }  
○ (5)   return num.Sum() / num.Length; } }//class  
 
◆〔5〕7-5  
○ (1) internal (double addition, double subtract)  
        GetAddSubtract (double x, double y) {  
○ (2)   return (x + y, x - y); }  
*/  
/*==== Appendix ====  
 *@date: 2021-11-25 (木)  
 *@time: 00:14 ～ 00:50 (36分)  
 *@rate: 82.14％ (○ 23 問 / 全 28 問)  
*/  
/* 
2021-11-25 (木)
==== Exercise Result ==== 
◆〔1〕章末問題１ 
○ (1) アクセス修飾子 
○ (2) public, protected, internal, private 
○ (3) static 
○ (4) 静的メソッド 
○ (5) 静的クラス 
○ (6) const 
○ (7) readonly 
○ (8) param 
○ (9) 配列 

◆〔2〕２ 
○ (1) × -> privateも可 
× (2) ○: readonlyは値型とstringのみ => ○: constの説明 
○ (3) × -> 望ましくはないが、フィールドとローカル変数の識別子は重複可。別物の変数として扱われる。 
○ (4) × -> for のカウンター変数は forブロック内のみ 
× (5) ○: 匿名型は引数や戻り値として利用可 => ○: 匿名型は型宣言として利用不可。タプルは可。 

◆〔3〕３ 
× (1) private => ○: readonly 
○ (2) this 
○ (3) this("権兵衛", 0) 
○ (4) string 
○ (5) = 
○ (6) return 

◆〔4〕４ 
○ (1) ref: 15, 15 
○ (2) non: 15, 10 
*/ 
/*==== Appendix ==== 
 *@date: 2021-11-25 (木) 
 *@time: 01:23 ～ 01:38 (14分) 
 *@rate: 86.36％ (○ 19 問 / 全 22 問) 
*/ 
