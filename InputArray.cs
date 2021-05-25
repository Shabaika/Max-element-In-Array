using System;

namespace lab1
{
    class InputArray
    {
        public static void InputCount()
        {
            string str;
            Console.WriteLine("Введдите размерность массива: ");
            str = Console.ReadLine();
            while(!Int32.TryParse(str, out Algorithm.len) || Algorithm.len < 1)
            {
                Console.WriteLine("Введен некорректный размер массива. Повторите попытку.");
                Console.WriteLine("Введдите размерность массива: ");
                str = Console.ReadLine();
            }
            Algorithm.arr = new int[Algorithm.len];
        }

        public static void ArrRandom()
        {
            var rand = new Random();
            for(int i = 0; i < Algorithm.len; i++)
            {
                Algorithm.arr[i] = rand.Next(-100, 100);
            }
            ArrOutput();
        }

        public static void ArrInput()
        {
            Console.WriteLine("Введите элементы массива через Enter: ");
            for(int i=0; i<Algorithm.len; i++)
            {
                string input = Console.ReadLine();
                while(!Int32.TryParse(input, out Algorithm.arr[i]))
                {
                    Console.WriteLine("Некорректный ввод элемента массива. Повторите ввод:");
                    input = Console.ReadLine();
                }
            }
            Console.WriteLine("Считывание массива произведено успешно");
        }

        public static void ArrOutput()
        {
            Console.WriteLine("");
            for (int i = 0; i < Algorithm.len; i++)
            {
                Console.WriteLine(Algorithm.arr[i] + " ");
            }
            
        }

    }
}
