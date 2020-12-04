using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Event_App
{
    public class TicketMasterAPI
    {
        public class EventJsonData
        {
            public _Embedded _embedded { get; set; }
            public _Links3 _links { get; set; }
            public Page page { get; set; }
        }

        public class _Embedded
        {
            public Event[] events { get; set; }
        }

        public class Event
        {
            public string name { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public bool test { get; set; }
            public string url { get; set; }
            public string locale { get; set; }
            public Image2[] images { get; set; }
            public Sales sales { get; set; }
            public Dates dates { get; set; }
            public Classification1[] classifications { get; set; }
            public Promoter promoter { get; set; }
            public Promoter1[] promoters { get; set; }
            public string info { get; set; }
            public string pleaseNote { get; set; }
            public Pricerange[] priceRanges { get; set; }
            public Seatmap seatmap { get; set; }
            public Accessibility accessibility { get; set; }
            public Agerestrictions ageRestrictions { get; set; }
            public _Links _links { get; set; }
            public _Embedded1 _embedded { get; set; }
            public Ticketlimit ticketLimit { get; set; }
            public Product[] products { get; set; }
        }

        public class Sales
        {
            public Public _public { get; set; }
            public Presale[] presales { get; set; }
        }

        public class Public
        {
            public DateTime startDateTime { get; set; }
            public bool startTBD { get; set; }
            public bool startTBA { get; set; }
            public DateTime endDateTime { get; set; }
        }

        public class Presale
        {
            public DateTime startDateTime { get; set; }
            public DateTime endDateTime { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string url { get; set; }
        }

        public class Dates
        {
            public Start start { get; set; }
            public End end { get; set; }
            public string timezone { get; set; }
            public Status status { get; set; }
            public bool spanMultipleDays { get; set; }
            public Initialstartdate initialStartDate { get; set; }
        }

        public class Start
        {
            public string localDate { get; set; }
            public bool dateTBD { get; set; }
            public bool dateTBA { get; set; }
            public bool timeTBA { get; set; }
            public bool noSpecificTime { get; set; }
            public string localTime { get; set; }
            public DateTime dateTime { get; set; }
        }

        public class End
        {
            public string localDate { get; set; }
            public bool approximate { get; set; }
            public bool noSpecificTime { get; set; }
        }

        public class Status
        {
            public string code { get; set; }
        }

        public class Initialstartdate
        {
            public string localDate { get; set; }
            public string localTime { get; set; }
            public DateTime dateTime { get; set; }
        }

        public class Promoter
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
        }

        public class Seatmap
        {
            public string staticUrl { get; set; }
        }

        public class Accessibility
        {
            public int ticketLimit { get; set; }
            public string info { get; set; }
        }

        public class Agerestrictions
        {
            public bool legalAgeEnforced { get; set; }
            public string ageRuleDescription { get; set; }
        }

        public class _Links
        {
            public Self self { get; set; }
            public Attraction[] attractions { get; set; }
            public Venue[] venues { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class Attraction
        {
            public string href { get; set; }
        }

        public class Venue
        {
            public string href { get; set; }
        }

        public class _Embedded1
        {
            public Venue1[] venues { get; set; }
            public Attraction1[] attractions { get; set; }
        }

        public class Venue1
        {
            public string name { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public bool test { get; set; }
            public string url { get; set; }
            public string locale { get; set; }
            public Image[] images { get; set; }
            public string postalCode { get; set; }
            public string timezone { get; set; }
            public City city { get; set; }
            public State state { get; set; }
            public Country country { get; set; }
            public Address address { get; set; }
            public Location location { get; set; }
            public Market[] markets { get; set; }
            public Dma[] dmas { get; set; }
            public Boxofficeinfo boxOfficeInfo { get; set; }
            public string parkingDetail { get; set; }
            public string accessibleSeatingDetail { get; set; }
            public Generalinfo generalInfo { get; set; }
            public Upcomingevents upcomingEvents { get; set; }
            public _Links1 _links { get; set; }
            public string[] aliases { get; set; }
            public Social social { get; set; }
            public Ada ada { get; set; }
        }

        public class City
        {
            public string name { get; set; }
        }

        public class State
        {
            public string name { get; set; }
            public string stateCode { get; set; }
        }

        public class Country
        {
            public string name { get; set; }
            public string countryCode { get; set; }
        }

        public class Address
        {
            public string line1 { get; set; }
        }

        public class Location
        {
            public string longitude { get; set; }
            public string latitude { get; set; }
        }

        public class Boxofficeinfo
        {
            public string phoneNumberDetail { get; set; }
            public string openHoursDetail { get; set; }
            public string acceptedPaymentDetail { get; set; }
            public string willCallDetail { get; set; }
        }

        public class Generalinfo
        {
            public string generalRule { get; set; }
            public string childRule { get; set; }
        }

        public class Upcomingevents
        {
            public int _total { get; set; }
            public int ticketmaster { get; set; }
            public int tmr { get; set; }
        }

        public class _Links1
        {
            public Self1 self { get; set; }
        }

        public class Self1
        {
            public string href { get; set; }
        }

        public class Social
        {
            public Twitter twitter { get; set; }
        }

        public class Twitter
        {
            public string handle { get; set; }
        }

        public class Ada
        {
            public string adaPhones { get; set; }
            public string adaCustomCopy { get; set; }
            public string adaHours { get; set; }
        }

        public class Image
        {
            public string ratio { get; set; }
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public bool fallback { get; set; }
            public string attribution { get; set; }
        }

        public class Market
        {
            public string name { get; set; }
            public string id { get; set; }
        }

        public class Dma
        {
            public int id { get; set; }
        }

        public class Attraction1
        {
            public string name { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public bool test { get; set; }
            public string url { get; set; }
            public string locale { get; set; }
            public Image1[] images { get; set; }
            public Classification[] classifications { get; set; }
            public Upcomingevents1 upcomingEvents { get; set; }
            public _Links2 _links { get; set; }
            public Externallinks externalLinks { get; set; }
            public string[] aliases { get; set; }
        }

        public class Upcomingevents1
        {
            public int _total { get; set; }
            public int universe { get; set; }
            public int ticketmaster { get; set; }
        }

        public class _Links2
        {
            public Self2 self { get; set; }
        }

        public class Self2
        {
            public string href { get; set; }
        }

        public class Externallinks
        {
            public Twitter1[] twitter { get; set; }
            public Facebook[] facebook { get; set; }
            public Wiki[] wiki { get; set; }
            public Instagram[] instagram { get; set; }
            public Homepage[] homepage { get; set; }
            public Itune[] itunes { get; set; }
            public Lastfm[] lastfm { get; set; }
            public Musicbrainz[] musicbrainz { get; set; }
        }

        public class Twitter1
        {
            public string url { get; set; }
        }

        public class Facebook
        {
            public string url { get; set; }
        }

        public class Wiki
        {
            public string url { get; set; }
        }

        public class Instagram
        {
            public string url { get; set; }
        }

        public class Homepage
        {
            public string url { get; set; }
        }

        public class Itune
        {
            public string url { get; set; }
        }

        public class Lastfm
        {
            public string url { get; set; }
        }

        public class Musicbrainz
        {
            public string id { get; set; }
        }

        public class Image1
        {
            public string ratio { get; set; }
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public bool fallback { get; set; }
        }

        public class Classification
        {
            public bool primary { get; set; }
            public Segment segment { get; set; }
            public Genre genre { get; set; }
            public Subgenre subGenre { get; set; }
            public Type type { get; set; }
            public Subtype subType { get; set; }
            public bool family { get; set; }
        }

        public class Segment
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Genre
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Subgenre
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Type
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Subtype
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Ticketlimit
        {
            public string info { get; set; }
        }

        public class Image2
        {
            public string ratio { get; set; }
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public bool fallback { get; set; }
        }

        public class Classification1
        {
            public bool primary { get; set; }
            public Segment1 segment { get; set; }
            public Genre1 genre { get; set; }
            public Subgenre1 subGenre { get; set; }
            public Type1 type { get; set; }
            public Subtype1 subType { get; set; }
            public bool family { get; set; }
        }

        public class Segment1
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Genre1
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Subgenre1
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Type1
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Subtype1
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Promoter1
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
        }

        public class Pricerange
        {
            public string type { get; set; }
            public string currency { get; set; }
            public float min { get; set; }
            public float max { get; set; }
        }

        public class Product
        {
            public string name { get; set; }
            public string id { get; set; }
            public string url { get; set; }
            public string type { get; set; }
            public Classification2[] classifications { get; set; }
        }

        public class Classification2
        {
            public bool primary { get; set; }
            public Segment2 segment { get; set; }
            public Genre2 genre { get; set; }
            public Subgenre2 subGenre { get; set; }
            public Type2 type { get; set; }
            public Subtype2 subType { get; set; }
            public bool family { get; set; }
        }

        public class Segment2
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Genre2
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Subgenre2
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Type2
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Subtype2
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class _Links3
        {
            public First first { get; set; }
            public Self3 self { get; set; }
            public Next next { get; set; }
            public Last last { get; set; }
        }

        public class First
        {
            public string href { get; set; }
        }

        public class Self3
        {
            public string href { get; set; }
        }

        public class Next
        {
            public string href { get; set; }
        }

        public class Last
        {
            public string href { get; set; }
        }

        public class Page
        {
            public int size { get; set; }
            public int totalElements { get; set; }
            public int totalPages { get; set; }
            public int number { get; set; }
        }

    }
}
