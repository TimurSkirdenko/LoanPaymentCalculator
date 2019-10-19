using System;

namespace Calculator
{
    class DataPrinting
    {
        virtual public void DifferentiatedPaymentWithCommission(int month, DateTime DateStart, double monthlyPaymentPercent, double BasicPayment, double loanBalance, double AmountOfCommission, string currency)
        {
            Console.WriteLine(month + "   " + DateStart.AddMonths(month).ToLongDateString() + " - Сумма %: " + monthlyPaymentPercent + currency + " - Сумма общего платежа: " + BasicPayment + " - Остаток кредита: " + loanBalance + " - Комиссия = " + AmountOfCommission);
        }
        virtual public void DifferentiatedPaymentWithoutCommission(int month, DateTime DateStart, double monthlyPaymentPercent, double BasicPayment, double loanBalance, string currency)
        {
            Console.WriteLine(month + "   " + DateStart.AddMonths(month).ToLongDateString() + " - Сумма %: " + monthlyPaymentPercent + currency + " - Сумма общего платежа: " + BasicPayment + " - Остаток кредита: " + loanBalance);
        }
        virtual public void AnnuityPaymentWithCommission(int month, DateTime DateStart, double monthlyPaymentPercent, double difference, double loanBalance, double AmountOfCommission, string currency)
        {
            Console.WriteLine(month + "   " + DateStart.AddMonths(month).ToLongDateString() + " - Сумма %: " + monthlyPaymentPercent + currency + " - Сумма тело кредита: " + difference + " - Остаток кредита: " + loanBalance + " - Комиссия = " + AmountOfCommission);
        }
        virtual public void AnnuityPaymentWithoutCommission(int month, DateTime DateStart, double monthlyPaymentPercent, double difference, double loanBalance, string currency)
        {
            Console.WriteLine(month + "   " + DateStart.AddMonths(month).ToLongDateString() + " - Сумма %: " + monthlyPaymentPercent + currency + " - Сумма тело кредита: " + difference + " - Остаток кредита: " + loanBalance);
        }
    }
}
