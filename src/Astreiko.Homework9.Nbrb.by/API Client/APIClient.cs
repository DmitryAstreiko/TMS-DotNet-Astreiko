using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Astreiko.Homework9.Nbrb.by.API_Client.Models;
using System.Linq;
using System.Net.Http.Json;

namespace Astreiko.Homework9.Nbrb.by.API_Client
{
    public class APIClient
    {
        /// <summary>
        /// Dictionary for currencies (save code currency and internal code)
        /// </summary>
        private Dictionary<int, int> dictionaryCurrencies;

        private static HttpClient httpClient = new HttpClient();

        public APIClient()
        {
            dictionaryCurrencies = new Dictionary<int, int>();
        }

        /// <summary>
        /// Getting full json file with all currencies
        /// </summary>
        /// <returns>list Currencies</returns>
        private async Task<List<Currency>> GetAllCurrenciesAsync()
        {
            //HttpClient httpClient = new HttpClient();
            //string request = "https://www.nbrb.by/api/exrates/currencies";
            //HttpResponseMessage response = (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();

            //return JsonConvert.DeserializeObject<List<Currencies>>(responseBody);

            return await httpClient.GetFromJsonAsync<List<Currency>>("https://www.nbrb.by/api/exrates/currencies");
        }

        /// <summary>
        /// Receiving currency as a short list
        /// </summary>
        /// <returns>list short currencies</returns>
        /// 
        public async Task<List<Currency>> GetShortCurrenciesAsync()
        {
            var listCurrencies = (await GetAllCurrenciesAsync()).ToList();

            if (dictionaryCurrencies.Count == 0) CreateDictionaryCurrencies(listCurrencies);

            return listCurrencies.Where(x => x.Date > DateTime.Now)
                .OrderBy(y => y.Code)
                .Select(c => new Currency()
                {
                    Name = c.Name,
                    Abbreviation = c.Abbreviation,
                    Code = c.Code
                })
                .ToList();
        }

        /// <summary>
        /// Create dictionary for currencies
        /// </summary>
        /// <param name="listCurrencies">list currencies</param>
        private void CreateDictionaryCurrencies(List<Currency> listCurrencies)
        {
            dictionaryCurrencies.Clear();

            foreach (var currency in listCurrencies.Where(x => x.Date > DateTime.Now))
            {
                dictionaryCurrencies.Add(currency.Code, currency.InternalID);
            }
        }

        /// <summary>
        /// Get rates on date
        /// </summary>
        /// <param name="forDate">Date currency</param>
        /// <param name="codeCurrency">Code currency</param> 
        /// <returns>Rate</returns>
        public async Task<Rate> GetRatesAsync(DateTime forDate, int codeCurrency)
        {
            if (dictionaryCurrencies.Count == 0) CreateDictionaryCurrencies((await GetAllCurrenciesAsync()).ToList());

            var searchDate = forDate.ToString("yyyy-M-d");
            var searchCode = dictionaryCurrencies.FirstOrDefault(x => x.Key == codeCurrency).Value;

            var request = "https://www.nbrb.by/api/exrates/rates/" + searchCode + "?ondate=" + searchDate;
            return await httpClient.GetFromJsonAsync<Rate>(request);
        }

        /// <summary>
        /// Get list short rates
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="finishDate">Finish date</param>
        /// <param name="codeCurrency">Code currency</param>
        /// <returns>List short rate</returns>
        public async Task<List<ShortRate>> GetRatesAsync(DateTime startDate, DateTime finishDate, int codeCurrency)
        {
            if (dictionaryCurrencies.Count == 0) CreateDictionaryCurrencies((await GetAllCurrenciesAsync()).ToList());

            var searchFirstDate = startDate.ToString("yyyy-M-d");
            var searchFinishDate = finishDate.ToString("yyyy-M-d");
            var searchCode = dictionaryCurrencies.FirstOrDefault(x => x.Key == codeCurrency).Value;

            var request = "https://www.nbrb.by/API/ExRates/Rates/Dynamics/" + searchCode + "?startDate=" + searchFirstDate + "&endDate=" + searchFinishDate;
            return await httpClient.GetFromJsonAsync<List<ShortRate>>(request);
        }

    }
}
