using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rovers4.Data;
using Rovers4.Models;
using Rovers4.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Controllers
{
    public class FixtureController : Controller
    {
        private readonly ClubContext _context;
        private readonly IFixtureRepository _fixtureRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPlayerStatRepository _playerStatRepository;



        public FixtureController(ClubContext context, IFixtureRepository fixtureRepository, ITeamRepository teamRepository, IPersonRepository personRepository, IPlayerStatRepository playerStatRepository)
        {
            _context = context;
            _fixtureRepository = fixtureRepository;
            _teamRepository = teamRepository;
            _personRepository = personRepository;
            _playerStatRepository = playerStatRepository;

        }

        public ViewResult TeamFixtureList(int? id)
        {
            IEnumerable<Fixture> fixtures;
            IEnumerable<Fixture> janFixtures;
            IEnumerable<Fixture> febFixtures;
            IEnumerable<Fixture> marchFixtures;
            IEnumerable<Fixture> aprilFixtures;
            IEnumerable<Fixture> mayFixtures;
            IEnumerable<Fixture> juneFixtures;
            IEnumerable<Fixture> julyFixtures;
            IEnumerable<Fixture> augustFixtures;
            IEnumerable<Fixture> septemberFixtures;
            IEnumerable<Fixture> octoberFixtures;
            IEnumerable<Fixture> novemberFixtures;
            IEnumerable<Fixture> decemberFixtures;
            string currentTeam;
            int teamID;
            int totalWins;
            int totalDraws;
            int totalLosses;
            int goalsFor;
            int goalsAgainst;
            int gamesPlayed;

            if (id == null)
            {
                fixtures = _fixtureRepository.AllFixtures.OrderBy(p => p.TeamID);
                janFixtures = _fixtureRepository.JanuaryFixtures.OrderBy(p => p.TeamID);
                febFixtures = _fixtureRepository.FebruaryFixtures.OrderBy(p => p.TeamID);
                marchFixtures = _fixtureRepository.MarchFixtures.OrderBy(p => p.TeamID);
                aprilFixtures = _fixtureRepository.AprilFixtures.OrderBy(p => p.TeamID);
                mayFixtures = _fixtureRepository.MayFixtures.OrderBy(p => p.TeamID);
                juneFixtures = _fixtureRepository.JuneFixtures.OrderBy(p => p.TeamID);
                julyFixtures = _fixtureRepository.JulyFixtures.OrderBy(p => p.TeamID);
                augustFixtures = _fixtureRepository.AugustFixtures.OrderBy(p => p.TeamID);
                septemberFixtures = _fixtureRepository.SeptemberFixtures.OrderBy(p => p.TeamID);
                octoberFixtures = _fixtureRepository.OctoberFixtures.OrderBy(p => p.TeamID);
                novemberFixtures = _fixtureRepository.NovemberFixtures.OrderBy(p => p.TeamID);
                decemberFixtures = _fixtureRepository.DecemberFixtures.OrderBy(p => p.TeamID);
                currentTeam = "All Teams";
                teamID = 1;
                totalWins = 0;
                totalDraws = 0;
                totalLosses = 0;
                goalsFor = 0;
                goalsAgainst = 0;
                gamesPlayed = 0;
            }
            else
            {
                fixtures = _fixtureRepository.AllFixtures.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FixtureDate);
                janFixtures = _fixtureRepository.JanuaryFixtures.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FixtureDate);
                febFixtures = _fixtureRepository.FebruaryFixtures.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FixtureDate);
                marchFixtures = _fixtureRepository.MarchFixtures.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FixtureDate);
                aprilFixtures = _fixtureRepository.AprilFixtures.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FixtureDate);
                mayFixtures = _fixtureRepository.MayFixtures.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FixtureDate);
                juneFixtures = _fixtureRepository.JuneFixtures.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FixtureDate);
                julyFixtures = _fixtureRepository.JulyFixtures.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FixtureDate);
                augustFixtures = _fixtureRepository.AugustFixtures.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FixtureDate);
                septemberFixtures = _fixtureRepository.SeptemberFixtures.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FixtureDate);
                octoberFixtures = _fixtureRepository.OctoberFixtures.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FixtureDate);
                novemberFixtures = _fixtureRepository.NovemberFixtures.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FixtureDate);
                decemberFixtures = _fixtureRepository.DecemberFixtures.Where(p => p.TeamID == id)
                    .OrderBy(p => p.FixtureDate);
                currentTeam = _teamRepository.Teams.FirstOrDefault(c => c.TeamID == id)?.Name;
                teamID = id.Value;
                totalWins = _fixtureRepository.TotalWins(id);
                totalDraws = _fixtureRepository.TotalDraws(id);
                totalLosses = _fixtureRepository.TotalLosses(id);
                goalsFor = _fixtureRepository.GoalsFor(id);
                goalsAgainst = _fixtureRepository.GoalsAgainst(id);
                gamesPlayed = (totalWins + totalDraws + totalLosses);
            }

            //ViewData["TotalWins"] = currentTeam.
            return View(new FixtureListViewModel
            {
                Fixtures = fixtures,
                CurrentTeam = currentTeam,
                TeamID = teamID,
                JanuaryFixtures = janFixtures,
                FebruaryFixtures = febFixtures,
                MarchFixtures = marchFixtures,
                AprilFixtures = aprilFixtures,
                MayFixtures = mayFixtures,
                JuneFixtures = juneFixtures,
                JulyFixtures = julyFixtures,
                AugustFixtures = augustFixtures,
                SeptemberFixtures = septemberFixtures,
                OctoberFixtures = octoberFixtures,
                NovemberFixtures = novemberFixtures,
                DecemberFixtures = decemberFixtures,
                Teams = _teamRepository.Teams,
                TotalWins = totalWins,
                TotalDraws = totalDraws,
                TotalLosses = totalLosses,
                GoalsFor = goalsFor,
                GoalsAgainst = goalsAgainst,
                GamesPlayed = gamesPlayed
            });
        }

        public async Task<IActionResult> ResultDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.FixtureID == id);
            if (fixture == null)
            {
                return NotFound();
            }

            return View(fixture);
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
        public async Task<IActionResult> Create([Bind("FixtureID,TeamID,FixtureType,FixtureDate,Location,HomeOrAway,Opponent")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fixture);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Team");
            }
            return View(fixture);
        }

        [Authorize(Roles = "Super Admin, Team Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures.FindAsync(id);
            if (fixture == null)
            {
                return NotFound();
            }
            ViewBag.CurrentTeam = _teamRepository.GetTeamById(fixture.TeamID)?.Name;
            return View(fixture);
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FixtureID,TeamID,FixtureType,FixtureDate,HomeOrAway,OurScore,Opponent,OpponentScore,Result,ResultDescription,MatchReport")] Fixture fixture)
        {
            if (id != fixture.FixtureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fixture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FixtureExists(fixture.FixtureID))
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
            return View(fixture);
        }

        [Authorize(Roles = "Super Admin, Team Admin")]
        public async Task<IActionResult> EditResult(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures.FindAsync(id);
            if (fixture == null)
            {
                return NotFound();
            }
            ViewBag.CurrentTeam = _teamRepository.GetTeamById(fixture.TeamID)?.Name;
            return View(fixture);
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditResult(int id, [Bind("FixtureID,TeamID,FixtureType,FixtureDate,HomeOrAway,OurScore,Opponent,OpponentScore,Result,ResultDescription,MatchReport")] Fixture fixture)
        {
            if (id != fixture.FixtureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fixture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FixtureExists(fixture.FixtureID))
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
            return View(fixture);
        }

        [Authorize(Roles = "Super Admin, Team Admin")]
        public async Task<IActionResult> AddResult(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures.FindAsync(id);

            var playerList = _personRepository.Players.Where(i => i.TeamID == fixture.TeamID);
            fixture.Players = new List<PersonStats>();

            foreach (var player in playerList)
            {
                fixture.Players.Add(new PersonStats
                {
                    PersonID = player.PersonID,
                    FirstName = player.FirstName,
                    Surname = player.Surname,
                    Played = false,
                    Assists = 0,
                    Goals = 0,
                    CleanSheet = false,
                    RedCards = false,
                    MotmAward = false
                }); ;
            }

            if (fixture == null)
            {
                return NotFound();
            }

            ViewBag.CurrentTeam = _teamRepository.GetTeamById(fixture.TeamID)?.Name;
            return View(fixture);
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddResult(int id, Fixture fixture)
        {
            if (id != fixture.FixtureID)
            {
                return NotFound();
            }

            if (id == fixture.FixtureID)
            {
                try
                {
                    foreach (var player in fixture.Players)
                    {
                        if (player.Played == true)
                        {
                            _playerStatRepository.UpdatePlayerStats(player.PersonID, player.Played, player.Assists, player.Goals, player.CleanSheet, player.RedCards, player.MotmAward);
                        }
                    }
                    _context.Update(fixture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FixtureExists(fixture.FixtureID))
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
            return View(fixture);
        }


        [Authorize(Roles = "Super Admin, Team Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.FixtureID == id);
            if (fixture == null)
            {
                return NotFound();
            }

            return View(fixture);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Super Admin, Team Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fixture = await _context.Fixtures.FindAsync(id);
            _context.Fixtures.Remove(fixture);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Team");
        }
        private bool FixtureExists(int id)
        {
            return _context.Fixtures.Any(e => e.FixtureID == id);
        }
    }
}