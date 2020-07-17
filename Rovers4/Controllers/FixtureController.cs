using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rovers4.Data;
using Rovers4.Models;
using Rovers4.ViewModels;

namespace Rovers4.Controllers
{
    public class FixtureController : Controller
    {
        private readonly ClubContext _context;
        private readonly IFixtureRepository _fixtureRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPlayerStatRepository _playerStatRepository;
        

        public FixtureController(ClubContext context, IFixtureRepository fixtureRepository , ITeamRepository teamRepository , IPersonRepository personRepository , IPlayerStatRepository playerStatRepository)
        {
            _context = context;
            _fixtureRepository = fixtureRepository;
            _teamRepository = teamRepository;
            _personRepository = personRepository;
            _playerStatRepository = playerStatRepository;
        }

        //public ViewResult TeamFixtureList(string teamName)
        //{
        //    IEnumerable<Fixture> fixture;
        //    string currentTeam;

        //    if (string.IsNullOrEmpty(teamName))
        //    {
        //        fixture = _fixtureRepository.AllFixtures.OrderBy(p => p.FixtureID);
        //        currentTeam = "All Teams";
        //    }
        //    else
        //    {
        //        fixture = _fixtureRepository.AllFixtures.Where(p => p.TeamName == teamName)
        //            .OrderBy(p => p.FixtureID);
        //        currentTeam = _teamRepository.Teams.FirstOrDefault(c => c.Name == teamName)?.Name;
        //    }

        //    return View(new FixtureListViewModel
        //    {
        //        Fixtures = fixture,
        //        CurrentTeam = currentTeam
        //    });
        //}

        public ViewResult TeamFixtureList(int? id)
        {
            IEnumerable<Fixture> fixture;
            string currentTeam;

            if (id == null)
            {
                fixture = _fixtureRepository.AllFixtures.OrderBy(p => p.TeamID);
                currentTeam = "All Team";
            }
            else
            {
                fixture = _fixtureRepository.AllFixtures.Where(p => p.TeamID == id)
                    .OrderByDescending(p => p.FixtureDate);
                currentTeam = _teamRepository.Teams.FirstOrDefault(c => c.TeamID == id)?.Name;
            }

            return View(new FixtureListViewModel
            {
                Fixtures = fixture,
                CurrentTeam = currentTeam,
            });
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
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name");
            return View();
        }

        // POST: Fixture/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FixtureID,TeamID,FixtureType,FixtureDate,Location,HomeOrAway,Opponent")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fixture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", fixture.TeamID);
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
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", fixture.TeamID);
            return View(fixture);
        }

        // POST: Fixture/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FixtureID,TeamID,FixtureType,FixtureDate,Location,HomeOrAway,Opponent")] Fixture fixture)
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
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", fixture.TeamID);
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
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", fixture.TeamID);
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
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", fixture.TeamID);
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
