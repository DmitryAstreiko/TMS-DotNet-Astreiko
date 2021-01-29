using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Astreiko.Homework9.Nbrb.by.API_Client.Models;
using System.Linq;
using Newtonsoft.Json;

namespace Astreiko.Homework9.Nbrb.by.API_Client
{
    public class APIClientClass
    {
        private Dictionary<int, int> dictionaryCurrencies;

        public APIClientClass()
        {
            dictionaryCurrencies = new Dictionary<int, int>();
        }

        /// <summary>
        /// Getting full json file with all currencies
        /// </summary>
        /// <returns>list Currencies</returns>
        private async Task<List<Currencies>> GetAllCurrenciesAsync()
        {
            HttpClient httpClient = new HttpClient();
            string request = "https://www.nbrb.by/api/exrates/currencies";
            HttpResponseMessage response = (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Currencies>>(responseBody);
        }

        /// <summary>
        /// Receiving currency as a short list
        /// </summary>
        /// <param name="countCurrencies">Count elements need result</param>
        /// <returns>list short currencies</returns>
        public List<ShortCurrencies> GetShortCurrencies(int countCurrencies)
        {
            List<ShortCurrencies> vRes = new List<ShortCurrencies>();

            var listCurrencieses = GetAllCurrenciesAsync().Result.Where(x => x.Cur_DateEnd > DateTime.Now).OrderBy(y =>y.Cur_Code).ToList();

            CreateDictionaryCurrencies(listCurrencieses);

            for (int i = 0; i < countCurrencies; i++)
            {
                var shortCurrency = new ShortCurrencies();
                shortCurrency.Code = listCurrencieses[i].Cur_Code;
                shortCurrency.Abbreviation = listCurrencieses[i].Cur_Abbreviation;
                
                vRes.Add(shortCurrency);
            }
            return vRes;
        }

        /// <summary>
        /// Create dictionary for currencies
        /// </summary>
        /// <param name="listCurrencies">list currencies</param>
        private void CreateDictionaryCurrencies(List<Currencies> listCurrencies)
        {
            foreach (var currency in listCurrencies)
            {
                dictionaryCurrencies.Add(currency.Cur_Code, currency.Cur_ID);
            }
        }

        /// <summary>
        /// Task for get currency
        /// </summary>
        /// <param name="forDate">Date currency</param>
        /// <param name="codeCurrency">Code currency</param>
        /// <returns></returns>
        private async Task<Currencies> GetCurrencyOnDate(DateTime forDate, int codeCurrency)
        {
            HttpClient httpClient1 = new HttpClient();

            var searchDate = forDate.ToString("d");
            var searchCode = dictionaryCurrencies.FirstOrDefault(x => x.Key == codeCurrency).Value;

            string request = "https://www.nbrb.by/api/exrates/rates/" + searchCode + "?ondate=2020-1-1";
            HttpResponseMessage response = (await httpClient1.GetAsync(request)).EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Currencies>(responseBody);
        }

        /// <summary>
        /// Get currency on date
        /// </summary>
        /// <param name="forDate">Date currency</param>
        /// <param name="codeCurrency">Code currency</param>
        /// <returns></returns>
        public Currencies GetCurrency(DateTime forDate, int codeCurrency)
        {
            return GetCurrencyOnDate(forDate, codeCurrency).Result;
        }

        /// <summary>
        /// Get list currencies
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="finishDate">Finish date</param>
        /// <param name="codeCurrency">Code currency</param>
        /// <returns></returns>
        public List<Currencies> GetCurrencies(DateTime startDate, DateTime finishDate, int codeCurrency)
        {
            return GetCurrenciesOnPeriod(startDate, finishDate, codeCurrency).Result;
        }

        /// <summary>
        /// Task for get list currencies
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="finishDate">Finish date</param>
        /// <param name="codeCurrency">Code currency</param>
        /// <returns></returns>
        private async Task<List<Currencies>> GetCurrenciesOnPeriod(DateTime startDate, DateTime finishDate, int codeCurrency)
        {
            HttpClient httpClient = new HttpClient();

            var searchFirstDate = startDate.ToString("d");
            var searchfinishDate = finishDate.ToString("d");
            var searchCode = dictionaryCurrencies.FirstOrDefault(x => x.Key == codeCurrency).Value;

            ////https://www.nbrb.by/API/ExRates/Rates/Dynamics/190?startDate=2016-6-1&endDate=2016-6-30 

            string request = "https://www.nbrb.by/API/ExRates/Rates/Dynamics/" + searchCode + "?startDate=" + searchFirstDate + "&endDate=" + searchfinishDate;
            HttpResponseMessage response = (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Currencies>>(responseBody);
        }
    }
}
