// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2
using static System.Console;
Clear();

Write("Введите размер матрицы и диапазон значений через пробел : ");
string[] parameters = ReadLine()!.Split(new string[]{" ", "#", ";", ","},StringSplitOptions.RemoveEmptyEntries);

int[,] array = GetMatrixArray(int.Parse(parameters[0]), int.Parse(parameters[1]), int.Parse(parameters[2]), int.Parse(parameters[3]));

PrintMatrixArray(array);
WriteLine();

WriteLine();
PrintMatrixArray(SortRowArray(array));


int[,] SortRowArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        //Производим сортировку по убыванию
        int temp;
        for (int j = 0; j < inArray.GetLength(1) - 1; j++)
        {
            for (int k = j + 1; k < inArray.GetLength(1); k++)
            {
                if (inArray[i, j] < inArray[i, k])
                {
                    temp = inArray[i,j];
                    inArray[i, j] = inArray[i, k];
                    inArray[i, k] = temp;
                }
            }
        }
        
    }
    return inArray;
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
