using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS02_Immutable.BreakImmutable
{
    class LineImmutable
    {
        private readonly PointMutable startPoint;
        private readonly PointMutable endPoint;

        public LineImmutable(
            int startX, int startY, int endX, int endY)
        {
            this.startPoint = new PointMutable(startX, startY);
            this.endPoint = new PointMutable(endX, endY);
        }

        public LineImmutable(
            PointMutable startPoint, PointMutable endPoint)
        {
            //[NG] mutableなクラスをフィールドにそのまま代入
            //this.startPoint = startPoint;
            //this.endPoint = endPoint;

            //[OK] mutableなクラスをもとに、新たなインスタンスを作成
            this.startPoint = new PointMutable(startPoint.X, startPoint.Y);
            this.endPoint = new PointMutable(endPoint.X, endPoint.Y);
        }

        public int GetStartX() { return startPoint.X; }
        public int GetStartY() { return startPoint.Y; }
        public int GetEndX() { return endPoint.X; }
        public int GetEndY() { return endPoint.Y; }

        public override string ToString()
        {
            return $"Line: {startPoint} - {endPoint}";
        }
    }//class
}
