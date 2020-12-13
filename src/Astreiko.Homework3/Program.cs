using System;

namespace Astreiko.Homework3
{
    class Program
    {
        private static DateTime inputFirstDate { get; set; }

        private static DateTime inputFinishDate { get; set; }

        static void Main(string[] args)
        {
            if(!InputDates()) return;

            if (!CheckStartFinish()) 
            {
                Console.WriteLine("Error! START must become earlier then FINISH date.");
                return;
            }

            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Start date - {inputFirstDate}");
            Console.WriteLine($"Start date - {inputFinishDate}");
            Console.WriteLine("---------------------------------------");
        } 

        private static bool CheckStartFinish()
        {
            var vRes = true;

            if (inputFirstDate > inputFinishDate) vRes = false;

            return vRes;
        }

        private static bool InputDates()
        {
            var vRes = true;
            try
            {
                Console.Write("Enter start date:");

                inputFirstDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter finish date:");

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
