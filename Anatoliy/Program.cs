using System;

namespace Anatoliy
{
    class Program
    {
        static void Main(string[] args)
        {
            DataEntry dataEntry = new DataEntry();
            SettingsSystem settings = new SettingsSystem();
            Console.WriteLine("Калькулятор графика платежей по кредитам");
            Console.WriteLine("Выберите, в какой валюте отобразить сумму % (1-доллар, 2-рубль)");
            settings.CurrencySelection();
            Console.WriteLine("Ввести курс вручную - 1, получить курс с интернета - 2");
            settings.ChooseMethodInputCurrency();
            Console.WriteLine("Введите количество знаков после запятой для округления при расчетах: ");
            settings.SetNumberSimbolsAfterComma();
            Console.WriteLine("Введите сумму кредита: ");
            dataEntry.ValueEntry(out int sumCredit);
            Console.WriteLine("Введите срок кредита(в месяцах): ");
            dataEntry.ValueEntry(out int termMonthsCredit);
            Console.WriteLine("Введите тип погашения кредита(1 - дифференциальный, 2 - аннуитет): ");
            dataEntry.TypeEntry(out int typeCredit);
            Console.WriteLine("Введите процент кредита: ");
            dataEntry.ValueEntry(out int percentCredit);
            Console.WriteLine("Введите частоту комисси(1 раз в N месяцев):\nN = ");
            dataEntry.ValueEntry(out int commissionFrequency);
            Console.WriteLine("Введите тип комиссии(1 - от суммы кредита, 2 - на остаток задолженности по кредиту): ");
            dataEntry.TypeEntry(out int commissionType);
            Console.WriteLine("Введите процент комиссии: ");
            dataEntry.ValueEntry(out double commissionPercentage);
            Credit credit = new Credit(settings, sumCredit, termMonthsCredit, percentCredit, commissionType, commissionFrequency, commissionPercentage);
            switch (typeCredit)
            {
                case 1: credit.DifferentiatedPayment();
                    break;
                case 2: credit.AnnuityPayment();
                    break;
            }
        }
    }
}
