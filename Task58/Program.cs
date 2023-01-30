// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18
using static System.Console;
Clear();

Write("Введите размер квадратной матрицы и диапазон значений через пробел : ");
string[] parameters1 = ReadLine()!.Split(new string[]{" ", "#", ";", ","},StringSplitOptions.RemoveEmptyEntries);

int[,] array1 = GetMatrixArray(int.Parse(parameters1[0]), int.Parse(parameters1[1]), int.Parse(parameters1[2]));

//string[] parameters2 = ReadLine()!.Split(new string[]{" ", "#", ";", ","},StringSplitOptions.RemoveEmptyEntries);

int[,] array2 = GetMatrixArray(int.Parse(parameters1[0]), int.Parse(parameters1[1]), int.Parse(parameters1[2]));

PrintMatrixArray(array1);
WriteLine();
PrintMatrixArray(array2);
WriteLine();
PrintMatrixArray(MultyArray(array1, array2));


int[,] MultyArray(int[,] inArray1, int[,] inArray2)
{
   int [,] result = new int[inArray1.GetLength(0), inArray2.GetLength(1)];
    for (int n = 0; n < inArray1.GetLength(0); n++)
    {
        for (int m = 0; m < inArray2.GetLength(0); m++)
        {
            for (int p = 0; p <  inArray1.GetLength(0); p++)
            {
            result[n,m] = result[n,m] + array1[n,p]*array2[p,m];   
            }
            
        }
    }
    return result;
}

int[,] GetMatrixArray(int rows, int minValue, int maxValue) 
{
    Random rnd = new Random();
    int[,] resultArray = new int[rows, rows];
    for (int i=0; i < rows; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            resultArray[i,j] = rnd.Next(minValue, maxValue);
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
