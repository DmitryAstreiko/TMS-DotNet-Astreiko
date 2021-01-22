using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.Homework4
{
    /// <summary>
    /// Класс для записей календаря
    /// </summary>
    public class TemplateEvent
    {
        /// <summary>
        /// Идентификатор события
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Наименование события
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Начало периода
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Окончание периода
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Статус события
        /// </summary>
        public string Status { get; set; }
    }
}
