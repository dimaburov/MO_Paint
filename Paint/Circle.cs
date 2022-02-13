using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class Circle
    {
        private double x;
        private double y;
        private double r;

        //массив для хранения точек созданной линии
        private List<int> array_x = new List<int>();
        private List<int> array_y = new List<int>();

        public void Set_Y(double y, double x) { this.y = y; this.x = x; }
        public double Get_X() { return x; }
        public void Set_R(double r) { this.r = r; }

        public List<int> Get_array_x() { return array_x; }
        public List<int> Get_array_y() { return array_y; }

        public void DrowCircle()
        {
            int x = (int)(-r);
            int y = 0;

            int F = 1 - (int)r;
            int delta_Fs = 3;
            int delta_Fd = 5 - 2 * (int)r;

            while (x + y < 0)
            {
                array_x.Add(x+ (int)this.x);
                array_y.Add(y+ (int)this.y);
                array_x.Add(x + (int)this.x);
                array_y.Add((int)this.y -y);
                array_x.Add((int)this.x-x);
                array_y.Add((int)this.y-y);
                array_x.Add((int)this.x-x);
                array_y.Add(y + (int)this.y);

                array_x.Add((int)this.x+y);
                array_y.Add((int)this.y-x);
                array_x.Add((int)this.x + y);
                array_y.Add((int)this.y +x);
                array_x.Add((int)this.x - y);
                array_y.Add((int)this.y - x);
                array_x.Add((int)this.x - y);
                array_y.Add((int)this.y + x);

                if (F > 0)
                {
                    // d: Диагональное смещение
                    F += delta_Fd;
                    x++; y++;
                    delta_Fs += 2;
                    delta_Fd += 4;
                }
                else
                {
                    // s: Вертикальное смещение
                    F += delta_Fs;
                    y++;
                    delta_Fs += 2;
                    delta_Fd += 2;
                }
            }
        }
    }
}
