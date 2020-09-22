using System;
using System.Linq;
using System.Text;

namespace oop_lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //////////////////////////////////////////////////////////1
            bool statement = true;
            byte numB = 255; //2^8
            sbyte numSB = -127;
            short numS = -32768; //(2^8)^8
            ushort numUS = (32767 * 2) + 1;
            int numI = -2147483648; // short(2^8)^8 * 256^2
            uint numUI = 0;
            long numL = -1;
            ulong numUL = 1;
            float numF = 0.03f;
            double numD = 0.03;
            decimal numDec = 0.03m;
            char symbol = ' ';

            Console.WriteLine($"{statement}");
            Console.WriteLine($"{numB}");
            Console.WriteLine($"{numSB}");
            Console.WriteLine($"{numS}");
            Console.WriteLine($"{numUS}");
            Console.WriteLine($"{numI}");
            Console.WriteLine($"{numUI}");
            Console.WriteLine($"{numL}");
            Console.WriteLine($"{numUL}");
            Console.WriteLine($"{numF}");
            Console.WriteLine($"{numD}");
            Console.WriteLine($"{numDec}");
            Console.WriteLine($"{symbol} \n");

            numS = numB; //5 операций неявного приведения
            numI = numS;
            numD = numF;
            numDec = numI;
            numF = numI;

            numI = (int)numUI; //5 операций явного приведения
            numB = (byte)numSB;
            numUL = (ulong)numL;
            numI = (int)numF;
            numF = (float)numD;

            int newNum = Convert.ToInt32(statement);
            Console.WriteLine($"{newNum}");

            Nullable<int> numN1 = null;
            Nullable<int> numN2 = 4;
            int? value = numN1 ?? numN2;

            Console.WriteLine($"value = {value}");

            var anyType = 'A';
            //anyType = 3; -- компилятор не пропускает ошибку


            ///////////////////////////////////////////////////////////////2
            var lit1 = "first";
            var lit2 = "second";
            var lit3 = "second";
            Console.WriteLine("Is first == second --  {0}, type is {2} \nIs second == third -- {1}", lit1 == lit2, lit2 == lit3, lit1.GetType());

            string str1 = "FIRST ";
            string str2 = "SECOND ";
            string str3 = "THIRD ";
            str1 = str1 + str2; // конкатенация
            str2 = str1; // копирование
            str3 = str3 + str1.Substring(0, 4); //выделение подстроки
            string[] words1 = str3.Split(' '); // разделение на слова
            str3 = str3.Insert(str3.Length, str1);
            str3 = str3.Remove(6, 4);
            Console.WriteLine(str1 + "\n" + str2 + "\n" + $"{str3}");

            String strNull = null;
            Console.WriteLine($"Nullstring = {string.IsNullOrEmpty(strNull)}, str3 = {string.IsNullOrEmpty(str3)} ");

            StringBuilder ddd = new StringBuilder("StringBuilder");
            ddd = ddd.Remove(3, 3);
            ddd = ddd.Append("ZhbubaPogromist");
            string ddT = ddd.ToString();
            Console.WriteLine(ddT + "\n");

            ////////////////////////////////////////////////////////////////3
            int[,] arr = { { 2, 4, 5 }, { 6, 7, 413 } };
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.Write('\n');
            }

            string[] words = { "Zhbub", "Is", "Pogromist" };
            Console.WriteLine($"Длина массива: {words.Length}");
            foreach (string word in words)
            {
                Console.Write($"{word} ");
            }

            Console.WriteLine("\nКакое слово изменять? 0, 1 или 2?");
            /*int numW = Convert.ToInt32(Console.ReadLine());
            if (numW >= 0 && numW < words.Length)
            {
                Console.WriteLine("Введите новое значение");
                words[numW] = Console.ReadLine();
            } 
            else
            {
                Console.WriteLine("Такого слова нет");
            }
            foreach (string word in words)
            {
                Console.Write($"{word} ");
            }
            Console.Write("\n");*/

            int[][] arr2 = new int[3][];
            arr2[0] = new int[2];
            arr2[1] = new int[3];
            arr2[2] = new int[4];

            /*  Console.WriteLine("Введите элементы массива");
              for(int i = 0; i < arr2.Length; i++)
              {
                  for(int j = 0; j < arr2[i].Length; j++)
                  {
                      arr2[i][j] = Convert.ToInt32(Console.ReadLine());
                  }
              }

              for (int i = 0; i < arr2.Length; i++)
              {
                  for (int j = 0; j < arr2[i].Length; j++)
                  {
                      Console.Write($"{arr2[i][j]} ");
                  }
                  Console.Write("\n");
              }*/

            var variable1 = arr2;
            var variable2 = "O Hi Mark";

            /////////////////////////////////////////////////////////////////// 4

            (int num, string mimi, char symb, ulong lnum) tuple = (0, "(^_^)/", '_', 0l);

            Console.WriteLine(tuple);
            Console.WriteLine(tuple.num);
            Console.WriteLine(tuple.Item2);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item4);



            string bbb = tuple.mimi; // распаковка 1

            (var a, var b, var c, var d) = tuple; // распаковка 2

            var (a0, b0, c0, d0) = tuple; // распаковка 3

            (int a1, string b1, char c1, ulong d1) = tuple; // распаковка 4

            int a2;
            string b2;
            char c2;
            ulong d2;

            (a2, b2, c2, d2) = tuple; // распаковка 5 

            //////////////////////////////////////////////////////////////////////////

            (int, int, int, char) func(int[] arrI, string str)
            {
                int sum = 0;
                foreach (int x in arrI)
                {
                    sum += x;
                }

                return (arrI.Max(), arrI.Min(), sum, str[0]);
            }

            int[] ar = { 1, 2, 3, 4, 5 };
            var (max, min, sum, symb) = func(ar, "Hello");

            /////////////////////////////////////////////////////////////////////////


            int test1()
            {
                checked
                {
                    int numCh = 2147483647;
                    try
                    {
                        return numCh + 1;
                    }
                    catch
                    {
                        Console.WriteLine("Переполнение");
                        return numCh;
                    }

                }
            }

            int test2()
            {
                unchecked
                {
                    return int.MaxValue + 1;
                }
            }

            Console.WriteLine($"Checked - {test1()} ");
            Console.WriteLine($"Unchecked - {test2()} ");
        }
    }
}
