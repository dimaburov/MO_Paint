using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class Bezie
    {
        private List<double> array_x = new List<double>();
        private List<double> array_y = new List<double>();

        private List<int> array_finish_x = new List<int>();
        private List<int> array_finish_y = new List<int>();

        public void SetArray_x(double x) { array_x.Add(x);}
        public void SetArray_y(double y) {array_y.Add(y);}

        public List<int> GetArray_x() { return array_finish_x; }
        public List<int> GetArray_y() { return array_finish_y; }

        //алгоритм для двух точек
        public void DrowBezie()
        {
            switch (array_x.Count())
            {
                case 2:
                    Bezie2Point();
                    break;
                case 3:
                    Bezie3Point();
                    break;
                case 4:
                    Bezie4Point();
                    break;
            }
        }

        private void Bezie2Point()
        {
            double t = 0;
            //приращение
            double dt = 1/Math.Abs(Math.Abs(array_x[0]) - Math.Abs(array_x[1]));
            while (t < 1)
            {
                //формула для  2 точек
                array_finish_x.Add((int)((1-t)*array_x[0]+t* array_x[1]));
                array_finish_y.Add((int)((1 - t) * array_y[0] + t * array_y[1]));
                t += dt;
            }
        }

        private void Bezie3Point()
        {
            double t = 0;
            //приращение
            double dt = 1 / Math.Abs(Math.Abs(array_x[0]) - Math.Abs(array_x[2]));
            while (t < 1)
            {
                //формула для  2 точек
                array_finish_x.Add((int)((1 - t)*(1-t) * array_x[0] +2*(1-t)*t*array_x[1] + t*t*array_x[2]));
                array_finish_y.Add((int)((1 - t) * (1 - t) * array_y[0] + 2 * (1 - t) * t * array_y[1] + t * t * array_y[2]));
                t += dt;
            }
        }

        private void Bezie4Point()
        {
            double t = 0;
            //приращение
            double dt = 1 / Math.Abs(Math.Abs(array_x[0]) - Math.Abs(array_x[3]));
            while (t < 1)
            {
                //формула для  2 точек
                array_finish_x.Add((int)((1 - t) * (1 - t) * (1 - t) * array_x[0] + 3 * (1 - t)*(1 - t)* t * array_x[1] + 3*(1 - t) * t * t *  array_x[2] + t * t * t * array_x[3]));
                array_finish_y.Add((int)((1 - t) * (1 - t) * (1 - t) * array_y[0] + 3 * (1 - t) * (1 - t) * t * array_y[1] + 3 * (1 - t) * t * t * array_y[2] + t * t * t * array_y[3]));
                t += dt;
            }
        }

    }
}
