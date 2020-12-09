using System;

namespace Astreiko.Homework2
{
    class Program
    {
        static void Main(string[] args)
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
            Console.Write("Version 1. Enter date (format date - yyyy-mm-dd): ");
            string inPutdate = Console.ReadLine().ToString().Trim();

            if (inPutdate.Length != 10)
            {
                Console.WriteLine("Uncorrect date!");
                return;
            }

            if ((inPutdate.IndexOf("-") != 4) || (inPutdate.Substring(5).IndexOf("-") != 2))
            {
                Console.WriteLine("Uncorrect date!");
                return;
            }

            try
            {
                var dateTimeNew = Convert.ToDateTime(inPutdate);
                var valueDay = dateTimeNew.DayOfWeek;
                Console.WriteLine($"Day is - {valueDay}");
            }
            catch
            {
                Console.WriteLine("Uncorrect date!");
                return;
            }           
        }

        public static void WorkWithDate2()
        {
            Console.Write("Version 2. Enter date: ");
            try
            {
                var inPutDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine($"Day is - {inPutDate.DayOfWeek}");
            }
            catch
            {
                Console.WriteLine("Uncorrect date!");
                return;
            }
        }
    }
}
