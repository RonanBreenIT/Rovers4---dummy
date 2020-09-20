﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Rovers4.Data;
using Rovers4.Models;
using Rovers4.Services;
using Rovers4.ViewModels;

namespace Rovers4.Controllers
{
    public class TeamController : Controller
    {
        private readonly ClubContext _context;
        private readonly IPersonRepository _personRepository;
        private readonly ITeamRepository _teamRepository;
        private IMailService _mailService;
        private readonly IWebHostEnvironment hostingEnvironment;


        public TeamController(IPersonRepository personRepository, ITeamRepository teamRepository, ClubContext context, IMailService mailService, IWebHostEnvironment _hostingEnvironment)
        {
            _personRepository = personRepository;
            _teamRepository = teamRepository;
            _context = context;
            _mailService = mailService;
            hostingEnvironment = _hostingEnvironment;
        }

        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        public ViewResult TeamPlayerList(int? id)
        {
            IEnumerable<Person> staff;
            IEnumerable<Person> goalkeepers;
            IEnumerable<Person> defenders;
            IEnumerable<Person> midfielders;
            IEnumerable<Person> forwards;
            IEnumerable<Person> mgmt;
            string currentTeam;

            if (id == null)
            {
                staff = _personRepository.AllStaff.OrderBy(p => p.PersonID);
                goalkeepers = _personRepository.AllGoalkeepers.OrderBy(p => p.PersonID);
                defenders = _personRepository.AllDefenders.OrderBy(p => p.PersonID);
                midfielders = _personRepository.AllGoalkeepers.OrderBy(p => p.PersonID);
                forwards = _personRepository.AllGoalkeepers.OrderBy(p => p.PersonID);
                mgmt = _personRepository.Mgmt.OrderBy(p => p.PersonID);
                currentTeam = "All Teams";
            }
            else
            {
                staff = _personRepository.AllStaff.Where(p => p.TeamID == id)
                    .OrderBy(p => p.PersonID);
                goalkeepers = _personRepository.AllGoalkeepers.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FullName);
                defenders = _personRepository.AllDefenders.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FullName);
                midfielders = _personRepository.AllMidfielders.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FullName);
                forwards = _personRepository.AllForwards.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FullName);
                mgmt = _personRepository.Mgmt.Where(p => p.TeamID == id)
                    .OrderByDescending(p => p.MgmtRole == MgmtRole.Manager)
                    .ThenBy(p => p.MgmtRole == MgmtRole.Coach)
                    .ThenBy(p => p.MgmtRole == MgmtRole.GoalKeeperCoach)
                    .ThenBy(p => p.MgmtRole == MgmtRole.SandC)
                    .ThenBy(p => p.MgmtRole == MgmtRole.Physio)
                    .ThenBy(p => p.MgmtRole == MgmtRole.SandC);
                currentTeam = _teamRepository.Teams.FirstOrDefault(c => c.TeamID == id)?.Name;
            }
            ViewData["TeamNumbers"] = staff.Count();
            return View(new PlayersListViewModel
            {
                Staff = staff,
                CurrentTeam = currentTeam,
                Goalkeepers = goalkeepers,
                Defenders = defenders,
                Midfielders = midfielders,
                Forwards = forwards,
                Mgmt = mgmt,
                Teams = _teamRepository.Teams
            });
        }

        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        public IActionResult Index()
        {
            var PlayersListViewModel = new PlayersListViewModel
            {
                Teams = _teamRepository.Teams
            };

            return View(PlayersListViewModel);
        }

        private string UploadedImage(Team model)
        {
            string uniqueFileName = null;

            if (model.TeamImageFile != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.TeamImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.TeamImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [Authorize(Roles = "Super Admin")]
        public IActionResult Create()
        {
            ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "Name");
            return View();
        }

        [Authorize(Roles = "Super Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamID,Name,ClubID, TeamBio, TeamImageFile")] Team team)
        {
            if (ModelState.IsValid)
            {
                string image = UploadedImage(team);

                team.TeamImage = image;

                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "Name", team.ClubID);
            return View(team);
        }

        [Authorize(Roles = "Super Admin")]
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

        [Authorize(Roles = "Super Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamID,Name,ClubID,TeamBio, TeamImageFile")] Team team)
        {
            if (id != team.TeamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string image = UploadedImage(team);

                team.TeamImage = image;
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

        [Authorize(Roles = "Super Admin")]
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

        [Authorize(Roles = "Super Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Below all for our Email Service
        public async Task <IActionResult> SendgridEmail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.TeamID == id);
            if (team == null)
            {
                return NotFound();
            }
            ViewData["CurrentTeam"] = _teamRepository.Teams.FirstOrDefault(c => c.TeamID == id)?.Name;
            return View("SendgridEmail");
        }

        [HttpPost]
        public async Task<IActionResult> SendgridEmail(EmailModel emailmodel, int? id)
        {
            ViewData["Message"] = "Notification Sent for Fixture!!!...";
            var emailList = _personRepository.AllStaff.Where(p => p.TeamID == id)
                    .Select(i => i.Email);
            var currentTeam = _teamRepository.Teams.FirstOrDefault(p => p.TeamID == id)?.Name;
            currentTeam += " Fixture";
            emailmodel.Subject = currentTeam;

            foreach (var person in emailList)
            {
                if (person != null)
                {
                    await _mailService.SendEmailAsync(person, emailmodel.Subject, emailmodel.FixTypeString, emailmodel.HomeOrAwayString, emailmodel.KickOffTime, emailmodel.Opponent, emailmodel.MeetLocation, emailmodel.MeetTime);
                }
            }
            
            return View("EmailSent");
        }

        public IActionResult EmailSent()
        {
            return View();
        }
        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamID == id);
        }
    }
}

