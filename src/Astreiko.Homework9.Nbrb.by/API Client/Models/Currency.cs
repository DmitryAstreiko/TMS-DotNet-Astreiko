using System;
using System.Text.Json.Serialization;

namespace Astreiko.Homework9.Nbrb.by.API_Client.Models
{
    public class Currency
    {

        /// <summary>
        /// Internal code (внутренний код)
        /// </summary>
        [JsonPropertyName("Cur_ID")]
        public int InternalID { get; set; }

        /// <summary>
        /// Currency code
        /// </summary>
        [JsonPropertyName("Cur_Code")]
        public int Code { get; set; }

        /// <summary>
        /// Abbreviation
        /// </summary>
        [JsonPropertyName("Cur_Abbreviation")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// Currency name
        /// </summary>
        [JsonPropertyName("Cur_Name")]
        public string Name { get; set; }

        /// <summary>
        /// Date of exclusion of a currency from the list of currencies (дата исключения валюты из перечня валют)
        /// </summary>
        [JsonPropertyName("Cur_DateEnd")]
        public DateTime? Date { get; set; }
    }
}
