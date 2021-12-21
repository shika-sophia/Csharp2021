/** 
 *@title CsharpBegin / MultiThread / MTCS02_Immutable / BreakImmutable / MainPointLine.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@reference 結城 浩『デザインパターン入門 マルチスレッド編 [増補改訂版]』SB Creative, 2006 
 *@content ■ Immutabilityを壊す原因 / p110, p484 / 練習問題 2-5 / List 2-13, 2-14, A2-3, A2-4
 *         ◆ mutableクラスの値をそのままフィールドに代入
 *         => mutableクラスを immutableクラスに入れるときは、
 *         新たに newしたクラスでフィールドに保持しないと不変性が壊れる。
 * 
 *@subject × ==== Break Immutable ====
 *         public LineImmutable(
 *              PointMutable startPoint, PointMutable endPoint)
 *         {
 *             //[NG] mutableなクラスをフィールドにそのまま代入
 *             this.startPoint = startPoint;
 *             this.endPoint = endPoint;
 *         }
 *         
 *@subject ○ ==== Immutable ====
 *         public LineImmutable(
 *             PointMutable startPoint, PointMutable endPoint)
 *         {
 *             //[OK] 新たなインスタンスを作成してフィールドに保持
 *             this.startPoint = new PointMutable(startPoint.X, startPoint.Y);
 *             this.endPoint = new PointMutable(endPoint.X, endPoint.Y);
 *         }
 *         
 *@class MainPointLine / ◆Main() new Point(), new Line()
 *@class PointMutable 
 *       / + int X { get; set; },
 *         + int Y { get; set; } /
 *       + PointMutable(int x, int y)
 *     
 *@class LineImmutable
 *       / - ◇PointMutable startPoint,
 *         - ◇PointMutable endPoint   /
 *       + LineImmutable(int,int,int,int)
 *       + LineImmutable(PointMutable startPoint, PointMutable endPoint)
 *
 *@author shika 
 *@date 2021-12-21 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.MultiThread.MTCS02_Immutable.BreakImmutable 
{ 
    class MainPointLine 
    { 
        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            PointMutable p1 = new PointMutable(0, 0);
            PointMutable p2 = new PointMutable(100, 0);
            LineImmutable line = new LineImmutable(p1, p2);
            Console.WriteLine($"line: {line}");

            //Pointのフィールド変更
            p1.X = 150;
            p2.X = 150;
            p2.Y = 250;
            Console.WriteLine($"line: {line}");
        }//Main() 
    }//class 
}

/*
//==== Break Immutable ====
//不変のはずの Lineオブジェクトが変更されている。
line: Line: Point(0,0) - Point(100,0)
line: Line: Point(150,0) - Point(150,250)

//==== Immutable ====
//Pointの変更でも、Lineは不変のまま
line: Line: Point(0,0) - Point(100,0)
line: Line: Point(0,0) - Point(100,0)
 */