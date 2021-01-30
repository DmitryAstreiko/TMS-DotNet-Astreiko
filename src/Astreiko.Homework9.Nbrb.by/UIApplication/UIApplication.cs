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

        private Rate CheckedRates;

        private List<Rate> checkListRates;

        public UIApplication()
        {
            countCurrency = 10;
            apiClient = new APIClient();
            fIleService = new FIleService();
        }

        public void ToDo()
        {
            while (true)
            {
                GetMenuSelectDate();

                typeSelectDates = GetVariantDate();

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

                switch (typeSelectDates)
                {
                    case TypeSelectDates.OneDate:
                        CheckedRates = apiClient.GetRates(DateTime.Parse(enteredDate), enteredCode);
                        ShowRates(CheckedRates);
                        break;
                    case TypeSelectDates.PeriodDate:
                        checkListRates = apiClient.GetRates(DateTime.Parse(enteredFirstDate),
                            DateTime.Parse(enteredFinishDate), enteredCode);
                        ShowRates(checkListRates);
                        break;
                }

                if (NeedSaveToFile())
                {
                    
                    var ttt = ShowPathToSaveFile();
                }
                Console.WriteLine("--------------");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool ShowPathToSaveFile()
        {
            Console.WriteLine();
            Console.Write($"Enter path (default C:\\temp): ");

            return fIleService.SaveFile(Console.ReadLine().Trim() != null ? Console.ReadLine().Trim() : "C:\\Temp", CheckedRates);
        }

        /// <summary>
        /// Check to need save to file
        /// </summary>
        /// <returns></returns>
        private bool NeedSaveToFile()
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Are you want to save currency into file? (y or n) ");

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
        /// <param name="listRates">list rate</param>
        private void ShowRates(List<Rate> listRates)
        {
            Console.WriteLine("------Info about selected rate:-------");

            foreach (var rates in listRates)
            {
                Console.WriteLine($"Abbreviation - {rates.Cur_Abbreviation}, name - {rates.Cur_Name}, rate - {rates.Cur_OfficialRate}.");
            }
        }

        /// <summary>
        /// Show rate
        /// </summary>
        /// <param name="rate">rate</param>
        private void ShowRates(Rate rate)
        {
            Console.WriteLine("------Info about selected rate:-------");

            Console.WriteLine($"Abbreviation - {rate.Cur_Abbreviation}, name - {rate.Cur_Name}, rate - {rate.Cur_OfficialRate}.");
        }

        private void ShowCurrencies(List<ShortCurrency> listCurrencies)
        {
            foreach (var currency in listCurrencies)
            {
                Console.WriteLine($"Code currency - {currency.Code}, abbreviation - {currency.Abbreviation}.");
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
