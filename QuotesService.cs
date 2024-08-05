using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TakeHomeAssessment.Models;


namespace TakeHomeAssessment
{
    public class QuotesService
    {

        HttpClient client;
        public QuotesService()
        {
            this.client = new HttpClient();
        }

        public async Task<QuoteDTO> GetQuote()
        {
            var response = await client.GetAsync("https://zenquotes.io/api/random");

           

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                List<QuoteDTO> Quotes = JsonSerializer.Deserialize<List<QuoteDTO>>(res);
                return Quotes[0];
            }

            return null;
        }
    }
}
