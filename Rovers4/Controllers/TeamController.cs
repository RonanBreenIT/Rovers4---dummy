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
    public class TeamController : Controller
    {
        private readonly ClubContext _context;
        private readonly IPersonRepository _personRepository;
        private readonly ITeamRepository _teamRepository;
       


        public TeamController(IPersonRepository personRepository, ITeamRepository teamRepository, ClubContext context)
        {
            _personRepository = personRepository;
            _teamRepository = teamRepository;
            _context = context;
        }

        public ViewResult TeamPlayerList(string teamName)
        {
            IEnumerable<Person> staff;
            IEnumerable<Person> goalkeepers;
            IEnumerable<Person> defenders;
            IEnumerable<Person> midfielders;
            IEnumerable<Person> forwards;
            string currentTeam;

            if (string.IsNullOrEmpty(teamName))
            {
                staff = _personRepository.AllStaff.OrderBy(p => p.PersonID);
                goalkeepers = _personRepository.AllGoalkeepers.OrderBy(p => p.PersonID);
                defenders = _personRepository.AllGoalkeepers.OrderBy(p => p.PersonID);
                midfielders = _personRepository.AllGoalkeepers.OrderBy(p => p.PersonID);
                forwards = _personRepository.AllGoalkeepers.OrderBy(p => p.PersonID);
                currentTeam = "All Teams";
            }
            else
            {
                staff = _personRepository.AllStaff.Where(p => p.TeamName == teamName)
                    .OrderBy(p => p.PersonID);
                goalkeepers = _personRepository.AllGoalkeepers.Where(p => p.TeamName == teamName)
                    .OrderBy(p => p.FullName);
                defenders = _personRepository.AllDefenders.Where(p => p.TeamName == teamName)
                    .OrderBy(p => p.FullName);
                midfielders = _personRepository.AllMidfielders.Where(p => p.TeamName == teamName)
                    .OrderBy(p => p.FullName);
                forwards = _personRepository.AllForwards.Where(p => p.TeamName == teamName)
                    .OrderBy(p => p.FullName);
                currentTeam = _teamRepository.Teams.FirstOrDefault(c => c.Name == teamName)?.Name;
            }

            return View(new PlayersListViewModel
            {
                Staff = staff,
                CurrentTeam = currentTeam,
                Goalkeepers = goalkeepers,
                Defenders = defenders,
                Midfielders = midfielders,
                Forwards = forwards

            });
        }

        //public IActionResult TeamPlayerDetails(int id)
        //{
        //    var person = _personRepository.GetPersonById(id);
        //    if (person == null)
        //        return NotFound();

        //    return View(person);
        //}

        public IActionResult Index()
        {
            var PlayersListViewModel = new PlayersListViewModel
            {
                Teams = _teamRepository.Teams
            };

            return View(PlayersListViewModel);
        }

        // GET: Team/Create
        public IActionResult Create()
        {
            ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "Address");
            return View();
        }

        // POST: Team/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamID,Name,ClubID")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "Address", team.ClubID);
            return View(team);
        }

        // GET: Team/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "Name", team.ClubID);
            return View(team);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamID,Name,ClubID")] Team team)
        {
            if (id != team.TeamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamID))
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
            ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "Name", team.ClubID);
            return View(team);
        }

        // GET: Team/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.Club)
                .FirstOrDefaultAsync(m => m.TeamID == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamID == id);
        }
    }
}

