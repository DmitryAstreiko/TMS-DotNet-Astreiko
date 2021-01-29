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
        /// 
        /// </summary>
        /// <param name="forDateTime"></param>
        /// <param name="codeCurrency"></param>
        /// <returns></returns>
        public async Task<Currencies> GetCurrencies(DateTime forDateTime, int codeCurrency)
        {
            HttpClient httpClient = new HttpClient();

            var searchDate = forDateTime.ToString("d");
            var searchCode = dictionaryCurrencies.FirstOrDefault(x => x.Key == codeCurrency).Key;

            //string request = "https://www.nbrb.by/api/exrates/rates/145?ondate=2016-7-5";

            string request = "https://www.nbrb.by/api/exrates/rates/{searchCode}?ondate={searchDate}";
            HttpResponseMessage response = (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Currencies>(responseBody);
        }
    }
}
