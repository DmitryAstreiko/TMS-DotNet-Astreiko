using System;
using System.Collections.Generic;
using Astreiko.Homework9.Nbrb.@by.API_Client;
using Astreiko.Homework9.Nbrb.@by.API_Client.Models;
using Astreiko.Homework9.Nbrb.@by.FileClient;
using Astreiko.Homework9.Nbrb.@by.UI.Enums;

namespace Astreiko.Homework9.Nbrb.by.UI
{
    public class UIApplication
    {
        /// <summary>
        /// Count currency which will be show in the list
        /// </summary>
        private int countCurrency;

        private APIClient apiClient;

        private FIleService fIleService;

        /// <summary>
        /// Entered first date
        /// </summary>
        private string enteredFirstDate;

        /// <summary>
        /// Entered end date
        /// </summary>
        private string enteredFinishDate;

        /// <summary>
        /// Entered currency code
        /// </summary>
        private int enteredCode;

        /// <summary>
        /// Entered date for searching currency
        /// </summary>
        private string enteredDate;

        /// <summary>
        /// Enum for date options 
        /// </summary>
        private TypeSelectDates typeSelectDates;

        private Rate checkedRate;

        private List<ShortRate> checkListShortRates;

        public UIApplication()
        {
            countCurrency = 30;
            apiClient = new APIClient();
            fIleService = new FIleService();
        }

        public void ToDo()
        {
            while (true)
            {
                GetMenuSelectDate();

                typeSelectDates = GetVariantDate();

                Console.ForegroundColor = ConsoleColor.Green;
                switch (typeSelectDates)
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
                        Console.WriteLine();
                        enteredFinishDate = GetDate("Enter finish date: ").ToShortDateString();
                        Console.WriteLine($"Entered finish date - {enteredFinishDate}");
                        break;
                    case TypeSelectDates.None:
                        Console.WriteLine("--------------");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Application will be close.");
                        Console.ResetColor();
                        return;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-------List currencies-------");
                ShowCurrencies(apiClient.GetShortCurrencies(countCurrency));
                Console.WriteLine("--------------");

                Console.ForegroundColor = ConsoleColor.Magenta;
                enteredCode = GetCode();
                Console.WriteLine($"Entered code - {enteredCode}");
                Console.WriteLine("--------------");
                Console.ResetColor();

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                switch (typeSelectDates)
                {
                    case TypeSelectDates.OneDate:
                        checkedRate = apiClient.GetRates(DateTime.Parse(enteredDate), enteredCode);
                        ShowRate(checkedRate);
                        SaveFile(null);
                        break;
                    case TypeSelectDates.PeriodDate:
                        var resultRates = apiClient.GetRates(DateTime.Parse(enteredFirstDate),
                            DateTime.Parse(enteredFinishDate), enteredCode);
                        checkListShortRates = resultRates.listShortRate;
                        ShowRates(checkListShortRates);
                        SaveFile(resultRates.codeCurrency);
                        break;
                }
                Console.ResetColor();
            }
        }

        private void SaveFile(int? codeCurrency)
        {
            if (NeedSaveToFile())
            {
                if (!ShowPathToSaveFile(codeCurrency))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error save file");
                    Console.ResetColor();
                }
            }
            Console.WriteLine("--------------");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool ShowPathToSaveFile(int? codeCurrency)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.Write($"Enter path (default C:\\temp): ");

            var enteredPath = Console.ReadLine().Trim();
            var workPath = String.IsNullOrEmpty(enteredPath) != true ? enteredPath : "C:\\Temp";

            switch (typeSelectDates)
            {
                case TypeSelectDates.OneDate:
                    if (checkedRate is null) return false;
                    else return fIleService.SaveFile(workPath, checkedRate);
                case TypeSelectDates.PeriodDate:
                    if (checkListShortRates.Count == 0) return false;
                    else return fIleService.SaveFile(workPath, checkListShortRates, codeCurrency);
                default:
                    return false;
            }
            //return typeSelectDates == TypeSelectDates.OneDate ? fIleService.SaveFile(workPath, checkedRate) : fIleService.SaveFile(workPath, checkListShortRates, codeCurrency);
        }

        /// <summary>
        /// Check to need save to file
        /// </summary>
        /// <returns></returns>
        private bool NeedSaveToFile()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.Write("Are you want to save currency into file? (y or n) ");
                Console.ResetColor();

                switch (Console.ReadLine()?.Trim())
                {
                    case "y":
                        return true;
                    case "n":
                        return false;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entered correct answer.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        /// <summary>
        /// Show rate
        /// </summary>
        /// <param name="listShortRates">list rate</param>
        private void ShowRates(List<ShortRate> listShortRates)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------Info about selected rate:-------");

            if (listShortRates.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No information to display.");
                Console.ResetColor();
            }
            else
            {
                foreach (var rates in listShortRates)
                {
                    Console.WriteLine($"Date - {rates.Date}, rate - {rates.Cur_OfficialRate}.");
                }
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Show rate
        /// </summary>
        /// <param name="rate">rate</param>
        private void ShowRate(Rate rate)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------Info about selected rates:-------");

            if (rate == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No information to display.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Abbreviation - {rate.Cur_Abbreviation}, name - {rate.Cur_Name}, rate - {rate.Cur_OfficialRate}.");
                Console.ResetColor();
            }
        }

        private void ShowCurrencies(List<ShortCurrency> listCurrencies)
        {
            foreach (var currency in listCurrencies)
            {
                Console.WriteLine($"Code currency - {currency.Code}, abbreviation - {currency.Abbreviation}, name - {currency.Name}.");
            }
        }

        /// <summary>
        /// Main menu
        /// </summary>
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

        /// <summary>
        /// Get date option
        /// </summary>
        /// <returns>enum TypeSelectDates</returns>
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

        /// <summary>
        /// Check correctly date
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Check correctly code
        /// </summary>
        /// <returns></returns>
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
