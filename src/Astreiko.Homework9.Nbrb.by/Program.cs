using System;
using Astreiko.Homework9.Nbrb.by;
using Astreiko.Homework9.Nbrb.@by.UI;
using Astreiko.Homework9.Nbrb.@by.UI.Enums;

namespace Astreiko.Homework9.Nbrb.by
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDo();   
        }

        private static void ToDo()
        {
           var uiClass = new UIClass();

           uiClass.GetMenuSelectDate();

           var inputNumDate = uiClass.GetVariantDate();

           switch (inputNumDate)
           {
               case TypeSelectDates.OneDate:
                   break;
               case TypeSelectDates.PeriodDate:
                   break;
               case TypeSelectDates.None:
                   break;
           }

           Console.ReadKey();
        }
    }
}
