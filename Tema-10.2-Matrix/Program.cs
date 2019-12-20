using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tema_10._2_Matrix
{
    class Program
    {
        static readonly Random rnd = new Random();

        static void Main(string[] args)
        {
            var matrix1 = new Matrix<int>(3, 3,
            1, 2, 0,
            0, 1, 1,
            2, 0, 1);

            var matrix2 = new Matrix<int>(3, 3);

            for (int row = 0; row < matrix2.Rows; row++)
                for (int col = 0; col < matrix2.Columns; col++)
                    matrix2[row, col] = rnd.Next(10);

            Console.WriteLine("First Matrix is:", matrix1.Rows, matrix1.Columns);
            Console.WriteLine(matrix1);

            Console.WriteLine("Second Matrix is:", matrix2.Rows, matrix2.Columns);
            Console.WriteLine(matrix2);

            Console.WriteLine("Add");
            Console.WriteLine(matrix1 + matrix2);

            Console.WriteLine("Sub");
            Console.WriteLine(matrix1 - matrix2);

            Console.WriteLine("Multiplication:");
            Console.WriteLine(matrix1 * matrix2);

            Console.ReadLine();
        }
    }
}
