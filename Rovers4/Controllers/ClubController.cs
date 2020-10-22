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
using Rovers4.Services;

namespace Rovers4.Controllers
{
    [Authorize(Roles = "Super Admin")]
    public class ClubController : Controller
    {
        private readonly ClubContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IBlobStorageService _blobService;

        public ClubController(ClubContext context, IWebHostEnvironment _hostingEnvironment, IBlobStorageService storageService)
        {
            _context = context;
            hostingEnvironment = _hostingEnvironment;
            _blobService = storageService;
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
            if (model.ClubImageFile1 != null)
            {
                string mimeType = model.ClubImageFile1.ContentType;
                byte[] dataFiles;

                using (var target = new MemoryStream())
                {
                    model.ClubImageFile1.CopyTo(target);
                    dataFiles = target.ToArray();
                }
                model.ClubImage1 = _blobService.UploadFileToBlob(model.ClubImageFile1.FileName, dataFiles, mimeType);
            }
            return model.ClubImage1;
        }
        private string UploadedImage2(Club model)
        {
            if (model.ClubImageFile2 != null)
            {
                string mimeType = model.ClubImageFile2.ContentType;
                byte[] dataFiles;

                using (var target = new MemoryStream())
                {
                    model.ClubImageFile2.CopyTo(target);
                    dataFiles = target.ToArray();
                }
                model.ClubImage2 = _blobService.UploadFileToBlob(model.ClubImageFile2.FileName, dataFiles, mimeType);
            }
            return model.ClubImage2;
        }


        private string UploadedImage3(Club model)
        {
            if (model.ClubImageFile3 != null)
            {
                string mimeType = model.ClubImageFile2.ContentType;
                byte[] dataFiles;

                using (var target = new MemoryStream())
                {
                    model.ClubImageFile3.CopyTo(target);
                    dataFiles = target.ToArray();
                }
                model.ClubImage3 = _blobService.UploadFileToBlob(model.ClubImageFile3.FileName, dataFiles, mimeType);
            }
            return model.ClubImage3;
        }

        private void DeleteImage(string imageString)
        {
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
            string filePath = Path.Combine(uploadsFolder, imageString);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
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
        public async Task<IActionResult> Edit(int id, [Bind("ClubID,Name,Address,Email,Number,ClubImage1,ClubImage2,ClubImage3,ClubImageFile1,ClubImageFile2,ClubImageFile3")] Club club)
        {
            if (id != club.ClubID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (club.ClubImageFile1 != null)
                {
                    _blobService.DeleteBlobData(club.ClubImage1);
                    string image = UploadedImage1(club);
                    club.ClubImage1 = image;
                }

                if (club.ClubImageFile2 != null)
                {
                    _blobService.DeleteBlobData(club.ClubImage2);
                    string image = UploadedImage2(club);
                    club.ClubImage2 = image;
                }

                if (club.ClubImageFile3 != null)
                {
                    _blobService.DeleteBlobData(club.ClubImage3);
                    string image = UploadedImage3(club);
                    club.ClubImage3 = image;
                }

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
            _blobService.DeleteBlobData(club.ClubImage1);
            _blobService.DeleteBlobData(club.ClubImage2);
            _blobService.DeleteBlobData(club.ClubImage3);
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
