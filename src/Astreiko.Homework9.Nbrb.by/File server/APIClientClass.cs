using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Astreiko.Homework9.Nbrb.by.File_server.Models;
using Newtonsoft.Json;
using System.IO;
using Astreiko.Homework9.Nbrb.by.File_server.Models;

namespace Astreiko.Homework9.Nbrb.by.File_server
{
    public class APIClientClass
    {
        public List<Currencies> GetAllCurrencies()
        {
            var clientHttp = new HttpClient();
            var response = clientHttp.GetAsync(new Uri("https://www.nbrb.by/api/exrates/currencies"));
            var qqq = response.GetAwaiter().GetResult();
            //var result = response.Content.ReadAsStringAsync();

            var ttt = JsonConvert.DeserializeObject<Currencies>();

            return ttt;
        }

        public int GetCurrencies(int countCurrencies)
        {
            //var listCurriens = new List<Currencies>();
            var ttt = GetAllCurrencies();

            return 0;
        }
    }
}
