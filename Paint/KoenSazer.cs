using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class KoenSazer
    {
        private List<int> array_x = new List<int>();
        private List<int> array_y = new List<int>();

        public List<int> Get_array_x() { return array_x; }
        public List<int> Get_array_y() { return array_y; }


        private int Code(int x, int y, Point p)
        {
            int res = 0;
            if (p.X < x)
                res += 1;

            if (p.X > x + 264)
                res += 2;

            if (p.Y > y + 114)
                res += 4;

            if (p.Y < y)
                res += 8;


            return res;
        }

        public void SazerlendCoen(int x, int y, Point p1, Point p2)
        {
            int code;
            Point A;

            int codeA = Code(x, y, p1);
            int codeB = Code(x, y, p2);

            while (codeA != 0 || codeB != 0)
            {
                //крайний случай
                if ((codeA & codeB) != 0)
                    return;
                //меняем местами
                if (codeA != 0)
                {
                    code = codeA;
                    A = p1;
                }
                else
                {
                    code = codeB;
                    A = p2;
                }
                //лево
                if ((code & 1) != 0)
                {
                    A.Y += (p1.Y - p2.Y) * (x - A.X) / (p1.X - p2.X);
                    A.X = x;
                }
                //право
                else if ((code & 2) != 0)
                {
                    A.Y += (p1.Y - p2.Y) * (x +264 - A.X) / (p1.X - p2.X);
                    A.X =x + 264;
                }
                //низ
                else if ((code & 4) != 0)
                {

                    A.X += (p1.X - p2.X) * (y + 114 - A.Y) / (p1.Y - p2.Y);
                    A.Y = y + 114;
                }
                //верх
                else if ((code & 8) != 0)
                {
                    A.X += (p1.X - p2.X) * (y - A.Y) / (p1.Y - p2.Y);
                    A.Y = y;
                }

                //запоминаем изменения
                if (code == codeA)
                {
                    p1 = A;
                    codeA = Code(x, y, p1);
                }
                else
                {
                    p2 = A;
                    codeB = Code(x, y, p2);
                }

            }

            //точки на рисование
            array_x.Add((int)p1.X); array_x.Add((int)p2.X);
            array_y.Add((int)p1.Y); array_y.Add((int)p2.Y);

        }

    }
}
