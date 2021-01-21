using System;
using System.Collections.Generic;
using System.Linq;
using Test_6_LINQ.Models;

namespace Test_6_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Fitness Tracker...");
            Console.WriteLine("");

            var trainings = TrainingGenerator.GetTrainings();
            //var pulse1 = TrainingGenerator.GetPulses(true);
            //var pulse2 = TrainingGenerator.GetPulses(false);

            ShowTrainings(trainings);

            Console.WriteLine("Statistics...");
            var evegareDistance = GetAverageDistanse(trainings);
            var allTimeDistance = GetAllTimeDistanse(trainings);
            var maxDistance = GetMaxDistanse(trainings);

            ShowStatistics(evegareDistance, maxDistance, allTimeDistance);
        }

        /// <summary>
        /// Show all trainings
        /// </summary>
        /// <param name="trainings">Collection of training</param>
        private static void ShowTrainings(IEnumerable<Training> trainings)
        {
            Console.WriteLine("Exist trainings...");

            foreach (var train in trainings)
            {
                Console.WriteLine($"Training: {train.StartDate}, {train.Duration}, {train.Distance}, {train.Step}, {train.AveragePulse}.");
            }

            Console.WriteLine("");
        }

        /// <summary>
        /// Show statistics
        /// </summary>
        /// <param name="evegareDistance">Max distance for all trainings</param>
        /// <param name="maxDistance">Distance for all trainings</param>
        /// <param name="allTimeDistance">Average distance for all trainings</param>
        private static void ShowStatistics(double evegareDistance, double maxDistance, double allTimeDistance)
        {
            Console.WriteLine("----------------");
            Console.WriteLine("Show statistics:");
            Console.WriteLine($"Max distance for all trainings: {maxDistance}");
            Console.WriteLine($"Distance for all trainings: {allTimeDistance}");
            Console.WriteLine($"Average distance for all trainings: {evegareDistance}");
            Console.WriteLine("----------------");

            Console.ReadKey();
        }

        /// <summary>
        /// Max distance for all trainings
        /// </summary>
        /// <param name="trainings">Collection of training</param>
        /// <returns></returns>
        private static double GetMaxDistanse(IEnumerable<Training> trainings)
        {
            return trainings.Max(x => x.Distance);
        }

        /// <summary>
        /// Distance for all trainings
        /// </summary>
        /// <param name="trainings">Collection of training</param>
        /// <returns></returns>
        private static double GetAllTimeDistanse(IEnumerable<Training> trainings)
        {
            return trainings.Sum(x => x.Distance);
        }

        /// <summary>
        /// Average distance for all trainings
        /// </summary>
        /// <param name="trainings">Collection of training</param>
        /// <returns></returns>
        private static double GetAverageDistanse(IEnumerable<Training> trainings)
        {
            return trainings.Average(x => x.Distance);
        }
    }
}
