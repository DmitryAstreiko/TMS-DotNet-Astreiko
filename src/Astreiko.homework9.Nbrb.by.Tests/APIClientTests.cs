using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Astreiko.Homework9.Nbrb.@by.API_Client;
using Astreiko.Homework9.Nbrb.@by.API_Client.Models;
using Astreiko.Homework9.Nbrb.@by.FileClient;
using NUnit.Framework;

namespace Astreiko.homework9.Nbrb.by.Tests
{
    public class APIClientTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetRatesAsyncShouldGetRates()
        {
            //arrange
            var apiClient = new APIClient();

            //act
            var rates = apiClient.GetRatesAsync(DateTime.Now, 141);

            //assert
            Assert.IsNotNull(rates);
        }


        [Test]
        public void GetRatesAsyncShouldGetListRates()
        {
            //arrange
            var apiClient = new APIClient();

            //act
            var listRates = apiClient.GetRatesAsync(new DateTime(2020,05,05), new DateTime(2020, 06, 06), 141);

            //assert
            Assert.IsNotNull(listRates);
        }

        [Test]
        public void GetCurrenciesAsyncShouldGetListCurrency()
        {
            //arrange
            var apiClient = new APIClient();

            //act
            var listCurrence = apiClient.GetCurrenciesAsync();

            //assert
            Assert.IsNotNull(listCurrence);
        }

        [Test]
        public async Task SaveAsyncShouldCorrectlySerializeRate()
        {
            //arrange
            var fileService = new FIleService();
            var rnd = new Random();

            var workFullPath = Path.Combine("D:\\_Temp\\", 
                            $"{rnd.Next(1000)}_{DateTime.Now.ToShortDateString()}.txt");

            var rate = new Rate()
            {
                Cur_ID = 111,
                Cur_Name = "USSR",
                Cur_Abbreviation = "Biggest Currency",
                Cur_Scale = 1,
                Cur_OfficialRate = 698.11
            };

            //act
            await fileService.SaveAsync(workFullPath, rate);

            //assert
            Assert.True(File.Exists(workFullPath));
        }

        [Test]
        public async Task SaveAsyncShouldCorrectlySerializeListShortRate()
        {
            //arrange
            var fileService = new FIleService();
            var rnd = new Random();

            var workFullPath = Path.Combine("D:\\_Temp\\",
                $"{rnd.Next(1000).ToString()}_{DateTime.Now.ToShortDateString()}.txt");

            var listShortRate = new List<ShortRate>();

            listShortRate.Add(new ShortRate() { Cur_ID = 455, Cur_OfficialRate = 56.25M, Date = new DateTime(2020, 09, 09) });
            listShortRate.Add(new ShortRate() { Cur_ID = 455, Cur_OfficialRate = 57.13M, Date = new DateTime(2020, 09, 10) });
            listShortRate.Add(new ShortRate() { Cur_ID = 455, Cur_OfficialRate = 60.49M, Date = new DateTime(2020, 09, 11) });
            listShortRate.Add(new ShortRate() { Cur_ID = 455, Cur_OfficialRate = 54.77M, Date = new DateTime(2020, 09, 12) });

            //act
            await fileService.SaveAsync(workFullPath, listShortRate);

            //assert
            Assert.True(File.Exists(workFullPath));
        }
    }
}