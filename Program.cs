using System;
using System.Text;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine("         ДОМАШНЯ РОБОТА №7: ПАТЕРНИ      ");
                Console.WriteLine("=========================================\n");

                Console.WriteLine(" 0. Довідка\n");

                Console.WriteLine(" 1. Abstract Factory (Автомобілі / Mercedes)");
                Console.WriteLine(" 2. Builder (Піци / Margarita)");
                Console.WriteLine(" 3. Composite (Дерево компонентів)");
                Console.WriteLine(" 4. Decorator (Новорічна ялинка)");
                Console.WriteLine(" 5. Factory Method (Продукти / Product C)");
                Console.WriteLine(" 6. Mediator (Колеги / Чат)");
                Console.WriteLine(" 7. Prototype (Фігури / Трикутник)\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" 8. Вихід");
                Console.ResetColor();

                Console.WriteLine("\n=========================================");
                Console.Write("Оберіть номер пункту (0-8): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "0":
                        Console.WriteLine("=========================================");
                        Console.WriteLine("                ДОВІДКА                  ");
                        Console.WriteLine("=========================================");
                        Console.WriteLine(" Виконала: Мариніна Анна");
                        Console.WriteLine(" Група: К-27");
                        Console.WriteLine("=========================================");
                        break;
                    case "1":
                        Console.WriteLine("--- Виконання: Abstract Factory ---\n");
                        AbstractFactoryTask.Run();
                        break;
                    case "2":
                        Console.WriteLine("--- Виконання: Builder ---\n");
                        BuilderExample.Run();
                        break;
                    case "3":
                        Console.WriteLine("--- Виконання: Composite ---\n");
                        CompositeExampleTask.Run();
                        break;
                    case "4":
                        Console.WriteLine("--- Виконання: Decorator ---\n");
                        DecoratorExampleTask.Run();
                        break;
                    case "5":
                        Console.WriteLine("--- Виконання: Factory Method ---\n");
                        FactoryMethodTask.Run();
                        break;
                    case "6":
                        Console.WriteLine("--- Виконання: Mediator ---\n");
                        MediatorTask.Run();
                        break;
                    case "7":
                        Console.WriteLine("--- Виконання: Prototype ---\n");
                        PrototypeTask.Run();
                        break;
                    case "8":
                        exit = true;
                        Console.WriteLine("Вихід з програми.");
                        continue;
                    default:
                        Console.WriteLine("Помилка! Такого пункту немає.");
                        break;
                }

                Console.WriteLine("\n-----------------------------------------");
                Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
                Console.ReadKey();
            }
        }
    }
}
