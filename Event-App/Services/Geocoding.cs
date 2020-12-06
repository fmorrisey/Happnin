using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.Services
{
    public class Geocoding
    {
        public class GeocodingService
        {
            private string GetGeoCodingURL(Customer customer)
            {
                return $"https://maps.google.com/maps/api/geocode/json?address={customer.Line_1}+{customer.City}+{customer.State}&key="
                    + AuthKeys.AuthKeys.Google_API_Key;
            }

            public async Task<Customer> GetGeoCoding(Customer customer)
            {
                string apiURL = GetGeoCodingURL(customer);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicationException/json"));

                    HttpResponseMessage response = await client.GetAsync(apiURL);

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        JObject jsonResults = JsonConvert.DeserializeObject<JObject>(data);
                        JToken results = jsonResults["results"][0];
                        JToken location = results["geometry"]["location"];

                        customer.Latitude = (double)location["lat"];
                        customer.Longitude = (double)location["lng"];
                    }
                }

                return customer;
            }


        }
    }
}
