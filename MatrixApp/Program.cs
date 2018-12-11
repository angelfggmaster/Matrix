using Matrix.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixApp.Utilities;

namespace MatrixApp
{
    /// <summary>
    /// Clase programa principal
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Método de inicio
        /// </summary>
        /// <param name="args">Argumentos de la línea de comandos</param>
        static void Main(string[] args)
        {
            Matrix.Services.Models.Matrix A = new Matrix.Services.Models.Matrix(2,3);

            A.Content = new object[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

            Matrix.Services.Models.Matrix B = 2 * A;

            Utilities.Utilities.PrintMatrix(A);
            Console.WriteLine();
            Utilities.Utilities.PrintMatrix(B);

            Console.ReadLine();
        }
    }
}
