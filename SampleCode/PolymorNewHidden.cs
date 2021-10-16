/**
 *@title CsharpBegin / SampleCode / PolymorNewHidden.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 第８章 Polymorphism ポリモーフィズム / p369 / List 8-A
 *    ◆new修飾子によるメソッドの隠蔽だとポリモーフィズムが働かない例
 *
 *@see PolymorBasic.cs
 *@author shika 
 *@date 2021-10-16 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.SampleCode
{
    class PolymorNewHidden
    {
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            FigureHidden figue = new TriangleHidden(10, 30);
            Console.WriteLine($"Triangle: {figue.GetArea():F}");

            figue = new RectangleHidden(10, 30);
            Console.WriteLine($"Rectangle: {figue.GetArea():F}");
        }//Main()
    }//class

    class FigureHidden
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public FigureHidden(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double GetArea()
        {
            return 0.0d;
        }

    }//class FigureHidden

    class TriangleHidden : FigureHidden
    {
        public TriangleHidden(double width, double height)
            : base(width, height) { }

        public new double GetArea()
        {
            return Width * Height / 2;
        }
    }//class TriangleHidden

    class RectangleHidden : FigureHidden
    {
        public RectangleHidden(double width, double height)
            : base(width, height) { }

        public new double GetArea()
        {
            return Width * Height;
        }
    }//class Rectangle
}

/*
Triangle: 0.00
Rectangle: 0.00
 */