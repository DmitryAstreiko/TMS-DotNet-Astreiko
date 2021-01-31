using System;
using System.Collections.Generic;
using Astreiko.Homework9.Nbrb.@by.API_Client.Models;
using System.IO;

namespace Astreiko.Homework9.Nbrb.by.FileClient
{
    public class FIleService
    {
        /// <summary>
        /// Save file
        /// </summary>
        /// <param name="pathToSave">path</param>
        /// <param name="rate">rate</param>
        /// <returns>bool</returns>
        public bool SaveFile(string pathToSave, Rate rate)
        {
            if (!ChechCreatePath(pathToSave)) return false;

            string[] lines = { $"{rate.CurID}", $"{rate.Cur_Name}", $"{rate.Cur_Abbreviation}", $"{rate.Cur_Scale}", $"{rate.Date}" };

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(pathToSave, $"{rate.Cur_Name}.txt")))
            {
                foreach (var line in lines)
                {
                    outputFile.WriteLine(line);
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Text save to file: {pathToSave}\\{rate.Cur_Name}.txt");
            Console.ResetColor();
            Console.WriteLine();

            return true;
        }

        /// <summary>
        /// Save file
        /// </summary>
        /// <param name="pathToSave">path</param>
        /// <param name="listShortRate">list short rate</param>
        /// <param name="codeCurrency"> code currency</param>
        /// <returns>bool</returns>
        public bool SaveFile(string pathToSave, List<ShortRate> listShortRate, int? codeCurrency)
        {
            try
            {
                if (!ChechCreatePath(pathToSave)) return false;

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(pathToSave, $"{codeCurrency}.txt")))
                {
                    foreach (var rate in listShortRate)
                    {
                        string[] lines = { $"{rate.Cur_ID}", $"{rate.Cur_OfficialRate}", $"{rate.Date}" };

                        foreach (var line in lines)
                        {
                            outputFile.WriteLine(line);
                        }
                    }
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Text save to file: {pathToSave}\\{codeCurrency}.txt.");
                Console.ResetColor();
                Console.WriteLine();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// Fill file (заполнение файла)
        /// </summary>
        /// <param name="fullFileName">full path</param>
        /// <param name="rate">rate</param>
        private void FillFile(string fullFileName, Rate rate)
        {
            using StreamWriter outputFile = new StreamWriter(Path.Combine(fullFileName));

            outputFile.WriteLine(rate);
        }

        /// <summary>
        /// Check or check and create path
        /// </summary>
        /// <param name="path">path</param>
        /// <returns>bool</returns>
        private bool ChechCreatePath(string path)
        {
            try
            {
                if (Directory.Exists(path)) return true;

                Directory.CreateDirectory(path);
                
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
