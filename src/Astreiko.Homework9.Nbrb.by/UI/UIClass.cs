using System;
using System.Collections.Generic;
using Astreiko.Homework9.Nbrb.@by.API_Client;
using Astreiko.Homework9.Nbrb.@by.API_Client.Models;
using Astreiko.Homework9.Nbrb.@by.UI.Enums;

namespace Astreiko.Homework9.Nbrb.by.UI
{
    public class UIClass
    {
        private int countCurrency;

        private APIClientClass apiClient;

        private string enteredFirstDate;

        private string enteredFinishDate;

        private int enteredCode;

        private string enteredDate;

        public UIClass()
        {
            countCurrency = 10;
            apiClient = new APIClientClass();
        }

        public void ToDo()
        {
            GetMenuSelectDate();

            var variantDate = GetVariantDate();

            switch (variantDate)
            {
                case TypeSelectDates.OneDate:
                    Console.WriteLine("--------------");
                    enteredDate = GetDate("Enter date: ").ToShortDateString();
                    Console.WriteLine($"Entered date - {enteredDate}");
                    break;
                case TypeSelectDates.PeriodDate:
                    Console.WriteLine("--------------");
                    enteredFirstDate = GetDate("Enter first date: ").ToShortDateString();
                    Console.WriteLine($"Entered first date - {enteredFirstDate}");
                    enteredFinishDate = GetDate("Enter finish date: ").ToShortDateString();
                    Console.WriteLine($"Entered finish date - {enteredFinishDate}");
                    break;
                case TypeSelectDates.None:
                    Console.WriteLine("--------------");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Application will be close.");
                    Console.ResetColor();
                    return;
            }

            Console.WriteLine("-------List currencies-------");
            ShowCurrencies(apiClient.GetShortCurrencies(countCurrency));
            Console.WriteLine("--------------");

            enteredCode = GetCode();
            Console.WriteLine($"Entered code - {enteredCode}");
            Console.WriteLine("--------------");
            
            Console.WriteLine();

            if (variantDate == TypeSelectDates.OneDate)
            {
                ShowCurrencies(apiClient.GetCurrency(DateTime.Parse(enteredDate), enteredCode));
            }
            else if (variantDate == TypeSelectDates.PeriodDate)
            {
                ShowCurrencies();
            }

            Console.WriteLine("-4444444444-");
        }

        private void ShowCurrencies(List<Currencies> listCurrencies)
        {
            Console.WriteLine("------Info about selected currencies:-------");

            foreach (var currency in listCurrencies)
            {
                Console.WriteLine($"Code currency - {currency.Cur_Code}, abbreviation - {currency.Cur_Abbreviation}, name - {currency.Cur_QuotName}.");
            }
        }
        private void ShowCurrencies(Currencies currencies)
        {
            Console.WriteLine("------Info about selected currency:-------");

            Console.WriteLine($"Code currency - {currencies.Cur_Code}, abbreviation - {currencies.Cur_Abbreviation}, name - {currencies.Cur_Name}.");
        }

        private void ShowCurrencies(List<ShortCurrencies> listCurrencies)
        {
            foreach (var currency in listCurrencies)
            {
                Console.WriteLine($"Code currency - {currency.Code}, abbreviation - {currency.Abbreviation}.");
            }
        }

        private void GetMenuSelectDate()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Please choose the operation : ");
            Console.WriteLine("Input date for select currency - [1]");
            Console.WriteLine("Input period for select currency - [2]");
            Console.WriteLine("Exit - [3]");
            Console.ResetColor();
            Console.WriteLine("--------------");
        }

        private TypeSelectDates GetVariantDate()
        {
            while (true)
            {
                Console.Write("Select operation: ");

                switch (Console.ReadLine()?.Trim())
                {
                    case "1":
                        return TypeSelectDates.OneDate;
                    case "2":
                        return TypeSelectDates.PeriodDate;
                    case "3":
                        return TypeSelectDates.None;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entered uncorrect number. Please try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }
        private DateTime GetDate(string text)
        {
            while (true)
            {
                Console.Write($"{text}");

                if (DateTime.TryParse(Console.ReadLine()?.Trim(), out var selectDateTime)) return selectDateTime;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter correct date. ");
                    Console.ResetColor();
            }
        }

        private int GetCode()
        {
            while (true)
            {
                Console.Write($"Enter code: ");

                if (int.TryParse(Console.ReadLine()?.Trim(), out var selectcode)) return selectcode;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter correct code. ");
                Console.ResetColor();
            }
        }
    }
}
