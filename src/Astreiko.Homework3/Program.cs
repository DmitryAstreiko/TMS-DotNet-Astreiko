using System;
using System.Collections.Generic;

namespace Astreiko.Homework3
{
    internal class Program
    {
        private enum Days
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7
        }

        private static void Main(string[] args)
        {
            var daysPeriod = GetDaysForPeriod();
            var inputFirstDate = daysPeriod.firstDate;
            var inputFinishDate = daysPeriod.secondDate;

            var cycleCheck = true;

            while (cycleCheck)
            {
                if (!CheckStartFinish(inputFirstDate, inputFinishDate))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! START must become earlier than FINISH date.");
                    Console.ResetColor();

                    daysPeriod = GetDaysForPeriod();
                    inputFirstDate = daysPeriod.firstDate;
                    inputFinishDate = daysPeriod.secondDate;
                }
                else cycleCheck = false;
            }

            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Start date - {inputFirstDate.ToShortDateString()}");
            Console.WriteLine($"Finish date - {inputFinishDate.ToShortDateString()}");
            Console.WriteLine("---------------------------------------");

            var selectedDay = string.Empty;

            cycleCheck = true;

            while (cycleCheck)
            {
                Console.Write("Enter DAY to search (in english) - : ");

                selectedDay = GetSelectDay(Console.ReadLine());

                if (selectedDay != null)
                {
                    Console.WriteLine($"DAY entered - {selectedDay}");
                    Console.WriteLine("---------------------------------------");
                    cycleCheck = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error. Wrong date entered.");
                    Console.ResetColor();
                }

            }

            var listFullDays = GetFullDates(inputFirstDate, inputFinishDate);

            var listFundedDays = GetFoundedDates(selectedDay, listFullDays);

            ShowToConsole(listFundedDays, selectedDay);

            Console.ReadKey();
        }

        private static (bool resParse, DateTime resDate) GetDate(string inputText)
        {
            var vRes = true;
            var inputDateRes = new DateTime(0001, 01, 01);

            try
            {
                inputDateRes = DateTime.Parse(inputText);
            }
            catch
            {                
                vRes = false;
            }

            return (vRes, inputDateRes);
        }

        private static (DateTime firstDate, DateTime secondDate) GetDaysForPeriod()
        {
            var inputFirstDate = new DateTime();
            var inputFinishDate = new DateTime();

            var cycleCheck = true;

            while (cycleCheck)
            {
                Console.Write("Enter start date : ");

                var resDateFirst = GetDate(Console.ReadLine());

                if (resDateFirst.resParse == true)
                {
                    inputFirstDate = resDateFirst.resDate;
                    cycleCheck = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Wrong date entered");
                    Console.ResetColor();
                }
            }

            cycleCheck = true;

            while (cycleCheck)
            {
                Console.Write("Enter finish date : ");

                var resDateEnd = GetDate(Console.ReadLine());

                if (resDateEnd.resParse == true)
                {
                    inputFinishDate = resDateEnd.resDate;
                    cycleCheck = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Wrong date entered");
                    Console.ResetColor();
                }
            }

            return (inputFirstDate, inputFinishDate);
        }

        private static bool CheckStartFinish(DateTime firstDate, DateTime endDate)
        {
            var vRes = !(firstDate > endDate);

            return vRes;
        }

        private static string GetSelectDay(string searchRow)
        {
            string vRes = null;

            if (searchRow.ToLower().Equals(nameof(Days.Monday).ToLower())) vRes = nameof(Days.Monday);
            else if (searchRow.ToLower().Equals(nameof(Days.Tuesday).ToLower())) vRes = nameof(Days.Tuesday);
            else if (searchRow.ToLower().Equals(nameof(Days.Wednesday).ToLower())) vRes = nameof(Days.Wednesday);
            else if (searchRow.ToLower().Equals(nameof(Days.Thursday).ToLower())) vRes = nameof(Days.Thursday);
            else if (searchRow.ToLower().Equals(nameof(Days.Friday).ToLower())) vRes = nameof(Days.Friday);
            else if (searchRow.ToLower().Equals(nameof(Days.Saturday).ToLower())) vRes = nameof(Days.Saturday);
            else if (searchRow.ToLower().Equals(nameof(Days.Sunday).ToLower())) vRes = nameof(Days.Sunday);

            return vRes;
        }

        private static List<DateTime> GetFullDates(DateTime start, DateTime end)
        {
            var listDates = new List<DateTime>();

            while(start < end)
            {
                listDates.Add(start);
                start = start.AddDays(1);
            }

            return listDates;
        }

        private static List<DateTime> GetFoundedDates(string rowSearch, List<DateTime> listSource) 
        {
            var listFunded = new List<DateTime>();

            foreach (var rowDate in listSource)
            {
                if (rowDate.DayOfWeek.ToString() == rowSearch)
                {
                    listFunded.Add(rowDate);
                }
            }
            return listFunded;
        }

        private static void ShowToConsole(List<DateTime> sourceList, string daySearch)
        {
            foreach (var rowList in sourceList)
            {
                Console.WriteLine($"{rowList.ToShortDateString()} - {daySearch}");
            }

            Console.WriteLine();

            Console.WriteLine($"Count days in period - {sourceList.Count}");
        }
    }
}
