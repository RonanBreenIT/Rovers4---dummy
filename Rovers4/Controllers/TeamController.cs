﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rovers4.Data;
using Rovers4.Models;
using Rovers4.Services;
using Rovers4.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Controllers
{
    [ResponseCache(CacheProfileName = "None")]
    public class TeamController : Controller
    {
        private readonly ClubContext _context;
        private readonly IPersonRepository _personRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IMailService _mailService;
        private readonly IBlobStorageService _blobService;
        private readonly ILogger<TeamController> _logger;

        public TeamController(IPersonRepository personRepository, ITeamRepository teamRepository, ClubContext context, IMailService mailService, IBlobStorageService storageService, ILogger<TeamController> logger)
        {
            _personRepository = personRepository;
            _teamRepository = teamRepository;
            _context = context;
            _mailService = mailService;
            _blobService = storageService;
            _logger = logger;
        }

        public ViewResult TeamPlayerList(int? id)
        {
            IEnumerable<Person> staff;
            IEnumerable<Person> goalkeepers;
            IEnumerable<Person> defenders;
            IEnumerable<Person> midfielders;
            IEnumerable<Person> forwards;
            IEnumerable<Person> mgmt;
            string currentTeam;
            int teamID;

            if (id == null)
            {
                staff = _personRepository.AllStaff.OrderBy(p => p.PersonID);
                goalkeepers = _personRepository.AllGoalkeepers.OrderBy(p => p.PersonID);
                defenders = _personRepository.AllDefenders.OrderBy(p => p.PersonID);
                midfielders = _personRepository.AllGoalkeepers.OrderBy(p => p.PersonID);
                forwards = _personRepository.AllGoalkeepers.OrderBy(p => p.PersonID);
                mgmt = _personRepository.Mgmt.OrderBy(p => p.PersonID);
                currentTeam = "All Teams";
                teamID = 1;
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
                teamID = id.Value;
            }
            ViewData["TeamNumbers"] = (staff.Count() - mgmt.Count());
            return View(new PlayersListViewModel
            {
                Staff = staff,
                CurrentTeam = currentTeam,
                TeamID = teamID,
                Goalkeepers = goalkeepers,
                Defenders = defenders,
                Midfielders = midfielders,
                Forwards = forwards,
                Mgmt = mgmt,
                Teams = _teamRepository.Teams
            });
        }

        public IActionResult Index()
        {
            var PlayersListViewModel = new PlayersListViewModel
            {
                Teams = _teamRepository.Teams
            };
            return View(PlayersListViewModel);
        }

        [Authorize(Roles = "Super Admin")]
        private string UploadedImage(Team model)
        {
            if (model.TeamImageFile != null)
            {
                string mimeType = model.TeamImageFile.ContentType;
                byte[] dataFiles;

                using (var target = new MemoryStream())
                {
                    model.TeamImageFile.CopyTo(target);
                    dataFiles = target.ToArray();
                }
                model.TeamImage = _blobService.UploadFileToBlob(model.TeamImageFile.FileName, dataFiles, mimeType);
            }
            _logger.LogInformation("Team Image uploaded at {Time}", DateTime.UtcNow);
            return model.TeamImage;
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
            if (team == null)
            {
                _logger.LogWarning("Issue Creating Team at {Time}", DateTime.UtcNow);
                throw new ArgumentNullException(nameof(team));
            }

            if (ModelState.IsValid)
            {
                string image = UploadedImage(team);
                team.TeamImage = image;

                _context.Add(team);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return RedirectToAction(nameof(Index));
            }
            _logger.LogInformation("Team {Name} created at at {Time}", team.Name, DateTime.UtcNow);
            ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "Name", team.ClubID);
            return View(team);
        }

        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("No Team found to edit at {Time}", DateTime.UtcNow);
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id).ConfigureAwait(true);
            if (team == null)
            {
                _logger.LogWarning("No Team found to edit at {Time}", DateTime.UtcNow);
                return NotFound();
            }
            _logger.LogInformation("Team found at {Time} for editing", DateTime.UtcNow);
            ViewData["ClubID"] = new SelectList(_context.Clubs, "ClubID", "Name", team.ClubID);
            return View(team);
        }

        [Authorize(Roles = "Super Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamID,Name,ClubID,TeamBio,TeamImage,TeamImageFile")] Team team)
        {
            if (team == null)
            {
                _logger.LogWarning("Issue editing Team at {Time}", DateTime.UtcNow);
                throw new ArgumentNullException(nameof(team));
            }

            if (id != team.TeamID)
            {
                _logger.LogWarning("Issue editing Team at {Time}", DateTime.UtcNow);
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (team.TeamImageFile != null && team.TeamImage != null)
                {
                    _blobService.DeleteBlobData(team.TeamImage);
                    string teamImage = UploadedImage(team);
                    team.TeamImage = teamImage;
                }
                else if (team.TeamImageFile != null && team.TeamImage == null)
                {
                    string teamImage = UploadedImage(team);
                    team.TeamImage = teamImage;
                }

                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync().ConfigureAwait(true);
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
                _logger.LogInformation("Team {Name} edited at at {Time}", team.Name, DateTime.UtcNow);
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
                _logger.LogWarning("Issue deleting Team at {Time}", DateTime.UtcNow);
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.Club)
                .FirstOrDefaultAsync(m => m.TeamID == id).ConfigureAwait(true);
            if (team == null)
            {
                _logger.LogWarning("Issue deleting Team at {Time}", DateTime.UtcNow);
                return NotFound();
            }
            _logger.LogInformation("Team found for deletion at {Time}", DateTime.UtcNow);
            return View(team);
        }

        [Authorize(Roles = "Super Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id).ConfigureAwait(true);
            if (team.TeamImage != null)
            {
                _blobService.DeleteBlobData(team.TeamImage);
            }
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            _logger.LogInformation("Team {id} removed at {Time}", id, DateTime.UtcNow);
            return RedirectToAction(nameof(Index));
        }

        // Below all for our Email Service
        [Authorize(Roles = "Super Admin, Team Admin")]
        public async Task<IActionResult> SendgridEmail(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("No Team found at {Time}", DateTime.UtcNow);
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.TeamID == id).ConfigureAwait(true);
            if (team == null)
            {
                _logger.LogWarning("No Team found at {Time}", DateTime.UtcNow);
                return NotFound();
            }
            _logger.LogInformation("Team found at {Time}", DateTime.UtcNow);
            ViewData["CurrentTeam"] = _teamRepository.Teams.FirstOrDefault(c => c.TeamID == id)?.Name;
            return View("SendgridEmail");
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin")]
        public async Task<IActionResult> SendgridEmail(EmailModel emailmodel, int? id)
        {
            if (emailmodel == null)
            {
                _logger.LogWarning("No Team found at {Time}", DateTime.UtcNow);
                throw new ArgumentNullException(nameof(emailmodel));
            }

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
                    await _mailService.SendEmailAsync(person, emailmodel.Subject, emailmodel.FixTypeString, emailmodel.HomeOrAwayString, emailmodel.KickOffTime, emailmodel.Opponent, emailmodel.MeetLocation, emailmodel.MeetTime).ConfigureAwait(true);
                }
            }
            _logger.LogInformation("Email sent for {Name} at {Time}", currentTeam, DateTime.UtcNow);
            return View("EmailSent");
        }

        [Authorize(Roles = "Super Admin, Team Admin")]
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

