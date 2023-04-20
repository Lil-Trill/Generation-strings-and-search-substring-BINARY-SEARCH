﻿using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;


//Напишите программу, помещающую случайно сформированные короткие строки
//в массив, а затем находящую заданную строку в массиве при помощи:
//• простого линейного поиска (метод грубой силы);
//• более сложного метода по вашему выбору. 
internal class Program
{
    public static void PrintConsole(List<string> strings)
    {
        foreach(var str in strings)
        {
            Console.WriteLine(str.ToString());
        }
    }

    private static void Main(string[] args)
    {
        //Random rnd = new Random(); 
        //int length = rnd.Next(1, 1000);
        //List<string> strs = new List<string>();
        //string[] path = File.ReadAllLines("text.txt");

        //for (int i = 0; i < path.Length; i++) strs.Add(path[i]);

        //PrintConsole(strs);

        ////for (int i = 0; i < length; i++)
        ////{
        ////    int lengthStr = rnd.Next(1, 10);
        ////    char[] ch = new char[lengthStr];
        ////    for (int j = 0; j < lengthStr; j++)
        ////        ch[j] = Convert.ToChar(rnd.Next(97,122));

        ////    strs.Add(new string(ch));
        ////}
        

        //Console.ForegroundColor = ConsoleColor.Green;
        //Console.WriteLine("Введите искомую строку");
        //string searchString = Console.ReadLine();
        //LinerSearch.SearchLiner(strs, searchString);
        //BinarySearch.Sort(ref strs);

        var testList = new List<string>();
        testList.Add("allo");
        testList.Add("bllo");
        testList.Add("hello");
        testList.Add("hamlo");
        testList.Add("govno");
        testList.Add("zondo");
        BinarySearch.Sort(ref testList);
        PrintConsole(testList);
        BinarySearch.Search(testList, "hamlo");
        // Console.WriteLine(BinarySearch.Search(testList, "hamlo"));
        long[] arr = { 1,2,3, 4, 4, 6 };
        
        Console.WriteLine(BinSearchLeftBorder(arr, 4, 0, arr.Length));

    }
    public static int BinSearchLeftBorder(long[] array, long value, int left, int right)
    {
        if (array.Length == 0) return -1;
        if (array[left + 1] >= value || left + 1 >= right || right == left)
        {
            if (value < array[0]) return -1;
            if (array[left + 1] != value && array[left] != value) return -1;

            return left;
        }
        if (value > array[array.Length - 1]) return -1;
        var m = (left + right) / 2;
        if (array[m] < value)
            return BinSearchLeftBorder(array, value, m, right);
        return BinSearchLeftBorder(array, value, left, m);
    }
}
class LinerSearch
{
    public static void SearchLiner(List<string> array, string searchString)
    {
        bool flag = false;
        for (int i = 0; i < array.Count; i++)
        {
            if (array[i].Contains(searchString))
            {
                Console.WriteLine($"Строка {i + 1} соответствует запросу");
                flag = true;
            }
        }
        if (flag == false) Console.WriteLine("искомой строки не нашлось :<");
    }
}

class BinarySearch
{
    public static void Sort(ref List<string> arrayStrings)
    {
        for (int i = 1; i < arrayStrings.Count; i++)
        {
            for (int j = 0; j < arrayStrings.Count-1; j++)
            {
                if (arrayStrings[j][0] == ' ' || arrayStrings[j + 1][0] == ' ' || arrayStrings[j] == "\n" || arrayStrings[j + 1]=="\n") continue;
                if (arrayStrings[j][0] > arrayStrings[j + 1][0])
                {
                    string temp = arrayStrings[j];
                    arrayStrings[j] = arrayStrings[j+1];
                    arrayStrings[j+1] = temp;
                }
            }
        }
    }
    public static string Search(List<string> array, string searchString)
    {
        int left = 0;
        int right = array.Count - 1;

        while (left <= right)
        {
            int middle = (right + left) / 2;
            if (Convert.ToInt16(array[middle][0]) == Convert.ToInt16(searchString[0]))
            {
                if (array[middle] == searchString)
                {
                    Console.WriteLine("искомая строка найдена на номере: " + middle);
                    return array[middle];
                    break;
                }
                
            }
            if (Convert.ToInt16(searchString[0]) < Convert.ToInt16(array[middle][0])) right = middle - 1;
            if (Convert.ToInt16(searchString[0]) > Convert.ToInt16(array[middle][0])) left = middle + 1;
        }

        return "искомой строки не нашлось увы и ах";
    }
}