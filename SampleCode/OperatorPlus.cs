/**        
 *@title CsharpBegin / SampleCode / OperatorPlus.cs        
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017        
 *@content 9.6 OperatorPlus / p462 / List 9-55, 9-56, 9-57
 *@subject OpePlus「+」
 *@subject OpePlusProperty「obj + int」 
 *@subject OpeIncrement「++」「--」
 *         呼出時の「++」で、もとのオブジェクトもインクリメントされるので
 *         毎回 新規オブジェクトをベースに「++」
 *         前置と後置で結果が異なるので注意
 *         
 *@notice 【註】static methods have been to comment out.
 *
 *@subject OpeTrueFalse        
 *@subject OpeCast        
 *       
 *@author shika        
 *@date 2021-10-31        
*/       
using System;        
using System.Collections.Generic;        
using System.Linq;        
using System.Text;        
using System.Threading.Tasks;        
        
namespace CsharpBegin.SampleCode        
{        
    class OperatorPlus        
    {        
        //static void Main(string[] args)        
        public void Main(string[] args)        
        {
            var co1 = new CoordinateOpe { X = 10, Y = 20 };
            var co2 = new CoordinateOpe { X = 17, Y = 25 };
            //var co3 = co1 + co2;
            //var co4 = co1 + 100;

            //var coBase = new CoordinateOpe { X = 10, Y = 20 };
            //var co5 = ++coBase;
            //coBase = new CoordinateOpe { X = 10, Y = 20 };
            //var co6 = coBase++;

            //var coList = new List<CoordinateOpe> { co1, co2, co3, co4, co5, co6 };
            //int count = 1;
            //coList.ForEach(co => Console.WriteLine($"co{count++}: {co}"));
        }//Main()        
    }//class
    
    class CoordinateOpe
    {
        public int X { get; set; }
        public int Y { get; set; }

        ////CoordinateOpeオブジェクト同士の「+」を再定義
        //public static CoordinateOpe operator + (CoordinateOpe co1, CoordinateOpe co2)
        //{
        //    return new CoordinateOpe()
        //    {
        //        X = co1.X + co2.X,
        //        Y = co1.Y + co2.Y
        //    };
        //}//operator obj + obj

        ////CoordinateOpe + intの「+」を再定義
        //public static CoordinateOpe operator +(CoordinateOpe co1, int x)
        //{
        //    return new CoordinateOpe()
        //    {
        //        X = co1.X + x,
        //        Y = co1.Y
        //    };
        //}//operator obj + int

        //public static CoordinateOpe operator ++ (CoordinateOpe co)
        //{
        //    return new CoordinateOpe()
        //    {
        //        X = co.X + 1,
        //        Y = co.Y + 1
        //    };
        //}//operator ++

        //public static CoordinateOpe operator --(CoordinateOpe co)
        //{
        //    return new CoordinateOpe()
        //    {
        //        X = co.X - 1,
        //        Y = co.Y - 1
        //    };
        //}//operator --

        public override string ToString()
        {
            return $"X: {X}, Y:{Y}";
        }
    }//class
}
/*
co1: X: 10, Y:20
co2: X: 17, Y:25
co3: X: 27, Y:45
co4: X: 110, Y:20
co5: X: 11, Y:21
co6: X: 10, Y:20
*/
