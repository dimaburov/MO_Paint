using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class Average
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
        
        public void Drow()
        {
            cutOff((int)x_left, (int)y_left, (int)x_right, (int)y_right);
        }

        public int cutOff(int x0, int y0, int x1, int y1)
        {
            if (Math.Abs(x1 - x0) <= 1 && Math.Abs(y1 - y0) <= 1) return 0;

            if (check(x0, y0) && check(x1, y1))
            {
                array_x.Add(x0); array_x.Add(x1);
                array_y.Add(y0); array_y.Add(y1);
                return 1;
            }

            

           // if(check(x0, y0)==false && check(x1, y1)==false) return 0;
            cutOff(x0,y0,(x0+x1)/2,(y0+y1)/2);
            cutOff((x0 + x1) / 2, (y0 + y1) / 2, x1, y1);
            return 1;
        }

        //AB что она лежит внутри отсекающего прямоугольника
        private bool check(int x, int y)
        {
            int x1 = 264, x2 = 528, y1 = 193, y2 = 307;
            //прямые у нас x = 264 x = 528 
            //             y = 193 y = 307
      
            if (x > x1 && x < x2)
            {
                if (y < y2 && y > y1) return true;
            }
            return false;
        }
    }
}
