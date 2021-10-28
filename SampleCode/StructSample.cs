/** 
 *@title CsharpBegin / SampleCode / StructSample.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 第９章 / p426 / List 9-34, 9-35
 *   ◆struct 構造体
 *   new()
 *   new { オブジェクト初期化子 };
 *   default(T)
 *   
 *@author shika 
 *@date 2021-10-28 
*/
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
 
namespace CsharpBegin.SampleCode 
{ 
    class StructSample 
    { 
        struct CoordinateSample
        {
            private double _x;
            private double _y;
            public double X { 
                get { return _x; }
                internal set { this._x = value; }
            }
            public double Y { 
                get { return _y; }
                internal set { this._y = value; }
            }

            public CoordinateSample(double x, double y)
            {
                this._x = x;
                this._y = y;
            }

            public override string ToString()
            {
                return $"X座標: {_x:f}, Y座標: {_y:f}";
            }
        }//struct

        //static void Main(string[] args) 
        public void Main(string[] args) 
        {
            //---- new () ----
            //var cdn = new CoordinateSample();

            //---- new (x, y) ----
            //var cdn = new CoordinateSample(12.4, 23.25);

            //---- new {} ----
            //var cdn = new CoordinateSample
            //{
            //    X = 12.4,
            //    Y = 23.51
            //};

            //---- default ----
            var cdn = default(CoordinateSample);
            cdn.X = 11;
            cdn.Y = 51.2;

            Console.WriteLine(cdn.ToString());
        }//Main() 
    }//class 
}

/*
//---- new () ----
X座標: 0.00, Y座標: 0.00

//---- new (x, y) ----
X座標: 12.40, Y座標: 23.25

//---- default ----
X座標: 0.00, Y座標: 0.00
X座標: 11.00, Y座標: 51.20
 */