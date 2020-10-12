using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rovers4.Data;
using Rovers4.Models;
using Rovers4.ViewModels;

namespace Rovers4.Controllers
{
    [Authorize(Roles = "Super Admin, Team Admin, Member")]
    public class PeopleController : Controller
    {
        private readonly ClubContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IPlayerStatRepository _playerStat;
        private readonly ITeamRepository _teamRepository;

        public PeopleController(ClubContext context, IWebHostEnvironment _hostingEnvironment, IPlayerStatRepository playerStat, ITeamRepository teamRepository)
        {
            _context = context;
            hostingEnvironment = _hostingEnvironment;
            _playerStat = playerStat;
            _teamRepository = teamRepository;
        }

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

        private string UploadedThumbnailImage(Person model)
        {
            string uniqueFileName = null;

            if (model.ProfileThumbnailImage != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileThumbnailImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileThumbnailImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private string UploadedImage(Person model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        //Delete Images from Root Folder on Editing/Deleting player.
        private void DeleteImage(string imageString)
        {
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
            string filePath = Path.Combine(uploadsFolder, imageString);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        public IActionResult Create(int TeamID)
        {
            ViewBag.CurrentTeam = _teamRepository.GetTeamById(TeamID)?.Name;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int TeamID, [Bind("PersonID,PersonType,MgmtRole,PlayerPosition,FirstName,Surname,DOB,Mobile,Email,ProfileImage,TeamID,PlayerStatID, ProfileThumbnailImage,PersonBio")] Person model)
        {
            if (ModelState.IsValid)
            {
                string thumnailImage = UploadedThumbnailImage(model);
                string image = UploadedImage(model);

                model.Image = image;
                model.ThumbnailImage = thumnailImage;
                model.PersonType = PersonType.Player;

                _context.Add(model);
                await _context.SaveChangesAsync();

                // Instantiate new PlayerStat as can't leave it empty
                _playerStat.AddPlayerStats(model.PersonID);

                return RedirectToAction("Index", "Team");
            }
            ViewBag.CurrentTeam = _teamRepository.GetTeamById(TeamID)?.Name;
            return View();
        }

        // GET: People/Create
        [Authorize(Roles = "Super Admin, Team Admin")]
        public IActionResult CreateMgmt(int TeamID)
        {
            ViewBag.CurrentTeam = _teamRepository.GetTeamById(TeamID)?.Name;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMgmt(int TeamID, [Bind("PersonID,PersonType,MgmtRole,PlayerPosition,FirstName,Surname,DOB,Mobile,Email,ProfileImage,TeamID,PlayerStatID, ProfileThumbnailImage,PersonBio")] Person model)
        {
            if (ModelState.IsValid)
            {
                string thumnailImage = UploadedThumbnailImage(model);
                string image = UploadedImage(model);

                model.Image = image;
                model.ThumbnailImage = thumnailImage;
                model.PersonType = PersonType.Manager;

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Team");
            }
            ViewBag.CurrentTeam = _teamRepository.GetTeamById(TeamID)?.Name;
            return View();
        }

        [Authorize(Roles = "Super Admin, Team Admin")]
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
            ViewBag.CurrentTeam = _teamRepository.GetTeamById(person.TeamID)?.Name;
            ViewBag.PersonType = person.PersonType.ToString();
            return View(person);
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonID,PersonType,MgmtRole,PlayerPosition,FirstName,Surname,DOB,Mobile,Email,Image,ProfileImage,TeamID,PlayerStatID,ThumbnailImage, ProfileThumbnailImage,PersonBio")] Person person)
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (person.ProfileThumbnailImage != null)
                {
                    string thumnailImage = UploadedThumbnailImage(person);
                    DeleteImage(person.ThumbnailImage);
                    person.ThumbnailImage = thumnailImage;
                }

                if (person.ProfileImage != null)
                {
                    string image = UploadedImage(person);
                    DeleteImage(person.Image);
                    person.Image = image;
                }

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
                ViewBag.CurrentTeam = _teamRepository.GetTeamById(person.TeamID)?.Name;
                return RedirectToAction("Index", "Team");
            }
            return View(person);
        }

        [Authorize(Roles = "Super Admin, Team Admin")]
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

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.FindAsync(id); 
            DeleteImage(person.Image);
            DeleteImage(person.ThumbnailImage);
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
