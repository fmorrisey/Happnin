using Event_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.Services
{
    public class PublicEvents

    {
        public string getState(Person Person)
        {
            string zip = Person.ZipCode.ToString();
            string getState = $"https://maps.googleapis.com/maps/api/geocode/json?address={zip}&region=us&key=" + AuthKeys.Google_API_Key;
            var result = new System.Net.WebClient().DownloadString(getState);
            dynamic stateInfo = JsonConvert.DeserializeObject(result);

            string state = stateInfo.results[0].address_components[3].short_name.ToString();
            //Console.WriteLine(state);
            return state;
        }


        public string GetEvents(Person person)

        {
            string stateCode = getState(person);

            string eventUrl = $"https://app.ticketmaster.com/discovery/v2/events?stateCode={stateCode}&endDateTime=2021-05-01T08:18:00Z&apikey=" + AuthKeys.TicketMaster_API_Key;

            return eventUrl;
        }




            //var result = new System.Net.WebClient().DownloadString(eventUrl);
            //dynamic eventList = JsonConvert.DeserializeObject(result);

            //foreach (var item in eventList._embedded.events)
            //{
            //    var name = item.name;
            //    var date = item.dates.start.localDate;

            //    var venueName = item._embedded.venues[0].name;
            //    var street = item._embedded.venues[0].address.line1;
            //    var city = item._embedded.venues[0].city.name;
            //    var state = item._embedded.venues[0].state.stateCode;
            //    var zip = item._embedded.venues[0].postalCode;
            //    var lng = item._embedded.venues[0].location.longitude;
            //    var lat = item._embedded.venues[0].location.latitude;

            //    address.Venue = venueName;
            //    address.Street = street;
            //    address.City = city;
            //    address.State = state;
            //    address.ZipCode = zip;
            //    address.Longitude = lng;
            //    address.Latitude = lat;
            //    _context.Add(address);
            //    _context.SaveChanges();
                
                
                
                
            //    Console.WriteLine(name);
            //    Console.WriteLine(date);
            //    Console.WriteLine(venueName);
            //    Console.WriteLine(street);
            //    Console.WriteLine(city + ", " + state + " " + zip);
            //    Console.WriteLine("longitude: " + lng);
            //    Console.WriteLine("lattitude: " + lat);

            //    Console.WriteLine();
            //}

        }
}
