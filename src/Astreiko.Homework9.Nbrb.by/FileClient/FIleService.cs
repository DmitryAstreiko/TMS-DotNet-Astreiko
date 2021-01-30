using System;
using System.Collections.Generic;
using System.Text;
using Astreiko.Homework9.Nbrb.@by.API_Client.Models;
using System.IO;

namespace Astreiko.Homework9.Nbrb.by.FileClient
{
    public class FIleService
    {
        public bool SaveFile(string pathToSave, Rate rates)
        {
            if (ChechCreatePath(pathToSave))
            {
                var fullPathName = $"{pathToSave}\\{rates.Cur_Name}_{DateTime.Now}.txt";

                File.Create(fullPathName).Dispose();

                if (File.Exists(fullPathName)) FillFile(fullPathName, rates);


                return true;
            }

            return false;
        }

        private void FillFile(string fullFileName, Rate rates)
        {
            using StreamWriter outputFile = new StreamWriter(Path.Combine(fullFileName));

            outputFile.WriteLine(rates);
            
        }

        private bool ChechCreatePath(string path)
        {
            try
            {
                if (Directory.Exists(path)) return true;

                Directory.CreateDirectory(path);
                
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
