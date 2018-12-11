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

            matResult.Content = new object[rows, columns];

            for (uint i = 0; i < rows; i++)
            {
                for (uint j = 0; j < columns; j++)
                {
                    matResult.Content[i, j] = GenerarNumero();
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
            
            matResult.Content = new object[mat.Columns,mat.Rows];

            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    matResult.Content[j, i] = mat.Content[i, j];
                }
            }

            return matResult;
        }
    }
}
