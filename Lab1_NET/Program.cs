using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTestProject")]
[assembly: InternalsVisibleTo("WindowsFormsApp")]

namespace Lab1_NET
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Podaj liczbe przedmiotow: ");
            int n = int.Parse(Console.ReadLine());
            Knapsack knapsack = new Knapsack(n);
            Console.WriteLine("\n" + knapsack);
            Console.Write("Podaj ladownosc plecaka [kg]: ");
            int cap = int.Parse(Console.ReadLine());
            Problem problem = new Problem(cap, knapsack);
            Console.WriteLine(problem);
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}