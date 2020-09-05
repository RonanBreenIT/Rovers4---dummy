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

namespace Rovers4.Controllers
{
    [Authorize(Roles = "Super Admin")]
    public class ClubController : Controller
    {
        private readonly ClubContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ClubController(ClubContext context, IWebHostEnvironment _hostingEnvironment)
        {
            _context = context;
            hostingEnvironment = _hostingEnvironment;
        }

        // GET: Club
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clubs.ToListAsync());
        }

        // GET: Club/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs
                .FirstOrDefaultAsync(m => m.ClubID == id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        private string UploadedImage1(Club model)
        {
            string uniqueFileName = null;

            if (model.ClubImageFile1 != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ClubImageFile1.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ClubImageFile1.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        private string UploadedImage2(Club model)
        {
            string uniqueFileName = null;

            if (model.ClubImageFile1 != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ClubImageFile1.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ClubImageFile1.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        private string UploadedImage3(Club model)
        {
            string uniqueFileName = null;

            if (model.ClubImageFile1 != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ClubImageFile1.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ClubImageFile1.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: Club/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClubID,Name,Address,Email,Number,ClubImageFile1,ClubImageFile2,ClubImageFile3")] Club club)
        {
            if (ModelState.IsValid)
            {
                string image1 = UploadedImage1(club);
                string image2 = UploadedImage2(club);
                string image3 = UploadedImage3(club);
                
                club.ClubImage1 = image1;
                club.ClubImage2 = image2;
                club.ClubImage3 = image3;

                _context.Add(club);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(club);
        }

        // GET: Club/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }
            return View(club);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClubID,Name,Address,Email,Number,ClubImageFile1,ClubImageFile2,ClubImageFile3")] Club club)
        {
            if (id != club.ClubID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string image1 = UploadedImage1(club);
                string image2 = UploadedImage2(club);
                string image3 = UploadedImage3(club);

                club.ClubImage1 = image1;
                club.ClubImage2 = image2;
                club.ClubImage3 = image3;

                try
                {
                    _context.Update(club);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubExists(club.ClubID))
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
            return View(club);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs
                .FirstOrDefaultAsync(m => m.ClubID == id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubExists(int id)
        {
            return _context.Clubs.Any(e => e.ClubID == id);
        }
    }
}
