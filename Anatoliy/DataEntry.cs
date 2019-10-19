using System;

namespace Calculator
{
    class DataEntry
    {
        bool Result;
        virtual public void ValueEntry(out int data)
        {
            while (true)
            {
                Result = int.TryParse(Console.ReadLine(), out data);
                if (!Result)
                {
                    Console.WriteLine("Введено некоректное число");
                }
                else
                {
                    break;
                }
            }
        }
        virtual public void ValueEntry(out double data)
        {
            while (true)
            {
                Result = double.TryParse(Console.ReadLine(), out data);
                if (!Result)
                {
                    Console.WriteLine("Введено некоректное число");
                }
                else
                {
                    break;
                }
            }
        }
        virtual public void TypeEntry(out int data)
        {
            while (true)
            {
                Result = int.TryParse(Console.ReadLine(), out data);
                if (!Result)
                {
                    Console.WriteLine("Введено некоректное число");
                }
                else
                {
                    if (data != 1 && data != 2)
                    {
                        Console.WriteLine("Введено некоректное число");
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        virtual public void CurrencyEntry(out int data)
        {
            while (true)
            {
                Result = int.TryParse(Console.ReadLine(), out data);
                if (!Result)
                {
                    Console.WriteLine("Введено некоректное число");
                }
                else
                {
                    if (data != 1 && data != 2 && data != 3)
                    {
                        Console.WriteLine("Введено некоректное число");
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
