using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Astreiko.Homework7.Models
{
    internal class TrainingGenerator
    {
        private static int CountTrainingsInStatistic { get; set; } = 100;

        /// <summary>
        /// Get trainings
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Training> GetTrainings()
        {
            return Enumerable.Range(0, CountTrainingsInStatistic).Select(CreateTraining);
        }

        /// <summary>
        /// Create training
        /// </summary>
        /// <param name="num">Count training</param>
        /// <returns></returns>
        private static Training CreateTraining(int num)
        {
            Random rnd = new Random();

            var tempTrainig = new Training
            {
                StartDate = new DateTime(2020, rnd.Next(1, 12), rnd.Next(1, 30), rnd.Next(0, 23), rnd.Next(0, 59), rnd.Next(0, 59)),
                Step = rnd.Next(1000, 6000),
                Distance = rnd.Next(100, 2000),
                Duration = new TimeSpan(rnd.Next(0, 23), rnd.Next(0, 59), rnd.Next(0, 59)),
                AveragePulse = rnd.Next(80, 140)
            };

            return tempTrainig;
        }

        //public static IEnumerable<int> GetPulses(bool isThird)
        //{
        //    yield return 0;

        //    yield return 1;

        //    if (isThird)
        //        yield return 2;
        //    else yield break;

        //    yield return 3;
        //    // or
        //    // return isThird ? new[] {0,1,2,3} : new[] {0,1}
        //}
    }
}
