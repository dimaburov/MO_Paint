using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class LineBalueNonInt
    {
        //Изоражение отрезка с нецелочисленными координатами концов
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

        public void Drow()
        {

            int x = 0;
            int y = 0;
            int a = (int)Math.Round(x_right - x_left);
            int b = (int)Math.Round(y_right - y_left);
            int x_mnoj = 1, y_mnoj = 1;
            if (a < 0)
            {
                a = -a;
                x_mnoj = -1;
            }
            if (b < 0)
            {
                b = -b;
                y_mnoj = -1;
            }
            int c = 1000;
            double dh = c / Math.Abs(x_right - x_left);

            double h = 0;
            double dv = c / Math.Abs(y_right - y_left);

            double v = 0;
            while (h < c && v < c)
            {
                array_x.Add(x * x_mnoj + (int)Math.Round(x_left));
                array_y.Add(y * y_mnoj + (int)Math.Round(y_left));
                if (h < v)
                {
                    x++;
                    h += dh;
                }
                else if (h > v)
                {
                    y++;
                    v += dv;
                }
                else
                {
                    array_x.Add(x * x_mnoj + (int)Math.Round(x_left));
                    array_y.Add((y + 1) * y_mnoj + (int)Math.Round(y_left));

                    x++;
                    y++;
                    h += dh;
                    v += dv;
                }
            }
        }
    }
}
