using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Services.Models
{
    public class Matrix
    {
        public Matrix(int rows, int columns)
        {
            this.Content = new object[rows, columns];
        }

        #region Properties
        public int Rows
        {
            get
            {
                return this.Content.GetLength(0);
            }
        }
        public int Columns
        {
            get
            {
                return this.Content.GetLength(1);
            }
        }

        public object[,] Content { get; set; }
        #endregion

        public static implicit operator short(Models.Matrix mat)
        {
            return Convert.ToInt16(mat.Content[0, 0]);
        }

        public static Matrix operator +(Matrix mat1, Matrix mat2)
        {
            Matrix matResult = new Matrix(mat1.Rows, mat1.Columns);

            matResult.Content = new object[matResult.Rows, matResult.Columns];

            for (uint i = 0; i < matResult.Rows; i++)
            {
                for (uint j = 0; j < matResult.Columns; j++)
                {
                    matResult.Content[i, j] = Convert.ToInt16(mat1.Content[i, j]) + Convert.ToInt16(mat2.Content[i, j]);
                }
            }

            return matResult;
        }

        public static Matrix operator *(int k, Matrix mat)
        {
            Matrix matResult = new Matrix(mat.Rows, mat.Columns);

            for (uint i = 0; i < mat.Rows; i++)
            {
                for (uint j = 0; j < mat.Columns; j++)
                {
                    matResult.Content[i, j] = Convert.ToDouble(mat.Content[i, j]) * k;
                }
            }

            return matResult;
        }

        public static Matrix operator *(Matrix mat1, Matrix mat2)
        {
            Matrix matResult = new Matrix(mat1.Rows, mat2.Columns);

            int i, j;
            for (i = 0; i < matResult.Rows; i++)
            {
                for (j = 0; j < matResult.Columns; j++)
                {
                    var acum = 0.0;
                    for (int k = 0; k < matResult.Rows; k++)
                    {
                        acum += Convert.ToDouble(mat1.Content[i, k], CultureInfo.InvariantCulture) * Convert.ToDouble(mat2.Content[k, j], CultureInfo.InvariantCulture);
                    }
                    matResult.Content[i, j] = acum;
                }
            }

            return matResult;
        }

        public override bool Equals(object obj)
        {
            Matrix B = (Matrix)obj;

            if (this.Rows != B.Rows || this.Columns != B.Columns)
            {
                return false;
            }

            for (int i = 0; i < this.Rows; i++)
            {
                for (uint j = 0; j < this.Columns; j++)
                {
                    if (this.Content[i, j].Equals(B.Content[i, j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static Matrix operator -(Matrix mat1, Matrix mat2)
        {
            Matrix matResult = mat1 + (-1 * mat2);
            return matResult;
        }

    }
}
