using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Astreiko.Homework9.Nbrb.by.File_server.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;
using System.Linq;

namespace Astreiko.Homework9.Nbrb.by.File_server
{
    public class APIClientClass
    {
        public List<Currencies> listCurriensCurrencieses { get; set; }

        public async Task GetAllCurrenciesAsync()
        {
            //var clientHttp = new HttpClient();
            //var response = clientHttp.GetAsync(new Uri("https://www.nbrb.by/api/exrates/currencies"));
            //var qqq = response.
            ////var result = response.Content.ReadAsStringAsync();

            //var ttt = JsonConvert.DeserializeObject<Currencies>();

            //return ttt;

            HttpClient httpClient = new HttpClient();
            string request = "https://www.nbrb.by/api/exrates/currencies";
            HttpResponseMessage response = (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            //JArray jArray = JArray.Parse(responseBody);

            //JObject jObject = JObject.Parse(responseBody);
            //Currencies rrrrr = JsonConvert.DeserializeObject<Currencies>(responseBody);

            //var yyt = JValue.Parse(responseBody).ToList();

            //foreach (var aaa in rrrrr)
            //{
            //    Console.WriteLine(aaa);

            //    Console.WriteLine("asdasd");
            //}

            listCurriensCurrencieses = new List<Currencies>();

            List<Currencies> ttt = JsonSerializer.Deserialize<List<Currencies>>(responseBody);

            var q = responseBody.ToList();

            foreach (var tt in ttt)
            {
                var ttttttt = new Currencies();

                ttttttt.Cur_Abbreviation = tt.Cur_Abbreviation;
                ttttttt.Cur_Code = tt.Cur_Code;

                listCurriensCurrencieses.Add(ttttttt);
            }


            Console.WriteLine("asdasdas");

        }

        public int GetCurrencies(int countCurrencies)
        {
            //var listCurriens = new List<Currencies>();
            var ttt = GetAllCurrenciesAsync();
           ///55 ttt.
            

            return 0;
        }
    }
}
