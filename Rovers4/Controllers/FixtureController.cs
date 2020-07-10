using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rovers4.Data;
using Rovers4.Models;

namespace Rovers4.Controllers
{
    public class FixtureController : Controller
    {
        private readonly ClubContext _context;

        public FixtureController(ClubContext context)
        {
            _context = context;
        }

        // GET: Fixture
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fixtures.ToListAsync());
        }

        // GET: Fixture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures
                .FirstOrDefaultAsync(m => m.FixtureID == id);
            if (fixture == null)
            {
                return NotFound();
            }

            return View(fixture);
        }

        // GET: Fixture/Details/5
        public async Task<IActionResult> ResultDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures
                .FirstOrDefaultAsync(m => m.FixtureID == id);
            if (fixture == null)
            {
                return NotFound();
            }

            return View(fixture);
        }

        // GET: Fixture/Create
        public IActionResult Create()
        {
            ViewData["TeamName"] = new SelectList(_context.Teams, "Team", "Name");
            return View();
        }

        // POST: Fixture/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FixtureID,TeamID,FixtureType,FixtureDate,Location,HomeOrAway,MeetTime,MeetLocation,OurScore,Opponent,OpponentScore,Result,ResultDescription,MatchReport")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fixture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fixture);
        }



        // GET: Fixture/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures.FindAsync(id);
            if (fixture == null)
            {
                return NotFound();
            }
            ViewData["TeamName"] = new SelectList(_context.Teams, "Team", "Name", fixture.Team.Name);
            return View(fixture);
        }

        // POST: Fixture/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FixtureID,TeamID,FixtureType,FixtureDate,Location,HomeOrAway,MeetTime,MeetLocation,OurScore,Opponent,OpponentScore,Result,ResultDescription,MatchReport")] Fixture fixture)
        {
            if (id != fixture.FixtureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fixture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FixtureExists(fixture.FixtureID))
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
            ViewData["TeamName"] = new SelectList(_context.Teams, "Team", "Name", fixture.Team.Name);
            return View(fixture);
        }

        // GET: Fixture/Edit/5
        public async Task<IActionResult> AddResult(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures.FindAsync(id);
            if (fixture == null)
            {
                return NotFound();
            }
            ViewData["TeamName"] = new SelectList(_context.Teams, "Team", "Name", fixture.Team.Name);
            PopulatePlayerDropDownList();
            return View(fixture);
        }

        // POST: Fixture/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddResult(int id, [Bind("FixtureID,TeamID,FixtureType,FixtureDate,HomeOrAway,OurScore,Opponent,OpponentScore,Result,ResultDescription,MatchReport")] Fixture fixture)
        {
            if (id != fixture.FixtureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fixture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FixtureExists(fixture.FixtureID))
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
            ViewData["TeamName"] = new SelectList(_context.Teams, "Team", "Name", fixture.Team.Name);
            PopulatePlayerDropDownList();
            return View(fixture);
        }

        // Method that loads Player info for the dropdownList - https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/update-related-data?view=aspnetcore-3.1
        private void PopulatePlayerDropDownList(object selectedPlayer = null)
        {
            var personQuery = from d in _context.Persons
                              where d.PersonType == PersonType.Player
                              orderby d.FullName
                              select d;
            ViewBag.PlayerID = new SelectList(personQuery.AsNoTracking(), "PlayerID", "Name", selectedPlayer);
        }

        // GET: Fixture/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures
                .FirstOrDefaultAsync(m => m.FixtureID == id);
            if (fixture == null)
            {
                return NotFound();
            }

            return View(fixture);
        }

        // POST: Fixture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fixture = await _context.Fixtures.FindAsync(id);
            _context.Fixtures.Remove(fixture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FixtureExists(int id)
        {
            return _context.Fixtures.Any(e => e.FixtureID == id);
        }
    }
}
