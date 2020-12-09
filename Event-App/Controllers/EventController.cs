using Event_App.Data;
using Event_App.Models;
using Event_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Event_App.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Geocoding _geocoding;
        private PublicEvents _publicEvents;

        public EventController(ApplicationDbContext context, Geocoding geocoding, PublicEvents publicEvents)
        {
            _context = context;
            _geocoding = geocoding;
            _publicEvents = publicEvents;
        }

        // GET: Event
        public async Task<IActionResult> Index()
        {

            ViewData["APIkey"] = Services.AuthKeys.Google_API_Key;

            //queries
            EventViewModel eventViewModel = new EventViewModel()
            {

                Events = _context.Event.ToList(),
                Addresses = _context.Address.ToList(),
                Interests = _context.Interest.ToList(),

            };

            List<EventViewModel> evm = new List<EventViewModel>();
            evm.Add(eventViewModel);

            return View(evm);
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventContext = await _context.Event
                    .FirstOrDefaultAsync(m => m.EventId == id);
            if (eventContext == null)
            {
                return NotFound();
            }

            var eventHost = await _context.Person
                    .FirstOrDefaultAsync(m => m.PersonId == eventContext.PersonId);
            var eventAddress = await _context.Address
                    .FirstOrDefaultAsync(a => a.AddressId == eventContext.AddressId);


            EventDetialsViewModel evd = new EventDetialsViewModel()
            {
                deatilEvent = eventContext,
                host = eventHost,
                address = eventAddress,

            };

            return View(evd);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            // CreateEventViewModel createEvent = new CreateEventViewModel();
            ///// var interestList = new SelectList(_context.Interest.ToList(),"ID","InterestId");
            // createEvent.Interest = interestList; //_context.Interest.ToList();// interestList;

            CreateEventViewModel createEvent = new CreateEventViewModel();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            createEvent.CurrentPerson = _context.Person.Where(person => person.IdentityUserId == userId).SingleOrDefault();

            if (createEvent.CurrentPerson == null)
            {
                return new RedirectToActionResult("Create", "Person", null);
            }
            createEvent.Interests = _context.Interest.ToList();

            return View(createEvent);


        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event newEvent, Address venue)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var person = _context.Person.Where(person => person.IdentityUserId == userId).SingleOrDefault();

            _context.Add(venue);
            _context.SaveChanges();

            if (newEvent.IsVirtual == false) //this will save api calls cost $$$$ 
            {
                venue = await _geocoding.GetGeoCoding(venue);


            }

            _context.Update(venue);
            _context.SaveChanges();

            _context.SaveChanges();

            newEvent.AddressId = venue.AddressId;
            newEvent.PersonId = person.PersonId;

            _context.Add(newEvent);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }




        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventContext = await _context.Event
                    .FindAsync(id);

            if (eventContext == null)
            {
                return NotFound();
            }

            var eventHost = await _context.Person
                    .FirstOrDefaultAsync(m => m.PersonId == eventContext.PersonId);
            var eventAddress = await _context.Address
                    .FirstOrDefaultAsync(a => a.AddressId == eventContext.AddressId);


            EventDetialsViewModel evd = new EventDetialsViewModel()
            {
                deatilEvent = eventContext,
                host = eventHost,
                address = eventAddress,
                Interests = _context.Interest.ToList()

            };

            return View(evd);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Event editEvent, Address address)
        {
            if (id != editEvent.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    if (editEvent.IsVirtual == false) //this will save api calls cost $$$$ 
                    {
                        address = await _geocoding.GetGeoCoding(address);
                    }

                    editEvent.AddressId = address.AddressId;

                    _context.Update(address);
                    _context.Update(editEvent);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(editEvent.EventId))
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
            return View(editEvent);
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

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult CreatePublicEvents(Event newEvent, Address address)
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var person = _context.Person.Where(person => person.IdentityUserId == userId).SingleOrDefault();

            string eventUrl = _publicEvents.GetEvents(person);
            var result = new System.Net.WebClient().DownloadString(eventUrl);
            dynamic eventList = JsonConvert.DeserializeObject(result);

            foreach (var item in eventList._embedded.events)
            {
                var name = item.name;
                var date = item.dates.start.localDate;

                var venueName = item._embedded.venues[0].name;
                var street = item._embedded.venues[0].address.line1;
                var city = item._embedded.venues[0].city.name;
                var state = item._embedded.venues[0].state.stateCode;
                var zip = item._embedded.venues[0].postalCode;
                var lng = item._embedded.venues[0].location.longitude;
                var lat = item._embedded.venues[0].location.latitude;

                address.AddressId = 0;
                address.Venue = venueName;
                address.Street = street;
                address.City = city;
                address.State = state;
                address.ZipCode = zip;
                address.Longitude = lng;
                address.Latitude = lat;
                _context.Add(address);
                _context.SaveChanges();

                newEvent.EventId = 0;
                newEvent.EventName = name;
                newEvent.EventDate = date;
                newEvent.AddressId = address.AddressId;
                newEvent.PersonId = 1;
                newEvent.InterestId = 20;

                //newEvent.Address = address.Venue;
                _context.Add(newEvent);
                _context.SaveChanges();


            }
            return RedirectToAction(nameof(Index));

        }


        public ActionResult Confirm(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var person = _context.Person.Where(person => person.IdentityUserId == userId).SingleOrDefault();

            return RedirectToAction(nameof(Index));
        }


    }
}