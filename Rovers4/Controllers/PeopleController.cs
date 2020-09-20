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

        public PeopleController(ClubContext context, IWebHostEnvironment _hostingEnvironment)
        {
            _context = context;
            hostingEnvironment = _hostingEnvironment;
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

        [Authorize(Roles = "Super Admin, Team Admin, Member")]
        public IActionResult Create()
        {
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,PersonType,MgmtRole,PlayerPosition,FirstName,Surname,DOB,Mobile,Email,ProfileImage,TeamID,PlayerStatID, ProfileThumbnailImage,PersonBio")] Person model)
        {
            if (ModelState.IsValid)
            {
                string thumnailImage = UploadedThumbnailImage(model);
                string image = UploadedImage(model);

                model.Image = image;
                model.ThumbnailImage = thumnailImage;

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Team");
            }
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", model.TeamID);
            return View();
        }

        // GET: People/Create
        [Authorize(Roles = "Super Admin, Team Admin")]
        public IActionResult CreateMgmt()
        {
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMgmt([Bind("PersonID,PersonType,MgmtRole,PlayerPosition,FirstName,Surname,DOB,Mobile,Email,ProfileImage,TeamID,PlayerStatID, ProfileThumbnailImage,PersonBio")] Person model)
        {
            if (ModelState.IsValid)
            {
                string thumnailImage = UploadedThumbnailImage(model);
                string image = UploadedImage(model);

                model.Image = image;
                model.ThumbnailImage = thumnailImage;

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Team");
            }
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", model.TeamID);
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
            ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", person.TeamID);
            return View(person);
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonID,PersonType,MgmtRole,PlayerPosition,FirstName,Surname,DOB,Mobile,Email,ProfileImage,TeamID,PlayerStatID, ProfileThumbnailImage,PersonBio")] Person person)
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string thumnailImage = UploadedThumbnailImage(person);
                string image = UploadedImage(person);

                person.Image = image;
                person.ThumbnailImage = thumnailImage;

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

        // This is for Editing Photos with PersonViewModel. Wont work tho as TeamPlayerList passes in a Person Model. Need a way around.
        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[Authorize(Roles = "Super Admin, Team Admin")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("PersonID,PersonType,MgmtRole,PlayerPosition,FirstName,Surname,DOB,Mobile,Email,ProfileImage,TeamID,PlayerStatID, ProfileThumbnailImage,PersonBio")] PersonViewModel model)
        //{
        //    if (id != model.PersonID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        string thumnailImage = UploadedThumbnailImage(model);
        //        string image = UploadedImage(model);

        //        Person person = new Person
        //        {
        //            PersonID = model.PersonID,
        //            PersonType = model.PersonType,
        //            MgmtRole = model.MgmtRole,
        //            PlayerPosition = model.PlayerPosition,
        //            FirstName = model.FirstName,
        //            Surname = model.Surname,
        //            DOB = model.DOB,
        //            Mobile = model.Mobile,
        //            Email = model.Email,
        //            PersonBio = model.PersonBio,
        //            TeamID = model.TeamID,
        //            PlayerStatID = model.PlayerStatID,
        //            Image = image,
        //            ThumbnailImage = thumnailImage
        //        };

        //        try
        //        {
        //            _context.Update(person);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PersonExists(person.PersonID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("Index", "Team");
        //    }
        //    ViewData["TName"] = new SelectList(_context.Teams, "TeamID", "Name", model.TeamID);
        //    return View();
        //}

        // GET: People/Edit/5
        [Authorize(Roles = "Super Admin, Team Admin")]
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

        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin")]
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
