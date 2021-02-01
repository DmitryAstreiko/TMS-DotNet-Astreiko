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

        private static HttpClient httpClient;

        public APIClient()
        {
            dictionaryCurrencies = new Dictionary<int, int>();
            httpClient = new HttpClient();
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
        public async Task<List<ShortCurrency>> GetShortCurrenciesAsync()
        {
            List<ShortCurrency> vRes = new List<ShortCurrency>();

            try
            { var listCurrencies = (await GetAllCurrenciesAsync()).ToList();

                CreateDictionaryCurrencies(listCurrencies);

                return listCurrencies.Where(x => x.Cur_DateEnd > DateTime.Now)
                    .OrderBy(y => y.Cur_Code)
                    .Select(c => new ShortCurrency()
                    {
                        Name = c.Cur_Name,
                        Abbreviation = c.Cur_Abbreviation,
                        Code = c.Cur_Code
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.StackTrace}, {e.StackTrace}");

                return vRes;
            }
           
        }

        /// <summary>
        /// Create dictionary for currencies
        /// </summary>
        /// <param name="listCurrencies">list currencies</param>
        private void CreateDictionaryCurrencies(List<Currency> listCurrencies)
        {
            dictionaryCurrencies.Clear();

            foreach (var currency in listCurrencies.Where(x => x.Cur_DateEnd > DateTime.Now))
            {
                dictionaryCurrencies.Add(currency.Cur_Code, currency.Cur_ID);
            }
        }

        /// <summary>
        /// Task for get Rates
        /// </summary>
        /// <param name="forDate">Date currency</param>
        /// <param name="codeCurrency">Code currency</param>
        /// <returns>Task</returns>
        private async Task<Rate> GetRateOnDateAsync(DateTime forDate, int codeCurrency)
        {
            CreateDictionaryCurrencies((await GetAllCurrenciesAsync()).ToList());

            var searchDate = forDate.ToString("yyyy-M-d");
            var searchCode = dictionaryCurrencies.FirstOrDefault(x => x.Key == codeCurrency).Value;

            var request = "https://www.nbrb.by/api/exrates/rates/" + searchCode + "?ondate=" + searchDate;
            return await httpClient.GetFromJsonAsync<Rate>(request);
        }

        /// <summary>
        /// Get rates on date
        /// </summary>
        /// <param name="forDate">Date currency</param>
        /// <param name="codeCurrency">Code currency</param> 
        /// <returns>Rate</returns>
        public async Task<Rate> GetRatesAsync(DateTime forDate, int codeCurrency)
        {
            try
            {
                return await GetRateOnDateAsync(forDate, codeCurrency);
            }
            catch
            {
                return null;
            }
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
            try
            {
                return await GetRatesOnPeriodAsync(startDate, finishDate, codeCurrency);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Task for get list rates
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="finishDate">Finish date</param>
        /// <param name="codeCurrency">Code currency</param>
        /// <returns>Task</returns>
        private async Task<List<ShortRate>> GetRatesOnPeriodAsync(DateTime startDate, DateTime finishDate, int codeCurrency)
        {
            CreateDictionaryCurrencies((await GetAllCurrenciesAsync()).ToList());

            var searchFirstDate = startDate.ToString("yyyy-M-d");
            var searchFinishDate = finishDate.ToString("yyyy-M-d");
            var searchCode = dictionaryCurrencies.FirstOrDefault(x => x.Key == codeCurrency).Value;

            var request = "https://www.nbrb.by/API/ExRates/Rates/Dynamics/" + searchCode + "?startDate=" + searchFirstDate + "&endDate=" + searchFinishDate;
            return await httpClient.GetFromJsonAsync<List<ShortRate>>(request);
        }
    }
}
