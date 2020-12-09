using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Event_App.Data;
using Event_App.Models;
using System.Security.Claims;

namespace Event_App.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var person = _context.Person.Where(p => p.IdentityUserId == userId);
            if(person == null)
            {
                return View(nameof(Create));
            }
                
            return View(await person.ToListAsync());
        }

        // GET: Person/Details/5
        public async Task<IActionResult> Details()
        {
    

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var person = _context.Person.Where(c => c.IdentityUserId == userId).FirstOrDefault();
            if (person == null)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                return View(person);
            }


            //if (person == null)
            //{
            //    return NotFound();
            //}

            //return View(person);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            person.IdentityUserId = userId;

            try
            {

                _context.Add(person);
                person.IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    _context.Add(person);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", person.IdentityUserId);
            //return View(person);
        }


        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", person.IdentityUserId);
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Person person)
        {
            if (id != person.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", person.IdentityUserId);
            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Person.FindAsync(id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.PersonId == id);
        }

        public List<Person> SearchByName(string name)
        {
            var listOfPersons = _context.Person.Where(p => p.FirstName == name || p.LastName == name || p.FullName == name).ToList();
            return listOfPersons;
        }
        public List<Person> SearchByInterest(string interest)
        {
            var listOfPersons = _context.Person.Where(p => p.Interest == interest).ToList();
            return listOfPersons;
        }
        public void AddFriend(int id)
        {
            var newFriend = _context.Person.Where(p => p.PersonId == id).FirstOrDefault();
            Friends friend = new Friends();
            friend.PersonId2 = id;
            var selfId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Person self = _context.Person.Where(s => s.IdentityUserId == selfId).FirstOrDefault();
            friend.PersonId1 = self.PersonId;
            friend.isPending = true;
            self.pendingFriends.Add(newFriend);
        }

        public void AcceptFriendRequest(Friends friend)
        {
            friend.isPending = false;
            friend.isAccepted = true;
            Person self = _context.Person.Where(p => p.PersonId == friend.PersonId1).FirstOrDefault();
            Person newFriend = _context.Person.Where(p => p.PersonId == friend.PersonId2).FirstOrDefault();
            self.pendingFriends.Remove(newFriend);
            newFriend.pendingFriends.Remove(self);
            self.acceptedFriends.Add(newFriend);
            newFriend.acceptedFriends.Add(self);

        }

     
    }
}
