using Hello.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Greeting();

            //Calculate();

            //Arrays();

            //Arrays2d();

            //PersonUsage();

            //ReferenceTypes();
            //ValueTypes();

            Lists();

            Dictionaries();

            // Вызов новой функции для вычисления факториала
            CalculateFactorial();

            Console.ReadKey();
        }

        private static void Greeting()
        {
            Console.Write("Представьтесь, пожалуйста: ");
            var name = Console.ReadLine();

            var greeting = $@"Привет, ""{name}""!";

            if (string.IsNullOrWhiteSpace(name))
            {
                greeting = @"Здравствуйте, ""незнакомец""!";
            }

            Console.WriteLine(greeting);
        }

        private static void Calculate()
        {
            Console.Write("Введите первое слагаемое: ");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out var x))
            {
                Console.WriteLine("Внимательнее!");
                return;
            }

            Console.Write("Введите второе слагаемое: ");
            input = Console.ReadLine();
            var y = int.Parse(input);

            var sum = x + y;

            Console.WriteLine($"Сумма = {sum}");
        }

        private static void Arrays()
        {
            var array = new int[] { 1, 2, 3, 4, };

            Console.Write(string.Join(", ", array));

            Console.WriteLine();
        }

        private static void Arrays2d()
        {
            var array2d = new[,]
            {
                { 1, 2, 3, 4, },
                { 5, 6, 7, 8, },
                { 9, 10, 11, 12, },
            };

            for (int row = 0; row < array2d.GetLength(0); row++)
            {
                for (int column = 0; column < array2d.GetLength(1); column++)
                {
                    Console.Write($"{array2d[row, column]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            var arrayOfArray = new[]
            {
                new[] { 1, 2, 3, },
                new[] { 4, 5, 6, 7, },
                new[] { 8, 9, 10, 11, 12, },
            };

            for (int row = 0; row < arrayOfArray.Length; row++)
            {
                for (int column = 0; column < arrayOfArray[row].Length; column++)
                {
                    Console.Write($"{arrayOfArray[row][column]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            foreach (var subArray in arrayOfArray)
            {
                foreach (var item in subArray)
                {
                    Console.Write($"{item}, ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void PersonUsage()
        {
            var person = new Person
            {
                Name = "Nick",
                BirthYear = 2005,
            };

            Console.WriteLine(person.PrintString);

            var person2 = new Person("Ann", 25);
            person2.PrintOut();
        }

        private static void ReferenceTypes()
        {
            var person = new Person
            {
                Name = "Nick",
                BirthYear = 2005,
            };

            var person2 = person;

            Console.Write("Person 1: ");
            Console.WriteLine(person.PrintString);

            Console.Write("Person 2: ");
            Console.WriteLine(person2.PrintString);

            person.Name = "Paul";

            Console.Write("Person 1: ");
            Console.WriteLine(person.PrintString);

            Console.Write("Person 2: ");
            Console.WriteLine(person2.PrintString);
        }

        private static void ValueTypes()
        {
            var person = new PersonStruct
            {
                Name = "Nick",
                BirthYear = 2005,
            };

            var person2 = person;

            Console.Write("Person 1: ");
            Console.WriteLine(person.PrintString);

            Console.Write("Person 2: ");
            Console.WriteLine(person2.PrintString);

            person.Name = "Paul";

            Console.Write("Person 1: ");
            Console.WriteLine(person.PrintString);

            Console.Write("Person 2: ");
            Console.WriteLine(person2.PrintString);
        }

        private static void Lists()
        {
            var newList = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                newList.Add(i);
            }

            Console.WriteLine(string.Join(", ", newList));
        }

        private static void Dictionaries()
        {
            var newDict = new Dictionary<string, int>();
            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                newDict[rnd.Next(100).ToString()] = rnd.Next(100);
            }

            foreach (var kvp in newDict)
            {
                Console.WriteLine($"Ключ {kvp.Key}, значение {kvp.Value}");
            }

            Console.Write("Введите значение ключа: ");
            var keyInput = Console.ReadLine();
            if (newDict.TryGetValue(keyInput, out var value))
            {
                Console.WriteLine($"Значение = {value}");
            }
            else
            {
                Console.WriteLine("Такого ключа нет");
            }
        }

        // Новая функция для вычисления факториала
        private static void CalculateFactorial()
        {
            Console.Write("Введите число для вычисления факториала: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var number) && number >= 0)
            {
                long factorial = 1;
                for (int i = 1; i <= number; i++)
                {
                    factorial *= i;
                }
                Console.WriteLine($"Факториал {number} = {factorial}");
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите неотрицательное целое число.");
            }
        }
    }
}
