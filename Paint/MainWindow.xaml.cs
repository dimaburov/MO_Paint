using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Задачи:
        //Начнём с рисования прямой
        
        //создаём класс линия
        private LineBresenhem line = new LineBresenhem();
        //2 способ рисования линии
        private Line line2 = new Line();
        //создаём класс окружности
        private Circle circle = new Circle();
        //создаём класс безье линий
        private Bezie bezie = new Bezie();
        //класс под алгоритм средней точки
        private Average average = new Average();
        //класс для алгоритма Цируса-Бека
        private Beka beka = new Beka();
        //класс линии с нецелочисленными координатами
        private LineBalueNonInt lineNonInt = new LineBalueNonInt();

        //точки контура для закрашивания
        private List<int> outline_x = new List<int>();
        private List<int> outline_y = new List<int>();

        private List<Point> point = new List<Point>();

        private List<Point> pointBeka = new List<Point>();


        public MainWindow()
        {
            InitializeComponent();
        }
        //Класс линии
        private LineBresenhem GetLineContains(){return line; }
        private void SetLineContains(LineBresenhem line_new) { line = line_new;}

        private Line GetLineStandartContains() { return line2; }
        private void SetLineStandartContains(Line line_new) { line2 = line_new; }

        //класс окружности
        private Circle GetCircleContains() { return circle; }
        private void SetCircleContains(Circle circle_new) { circle = circle_new; }
        //класс безье линий
        private Bezie GetBezieContains() { return bezie; }
        private void SetBezieContains(Bezie bezie_new) { bezie = bezie_new; }

        //средней точки
        private Average GetAverageContains() { return average; }
        private void SetAverageContains(Average newAverage) { average = newAverage; }

        //линия с нецелочисленными концами
        private LineBalueNonInt GetLineNonInt() { return lineNonInt; }
        private void SetLineNonInt(LineBalueNonInt newLineNonInt) { lineNonInt = newLineNonInt; }

        //точки контура
        private List<int> GetOutlineX() { return outline_x; }
        private void SetOutlineX(List<int> new_OuntlineX) { outline_x = new_OuntlineX; }

        private List<int> GetOutlineY() { return outline_y; }
        private void SetOutlineY(List<int> new_OuntlineY) { outline_y = new_OuntlineY; }

        private Beka GetBekaContains() { return beka; }
        private void SetBekaContains(Beka newBeka) { beka = newBeka; }

        //нажата левая кнопка мыши
        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);

            if (CheckLine.IsChecked == true)
            {
                LineBresenhem line = GetLineContains();
                line.Set_X_left_Y_left(p.X, p.Y);
            }
            else if (CheckStandartLine.IsChecked == true)
            {
                Line line2 = GetLineStandartContains();
                line2.Set_X_left_Y_left(p.X, p.Y);
            }
            else if (CheckCircl.IsChecked == true)
            {
                Circle circle = GetCircleContains();

                circle.Set_Y(p.Y, p.X);
                SetCircleContains(circle);
            }
            else if (CheckBezier.IsChecked == true)
            {
                Bezie bezie = GetBezieContains();

                bezie.SetArray_x(p.X);
                bezie.SetArray_y(p.Y);

                SetBezieContains(bezie);
            }
            else if (CheckBoxCoeNa.IsChecked == true)
            {


                point.Add(p);
            }
            else if (CheckAverage.IsChecked == true)
            {
                Average average = GetAverageContains();

                average.Set_X_left_Y_left(p.X, p.Y);
                SetAverageContains(average);
            }
            else if (CheckXoR.IsChecked == true)
            {
                List<int> array1 = GetOutlineX(); array1.Add((int)p.X);
                List<int> array2 = GetOutlineY(); array2.Add((int)p.Y);
                SetOutlineX(array1);
                SetOutlineY(array2);
            }
            else if (CheckBeka.IsChecked == true)
            {
                Beka beka = GetBekaContains();

                pointBeka.Add(p);

                beka.Set_X_left_Y_left(p.X, p.Y);

                SetBekaContains(beka);

            }
        }

        //нажата правая кнопка мыши
        private void MyCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);

            List<int> array_x = new List<int>();
            List<int> array_y = new List<int>();

            if (CheckLine.IsChecked == true)
            {
                array_x = new List<int>();
                array_y = new List<int>();
                LineBresenhem line = GetLineContains();
                line.Set_X_right_Y_right(p.X, p.Y);

                //рисование линии
                line.Bresenhem();
                //получим массивы точек и по ним нарисуем линию
                array_x = line.Get_array_x();
                array_y = line.Get_array_y();

                SetLineContains(new LineBresenhem());

            }
            else if (CheckStandartLine.IsChecked == true)
            {
                array_x = new List<int>();
                array_y = new List<int>();

                Line line2 = GetLineStandartContains();
                line2.Set_X_right_Y_right(p.X, p.Y);

                line2.drowLine();

                array_x = line2.Get_array_x();
                array_y = line2.Get_array_y();

                SetLineStandartContains(new Line());

            }
            else if (CheckCircl.IsChecked == true)
            {
                array_x = new List<int>();
                array_y = new List<int>();
                Circle circle = GetCircleContains();

                circle.Set_R(p.X - circle.Get_X());
                circle.DrowCircle();

                array_x = circle.Get_array_x();
                array_y = circle.Get_array_y();

                SetCircleContains(new Circle());
            }
            else if (CheckBezier.IsChecked == true)
            {
                array_x = new List<int>();
                array_y = new List<int>();
                Bezie bezie = GetBezieContains();


                bezie.SetArray_x(p.X);
                bezie.SetArray_y(p.Y);
                //рисуем кривую
                bezie.DrowBezie();

                array_x = bezie.GetArray_x();
                array_y = bezie.GetArray_y();

                //чистим класс
                SetBezieContains(new Bezie());
            }
            else if (CheckBoxCoeNa.IsChecked == true)
            {
                array_x = new List<int>();
                array_y = new List<int>();

                KoenSazer koen = new KoenSazer();

                koen.SazerlendCoen(264, 193, point[point.Count - 1], p);

                array_x = koen.Get_array_x();
                array_y = koen.Get_array_y();
                LineBresenhem createLine = new LineBresenhem();
                if (array_x.Count != 0) {
                    createLine.Set_X_left_Y_left((double)array_x[0], (double)array_y[0]);
                    createLine.Set_X_right_Y_right((double)array_x[1], (double)array_y[1]);
                }

                createLine.Bresenhem();

                array_x = createLine.Get_array_x();
                array_y = createLine.Get_array_y();
            }
            else if (CheckAverage.IsChecked == true)
            {
                array_x = new List<int>();
                array_y = new List<int>();
                Average average = GetAverageContains();

                average.Set_X_right_Y_right(p.X, p.Y);

                average.Drow();
                array_x = average.Get_array_x();
                array_y = average.Get_array_y();
                //рисуем эту линию

                LineBresenhem createLine = new LineBresenhem();
                if (array_x.Count!=0)
                {
                    createLine.Set_X_left_Y_left((double)array_x[0], (double)array_y[0]);
                    createLine.Set_X_right_Y_right((double)array_x[array_x.Count() - 1], (double)array_y[array_y.Count() - 1]);

                    createLine.Bresenhem();

                    array_x = createLine.Get_array_x();
                    array_y = createLine.Get_array_y();

                }

                SetAverageContains(new Average());
            }
            else if (CheckXoR.IsChecked == true)
            {
                //рисуем сначала контур для закрашивания
                LineBresenhem createLine = new LineBresenhem();

                Completion comp = new Completion();

                array_x = new List<int>();
                array_y = new List<int>();

                List<int> array1 = GetOutlineX(); array1.Add((int)p.X);
                List<int> array2 = GetOutlineY(); array2.Add((int)p.Y);

                for (int i = 0; i < array1.Count-1; i++)
                {
                    createLine.Set_X_left_Y_left(array1[i], array2[i]);
                    createLine.Set_X_right_Y_right(array1[i+1], array2[i+1]);

                    createLine.Bresenhem();

                    array_x = createLine.Get_array_x();
                    array_y = createLine.Get_array_y();

                    comp.SetOutline_x(array_x);
                    comp.SetOutline_y(array_y);

                    Drow(array_x, array_y);

                }

                createLine.Set_X_left_Y_left(array1[array1.Count-1], array2[array2.Count - 1]);
                createLine.Set_X_right_Y_right(array1[0], array2[0]);

                createLine.Bresenhem();

                array_x = createLine.Get_array_x();
                array_y = createLine.Get_array_y();

                Drow(array_x, array_y);

                comp.SetOutline_x(array_x);
                comp.SetOutline_y(array_y);

                comp.Drow();
                array_x = comp.GetArray_x();
                array_y = comp.GetArray_y();

                SetOutlineX(new List<int>());
                SetOutlineY(new List<int>());
            }
            else if (CheckBeka.IsChecked == true)
            {
                //array_x = new List<int>();
                //array_y = new List<int>();

                //Beka bek = GetBekaContains();

                //bek.Set_X_right_Y_right(p.X, p.Y);

                //bek.CyrusBek();

                //array_x = bek.Get_array_x();
                //array_y = bek.Get_array_y();

                //LineBresenhem line = new LineBresenhem();

                ////Console.WriteLine(array_x[0]);
                ////Console.WriteLine(array_y[0]);
                ////Console.WriteLine(array_x[1]);
                ////Console.WriteLine(array_y[1]);

                //line.Set_X_left_Y_left(bek.px2, bek.py2);
                //line.Set_X_right_Y_right(bek.px3, bek.py3);

                //line.Bresenhem();

                //array_x = line.Get_array_x();
                //array_y = line.Get_array_y();

                //Пробуем иначе
                List<Point> points = new List<Point>();
                ////x0=264 y0=307  x1=528  y1=193

                points.Add(new Point(264, 193));
                points.Add(new Point(528, 193));
                points.Add(new Point(528, 307));
                points.Add(new Point(264, 307));

                Console.WriteLine("pointBeka[0] X "+ pointBeka[0].X +" Y "+ pointBeka[0].Y);
                Console.WriteLine("P X " + p.X + " Y " + p.Y);

                Polygon s = new Polygon(points);
                s.DrawCirusBec(new Segment(pointBeka[0], p));

                LineBresenhem line = new LineBresenhem();

                Console.WriteLine(s.getX1());
                Console.WriteLine(s.getY1());
                Console.WriteLine(s.getX2());
                Console.WriteLine(s.getY2());

                line.Set_X_left_Y_left(s.getX1(), s.getY1());
                line.Set_X_right_Y_right(s.getX2(), s.getY2());

                line.Bresenhem();

                array_x = line.Get_array_x();
                array_y = line.Get_array_y();

                pointBeka = new List<Point>();

                Console.WriteLine("array_x");

                for (int i = 0; i < array_x.Count(); i++)
                {
                    Console.Write(" "+array_x[i]);
                }
                Console.WriteLine("array_y");
                for (int i = 0; i < array_y.Count(); i++)
                {
                    Console.Write(" " + array_y[i]);
                }

            }
            Drow(array_x, array_y);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyCanvas.Children.Clear();
        }

        private void CheckBoxCoeNa_Checked(object sender, RoutedEventArgs e)
        {
            List<int> array_x = new List<int>();
            List<int> array_y = new List<int>();

            //строим квадрта в центре 
            LineBresenhem box = new LineBresenhem();
            box.Box();

            array_x = box.Get_array_x();
            array_y = box.Get_array_y();

            for (int i = 0; i < array_x.Count(); i++)
            {
                Rectangle rec = new Rectangle();
                rec.Width = 1;
                rec.Height = 1;
                rec.Fill = new SolidColorBrush(Colors.Black);
                Canvas.SetTop(rec, array_y[i] - 80);
                Canvas.SetLeft(rec, array_x[i]);
                MyCanvas.Children.Add(rec);
            }
        }


        private void Drow(List<int> array_x, List<int> array_y)
        {
            for (int i = 0; i < array_x.Count(); i++)
            {
                Rectangle rec = new Rectangle();
                rec.Width = 1;
                rec.Height = 1;
                rec.Fill = new SolidColorBrush(Colors.Black);
                Canvas.SetTop(rec, array_y[i] - 80);
                Canvas.SetLeft(rec, array_x[i]);
                MyCanvas.Children.Add(rec);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LineBalueNonInt line = new LineBalueNonInt();

            line.Set_X_left_Y_left(double.Parse(x_start.Text), double.Parse(y_start.Text) +80);
            line.Set_X_right_Y_right(double.Parse(x_end.Text), double.Parse(y_end.Text) + 80);

            List<int> array_x = new List<int>();
            List<int> array_y = new List<int>();

            line.Drow();

            array_x = line.Get_array_x();
            array_y = line.Get_array_y();

            Drow(array_x, array_y);

        }
    }

   
    
}
