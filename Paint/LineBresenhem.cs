using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class LineBresenhem
    {
        private double x_left;
        private double y_left;
        private double x_right;
        private double y_right;

        //массив для хранения точек созданной линии
        private List<int> array_x = new List<int>();
        private List<int> array_y = new List<int>();

        public void Set_X_left_Y_left(double x_left, double y_left) { this.x_left = x_left; this.y_left = y_left; }
        public void Set_X_right_Y_right(double x_right, double y_right) { this.x_right = x_right; this.y_right = y_right; }

        public List<int> Get_array_x() { return array_x; }
        public List<int> Get_array_y() { return array_y; }

        //алгоритм рисование линии
        //по алгоритму Брезенхема
        public void Bresenhem()
        {
            int x1 = (int)x_right;
            int x0 = (int)x_left;
            int y1 = (int)y_right;
            int y0 = (int)y_left;

            //Изменения координат
            int dx = (x1 > x0) ? (x1 - x0) : (x0 - x1);
            int dy = (y1 > y0) ? (y1 - y0) : (y0 - y1);

            //Направление изменения
            int sx = (x1 >= x0) ? (1) : (-1);
            int sy = (y1 >= y0) ? (1) : (-1);

            //в какую сторону идёт большее изменение
            if (dy < dx)
            {
                //основа в алгоритме Брезенхема
                int d = (dy*2) - dx;
                int d1 = dy*2;
                int d2 = (dy - dx)*2;

                array_x.Add(x0); array_y.Add(y0);
                int x = x0 + sx;
                int y = y0;
                for (int i = 1; i <= dx; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        y += sy;
                    }
                    else
                        d += d1;
                    array_x.Add(x); array_y.Add(y);
                    x += sx;
                }
            }
            else
            {
                int d = (dx*2) - dy;
                int d1 = dx*2;
                int d2 = (dx - dy)*2;
                array_x.Add(x0); array_y.Add(y0);
                int x = x0;
                int y = y0 + sy;
                for (int i = 1; i <= dy; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        x += sx;
                    }
                    else
                        d += d1;
                    array_x.Add(x); array_y.Add(y);
                    y += sy;
                }
            }
        }

        //рисования квадрата
        public void Box()
        {
            //x0=264 y0=307  x1=528  y1=193
            //строим 4 прямых
            // прямая - x0 264 y0 307 x1 264 y1 193
            Set_X_left_Y_left(264, 307);
            Set_X_right_Y_right(264, 193);

            Bresenhem();
            // прямая - x0 264 y0 193 x1 528 y1 193
            Set_X_left_Y_left(264, 193);
            Set_X_right_Y_right(528, 193);

            Bresenhem();
            // прямая - x0 528 y0 193 x1 528 y1 307
            Set_X_left_Y_left(528, 193);
            Set_X_right_Y_right(528, 307);

            Bresenhem();
            // прямая - x0 528 y0 307 x1 264 y1 307
            Set_X_left_Y_left(528, 307);
            Set_X_right_Y_right(264, 307);

            Bresenhem();
        }

    }
}
