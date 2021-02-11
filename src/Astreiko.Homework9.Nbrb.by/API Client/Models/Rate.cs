﻿using System;

namespace Astreiko.Homework9.Nbrb.by.API_Client.Models
{
    public class Rate
    {
        /// <summary>
        /// Internal code (внутренний код)
        /// </summary>
        public int Cur_ID { get; set; }

        /// <summary>
        /// Вate on which the course is requested (дата, на которую запрашивается курс)
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Abbreviation (буквенный код)
        /// </summary>
        public string Cur_Abbreviation { get; set; }

        /// <summary>
        /// Number of units of foreign currency (количество единиц иностранной валюты)
        /// </summary>
        public int Cur_Scale { get; set; }

        /// <summary>
        /// Currency name (наименование валюты)
        /// </summary>
        public string Cur_Name { get; set; }

        /// <summary>
        /// Rate (курс)
        /// </summary>
        public double? Cur_OfficialRate { get; set; }
    }
}
