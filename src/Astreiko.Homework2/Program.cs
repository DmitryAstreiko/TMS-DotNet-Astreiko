using System;

namespace Astreiko.Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter date (format date - yyyy-mm-dd): ");
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
            }
        }
    }
}
