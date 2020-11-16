using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rovers4.Data;
using Rovers4.Filters;
using Rovers4.Models;
using Rovers4.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Rovers4.Controllers
{
    //[RequireHeader]
    [ServiceFilter(typeof(TimerActionAttribute))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClubContext _context;
        private readonly IMapsService _mapsService;

        public HomeController(ILogger<HomeController> logger, ClubContext context, IMapsService mapsService)
        {
            _logger = logger;
            _context = context;
            _mapsService = mapsService;
        }

        [ResponseCache(CacheProfileName = "Default")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clubs.ToListAsync().ConfigureAwait(false));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            ViewBag.ApiKey = _mapsService.GetApiKey();
            return View(await _context.Clubs.ToListAsync().ConfigureAwait(false));
        }

        public async Task<IActionResult> ClubDetails()
        {
            return View(await _context.Clubs.ToListAsync().ConfigureAwait(false));
        }


        [ResponseCache(CacheProfileName = "None")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
