using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DatesAndHolidays_EntityVersion.Scrapping
{
    class HtmlLoader
    {
        static readonly HttpClient client = new HttpClient();

        public HtmlLoader()
        {
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.5359.125 Safari/537.36");
        }


        public async Task<string> getSource(string url)
        {
            HttpResponseMessage responce = await client.GetAsync(url);
            string source = default;

            if (responce != null && responce.StatusCode == HttpStatusCode.OK)
            {
                source = await responce.Content.ReadAsStringAsync();
                return source;
            }

            throw new HttpRequestException(responce.StatusCode.ToString());
        }
    }
}
