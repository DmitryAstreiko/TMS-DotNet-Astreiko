using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Astreiko.Homework9.Nbrb.by.API_Client.Models;
using System.Text.Json.Serialization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Astreiko.Homework9.Nbrb.by.API_Client
{
    public class APIClientClass
    {
        public async Task<List<Currencies>> GetAllCurrenciesAsync()
        {
            HttpClient httpClient = new HttpClient();
            string request = "https://www.nbrb.by/api/exrates/currencies";
            HttpResponseMessage response = (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Currencies>>(responseBody);
        }

        public List<ShortCurrences> GetCurrencies(int countCurrencies)
        {
            List<ShortCurrences> vRes = new List<ShortCurrences>();

            var listCurrencieses = GetAllCurrenciesAsync().Result.Where(x => x.Cur_DateEnd < DateTime.Now).ToList();

            for (int i = 0; i < countCurrencies; i++)
            {
                var shortCurrency = new ShortCurrences();
                shortCurrency.Code = listCurrencieses[i].Cur_Code;
                shortCurrency.Abbreviation = listCurrencieses[i].Cur_Abbreviation;
                
                vRes.Add(shortCurrency);
            }

            return vRes;
        }
    }
}
