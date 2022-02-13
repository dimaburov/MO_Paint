using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    //заполнение с затравкой
    class Completion
    {
        private List<int> arrayOutline_x = new List<int>();
        private List<int> arrayOutline_y = new List<int>();

        private List<int> array_x = new List<int>();
        private List<int> array_y = new List<int>();

        public void SetOutline_x(List<int> newArray_x)
        {
            for (int i = 0; i < newArray_x.Count; i++)
            {
                arrayOutline_x.Add(newArray_x[i]);
            }
        }

        public void SetOutline_y(List<int> newArray_y)
        {
            for (int i = 0; i < newArray_y.Count; i++)
            {
                arrayOutline_y.Add(newArray_y[i]);
            }
        }

        public List<int> GetArray_x() { return array_x; }
        public List<int> GetArray_y() { return array_y; }

        public void Drow()
        {
            int[,] Grid = new int[450, 800];

            //заполняем сначала границу
            for (int i = 0; i < arrayOutline_x.Count; i++)
            {
                Grid[arrayOutline_y[i], arrayOutline_x[i]] = 1;
            }

            //выполняем заливку
            for (int i = 0; i <Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1)-1; j++)
                {
                    Grid[i, j + 1] = XoR(Grid[i, j + 1], Grid[i, j]);

                    //добавляем точку для рисования
                    if (Grid[i, j + 1] == 1)
                    {
                        array_y.Add(i);
                        array_x.Add(j+1);
                    }
                }

            }

        
        }

        private int XoR(int number1, int number2)
        {
            if (number1 != number2) return 1;
            return 0;
        }

    }
}
