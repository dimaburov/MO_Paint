using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Paint
{
    class Polygon
    {

        private double x1, y1, x2, y2;

        public double getX1() { return x1; }
        public double getY1() { return y1; }
        public double getX2() { return x2; }
        public double getY2() { return y2; }

        private List<Point> points;

        public Polygon(List<Point> points)
        {
            this.points = points;
        }


        public List<Segment> GetEdges()
        {
            List<Segment> edges = new List<Segment>();
            for (int i = 0; i < points.Count - 1; i++)
            {
                edges.Add(new Segment(points[i], points[i + 1]));
            }
            edges.Add(new Segment(points[points.Count - 1], points[0]));

            return edges;
        }

        public void DrawCirusBec(Segment seg)
        {
            var dir = seg.Direction;
            var tA = 0.0f;
            var tB = 1.0f;
            var edges = GetEdges();
            foreach (var edge in edges)
            {
                switch (Math.Sign(edge.Normal.ScalarMul(dir)))
                {
                    case -1:
                        {
                            var t = seg.IntersectionParameter(edge);
                            if (t > tA)
                            {
                                tA = t;
                            }
                            break;
                        }
                    case +1:
                        {
                            var t = seg.IntersectionParameter(edge);
                            if (t < tB)
                            {
                                tB = t;
                            }
                            break;
                        }
                    case 0:
                        {
                            if (!edge.OnLeft(seg.A))
                            {
                                return;
                            }
                            break;
                        }
                }
            }
            if (tA > tB)
            {
                return;
            }
            seg = seg.Morph(tA, tB);

            x1 = (int)Math.Round(seg.A.X);
            y1 = (int)Math.Round(seg.A.Y);

            x2 = (int)Math.Round(seg.B.X);
            y2 = (int)Math.Round(seg.B.Y);

            //LineWithIntCords.Draw(g, new Point((int)Math.Round(seg.A.X), (int)Math.Round(seg.A.Y)), new Point((int)Math.Round(seg.B.X), (int)Math.Round(seg.B.Y)));
        }
    }
}
