using System;

namespace Astreiko.Homework2
{
    class Program
    {
        private static void Main(string[] args)
        {
            //version 1
            WorkWithDate1();
            Console.WriteLine("");

            //version 2            
            WorkWithDate2();
            Console.ReadLine();
        }

        public static void WorkWithDate1()
        {
            Console.WriteLine("Version 1. Bad idea.");

            var check = true;

            var inputDate = String.Empty;

            while (check)
            {
                Console.Write("Enter date (format date - yyyy-mm-dd): ");
                inputDate = Console.ReadLine().Trim();

                if (inputDate.Length == 10)
                {
                    if ((inputDate.IndexOf("-") != 4) || (inputDate.Substring(5).IndexOf("-") != 2))
                    {
                        Console.WriteLine("Uncorrect date!");
                    }
                    else
                    {
                        check = false;
                    }
                }
                else
                {
                    Console.WriteLine("Uncorrect date!");
                }
            }

            try
            {
                var dateTimeNew = Convert.ToDateTime(inputDate);
                var valueDay = dateTimeNew.DayOfWeek;
                Console.WriteLine($"Day is - {valueDay}");
            }
            catch
            {
                Console.WriteLine("Uncorrect date!");
            }           
        }

        public static void WorkWithDate2()
        {
            Console.WriteLine("Version 2. Excellent.");

            var check = true;

            while (check)
            {
                Console.Write("Enter date: ");
                try
                {
                    var inPutDate = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine($"Day is - {inPutDate.DayOfWeek}");

                    check = false;
                }
                catch
                {
                    Console.WriteLine("Uncorrect date!");
                }
            }
           
        }
    }
}
