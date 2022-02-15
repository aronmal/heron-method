using System;

namespace Heron
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Dieses Programm verwendet das Heron-Verfahren um die 2. Wurzel eines Radianten zu lösen.");
            do
            {
                Run();
            } while (AskUserIfYesOrNo("Rerun?"));
        }
        private static void Run()
        {
            Console.WriteLine("- - - - -");
            Console.WriteLine("");
            // input = ELib.getLong("Input a number <Input>");
            // exponent = ELib.getInt("Input exponent <Exponent>");
            Console.Write("Wurzel ziehen aus (Radiant): ");
            var radiant = int.Parse(Console.ReadLine());
            Console.Write("Wie vielte Wurzel?: ");
            var exponent = int.Parse(Console.ReadLine());
            Console.Write("Genauigkeit an Nachkommastellen: ");
            var precision = Math.Pow(10, -1 * int.Parse(Console.ReadLine()));
            Console.WriteLine(precision);
            Console.WriteLine("- - - - -");
            double x = radiant;
            double y = 1;
            var index = 1;
            while (!IsInRange(x, y, precision))
            {
                Console.WriteLine("Round " + index + ":");
                index++;
                Console.WriteLine(" | " + Math.Round(x, 5) + " | " + Math.Round(y, 5) + " | ");
                x = ((x * (exponent - 1)) + y) / exponent;
                y = radiant / Math.Pow(x, exponent - 1);
            }
            // Console.WriteLine($"The {exponent} root is {inputX.ToString(range.ToString())}; TimesRan {timesRan}");
            Console.WriteLine("Final Result:");
            Console.WriteLine(" | " + x + " | " + y + " | ");
        }
        private static bool IsInRange(double num1, double num2, double range)
        {
            double num;
            if (num1 > num2)
            {
                num = num1 - num2;
                return num <= range;
            }
            num = num2 - num1;
            return num <= range;
        }
        private static bool AskUserIfYesOrNo(string question)
        {
            string[] allowedInput = { "Y", "N", "Yes", "No", "Ja", "Nein", "J", "n", "j", "y", "ja", "nein", "yes", "no" };
            string[] yesInput = { "Y", "Yes", "Ja", "J", "j", "y", "ja", "yes" };
            Console.Write($"\n{question} [Y/N]: ");
            var key = Console.ReadLine();
            Console.WriteLine("");
            // ReSharper disable once IdentifierTypo
            bool iscorrect = false;
            while (!iscorrect)
            {
                foreach (var allowed in allowedInput)
                {
                    if (key == allowed)
                    {
                        iscorrect = true;
                        break;
                    }
                }

                if (!iscorrect)
                {
                    // ReSharper disable StringLiteralTypo //what do you mean?? its German >:(
                    Console.Write($"Bitte benutzte nur [Y/N] | Please use [Y/N] \n{question} [Y/N]: ");
                    // ReSharper restore StringLiteralTypo
                    key = Console.ReadLine();
                    Console.WriteLine("");
                }
            }
            foreach (var yes in yesInput)
            {
                if (key == yes)
                {
                    return true;
                }
            }
            return false;
        }
    }
}