﻿using System;
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
        //private readonly ClubContext _context;
        private readonly IPersonRepository _personRepository;
        private readonly ITeamRepository _teamRepository;
       


        public TeamController(IPersonRepository personRepository, ITeamRepository teamRepository)
        {
            _personRepository = personRepository;
            _teamRepository = teamRepository;
        }

        public ViewResult TeamPlayerList(string team)
        {
            IEnumerable<Person> staff;
            string currentTeam;

            if (string.IsNullOrEmpty(team))
            {
                staff = _personRepository.AllStaff.OrderBy(p => p.PersonID);
                currentTeam = "All Teams";
            }
            else
            {
                staff = _personRepository.AllStaff.Where(p => p.Team.Name == team)
                    .OrderBy(p => p.PersonID);
                currentTeam = _teamRepository.Teams.FirstOrDefault(c => c.Name == team)?.Name;
            }

            return View(new PlayersListViewModel
            {
                Staff = staff,
                CurrentTeam = currentTeam
            });
        }

        public IActionResult TeamPlayerDetails(int id)
        {
            var person = _personRepository.GetPersonById(id);
            if (person == null)
                return NotFound();

            return View(person);
        }

        public IActionResult Index()
        {
            var PlayersListViewModel = new PlayersListViewModel
            {
                Teams = _teamRepository.Teams
            };

            return View(PlayersListViewModel);
        }






        //    public TeamController(ClubContext context)
        //    {
        //        _context = context;
        //    }

        //    // GET: Team
        //    public async Task<IActionResult> Index()
        //    {
        //        var clubContext = _context.Teams.Include(t => t.Club);
        //        return View(await clubContext.ToListAsync());
        //    }

        //    //// Added View Result
        //    //public ViewResult TeamDetails(int? id)
        //    //{
        //    //    TeamDetailsViewModel teamDetailsViewModel = new TeamDetailsViewModel();
        //    //    teamDetailsViewModel.Team = _context.Teams.FirstOrDefaultAsync(m => m.TeamID == id);


        //    //    //{
        //    //    //    Team = _context.Teams.Find(id);
        //    //    //    Staff = _context.Persons.Where(i => i.TeamID == id);
        //    //    //};

        //    //}


        //    // GET: Team/Details/5
        //    public async Task<IActionResult> Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var team = await _context.Teams
        //            .Include(t => t.Person)
        //            .FirstOrDefaultAsync(m => m.TeamID == id);
        //        if (team == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(team);
        //    }

        //    // GET: Team/Create
        //    public IActionResult Create()
        //    {
        //        ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "Name");
        //        return View();
        //    }

        //    // POST: Team/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("TeamID,Grade,NoOfPlayers,ClubID,PersonID,fixtureID")] Team team)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(team);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "Name", team.ClubID);
        //        return View(team);
        //    }

        //    // GET: Team/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var team = await _context.Teams.FindAsync(id);
        //        if (team == null)
        //        {
        //            return NotFound();
        //        }
        //        ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "Name", team.ClubID);
        //        return View(team);
        //    }

        //    // POST: Team/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("TeamID,Grade,NoOfPlayers,ClubID,PersonID,fixtureID")] Team team)
        //    {
        //        if (id != team.TeamID)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(team);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!TeamExists(team.TeamID))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "Name", team.ClubID);
        //        return View(team);
        //    }

        //    // GET: Team/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var team = await _context.Teams
        //            .Include(t => t.Club)
        //            .FirstOrDefaultAsync(m => m.TeamID == id);
        //        if (team == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(team);
        //    }

        //    // POST: Team/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var team = await _context.Teams.FindAsync(id);
        //        _context.Teams.Remove(team);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool TeamExists(int id)
        //    {
        //        return _context.Teams.Any(e => e.TeamID == id);
        //    }
        //}
    }
}
