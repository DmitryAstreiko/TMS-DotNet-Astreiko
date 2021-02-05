using System;
using System.Collections.Generic;
using Astreiko.Homework9.Nbrb.@by.API_Client.Models;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Astreiko.Homework9.Nbrb.by.FileClient
{
    public class FIleService : IFileService
    {
        public async Task SaveAsync<T>(string path, T inputData, int enteredCode)
        {
            var fullPathFile = Path.Combine(path, $"{enteredCode}_{DateTime.Now.ToShortDateString()}.txt");

            using (FileStream fs = new FileStream(fullPathFile, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, inputData);
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Info saved to file.");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}
