using System;
using System.Collections.Generic;
using System.Linq;

namespace Payroll.Utils
{
    public class SelectedPeriod
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public string MonthName => MonthHelper.GetMonthName(Month);
    }

    public static class MonthHelper
    {
        public static readonly Dictionary<string, int> NameToNumber = new Dictionary<string, int>
        {
            { "Январь", 1 }, { "Февраль", 2 }, { "Март", 3 }, { "Апрель", 4 },
            { "Май", 5 }, { "Июнь", 6 }, { "Июль", 7 }, { "Август", 8 },
            { "Сентябрь", 9 }, { "Октябрь", 10 }, { "Ноябрь", 11 }, { "Декабрь", 12 }
        };

        public static string GetMonthName(int month)
        {
            return NameToNumber.FirstOrDefault(x => x.Value == month).Key ?? "Январь";
        }

        public static int GetMonthNumber(string name)
        {
            return NameToNumber.TryGetValue(name ?? "", out var number) ? number : DateTime.Now.Month;
        }
    }

}
