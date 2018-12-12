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
        public double this[int i, int j]
        {
            get { return Convert.ToDouble(Content[i, j]); }
            set { Content[i, j] = value; }
        }
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

        public bool IsSquared { get { return this.Rows == this.Columns; } }
        #endregion

        public static implicit operator short(Models.Matrix mat)
        {
            return Convert.ToInt16(mat[0, 0]);
        }

        public static Matrix operator +(Matrix mat1, Matrix mat2)
        {
            Matrix matResult = new Matrix(mat1.Rows, mat1.Columns);

            for (int i = 0; i < matResult.Rows; i++)
            {
                for (int j = 0; j < matResult.Columns; j++)
                {
                    matResult[i, j] = Convert.ToInt16(mat1[i, j]) + Convert.ToInt16(mat2[i, j]);
                }
            }

            return matResult;
        }

        public static Matrix operator *(int k, Matrix mat)
        {
            Matrix matResult = new Matrix(mat.Rows, mat.Columns);

            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    matResult[i, j] = Convert.ToDouble(mat[i, j]) * k;
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
                        acum += Convert.ToDouble(mat1[i, k], CultureInfo.InvariantCulture) * Convert.ToDouble(mat2[k, j], CultureInfo.InvariantCulture);
                    }
                    matResult[i, j] = acum;
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
                for (int j = 0; j < this.Columns; j++)
                {
                    if (!this[i, j].Equals(B[i, j]))
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
