using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rovers4.Data;
using Rovers4.Models;
using Rovers4.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Controllers
{
    [ResponseCache(CacheProfileName = "None")]
    public class PlayerStatController : Controller
    {

        private readonly IPersonRepository _personRepository;
        private readonly IPlayerStatRepository _playerStatRepository;
        private readonly ClubContext _context;

        public PlayerStatController(IPersonRepository personRepository, ClubContext context, IPlayerStatRepository playerStatRepository)
        {
            _personRepository = personRepository;
            _playerStatRepository = playerStatRepository;
            _context = context;

        }

        public ViewResult PlayerStatList(int? id)
        {
            IEnumerable<PlayerStat> stat;
            IEnumerable<Person> staff;
            string currentPlayer;
            bool hasStats;

            if (id == null)
            {
                stat = _playerStatRepository.AllStats.OrderBy(p => p.PersonID);
                staff = _personRepository.AllStaff.OrderBy(p => p.PersonID);
                currentPlayer = "All Players";
                hasStats = false;
            }
            else
            {
                stat = _playerStatRepository.AllStats.Where(p => p.PersonID == id)
                    .OrderBy(p => p.PersonID);
                staff = _personRepository.AllStaff.Where(p => p.PersonID == id)
                    .OrderBy(p => p.PersonID);
                currentPlayer = _personRepository.AllStaff.FirstOrDefault(c => c.PersonID == id)?.FullName;
                if (stat.Count() <= 0)
                {
                    hasStats = false;
                }
                else
                {
                    hasStats = true;
                }
            }

            return View(new PlayerStatsViewModel
            {
                Stats = stat,
                CurrentPlayer = currentPlayer,
                Staff = staff,
                HasStats = hasStats
            });
        }

        [Authorize(Roles = "Super Admin, Team Admin")]
        public IActionResult Create()
        {
            ViewData["Players"] = new SelectList(_context.Persons, "PersonID", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Super Admin, Team Admin")]
        public async Task<IActionResult> Create([Bind("PlayerStatID,GamesPlayed,Assists,Goals,CleanSheet,RedCards,MotmAward,PersonID")] PlayerStat playerStat)
        {
            if (PlayerStatExists(playerStat.PersonID))
            {
                return BadRequest("Player Stats already exists for this player");
            }

            if (ModelState.IsValid)
            {
                _context.Add(playerStat);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Team");
            }
            ViewData["Players"] = new SelectList(_context.Persons, "PersonID", "FullName", playerStat.PersonID);
            return View(playerStat);
        }

        [Authorize(Roles = "Super Admin, Team Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerStat = await _context.PlayerStats
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (playerStat == null)
            {
                return NotFound();
            }
            ViewData["CurrentPlayer"] = _personRepository.AllStaff.FirstOrDefault(c => c.PersonID == id)?.FullName;
            return View(playerStat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Super Admin, Team Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerStatID,GamesPlayed,Assists,Goals,CleanSheet,RedCards,MotmAward,PersonID")] PlayerStat playerStat)
        {
            if (id != playerStat.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerStat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerStatExists(playerStat.PersonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["CurrentPlayer"] = _personRepository.AllStaff.FirstOrDefault(c => c.PersonID == id)?.FullName;
                return RedirectToAction("Index", "Team");
            }
            ViewData["CurrentPlayer"] = _personRepository.AllStaff.FirstOrDefault(c => c.PersonID == id)?.FullName;
            return View(playerStat);
        }

        private bool PlayerStatExists(int id)
        {
            return _context.PlayerStats.Any(e => e.PersonID == id);
        }
    }
}


