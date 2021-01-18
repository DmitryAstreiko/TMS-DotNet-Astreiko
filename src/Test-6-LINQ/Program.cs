using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_6_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Fitness Tracker...");

            var trainings = TrainingGenerator.GetTrainings();
            //var pulse1 = TrainingGenerator.GetPulses(true);
            //var pulse2 = TrainingGenerator.GetPulses(false);

            Console.WriteLine("Statistics...");
            var evegareDistance = GetAverageDisnanse(trainings);
            var allTimeDistance = GetAllTimeDisnanse(trainings);
            var maxDistance = GetMaxDisnanse(trainings);
        }

        private static double GetMaxDisnanse(IEnumerable<Training> trainings)
        {
            throw new NotImplementedException();
        }

        private static double GetAllTimeDisnanse(IEnumerable<Training> trainings)
        {
            throw new NotImplementedException();
        }

        private static double GetAverageDisnanse(IEnumerable<Training> trainings)
        {
            throw new NotImplementedException();
        }
    }

    internal class TrainingGenerator
    {
        public static IEnumerable<Training> GetTrainings()
        {
            return Enumerable.Range(0, 100).Select(CreateTraining);
        }

        private static Training CreateTraining(int num)
        {
            //var rnd = Random();
            

            throw new NotImplementedException();
        }

        public static IEnumerable<int> GetPulses(bool isThird)
        {
            yield return 0;

            yield return 1;

            if (isThird)
                yield return 2;
            else yield break;

            yield return 3;
            // or
           // return isThird ? new[] {0,1,2,3} : new[] {0,1}
        }
    }

    internal class Training
    {
        public TimeSpan Duration { get; set; }

        public DateTime StartDate { get; set; }

        public double Distance { get; set; }

        public int Step { get; set; }

        public int AveragePulse { get; set; }
    }
}
