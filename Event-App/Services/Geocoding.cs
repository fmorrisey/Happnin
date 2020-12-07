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
        public class GeocodingService
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


        }
    }
