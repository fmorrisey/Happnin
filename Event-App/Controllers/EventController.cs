using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Event_App.Data;
using Event_App.Models;
using Event_App.Services;
using Newtonsoft.Json;

namespace Event_App.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private Geocoding _geocode;

        public EventController(ApplicationDbContext context) //, Geocoding geocoding)
        {
            _context = context;
            //_geocode = geocoding;
        }

        // GET: Event
        public async Task<IActionResult> Index()
        {
            ViewData["APIkey"] = Services.AuthKeys.Google_API_Key;
            return View(await _context.Event.ToListAsync());
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event newEvent, Address venue)
        //public async Task<IActionResult> Create([Bind("EventId,IdentityUserId,EventName,Venue,InterestId,EventDate,EventDescription,IsPrivate,IsVirtual")] Event @event)
        {



            if (ModelState.IsValid)
            {
                _context.Add(venue);
                _context.SaveChanges();

                GetCoordinates(venue);

                _context.Update(venue);
                _context.SaveChanges();

                newEvent.AddressId = venue.AddressId;


                _context.Add(newEvent);
                _context.SaveChanges();

                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newEvent);
        }




        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,IdentityUserId,EventName,Venue,InterestId,EventDate,EventDescription,IsPrivate,IsVirtual")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventId == id);
        }

        public async Task<Address> GetCoordinates(Address venue)
        //public void GetCoordinates(Address venue)
        {
            string address = venue.Street + "+" + venue.City + "+" + venue.State + "+" + venue.ZipCode;
            string baseUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=" + AuthKeys.Google_API_Key;

            var result = new System.Net.WebClient().DownloadString(baseUrl);
            dynamic geo = JsonConvert.DeserializeObject(result);

            var lat = geo.results[0].geometry.location.lat;//.ToString();
            var lng = geo.results[0].geometry.location.lng; //.ToString();
            venue.Latitude = lat;
            venue.Longitude = lng;
            return venue;
           //_context. Address.Update(venue);
            //_context.SaveChanges();




        }


    }
}
