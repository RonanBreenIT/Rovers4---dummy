using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rovers4.Data;
using Rovers4.Models;
using Rovers4.ViewModels;
using System;
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
        private readonly ILogger<PlayerStatController> _logger;

        public PlayerStatController(IPersonRepository personRepository, ClubContext context, IPlayerStatRepository playerStatRepository, ILogger<PlayerStatController> logger)
        {
            _personRepository = personRepository;
            _playerStatRepository = playerStatRepository;
            _context = context;
            _logger = logger;

        }

        public ViewResult PlayerStatList(int? id)
        {
            IEnumerable<PlayerStat> stat;
            IEnumerable<Person> staff;
            string currentPlayer;
            bool hasStats;

            if (id == null)
            {
                _logger.LogWarning("No Player Stat found at {Time}", DateTime.UtcNow);
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
                if (stat.Any())
                {
                    hasStats = true;
                }
                else
                {
                    hasStats = false;
                }
            }
            _logger.LogInformation("Player Stat found at {Time}", DateTime.UtcNow);
            return View(new PlayerStatsViewModel
            {
                Stats = stat,
                CurrentPlayer = currentPlayer,
                Staff = staff,
                HasStats = hasStats
            });
        }

        [Authorize(Roles = "Super Admin, Team Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("No Player Stat found at {Time}", DateTime.UtcNow);
                return NotFound();
            }

            var playerStat = await _context.PlayerStats
                .FirstOrDefaultAsync(m => m.PersonID == id).ConfigureAwait(true);
            if (playerStat == null)
            {
                _logger.LogWarning("No Player Stat found at {Time}", DateTime.UtcNow);
                return NotFound();
            }
            _logger.LogInformation("Player Stat found at {Time}", DateTime.UtcNow);
            ViewData["CurrentPlayer"] = _personRepository.AllStaff.FirstOrDefault(c => c.PersonID == id)?.FullName;
            return View(playerStat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Super Admin, Team Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerStatID,GamesPlayed,Assists,Goals,CleanSheet,RedCards,MotmAward,PersonID")] PlayerStat playerStat)
        {
            if (playerStat == null)
            {
                throw new ArgumentNullException(nameof(playerStat));
            }

            if (id != playerStat.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerStat);
                    await _context.SaveChangesAsync().ConfigureAwait(true);
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
                _logger.LogInformation("Player Stat updated for {id} at {Time}", playerStat.PersonID,  DateTime.UtcNow);
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


