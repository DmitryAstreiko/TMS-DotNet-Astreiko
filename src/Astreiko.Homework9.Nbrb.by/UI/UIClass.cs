using System;
using System.Collections.Generic;
using System.Text;
using Astreiko.Homework9.Nbrb.@by.UI.Enums;

namespace Astreiko.Homework9.Nbrb.by.UI
{
    public class UIClass
    {
        public void GetMenuSelectDate()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Please choose the operation : ");
            Console.WriteLine("Input date for select currency - (1)");
            Console.WriteLine("Input period for select currency - (2)");
            Console.WriteLine("Exit - [3]");
            Console.ResetColor();
            Console.WriteLine("-----");
        }

        public TypeSelectDates GetVariantDate()
        {
            while (true)
            {
                Console.Write("Select operation: ");
                var numInput = int.Parse(Console.ReadLine().Trim());

                switch (numInput)
                {
                    case 1:
                        return TypeSelectDates.OneDate;
                    case 2:
                        return TypeSelectDates.PeriodDate;
                    case 3:
                        return TypeSelectDates.None;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entered uncorrect number. Please try again.");
                        Console.ResetColor();
                        break;
                }
            }

        }
    }
}
