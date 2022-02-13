using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class Beka
    {
        private double x_left;
        private double y_left;
        private double x_right;
        private double y_right;

        public int px2, py2, px3, py3;

        //массив для хранения точек созданной линии
        private List<int> array_x = new List<int>();
        private List<int> array_y = new List<int>();

        public void Set_X_left_Y_left(double x_left, double y_left) { this.x_left = x_left; this.y_left = y_left; }
        public void Set_X_right_Y_right(double x_right, double y_right) { this.x_right = x_right; this.y_right = y_right; }

        public List<int> Get_array_x() { return array_x; }
        public List<int> Get_array_y() { return array_y; }

        

        public void CyrusBek()
        {
            //
            Console.WriteLine("x_left " + x_left);
            Console.WriteLine("y_left " + y_left);
            Console.WriteLine("x_right " + x_right);
            Console.WriteLine("y_right " + y_right);

            Console.WriteLine("p!!!!! ");
            //{ 264 + 300, 264 + 300, 528 + 300, 528 + 300};
            int[] cord_x = new int[]{400, 400, 700, 700 };
            int[] cord_y = new int[]{193, 307, 307, 193};

            int k = cord_x.Count();

            Console.WriteLine("k " + k);
            double dx =(x_right - x_left);
            double dy = (y_right - y_left);
            double px =0, py=0, px1=0, py1=0;
            List<double> normalsX = new List<double>();
            List<double> normalsY = new List<double>();



            double wx;
            double wy;
            int n = cord_x.Count();
            double tl = 0;
            double tu = 1;
            double t, Ddotn, Wdotn;

            for (int i = 0; i < n-1; i++)
            {
                normalsY.Add(cord_y[i+1] - cord_y[i]);
                normalsX.Add(cord_x[i] - cord_x[i+1]);

            }

            normalsY.Add(cord_y[0] - cord_y[n - 1]);
            normalsX.Add(cord_x[n - 1] - cord_x[0]);

            for (int i = 0; i < k; i++)
            {
                wx = x_left - cord_x[i];
                wy = y_left -cord_y[i];

                Ddotn = dotProduct(dx, dy, normalsX[i], normalsY[i]);
                Wdotn = dotProduct(wx, wy, normalsX[i], normalsY[i]);
                Console.WriteLine("Ddotn " + Ddotn);
                Console.WriteLine("Wdotn " + Wdotn);

                if (Ddotn != 0)
                {
                    t = (-1 * Wdotn) / Ddotn;

                    Console.WriteLine("t  " + t);

                    if (Ddotn > 0)
                    {
                        if (t > 1)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("t1  до " + tl);
                            Console.WriteLine("t  до " + t);
                            tl = Math.Max(t, tl);
                            Console.WriteLine("t1  " + tl);
                        }
                    }
                    else
                    {
                        if (t < 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("tu  до " + tu);
                            Console.WriteLine("t  до " + t);
                            tu = Math.Min(t, tu);
                            Console.WriteLine("tu  " + tu);
                        }
                    }
                }
                else
                {
                    if (Wdotn < 0)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("tl " + tl);
            Console.WriteLine("tu " + tu);
            if (tl <= tu)
            {
                px = (x_left + (x_right - x_left) * tl);
                py = (y_left + (y_right - y_left) * tl);
                px1 = (x_left + (x_right - x_left) *tu);
                py1 = (y_left + (y_right - y_left) * tu);

            }
            Console.WriteLine("px "+px);
            Console.WriteLine("px1 "+px1);
            Console.WriteLine("py "+py);
            Console.WriteLine("py1 "+py1);
            //array_x[0]= px; array_x[1] =px1;
            //array_y[0] = py; array_y[1]  =py1;

            //костыль
            //if (px < 200 && px1 < 200 )
            //{
            //    px2 = 0;
            //    py2 = 0;
            //    px3 = 1;
            //    py3 = 1;
            //}
             px2 = (int)px; py2 = (int)py; px3 = (int)px1; py3 = (int)py1;
            //else if(px3 < 400) { px2 = 0; py2 = 0; px3 = 1; py3 = 1; }


        }
        private double dotProduct(double x1, double y1, double x2, double y2)
        {
            return x1 * x2 + y1 * y2;
        }
    }


   
}

