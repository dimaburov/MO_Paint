using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class Line
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
        public void drowLine()
        {
            double x1 = x_right;
            double x0 = x_left;
            double y1 = y_right;
            double y0 = y_left;

            //Изменения координат
            double dx = (x1 > x0) ? (x1 - x0) : (x0 - x1);
            double dy = (y1 > y0) ? (y1 - y0) : (y0 - y1);

            //Направление изменения
            double sx = (x1 >= x0) ? (1) : (-1);
            double sy = (y1 >= y0) ? (1) : (-1);

            //в какую сторону идёт большее изменение
            if (dy < dx)
            {
                //алгоритм
                double d = dy/dx;
                double d1 = dy/dx;

                array_x.Add((int)x0); array_y.Add((int)y0);
                double x = x0 + sx;
                double y = y0;
                for (int i = 1; i <= dx; i++)
                {
                    if (d > 0.5)
                    {
                        d += d1 - 1;
                        y += sy;
                    }
                    else
                        d += d1;
                    array_x.Add((int)x); array_y.Add((int)y);
                    x += sx;
                }
            }
            else
            {
                double d = dx / dy;
                double d1 = dx / dy;

                array_x.Add((int)x0); array_y.Add((int)y0);
                double x = x0;
                double y = y0 + sy;
                for (int i = 1; i <= dy; i++)
                {
                    if (d > 0.5)
                    {
                        d += d1-1;
                        x += sx;
                    }
                    else
                        d += d1;
                    array_x.Add((int)x); array_y.Add((int)y);
                    y += sy;
                }
            }
        }

        
    }
}
