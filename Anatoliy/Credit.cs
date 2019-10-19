using System;

namespace Calculator
{
    class Credit
    {
        private int SumCredit;
        private int TermMonthsCredit;
        private int PercentCredit;
        private DateTime DateStart;
        private double BasicPayment;
        private double AmountOfCommission;
        private int CommissionType;
        private int CommissionFrequency;
        private double CommissionPercentage;
        private DataPrinting dataPrinting = new DataPrinting();
        private SettingsSystem Settings;

        public Credit(SettingsSystem _settings, int _sumCredit, int _termMonthsCredit, int _percentCredit, int _commissionType, int _commissionFrequency, double _commissionPercentage)
        {
            SumCredit = _sumCredit;
            TermMonthsCredit = _termMonthsCredit;
            PercentCredit = _percentCredit;
            CommissionType = _commissionType;
            CommissionFrequency = _commissionFrequency;
            CommissionPercentage = _commissionPercentage;
            Settings = _settings;
        }
        virtual public void DifferentiatedPayment()
        {
            double percent = PercentCredit / 100.0;
            BasicPayment = Math.Round((double)(SumCredit / TermMonthsCredit), Settings.NumberSimbolsAfterComma);
            DateStart = DateTime.Now;
            Console.WriteLine("Сумма основного платежа = " + BasicPayment);
            if (CommissionType == 1)
            {
                AmountOfCommission = Math.Round(SumCredit * CommissionPercentage / 100.0, Settings.NumberSimbolsAfterComma);
                for (int month = 1; month <= TermMonthsCredit; month++)
                {
                    double monthlyPaymentPercent = Math.Round((SumCredit - (BasicPayment * month)) * percent / 12.0, Settings.NumberSimbolsAfterComma);
                    double loanBalance = SumCredit - month * BasicPayment;
                    if (month % CommissionFrequency == 0)
                    {
                        dataPrinting.DifferentiatedPaymentWithCommission(month, DateStart, Math.Round(monthlyPaymentPercent / Settings.CurrencyValue, Settings.NumberSimbolsAfterComma), (BasicPayment + monthlyPaymentPercent), loanBalance, AmountOfCommission, Settings.Currency);
                    }
                    else
                    {
                        dataPrinting.DifferentiatedPaymentWithoutCommission(month, DateStart, Math.Round(monthlyPaymentPercent / Settings.CurrencyValue, Settings.NumberSimbolsAfterComma), (BasicPayment + monthlyPaymentPercent), loanBalance, Settings.Currency);
                    }
                }
            }
            else
            {
                for (int month = 1; month <= TermMonthsCredit; month++)
                {
                    double monthlyPaymentPercent = Math.Round((SumCredit - (BasicPayment * month)) * percent / 12.0, Settings.NumberSimbolsAfterComma);
                    double loanBalance = SumCredit - month * BasicPayment;
                    if (month % CommissionFrequency == 0)
                    {
                        AmountOfCommission = Math.Round(loanBalance * CommissionPercentage / 100.0, Settings.NumberSimbolsAfterComma);
                        dataPrinting.DifferentiatedPaymentWithCommission(month, DateStart, Math.Round(monthlyPaymentPercent / Settings.CurrencyValue, Settings.NumberSimbolsAfterComma), BasicPayment, loanBalance, AmountOfCommission, Settings.Currency);
                    }
                    else
                    {
                        dataPrinting.DifferentiatedPaymentWithoutCommission(month, DateStart, Math.Round(monthlyPaymentPercent / Settings.CurrencyValue, Settings.NumberSimbolsAfterComma), BasicPayment, loanBalance, Settings.Currency);
                    }
                }
            }
        }
        virtual public void AnnuityPayment()
        {
            double percent = Math.Round(PercentCredit / 100.0 / 12.0, Settings.NumberSimbolsAfterComma);
            BasicPayment = Math.Round(SumCredit * (percent + percent / (Math.Pow(1 + percent, TermMonthsCredit) - 1)), Settings.NumberSimbolsAfterComma);
            DateStart = DateTime.Now;
            double loanBalance = SumCredit;
            Console.WriteLine("Сумма ежемесячного платежа = " + BasicPayment);
            if (CommissionType == 1)
            {
                AmountOfCommission = SumCredit * CommissionPercentage / 100.0;
                for (int month = 1; month <= TermMonthsCredit; month++)
                {
                    double monthlyPaymentPercent = loanBalance * percent;
                    double difference = Math.Round(BasicPayment - monthlyPaymentPercent, Settings.NumberSimbolsAfterComma);
                    loanBalance -= difference;
                    if (month % CommissionFrequency == 0)
                    {
                        dataPrinting.AnnuityPaymentWithCommission(month, DateStart, Math.Round(monthlyPaymentPercent / Settings.CurrencyValue, Settings.NumberSimbolsAfterComma), difference, loanBalance, AmountOfCommission, Settings.Currency);
                    }
                    else
                    {
                        dataPrinting.AnnuityPaymentWithoutCommission(month, DateStart, Math.Round(monthlyPaymentPercent / Settings.CurrencyValue, Settings.NumberSimbolsAfterComma), difference, loanBalance, Settings.Currency);
                    }
                }
            }
            else
            {
                for (int month = 1; month <= TermMonthsCredit; month++)
                {
                    double monthlyPaymentPercent = loanBalance * percent;
                    double difference = Math.Round(BasicPayment - monthlyPaymentPercent, Settings.NumberSimbolsAfterComma);
                    loanBalance -= difference;
                    if (month % CommissionFrequency == 0)
                    {
                        AmountOfCommission = Math.Round(loanBalance * CommissionPercentage / 100.0, Settings.NumberSimbolsAfterComma);
                        dataPrinting.AnnuityPaymentWithCommission(month, DateStart, Math.Round(monthlyPaymentPercent / Settings.CurrencyValue, Settings.NumberSimbolsAfterComma), difference, loanBalance, AmountOfCommission, Settings.Currency);
                    }
                    else
                    {
                        dataPrinting.AnnuityPaymentWithoutCommission(month, DateStart, Math.Round(monthlyPaymentPercent / Settings.CurrencyValue, Settings.NumberSimbolsAfterComma), difference, loanBalance, Settings.Currency);
                    }
                }
            }
        }
    }
}
