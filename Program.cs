using System;

namespace lab1
{
    class Program
    {
        static string NL = Environment.NewLine;
        static void Main(string[] args)
        {
            Console.WriteLine("Что вы хотите сделать?" + NL + "1.Информация о задаче" + NL + "2.Решение задачи" + NL + "0.Выход");
            ConsoleKeyInfo keyboardSymbolMenu;
            keyboardSymbolMenu = Console.ReadKey(true);
            do
            {
                if(keyboardSymbolMenu.Key == ConsoleKey.NumPad1 || keyboardSymbolMenu.Key == ConsoleKey.D1)
                {
                    Console.WriteLine(NL + "Автор:Шабаева Дарья" + NL + "Группа 494" + NL + "Задача: Написать программу для поиска в массиве наибольшего элемента." + NL);
                    Console.WriteLine("Что вы хотите сделать?" + NL + "1.Информация о задаче" + NL + "2.Решение задачи" + NL + "0.Выход");
                    keyboardSymbolMenu = Console.ReadKey(true);
                }
                else if(keyboardSymbolMenu.Key == ConsoleKey.NumPad2 || keyboardSymbolMenu.Key == ConsoleKey.D2)
                {
                    Console.WriteLine(NL + "1.Ввод с клавиатуры");
                    Console.WriteLine("2.Ввод из файла ");
                    Console.WriteLine("3.Случайные значения");
                    ConsoleKeyInfo keyboardSymbolInput;
                    keyboardSymbolInput = Console.ReadKey(true);
                    bool userInput = false;
                    do
                    {
                        if(keyboardSymbolInput.Key==ConsoleKey.NumPad1 || keyboardSymbolInput.Key == ConsoleKey.D1)
                        {
                            InputArray.InputCount();
                            InputArray.ArrInput();
                            InputArray.ArrOutput();
                            Algorithm.max = Algorithm.FindOfMax(Algorithm.len, Algorithm.arr);
                            Console.WriteLine(NL + "Наибольшее число в массиве:" + Algorithm.max);
                            userInput = true;
                            Files.OutputRandAndKey();
                        }
                        else if (keyboardSymbolInput.Key == ConsoleKey.NumPad2 || keyboardSymbolInput.Key == ConsoleKey.D2)
                        {
                            Files.ArrFileOpen();
                            Algorithm.max = Algorithm.FindOfMax(Algorithm.len, Algorithm.arr);
                            InputArray.ArrOutput();
                            Console.WriteLine(NL + "Наибольшее число в массиве:" + Algorithm.max);
                            userInput = true;
                            Files.OutputFiles();
                        }
                        else if (keyboardSymbolInput.Key == ConsoleKey.NumPad3 || keyboardSymbolInput.Key == ConsoleKey.D3)
                        {
                            InputArray.InputCount();
                            InputArray.ArrRandom();
                            Algorithm.max = Algorithm.FindOfMax(Algorithm.len, Algorithm.arr);
                            InputArray.ArrOutput();
                            Console.WriteLine(NL + "Наибольшее число в массиве:" + Algorithm.max);
                            userInput = true;
                            Files.OutputRandAndKey();
                        }
                        else
                        {
                            Console.WriteLine("Неправильные данные.");
                            Console.WriteLine("1.Ввод с клавиатуры");
                            Console.WriteLine("2.Ввод из файла ");
                            Console.WriteLine("3.Случайные значения");
                            keyboardSymbolInput = Console.ReadKey(true);
                        }
                    } while (!userInput);
                    Console.WriteLine(NL + "Что вы хотите сделать?" + NL + "1.Информация о задаче" + NL + "2.Решение задачи" + NL + "0.Выход");
                    keyboardSymbolMenu = Console.ReadKey(true);
                }
                else if(keyboardSymbolMenu.Key != ConsoleKey.NumPad0 && keyboardSymbolMenu.Key != ConsoleKey.D0)
                {
                    Console.WriteLine(NL + "Неправильные данные.");
                    Console.WriteLine("Что вы хотите сделать?" + NL + "1.Информация о задаче" + NL + "2.Решение задачи" + NL + "0.Выход");
                    keyboardSymbolMenu = Console.ReadKey(true);
                }
            } while (keyboardSymbolMenu.Key != ConsoleKey.NumPad0 && keyboardSymbolMenu.Key != ConsoleKey.D0);
        }
    }
}
