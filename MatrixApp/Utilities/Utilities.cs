using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApp.Utilities
{
    public static class Utilities
    {
        public static void PrintMatrix(Matrix.Services.Models.Matrix mat)
        {
            int xInit = Console.CursorTop;

            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    Console.SetCursorPosition((j * 5), i + xInit +2 );
                    Console.Write(mat.Content[i, j].ToString().PadLeft(5));
                }
            }
        }
    }
}
