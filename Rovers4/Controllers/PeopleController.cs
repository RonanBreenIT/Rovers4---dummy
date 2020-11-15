using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rovers4.Data;
using Rovers4.Models;
using Rovers4.Services;
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

        public PeopleController(ClubContext context, IPlayerStatRepository playerStat, ITeamRepository teamRepository, IBlobStorageService storageService)
        {
            _context = context;
            _playerStat = playerStat;
            _teamRepository = teamRepository;
            _blobService = storageService;
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
            return model.Image;
        }

        [Authorize(Roles = "Super Admin, Team Admin")]
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
                await _context.SaveChangesAsync().ConfigureAwait(true);

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
                await _context.SaveChangesAsync().ConfigureAwait(true);
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

            var person = await _context.Persons.FindAsync(id).ConfigureAwait(true);
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
                    _blobService.DeleteBlobData(person.ThumbnailImage);
                    string thumnailImage = UploadedThumbnailImage(person);
                    person.ThumbnailImage = thumnailImage;
                }

                if (person.ProfileImage != null)
                {
                    _blobService.DeleteBlobData(person.Image);
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
                .FirstOrDefaultAsync(m => m.PersonID == id).ConfigureAwait(true);
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
            var person = await _context.Persons.FindAsync(id).ConfigureAwait(true);
            var playerStat = await _context.PlayerStats.FirstOrDefaultAsync(i => i.PersonID == id).ConfigureAwait(true);
            _blobService.DeleteBlobData(person.ThumbnailImage);
            _blobService.DeleteBlobData(person.Image);
            _context.PlayerStats.Remove(playerStat); // Delete player stat record first
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return RedirectToAction("Index", "Team");
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.PersonID == id);
        }
    }
}
