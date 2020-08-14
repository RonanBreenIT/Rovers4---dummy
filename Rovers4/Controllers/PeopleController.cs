using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rovers4.Data;
using Rovers4.Models;

namespace Rovers4.Controllers
{
    [Authorize(Roles = "Super Admin, Team Admin, Member")]
    public class PeopleController : Controller
    {
        private readonly ClubContext _context;

        public PeopleController(ClubContext context)
        {
            _context = context;
        }

        //// GET: People
        //[Authorize(Roles = "Super Admin, Team Admin, Member")]
        //public async Task<IActionResult> Index()
        //{
        //    var clubContext = _context.Persons.Include(p => p.Team);
        //    return View(await clubContext.ToListAsync());
        //}

        // GET: People/Details/5
        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        public IActionResult Create()
        {
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,PersonType,MgmtRole,PlayerPosition,FirstName,Surname,DOB,Mobile,Email,Image,TeamID,PlayerStatID,ThumbnailImage,PersonBio")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Team");
            }
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", person.TeamID);
            return View(person);
        }

        // GET: People/Create
        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        public IActionResult CreateMgmt()
        {
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMgmt([Bind("PersonID,PersonType,MgmtRole,FirstName,Surname,DOB,Mobile,Email,Image,TeamID,PlayerStatID,ThumbnailImage,PersonBio")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Team");
            }
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", person.TeamID);// Might just be person.TeamName
            return View(person);
        }

        // GET: People/Edit/5
        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", person.TeamID);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonID,PersonType,MgmtRole,PlayerPosition,FirstName,Surname,DOB,Mobile,Email,Image,TeamID,PlayerStatID, ThumbnailImage,PersonBio")] Person person)
        {
            if (id != person.PersonID)
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
                    if (!PersonExists(person.PersonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Team");
            }
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", person.TeamID);
            return View(person);
        }

        // GET: People/Edit/5
        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        public async Task<IActionResult> EditMgmt(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", person.TeamID);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMgmt(int id, [Bind("PersonID,PersonType,MgmtRole,PlayerPosition,FirstName,Surname,DOB,Mobile,Email,Image,TeamID,PlayerStatID, ThumbnailImage,PersonBio")] Person person)
        {
            if (id != person.PersonID)
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
                    if (!PersonExists(person.PersonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Team");
            }
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", person.TeamID);
            return View(person);
        }

        // GET: People/Delete/5
        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Team");
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.PersonID == id);
        }
    }
}
