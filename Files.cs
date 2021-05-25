using System;
using System.Linq;
using System.IO;


namespace lab1
{
    class Files
    {
        static string filePath;
        static ConsoleKeyInfo keyboardSymbol;
        public static void ArrOutfile(string path)
        {
            File.WriteAllLines(path, Algorithm.arr.Select(s=>s.ToString()).ToArray());
            Console.WriteLine("Сохранение массива произведено успешно");
        }

        public static void ResultsOutfile(string path)
        {
            File.WriteAllText(path, "Наибольший элемент массива: " + Algorithm.max);
            Console.WriteLine("Сохранение результата произведено успешно");
        }

        public static void AllOutfile(string path)
        {
            File.WriteAllLines(path, Algorithm.arr.Select(s => s.ToString()).ToArray());
            File.AppendAllText(path, "Наибольший элемент массива: " + Algorithm.max);
            Console.WriteLine("Сохранение произведено успешно");
        }

        public static string OutfileCheck()
        {
            string filePath;
            FileStream file;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите путь нового файла:");
                    filePath = Console.ReadLine();
                    file = File.Open(filePath, FileMode.OpenOrCreate);
                    file.Close();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Неверное имя файла или файл недоступен для записи, попробуйте снова");
                    filePath = Console.ReadLine();
                    continue;
                }
                catch(IOException)
                {
                    Console.WriteLine("Неверное имя файла, попробуйте снова");
                    //filePath = Console.ReadLine();
                    continue;
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Неверное имя файла, попробуйте снова");
                    //filePath = Console.ReadLine();
                    continue;
                }
                FileInfo infileInfo = new FileInfo(filePath);
                bool check = true;
                if (infileInfo.Length != 0)
                {
                    Console.WriteLine("Файл уже существует, вы хотите перезаписать его?\n1.Да\n2.Нет");
                    while (true)
                    {
                        keyboardSymbol = Console.ReadKey(true);
                        if(keyboardSymbol.Key==ConsoleKey.D1 || keyboardSymbol.Key == ConsoleKey.NumPad1)
                        {
                            break;
                        }
                        else if(keyboardSymbol.Key == ConsoleKey.D2 || keyboardSymbol.Key == ConsoleKey.NumPad2)
                        {
                            check = false;
                            break;
                        }
                    }
                }
                if (!check)
                {
                    continue;
                }
                else
                    break;
            }
            return filePath;
        }

        public static void ArrFileOpen()
        {
            FileStream file;
            while (true)
            {
                Console.WriteLine("Введите путь нового файла:");
                filePath = Console.ReadLine();
                try
                {
                    file = File.Open(filePath, FileMode.OpenOrCreate);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Некорректный путь файла. Повторите ввод.");
                    continue;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файл не существует. Выберите другой файл.");
                    continue;
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Неопределенная ошибка. Повторите попытку или выберите другой файл.");
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Неопределенная ошибка. Повторите попытку или выберите другой файл.");
                    continue;
                }
                FileInfo infileInfo = new FileInfo(filePath);
                if (infileInfo.Length == 0)
                {
                    Console.WriteLine("Файл пуст. Выберите другой файл");
                    continue;
                }
                byte[] array = new byte[file.Length];
                file.Read(array, 0, array.Length);
                file.Close();
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                try
                {
                    Algorithm.arr = textFromFile.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
                    Algorithm.len = Algorithm.arr.Length;
                }
                catch
                {
                    Console.WriteLine("Неверный формат исходного файла. Выберите другой файл.");
                    continue;
                }
                break;
            }
        }

        public static void OutputRandAndKey()
        {
            bool res, array;
            while (true)
            {
                Console.WriteLine("Желаете сохранить результат?");
                Console.WriteLine("1.Да");
                Console.WriteLine("2.Нет");
                keyboardSymbol = Console.ReadKey(true);
                if(keyboardSymbol.Key==ConsoleKey.D1 || keyboardSymbol.Key == ConsoleKey.NumPad1)
                {
                    res = true;
                    break;
                }
                else if (keyboardSymbol.Key == ConsoleKey.D2 || keyboardSymbol.Key == ConsoleKey.NumPad2)
                {
                    res = false;
                    break;
                }
            }
            ConsoleKeyInfo keyboardSymbol1;
            while (true)
            {
                Console.WriteLine("Желаете сохранить массив для дальнейшей работы?");
                Console.WriteLine("1.Да");
                Console.WriteLine("2.Нет");
                keyboardSymbol1 = Console.ReadKey(true);
                if (keyboardSymbol1.Key == ConsoleKey.D1 || keyboardSymbol1.Key == ConsoleKey.NumPad1)
                {
                    array = true;
                    break;
                }
                else if (keyboardSymbol1.Key == ConsoleKey.D2 || keyboardSymbol1.Key == ConsoleKey.NumPad2)
                {
                    array = false;
                    break;
                }
            }

            if (res && array)
            {
                ConsoleKeyInfo keyboardSymbol2;
                while (true)
                {
                    Console.WriteLine("Желаете сохранить все в один файл?");
                    Console.WriteLine("1.Да");
                    Console.WriteLine("2.Нет");
                    keyboardSymbol2 = Console.ReadKey(true);
                    if (keyboardSymbol2.Key == ConsoleKey.D1 || keyboardSymbol2.Key == ConsoleKey.NumPad1)
                    {
                        string path;
                        path = OutfileCheck();
                        AllOutfile(path);
                        break;
                    }
                    else if (keyboardSymbol2.Key == ConsoleKey.D2 || keyboardSymbol2.Key == ConsoleKey.NumPad2)
                    {
                        Console.WriteLine("Сохранение массива:");
                        ArrOutfile(OutfileCheck());
                        Console.WriteLine("Сохранение результата:");
                        ResultsOutfile(OutfileCheck());
                        break;
                    }
                }
            }
            else if (res)
            {
                Console.WriteLine("Сохранение результата:");
                ResultsOutfile(OutfileCheck());
            }
            else if (array)
            {
                Console.WriteLine("Сохранение массива:");
                ArrOutfile(OutfileCheck());
            }

        }

        public static void OutputFiles()
        {
            while (true)
            {
                Console.WriteLine("Желаете сохранить результат программы?");
                Console.WriteLine("1.Да");
                Console.WriteLine("2.Нет");
                while (true)
                {
                    keyboardSymbol = Console.ReadKey(true);
                    if (keyboardSymbol.Key == ConsoleKey.D1 || keyboardSymbol.Key == ConsoleKey.NumPad1)
                    {
                        ConsoleKeyInfo keyboardSymbol1;
                        while (true)
                        {
                            Console.WriteLine("Желаете сохранить в этот же файл?");
                            Console.WriteLine("1.Да");
                            Console.WriteLine("2.Нет");
                            keyboardSymbol1 = Console.ReadKey(true);
                            if (keyboardSymbol1.Key == ConsoleKey.D1 || keyboardSymbol1.Key == ConsoleKey.NumPad1)
                            {
                                File.AppendAllText(filePath, Environment.NewLine + "Наибольший элемент массива:" + Algorithm.max);
                                Console.WriteLine("Сохранение произведено успешно");
                                break;
                            }
                            else if (keyboardSymbol1.Key == ConsoleKey.D2 || keyboardSymbol1.Key == ConsoleKey.NumPad2)
                            {
                                ResultsOutfile(OutfileCheck());
                                break;
                            }
                        }
                        break;
                    }
                    else if (keyboardSymbol.Key == ConsoleKey.D2 || keyboardSymbol.Key == ConsoleKey.NumPad2)
                    {
                        break;
                    }

                }
            }
        }


    }
}
