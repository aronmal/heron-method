using System;
using ELibCode;
namespace HeronVerfahren
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ELib.Init(false);
            do
            {
                run();
            } while (ELib.AskUserIfYesOrNo("Rerun?"));
        }

        static void run()
        {
            double input, timesRan = 0, inputX, inputY = 1, inputZ = 1, range;
            int exponent;
            input = ELib.getLong("Input a number <Input>");
            inputX = input;
            Console.Write("Input precision <0.001>: ");
            exponent = ELib.getInt("Input exponent <Exponent>");
            range = double.Parse(Console.ReadLine());
            while (!isInRange(inputX, inputY, range))
            {
                inputX = ((inputX * (exponent - 1)) + inputY) / 2;
                inputY = input / Math.Pow(inputX, exponent - 1);
                timesRan++;
            }
            Console.WriteLine($"The {exponent} root is {inputX.ToString(range.ToString())}; TimesRan {timesRan}");
        }

        static bool isInRange(double num1, double num2, double range)
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
    }
} 