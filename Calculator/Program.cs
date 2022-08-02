using System;
using System.IO;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "Calculator.txt";
            Console.WriteLine("----------THE CALCULATOR-----------");
            string num;
            double result;
            do
            {
                Console.WriteLine("Input number of operation you want to do:");
                Console.WriteLine("0. Exit;");
                Console.WriteLine("1. Show list of history operations;");
                Console.WriteLine("2. Calculate;");
                num = Console.ReadLine();
                switch (num)
                {
                    case "1":
                        Console.Clear();
                        if (File.Exists(fileName))
                            Console.WriteLine($"{File.ReadAllText(fileName)}\n");
                        else
                            Console.WriteLine("\nHistory does not exist!\n");
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Enter a formula use next symbols: + - * /  =");
                        string formula = Console.ReadLine();
                        if (!formula.Contains('='))
                            formula += "=";
                        Formula newformula = new Formula(formula);
                        result = newformula.Calculation();
                        if (File.Exists(fileName))
                            File.AppendAllText(fileName, $"\n{formula}{Math.Round(result, 3)}");
                        else
                             File.AppendAllText(fileName, $"\n{formula}{Math.Round(result, 3)}");
                        Console.WriteLine($"{formula}{Math.Round(result, 3)}");
                        break;
                }
            } while (num != "0");
        }
    }
}
