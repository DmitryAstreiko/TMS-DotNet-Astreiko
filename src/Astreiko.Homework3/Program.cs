using System;

namespace Astreiko.Homework3
{
    class Program
    {
        private static DateTime inputFirstDate { get; set; }

        private static DateTime inputFinishDate { get; set; }

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

        static void Main(string[] args)
        {
            //if(!InputDates()) return;

            //if (!CheckStartFinish()) return;

            //Console.WriteLine("---------------------------------------");
            //Console.WriteLine($"Start date - {inputFirstDate}");
            //Console.WriteLine($"Start date - {inputFinishDate}");
            //Console.WriteLine("---------------------------------------");

            var www = CheckInputDay();

            Console.WriteLine($"{www}");
        } 

        private static string CheckInputDay()
        {
            string vRes = "123";
            Console.Write("Enter DAY to search - ");

            var inputDay = Console.ReadLine();

            if (inputDay.Equals(Enum.Parse(Days.Monday))) 
            { 
                vRes = Days.Monday.ToString(); 
            }

            //string qqq;
            //Enum.TryParse(inputDay, out qqq)

            ////Name myName;
            //if (Enum.TryParse<Name>(nameString, out myName))
            //{
            //    switch (myName) { case John: ... }
            //}

            return vRes;
        }

        private static bool CheckStartFinish()
        {
            var vRes = true;

            if (inputFirstDate > inputFinishDate)
            {
                vRes = false;
                Console.WriteLine("Error! START must become earlier then FINISH date.");
            }

            return vRes;
        }

        private static bool InputDates()
        {
            var vRes = true;
            try
            {
                Console.Write("Enter start date : ");

                inputFirstDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter finish date : ");

                inputFinishDate = DateTime.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Error! Wrong date entered");
                vRes = false;
            }

            return vRes;
        }

    }
}
