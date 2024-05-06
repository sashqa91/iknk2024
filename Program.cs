using System;

namespace Sorting
{
    internal class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            // Количество элементов
            int[] N = { 20, 40, 80, 160, 320, 640, 1280 };
            int comparisons, permutations;

            // Цикл по всем размерам
            for (int i = 0; i < N.Length; i++)
            {
                int[] arr = new int[N[i]];
                FillRandom(arr);
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine("\nN = " + N[i]);
                comparisons = permutations = 0;
                // Пузырьковая сортировка массива
                BubbleSort(arr, out comparisons, out permutations);
                Console.WriteLine("Пузырьковая сортировка:");
                PrintResults(N[i], comparisons, permutations);

                comparisons = permutations = 0;
                FillRandom(arr);
                // Сортировка отбором
                OtborSort(arr, out comparisons, out permutations);
                Console.WriteLine("\nСортировка отбором:");
                PrintResults(N[i], comparisons, permutations);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Пузырьковая сортировка массива
        /// </summary>
        /// <param name="inArray">Массив</param>
        /// <param name="comparisons">Количество сравнений</param>
        /// <param name="permutations">Количество перестановок</param>
        static void BubbleSort(int[] inArray, out int comparisons, out int permutations)
        {
            comparisons = permutations = 0;

            // Цикл по массиву
            for (int i = 0; i < inArray.Length; i++)
                for (int j = 0; j < inArray.Length - i - 1; j++)
                {
                    if (inArray[j] > inArray[j + 1])
                    {
                        comparisons++;
                        int temp = inArray[j];
                        inArray[j] = inArray[j + 1];
                        inArray[j + 1] = temp;
                        permutations++;
                    }
                }
        }

        /// <summary>
        /// Сортировка отбором
        /// </summary>
        /// <param name="inArray">Массив</param>
        /// <param name="comparisons">Количество сравнений</param>
        /// <param name="permutations">Количество перестановок</param>
        static void OtborSort(int[] inArray, out int comparisons, out int permutations)
        {
            comparisons = permutations = 0;

            // Цикл по массиву
            for (int i = 0; i < inArray.Length - 1; i++)
            {
                // Поиск минимального числа
                int min = i;
                for (int j = i + 1; j < inArray.Length; j++)
                {
                    if (inArray[j] < inArray[min])
                    {
                        min = j;
                        comparisons++;
                    }
                }
                //обмен элементов
                int temp = inArray[min];
                inArray[min] = inArray[i];
                inArray[i] = temp;
                permutations++;
            }
        }

        /// <summary>
        /// Заполнить массив случайными данными
        /// </summary>
        /// <param name="inArray">Массив</param>
        static void FillRandom(int[] inArray)
        {
            // Цикл по массиву
            for (int i = 0; i < inArray.Length; i++)
                inArray[i] = rnd.Next();
        }

        /// <summary>
        /// Вывод результатов
        /// </summary>
        /// <param name="N">Количество элементов</param>
        /// <param name="comparisons">Количество сравнений</param>
        /// <param name="permutations">Количество перестановок</param>
        static void PrintResults(int N, int comparisons, int permutations)
        {
            Console.WriteLine("абсолютные значения:");
            Console.WriteLine("сравнений - " + comparisons + "; перестановок - " + permutations);
            Console.WriteLine("нормированные значения:");
            Console.WriteLine("сравнений - " + comparisons / N + "; перестановок - " + permutations / N);
            Console.WriteLine("логарифмические значения:");
            Console.WriteLine("сравнений - " + Math.Log(comparisons) + "; перестановок - " + Math.Log(permutations));
        }
    }
}
