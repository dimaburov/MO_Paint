using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Paint
{
    class  Segment
    {
        public readonly Point A, B;

        public Segment(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public bool OnLeft(Point p)
        {
            var ab = new Point(B.X - A.X, B.Y - A.Y);
            var ap = new Point(p.X - A.X, p.Y - A.Y);
            return ab.Det(ap) >= 0;
        }

        public Point Normal
        {
            get
            {
                return new Point(B.Y - A.Y, A.X - B.X);
            }
        }

        public Point Direction
        {
            get
            {
                return new Point(B.X - A.X, B.Y - A.Y);
            }
        }

        public float IntersectionParameter(Segment seg)
        {
            var segment = this;
            var edge = seg;

            var segmentToEdge = edge.A.Sub(segment.A);
            var segmentDir = segment.Direction;
            var edgeDir = edge.Direction;

            var t = edgeDir.Det(segmentToEdge) / edgeDir.Det(segmentDir);

            if (float.IsNaN(t))
            {
                t = 0;
            }

            return t;
        }

        public Segment Morph(float tA, float tB)
        {
            var d = Direction;
            return new Segment(A.Add(d.Mul(tA)), A.Add(d.Mul(tB)));
        }
    }

  

    public static class PointExtensions
    {
        public static Point Add(this Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static Point Sub(this Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        public static Point Mul(this Point a, float b)
        {
            return new Point(a.X * b, a.Y * b);
        }

        public static float ScalarMul(this Point a, Point b)
        {
            return (float)(a.X * b.X + a.Y * b.Y);
        }

        public static float Det(this Point a, Point b)
        {
            return (float)(a.X * b.Y - a.Y * b.X);
        }
    }

}
