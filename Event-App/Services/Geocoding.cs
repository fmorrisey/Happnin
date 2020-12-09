using Event_App.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Event_App.Services
{
    public class Geocoding
    {
        private string GetGeoCodingURL(Address address)
        {
            return $"https://maps.google.com/maps/api/geocode/json?address={address.Street}+{address.City}+{address.State}+{address.ZipCode}&key="
                + AuthKeys.Google_API_Key;
        }

        public async Task<Address> GetGeoCoding(Address address)
        {
            string apiURL = GetGeoCodingURL(address);

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

                    address.Latitude = (double)location["lat"];
                    address.Longitude = (double)location["lng"];
                }
            }

            return address;
        }


        private string GetGeoCodingURL(Person person)
        {
            return $"https://maps.googleapis.com/maps/api/geocode/json?components=postal_code%3A+{person.ZipCode}%7Ccountry%3USA&key="
                + AuthKeys.Google_API_Key;



        }

        public async Task<Person> GetGeoCoding(Person person)
        {
            string apiURL = GetGeoCodingURL(person);

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

                    person.Latitude = (double)location["lat"];
                    person.Longitude = (double)location["lng"];
                }
            }

            return person;
        }
    }
}
