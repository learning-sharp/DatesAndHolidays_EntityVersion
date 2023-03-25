using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatesAndHolidays_EntityVersion.Scrapping
{
    class Parser
    {
        private HtmlLoader loader = new HtmlLoader();
        public List<string> holidays = new List<string>() { };


        public async Task work(string url)
        {
            if (this.holidays != null)
            {
                this.holidays.Clear();
            }

            Console.WriteLine(url);

            string source = await loader.getSource(url);
            HtmlParser parser = new HtmlParser();

            IHtmlDocument document = await parser.ParseDocumentAsync(source);
            Console.WriteLine(document.TextContent);

            var holidays = document.GetElementsByClassName("listing_wr")[0].GetElementsByClassName("main");

            foreach (IHtmlElement element in holidays)
            {
                var text = element.QuerySelector("span").TextContent.Trim();
                this.holidays.Add(text);
            }
        }


        public string getHolidays()
        {
            return String.Join("/", holidays);
        }
    }
}
