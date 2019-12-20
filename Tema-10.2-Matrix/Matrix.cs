using System;
using System.Text;

namespace Tema_10._2_Matrix
{
    // Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals).
    public class Matrix<T>
    {
        
        private readonly T[,] matrix = null;

        public Matrix(int rows, int columns, params T[] elements)
        {
            this.matrix = new T[rows, columns];
            this.Rows = rows;
            this.Columns = columns;           
        }

        public int Rows { get; set; }

        public int Columns { get; set; }

        // Problem 2 - Matrix indexer
        public T this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }
            set
            {
                this.matrix[row, col] = value;
            }
        }

        // Problem 3. Matrix operations

        // Override ToString()
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                    result.AppendFormat("{0,4}", this.matrix[row, col]);
                result.AppendLine();
            }

            return result.ToString();
        }

        // (m1 + m2)
        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            return AdditionSubtraction(matrix1, matrix2, true);
        }

        // (m1 - m2)
        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            return AdditionSubtraction(matrix1, matrix2, false);
        }

        private static Matrix<T> AdditionSubtraction(Matrix<T> matrix1, Matrix<T> matrix2, bool op)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                throw new InvalidOperationException("Invalid operation!");

            Matrix<T> result = new Matrix<T>(matrix1.Rows, matrix1.Columns);

            for (int row = 0; row < result.Rows; row++)
                for (int col = 0; col < result.Columns; col++)
                    result[row, col] = matrix1[row, col] + (op ? matrix2[row, col] : -(dynamic)matrix2[row, col]);

            return result;
        }

        // (m1 * m2)
        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Matrix<T> result = new Matrix<T>(matrix1.Rows, matrix2.Columns);

            for (int row = 0; row < result.Rows; row++)
                for (int col = 0; col < result.Columns; col++)
                    for (int k = 0; k < matrix1.Columns; k++) 
                        result[row, col] += (dynamic)matrix1[row, k] * matrix2[k, col];

            return result;
        }

    }
}
