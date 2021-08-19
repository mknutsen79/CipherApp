using System;
using System.Collections.Generic;
using System.Text;

namespace cipherApp
{
    class ArrayBuilder
    {
        HashSet<string> alphabete = new HashSet<string>();
        string[,] matrix = new string[5, 5];

        public ArrayBuilder(HashSet<string> a)
        {
            this.alphabete = a;
        }

        public void buildMatrix()
        {
            String[] start = new string[alphabete.Count];
            alphabete.CopyTo(start);
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);
            int index = 0;
            for(int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    matrix[i, j] = start[index];
                    index++;
                }
            }

        }

        public void printMatrix()
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for(int i = 0; i < rowLength; i++)
            {
                for(int j = 0; j <colLength; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public string [,] getMatrix()
        {
            return matrix;
        }
    }
}
