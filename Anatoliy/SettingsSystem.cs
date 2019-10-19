using System;
using System.Globalization;
using System.Xml;

namespace Calculator
{
    class SettingsSystem
    {
        public string Currency;
        public string CodeCurrency;
        public double CurrencyValue;
        public int NumberSimbolsAfterComma;
        private DataEntry dataEntry = new DataEntry();
        public void CurrencySelection()
        {
            string currencyDollar = "доллар";
            string currencyRuble = "рубль";
            dataEntry.CurrencyEntry(out int typeCurrency);
            switch (typeCurrency)
            {
                case 1:
                    Currency = currencyDollar;
                    CodeCurrency = "840";
                    break;
                case 2:
                    Currency = currencyRuble;
                    CodeCurrency = "643";
                    break;
            }
        }
        public void GetCurrencyManually()
        {
            dataEntry.ValueEntry(out CurrencyValue);
        }
        public void GetCurrencyFromInternet()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("https://old.bank.gov.ua/NBUStatService/v1/statdirectory/exchange");
            XmlElement xRoot = xmlDocument.DocumentElement;
            XmlNode node = xRoot;
            bool stopFind = false;
            foreach (XmlNode xmlNode in xRoot)
            {
                foreach (XmlNode childnode in xmlNode.ChildNodes)
                {
                    if (childnode.Name == "r030" && childnode.InnerText == CodeCurrency)
                    {
                        node = xmlNode;
                        stopFind = true;
                        break;
                    }
                }
                if (stopFind)
                {
                    break;
                }
            }
            foreach (XmlNode xmlNode in node)
            {
                if (xmlNode.Name == "rate")
                {
                    CurrencyValue = double.Parse(xmlNode.InnerText, new CultureInfo("en-us"));
                    break;
                }
            }
            Console.WriteLine("Курс = " + CurrencyValue);
        }
        public void SetNumberSimbolsAfterComma()
        { 
            dataEntry.ValueEntry(out NumberSimbolsAfterComma);
        }
        public void ChooseMethodInputCurrency()
        {
            dataEntry.TypeEntry(out int typeEntryCurrencyValue);
            switch (typeEntryCurrencyValue)
            {
                case 1:
                    Console.WriteLine("Введите курс 1:N\nN = ");
                    GetCurrencyManually();
                    break;
                case 2:
                    GetCurrencyFromInternet();
                    break;
            }
        }
    }
}
