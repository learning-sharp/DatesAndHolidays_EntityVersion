using System;
using System.Collections.Generic;

namespace DatesAndHolidays_EntityVersion.Scrapping
{
    class UrlConstructor
    {
        static private string baseUrl = "https://kakoysegodnyaprazdnik.ru/baza/";
        static private Dictionary<int, string> months = new Dictionary<int, string>()
        {
            { 1, "yanvar"},
            { 2, "fevral"},
            { 3, "mart"},
            { 4, "aprel"},
            { 5, "may"},
            { 6, "iyun"},
            { 7, "iyul"},
            { 8, "avgust"},
            { 9, "sentyabr"},
            { 10, "oktyabr"},
            { 11, "noyabr"},
            { 12, "dekabr"},
        };

        public string makeUrl(DateTime date)
        {
            return baseUrl + months[date.Month] + "/" + date.Day.ToString();
        }
    }
}
