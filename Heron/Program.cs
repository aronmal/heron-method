using System;

namespace Heron
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Dieses Programm verwendet das Heron-Verfahren um die 2. Wurzel eines Radianten zu lösen.");
            Console.Write("Wurzel ziehen aus (Radiant): ");
            int radiant = int.Parse(Console.ReadLine());
            Console.Write("Wie vielte Wurzel?: ");
            int exponent = int.Parse(Console.ReadLine());
            Console.Write("Genauigkeit an Nachkommastellen: ");
            int precision = int.Parse(Console.ReadLine());
            double x = radiant;
            double y = 1;
            while (Math.Round(x, precision) != Math.Round(y, precision))
            {
                Console.WriteLine(" | " + Math.Round(x, precision) + " | " + Math.Round(y, precision) + " | ");
                x = ((x * (exponent - 1)) + y) / exponent;
                y = radiant / Math.Pow(x, exponent - 1);
            }
            Console.WriteLine(" | " + x + " | " + y + " | ");
        }
    }
}