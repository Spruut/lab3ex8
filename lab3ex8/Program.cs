using System;

namespace lab3ex8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of matrix ");
            int N = Int32.Parse(Console.ReadLine());
            int[,] matrix = new int[N, N];
            Random random = new Random();

            RandomMatrize(matrix, random);
            WriteMatrix(matrix);

            int k = 0;

            Console.WriteLine($"Determinate of the matrix = {CountDetMatrix(matrix, k, out int detMatrix)}");
        }
        static void RandomMatrize(int[,] array, Random random)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(0, 9);
                }
            }
        }
        static void WriteMatrix(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]}  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static int CountDetMatrix(int[,] array, int k, out int detMatrix)
        {
            detMatrix = 0;
            if (k == array.GetLength(0))
            {
                return detMatrix;
            }
            else
            {
                detMatrix = array[0, k] * CountAlgAdding(array, out int[,] minor, k, out int algAdding);
                k++;
            }
            return detMatrix + CountDetMatrix(array, k, out detMatrix);
        }
        static int CountAlgAdding(int[,] array, out int[,] array2, int k, out int algAdding)
        {
            array2 = new int[array.GetLength(0) - 1, array.GetLength(0) - 1];
            int detMinor = 0;
            if (array.GetLength(0) == 4)
            {
                bool check = false;
                for (int i = 0; i < array2.GetLength(0); i++)
                {
                    for (int j = 0; j < array2.GetLength(0); j++)
                    {
                        if (i != k)
                        {
                            if (!check)
                                array2[j, i] = array[j + 1, i];
                            else
                                array2[j, i] = array[j + 1, i + 1];
                        }
                        else
                        {
                            array2[j, i] = array[j + 1, i + 1];
                            check = true;
                        }
                    }
                }
                detMinor += array2[0, 0] * array2[1, 1] * array2[2, 2] + array2[0, 1] * array2[1, 2] * array2[2, 0] + array2[1, 0] * array2[0, 2] * array2[2, 1] - array2[2, 0] * array2[1, 1] * array2[0, 2] - array2[1, 0] * array2[0, 1] * array2[2, 2] - array2[0, 0] * array2[2, 1] * array2[1, 2];
            }
            else if (array.GetLength(0) == 3)
            {
                bool check = false;
                for (int i = 0; i < array2.GetLength(0); i++)
                {
                    for (int j = 0; j < array2.GetLength(0); j++)
                    {
                        if (i != k)
                        {
                            if (!check)
                                array2[j, i] = array[j + 1, i];
                            else
                                array2[j, i] = array[j + 1, i + 1];
                        }
                        else
                        {
                            array2[j, i] = array[j + 1, i + 1];
                            check = true;
                        }
                    }
                }
                detMinor = array2[0, 0] * array2[1, 1] - array2[0, 1] * array2[1, 0];
            }
            else if (array.GetLength(0) == 2)
            {
                detMinor = array[1, (array.GetLength(1) - 1) - k];
            }
            else
            {
                bool check = false;
                for (int i = 0; i < array2.GetLength(0); i++)
                {
                    for (int j = 0; j < array2.GetLength(0); j++)
                    {
                        if (i != k)
                        {
                            if (!check)
                                array2[j, i] = array[j + 1, i];
                            else
                                array2[j, i] = array[j + 1, i + 1];
                        }
                        else
                        {
                            array2[j, i] = array[j + 1, i + 1];
                            check = true;
                        }
                    }
                }
                int l = 0;
                detMinor = CountDetMatrix(array2, l, out int detMatrix);
            }
            algAdding = (int)Math.Pow(-1, 1 + (k + 1)) * detMinor;
            return algAdding;
        }
    }
}
