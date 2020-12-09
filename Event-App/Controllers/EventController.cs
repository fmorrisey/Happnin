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
using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace Event_App.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Geocoding _geocoding;

        public EventController(ApplicationDbContext context, Geocoding geocoding)
        {
            _context = context;
            _geocoding = geocoding;
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

    }
}
