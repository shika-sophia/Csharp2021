/**
 *@title CsharpBegin / SampleCode / PolymorBasic.cs 
 *@reference 山田祥寛『独習 C＃ [新版] 』 翔泳社, 2017 
 *@content 第８章 Polymorphism ポリモーフィズム / p366 / List 8-25, 8-26
 *    ◆abstract
 *    ◆異なる継承オブジェクトを変数型で同一視
 *@class PolymorBasic / ◆Main / new Triangle(), new Rectangle()
 *@class AbsFigure / abstract
 *       / +double Width, +double Height /
 *       + AbsFigure(double width, double height)
 *       + GetArea() abstract
 *@class Triangle : AbsFigure
 *       + TriAngle(double, double) : base(double, double)
 *       + GetAngle() override
 *@class Rectangle : AbsFigure
 *       + RectAngle(double, double) : base(double, double)
 *       + GetAngle() override
 *
 *@see PolymorNewHidden.cs
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
    class PolymorBasic
    {
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            AbsFigure figue = new Triangle(10, 30);
            Console.WriteLine($"Triangle: {figue.GetArea()}");

            figue = new Rectangle(10, 30);
            Console.WriteLine($"Rectangle: {figue.GetArea()}");
        }//Main()
    }//class

    abstract class AbsFigure
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public AbsFigure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public abstract double GetArea();

    }//abstract class

    class Triangle : AbsFigure
    {
        public Triangle(double width, double height)
            : base(width, height) { }
        
        public override double GetArea()
        {
            return Width * Height / 2;
        }
    }//class Triangle

    class Rectangle : AbsFigure
    {
        public Rectangle(double width, double height)
            : base(width, height) { }

        public override double GetArea()
        {
            return Width * Height;
        }
    }//class Rectangle
}

/*
Triangle: 150
Rectangle: 300
 */