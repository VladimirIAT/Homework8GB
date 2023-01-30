// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
//которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)
using static System.Console;
Clear();

Print3DMatrixArray(Form3DArray(3, 3, 3, 10, 40));

void Print3DMatrixArray(int[,,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            for (int n = 0; n < inArray.GetLength(2); n++)
            {
                WriteLine($"{inArray[i,j,n],4} ({i}, {j}, {n})");                
            }
        }
    }
}

static int[,,] Form3DArray(int rows, int columns, int columnsz, int minValue, int maxValue)
{
    int[,,] array = new int[rows, columns, columnsz];
//формируем одномерный массив с уникальными значениями
    var random = new Random();
    int[] tempArray = new int [rows * columns * columnsz];
    for (int i = 0; i < tempArray.Length; ++i)
    {
        bool isUnique;
        do
        {
            tempArray[i] = random.Next(minValue, maxValue);
            isUnique = true;
            for (int j = 0; j < i; ++j)
                if (tempArray[i] == tempArray[j])
                {
                    isUnique = false;
                    break;
                }
        } while (!isUnique);
    }
//заполняем трехмерный массив уникальными значениями из одномерного массива
    int p = 0;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            for (int k = 0; k < columnsz; k++)
            {
                array[i, j, k] = tempArray[p];
                p++;
            }
        }
    }
    
    return array;
}
