/** 
 *@title CsharpBegin / SampleCode / OperatorCast.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content OperatorCast / p467 / List 9-61, 9-62
 *         public static explicit operator 変換後の型 (変換前の型 引数)
 *           explicit: 明示的
 *           implicit: 暗黙的 / 暗黙的変換も定義可だが、利用すべきではない。
 *         (int) Coordinate: obj -> intのキャスト
 *         (Coordinate) int: int -> objのキャスト
 *
 *@notice 【註】static methods have been to comment out.
 *@author shika 
 *@date 2021-11-01 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class OperatorCast 
    {
        //static void Main(string[] args) 
        ////public void Main(string[] args) 
        //{
        //    var co1 = new CoordinateCast(10, 20);
        //    int value = (int)co1;
        //    Console.WriteLine($"co1: {co1} value: {value}");

        //    var co2 = (CoordinateCast) 100;
        //    Console.WriteLine($"co2: {co2}");
        //}//Main() 
    }//class

    class CoordinateCast
    {
        public int X { get; set; }
        public int Y { get; set; }

        public CoordinateCast() : this(0, 0) { }

        public CoordinateCast(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        ////obj -> intのキャスト
        //public static explicit operator int (CoordinateCast co)
        //{
        //    return co.X + co.Y;
        //}

        ////int -> objのキャスト
        //public static explicit operator CoordinateCast (int num)
        //{
        //    return new CoordinateCast(num, num);
        //}

        public override string ToString()
        {
            return $"X: {X}, Y:{Y}";
        }
    }//class
}

/*
co1: X: 10, Y:20 value: 30
co2: X: 100, Y:100
 */
