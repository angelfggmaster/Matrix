using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Services.Services
{
    public static class MatrixManager
    {
        static Random r = new Random();
        public static Models.Matrix CreateRandomMatrixInt(int rows, int columns)
        {
            Models.Matrix matResult = new Models.Matrix(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matResult[i, j] = GenerarNumero();
                }
            }

            return matResult;
        }

        private static int GenerarNumero()
        { 
            return r.Next(-100, 100);
        }

        public static Models.Matrix TransposeMatrix(Models.Matrix mat)
        {
            Models.Matrix matResult = new Models.Matrix(mat.Rows, mat.Columns);

            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    matResult[j, i] = mat[i, j];
                }
            }

            return matResult;
        }

        public static double DeterminantMatrix(Models.Matrix mat)
        {
            if (!mat.IsSquared)
            {
                throw new InvalidOperationException("La matriz debe ser cuadrada.");
            }

            if (mat.Rows==1 && mat.Columns == 1)
            {
                return mat[0, 0];
            }

            double determinante = 0;
            double aux = 0;
            int c;

            if (mat.Rows == 2 && mat.Columns == 2)
            {
                return mat[0, 0] * mat[1, 1] - mat[1, 0] * mat[0, 1];
            }
            else
            {
                for (int j = 0; j < mat.Rows; j++)
                {
                    Models.Matrix menor = new Models.Matrix(mat.Rows - 1, mat.Columns - 1);
                    for (int k = 1; k < mat.Rows; k++)
                    {
                        c = 0;
                        for (int l = 0; l < mat.Rows; l++)
                        {
                            if (l != j)
                            {
                                menor[k - 1, c] = mat[k, l];
                                c++;
                            }
                        }
                    }
                    aux = Math.Pow(-1, 2 + j) * mat[0, j] * DeterminantMatrix(menor);
                    determinante += aux;
                }
            }
            return determinante;
        }
    }
}
