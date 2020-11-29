using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rovers4.Data;
using Rovers4.Models;
using Rovers4.Services;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Controllers
{
    [ResponseCache(CacheProfileName = "None")]
    public class PeopleController : Controller
    {
        private readonly ClubContext _context;
        private readonly IPlayerStatRepository _playerStat;
        private readonly ITeamRepository _teamRepository;
        private readonly IBlobStorageService _blobService;
        private readonly ILogger<PeopleController> _logger;

        public PeopleController(ClubContext context, IPlayerStatRepository playerStat, ITeamRepository teamRepository, IBlobStorageService storageService, ILogger<PeopleController> logger)
        {
            _context = context;
            _playerStat = playerStat;
            _teamRepository = teamRepository;
            _blobService = storageService;
            _logger = logger;
        }

        [Authorize(Roles = "Super Admin, Team Admin")]
        private string UploadedThumbnailImage(Person model)
        {
            if (model.ProfileThumbnailImage != null)
            {
                string mimeType = model.ProfileThumbnailImage.ContentType;
                byte[] dataFiles;

                using (var target = new MemoryStream())
                {
                    model.ProfileThumbnailImage.CopyTo(target);
                    dataFiles = target.ToArray();
                }
                model.ThumbnailImage = _blobService.UploadFileToBlob(model.ProfileThumbnailImage.FileName, dataFiles, mimeType);
            }
            _logger.LogInformation("Staff Image uploaded at {Time}", DateTime.UtcNow);
            return model.ThumbnailImage;
        }

        [Authorize(Roles = "Super Admin, Team Admin")]
        private string UploadedImage(Person model)
        {
            if (model.ProfileImage != null)
            {
                string mimeType = model.ProfileImage.ContentType;
                byte[] dataFiles;

                using (var target = new MemoryStream())
                {
                    model.ProfileImage.CopyTo(target);
                    dataFiles = target.ToArray();
                }
                model.Image = _blobService.UploadFileToBlob(model.ProfileImage.FileName, dataFiles, mimeType);
            }
            _logger.LogInformation("Staff Image uploaded at {Time}", DateTime.UtcNow);
            return model.Image;
        }

        [Authorize(Roles = "Super Admin, Team Admin")]
        public IActionResult Create(int TeamID)
        {
            _logger.LogInformation("Team found at {Time}", DateTime.UtcNow);
            ViewBag.CurrentTeam = _teamRepository.GetTeamById(TeamID)?.Name;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int TeamID, [Bind("PersonID,PersonType,MgmtRole,PlayerPosition,FirstName,Surname,DOB,Mobile,Email,ProfileImage,TeamID,PlayerStatID, ProfileThumbnailImage,PersonBio")] Person model)
        {
            if (model == null)
            {
                _logger.LogWarning("No Player found at {Time}", DateTime.UtcNow);
                throw new ArgumentNullException(nameof(model));
            }

            if (ModelState.IsValid)
            {
                string thumnailImage = UploadedThumbnailImage(model);
                string image = UploadedImage(model);

                model.Image = image;
                model.ThumbnailImage = thumnailImage;
                model.PersonType = PersonType.Player;

                _context.Add(model);
                await _context.SaveChangesAsync().ConfigureAwait(true);

                // Instantiate new PlayerStat as can't leave it empty
                _playerStat.AddPlayerStats(model.PersonID);

                return RedirectToAction("Index", "Team");
            }
            _logger.LogInformation("Player {Name} created at {Time}", model.FullName, DateTime.UtcNow);
            ViewBag.CurrentTeam = _teamRepository.GetTeamById(TeamID)?.Name;
            return View();
        }

        // GET: People/Create
        [Authorize(Roles = "Super Admin, Team Admin")]
        public IActionResult CreateMgmt(int TeamID)
        {
            _logger.LogInformation("Team found at {Time}",DateTime.UtcNow);
            ViewBag.CurrentTeam = _teamRepository.GetTeamById(TeamID)?.Name;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMgmt(int TeamID, [Bind("PersonID,PersonType,MgmtRole,PlayerPosition,FirstName,Surname,DOB,Mobile,Email,ProfileImage,TeamID,PlayerStatID, ProfileThumbnailImage,PersonBio")] Person model)
        {
            if (model == null)
            {
                _logger.LogWarning("No Management found at {Time}", DateTime.UtcNow);
                throw new ArgumentNullException(nameof(model));
            }

            if (ModelState.IsValid)
            {
                string thumnailImage = UploadedThumbnailImage(model);
                string image = UploadedImage(model);

                model.Image = image;
                model.ThumbnailImage = thumnailImage;
                model.PersonType = PersonType.Manager;

                _context.Add(model);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return RedirectToAction("Index", "Team");
            }
            _logger.LogInformation("Management {Name} created at {Time}", model.FullName, DateTime.UtcNow);
            ViewBag.CurrentTeam = _teamRepository.GetTeamById(TeamID)?.Name;
            return View();
        }

        [Authorize(Roles = "Super Admin, Team Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("No Person found at {Time}", DateTime.UtcNow);
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id).ConfigureAwait(true);
            if (person == null)
            {
                _logger.LogWarning("No Person found at {Time}", DateTime.UtcNow);
                return NotFound();
            }
            _logger.LogInformation("Person found at {Time}", DateTime.UtcNow);
            ViewBag.CurrentTeam = _teamRepository.GetTeamById(person.TeamID)?.Name;
            ViewBag.PersonType = person.PersonType.ToString();
            return View(person);
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonID,PersonType,MgmtRole,PlayerPosition,FirstName,Surname,DOB,Mobile,Email,Image,ProfileImage,TeamID,PlayerStatID,ThumbnailImage, ProfileThumbnailImage,PersonBio")] Person person)
        {
            if (person == null)
            {
                _logger.LogWarning("No Person found at {Time}", DateTime.UtcNow);
                throw new ArgumentNullException(nameof(person));
            } 

            if (id != person.PersonID)
            {
                _logger.LogWarning("No Person found at {Time}", DateTime.UtcNow);
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (person.ProfileThumbnailImage != null  && person.ThumbnailImage != null)
                {
                    _blobService.DeleteBlobData(person.ThumbnailImage);
                    string thumnailImage = UploadedThumbnailImage(person);
                    person.ThumbnailImage = thumnailImage;
                }
                else if (person.ProfileThumbnailImage != null  && person.ThumbnailImage == null)
                {
                    string thumnailImage = UploadedThumbnailImage(person);
                    person.ThumbnailImage = thumnailImage;
                }
                
                if (person.ProfileImage != null && person.Image != null)
                {
                    _blobService.DeleteBlobData(person.Image);
                    string image = UploadedImage(person);
                    person.Image = image;
                }
                else if (person.ProfileImage != null && person.Image == null)
                {
                    string image = UploadedImage(person);
                    person.Image = image;
                }

                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync().ConfigureAwait(true);
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
                _logger.LogInformation("Person {Name} edited at {Time}", person.FullName, DateTime.UtcNow);
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
                _logger.LogWarning("No Person found at {Time}", DateTime.UtcNow);
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.PersonID == id).ConfigureAwait(true);
            if (person == null)
            {
                _logger.LogWarning("No Person found at {Time}", DateTime.UtcNow);
                return NotFound();
            }
            _logger.LogInformation("Person found at {Time}", DateTime.UtcNow);
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.FindAsync(id).ConfigureAwait(true);
            var playerStat = await _context.PlayerStats.FirstOrDefaultAsync(i => i.PersonID == id).ConfigureAwait(true);
            if (person.ThumbnailImage != null)
            {
                _blobService.DeleteBlobData(person.ThumbnailImage);
            }
            if (person.Image != null)
            {
                _blobService.DeleteBlobData(person.Image);
            }
            _context.PlayerStats.Remove(playerStat); // Delete player stat record first
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            _logger.LogInformation("Person {Name} deleted at {Time}", person.FullName, DateTime.UtcNow);
            return RedirectToAction("Index", "Team");
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.PersonID == id);
        }
    }
}
