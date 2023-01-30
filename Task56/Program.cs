// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
using static System.Console;
Clear();

Write("Введите размер матрицы и диапазон значений через пробел : ");
string[] parameters = ReadLine()!.Split(new string[]{" ", "#", ";", ","},StringSplitOptions.RemoveEmptyEntries);

int[,] array = GetMatrixArray(int.Parse(parameters[0]), int.Parse(parameters[1]), int.Parse(parameters[2]), int.Parse(parameters[3]));

PrintMatrixArray(array);
WriteLine();

Write($"Минимальная сумма в строке {FindMinSum(array)}");


int FindMinSum(int[,] inArray)
{
    int [] dict = new int[inArray.GetLength(0)];

        for (int i = 0; i < inArray.GetLength(0); i++)
        {
            int sum = 0;
            for (int j = 0; j < inArray.GetLength(1); j++)
            {
                sum = sum + inArray[i,j];
            }
            dict[i] = sum;
        }

    int MinSum = dict[0];
    int numberRowMinSum = 0;
    for(int i = 1; i < dict.Length; i++)
    {
        if(dict[i] < MinSum) 
        {
            MinSum = dict[i];
            numberRowMinSum = i;
        }
    }
    return numberRowMinSum;
}

int[,] GetMatrixArray(int rows, int columns, int minValue, int maxValue) 
{
    Random rnd = new Random();
    int[,] resultArray = new int[rows, columns];
    for (int i=0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            resultArray[i,j] = rnd.Next(minValue,maxValue);
        }
    }
    return resultArray;
}
void PrintMatrixArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Write($"{inArray[i,j],3} ");
        }
        WriteLine();
    }
}