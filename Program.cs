// Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.

/* int Prompt(string message)
{
    System.Console.WriteLine(message);
    string value = Console.ReadLine();
    int result = Convert.ToInt32(value);
    return result;
}

int[] InputArray(int length)
{
    int[] array = new int[length];
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = Prompt($"Enter the {i+1}-th element");
    }
    return array;
}

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine($"a[{i}] = {array[i]}");
    }
}

int CountPositiveNumbers(int[] array)
{
    int count = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if(array[i] > 0)
        {
            count++;
        }
    }
    return count;
}

int length = Prompt("Enter the number of items");
int[] array;
array = InputArray(length);
PrintArray(array);
Console.WriteLine($"The number of numbers greater than 0 - {CountPositiveNumbers(array)}");
 */



// Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.

using System.ComponentModel;

const int COEFFICIENT = 0;
const int CONSTANT = 1;
const int X_COORD = 0;
const int Y_COORD = 1;
const int LINE1 = 1;
const int LINE2 = 2;

double[] lineData1 = InputLineData(LINE1);
double[] lineData2 = InputLineData(LINE2);

if (ValidateLines(lineData1, lineData2))
{
    double[] coord = FindCoords(lineData1, lineData2);
    Console.Write($"The intersection point of the equations y={lineData1[COEFFICIENT]}*x+{lineData1[CONSTANT]} and y={lineData2[COEFFICIENT]}*x+{lineData2[CONSTANT]} ");
    Console.WriteLine($" has coordinates ({coord[X_COORD]}, {coord[Y_COORD]})");
}

// ВВод числа
double Prompt(string message)
{
    System.Console.Write(message); 
    string value = Console.ReadLine();
    double result = Convert.ToDouble(value); // преобразует строку в целое число
    return result;
}

// Ввод данных по прямой
double[] InputLineData(int numberOfLine)
{
    double[] lineData = new double[2];
    lineData[COEFFICIENT] = Prompt($"Enter the coefficient for the {numberOfLine} straight line: ");
    lineData[CONSTANT] = Prompt($"Enter a constant for the straight {numberOfLine} line: ");
    return lineData;
}

// Поиск координат

double[] FindCoords(double[] lineData1, double[] lineData2)
{
    double[] coord = new double[2];
    coord[X_COORD] = (lineData1[CONSTANT] - lineData2[CONSTANT]) / 
(lineData2[COEFFICIENT] - lineData1[COEFFICIENT]);
    coord[Y_COORD] = lineData1[CONSTANT] * coord[X_COORD] + lineData1[CONSTANT];
    return coord;
}

bool ValidateLines(double[] lineData1, double[] lineData2)
{
    if (lineData1[COEFFICIENT] == lineData2[COEFFICIENT])
    {
        if (lineData1[CONSTANT] == lineData2[CONSTANT])
        {
            Console.WriteLine("Straight lines match");
            return false;
        }
        else
        {
            Console.WriteLine("Straight lines are parallel");
            return false;
        }
    }
    return true;
}

