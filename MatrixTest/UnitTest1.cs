using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix.Services;
using System.Globalization;

namespace MatrixTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateMatrixTest()
        {
            Matrix.Services.Models.Matrix A = Matrix.Services.Services.MatrixManager.CreateRandomMatrixInt(10, 10);
            bool result = true;

            for (uint i = 0; i < A.Rows; i++)
            {
                for (uint j = 0; j < A.Columns; j++)
                {
                    if (int.Parse(A.Content[i, j].ToString()) < -100 && int.Parse(A.Content[i, j].ToString()) > 100)
                    {
                        result = false;
                    }
                }
            }

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void SumMatrixTest()
        {
            Matrix.Services.Models.Matrix A = Matrix.Services.Services.MatrixManager.CreateRandomMatrixInt(10, 10);
            Matrix.Services.Models.Matrix B = Matrix.Services.Services.MatrixManager.CreateRandomMatrixInt(10, 10);

            Matrix.Services.Models.Matrix matResult = A + B;

            bool result = true;

            for (uint i = 0; i < matResult.Rows; i++)
            {
                for (uint j = 0; j < matResult.Columns; j++)
                {
                    if (Convert.ToInt16(matResult.Content[i, j]) != Convert.ToInt16(A.Content[i, j]) + Convert.ToInt16(B.Content[i, j]))
                    {
                        result = false;
                    }
                }
            }

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TransposeMatrixTest()
        {
            Matrix.Services.Models.Matrix A = Matrix.Services.Services.MatrixManager.CreateRandomMatrixInt(10, 10);

            Matrix.Services.Models.Matrix B = Matrix.Services.Services.MatrixManager.TransposeMatrix(A);

            bool result = true;

            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Columns; j++)
                {
                    if (!A.Content[i, j].Equals(B.Content[j, i]))
                    {
                        result = false;
                        break;
                    }
                }
            }

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ProductMatIntTest()
        {
            Matrix.Services.Models.Matrix A = new Matrix.Services.Models.Matrix(2, 3);

            A.Content = new object[,] { { 1, 2, 3 }, { 4, 5, 6 } };

            Matrix.Services.Models.Matrix B = 2 * A;

            Matrix.Services.Models.Matrix result = new Matrix.Services.Models.Matrix(2, 3);
            result.Content = new object[,] { { 2, 4, 6 }, { 8, 10, 12 } };

            Assert.AreEqual(true, B.Equals(result));
        }

        [TestMethod]
        public void SubtractionMatrixTest()
        {
            Matrix.Services.Models.Matrix A = new Matrix.Services.Models.Matrix(2, 3);

            A.Content = new object[,] { { 1, 2, 3 }, { 4, 5, 6 } };

            Matrix.Services.Models.Matrix B = new Matrix.Services.Models.Matrix(2, 3);

            A.Content = new object[,] { { 3, 2, 1 }, { 6, 5, 4 } };

            Matrix.Services.Models.Matrix matResult = A - B;

            Matrix.Services.Models.Matrix matExpected = new Matrix.Services.Models.Matrix(2, 3);

            matExpected.Content = new object[,] { { -2, 0, 2 }, { -2, 0, 2 } };

            Assert.AreEqual(true, matResult.Equals(matExpected));
        }

        [TestMethod]
        public void ProductMatrixTest()
        {
            Matrix.Services.Models.Matrix A = new Matrix.Services.Models.Matrix(2, 2);
            A.Content = new object[,] { { 1, 3 }, { -1, 2 } };

            Matrix.Services.Models.Matrix B = new Matrix.Services.Models.Matrix(2, 3);
            B.Content = new object[,] { { 1, 3, 2 }, { 2, -3, 1 } };

            Matrix.Services.Models.Matrix matExpected = new Matrix.Services.Models.Matrix(2, 3);
            matExpected.Content = new object[,] { { 7, -6, 1 }, { 3, -9, -4 } };

            Matrix.Services.Models.Matrix matResult = A * B;

            Assert.AreEqual(true, matExpected.Equals(matResult));
            
        }
    }
}
