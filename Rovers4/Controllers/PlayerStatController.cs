using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rovers4.Data;
using Rovers4.Models;
using Rovers4.ViewModels;

namespace Rovers4.Controllers
{
    public class PlayerStatController : Controller
    {
    
        private readonly IPersonRepository _personRepository;
        private readonly IPlayerStatRepository _playerStatRepository;



        public PlayerStatController(IPersonRepository personRepository, ClubContext context, IPlayerStatRepository playerStatRepository)
        {
            _personRepository = personRepository;
            _playerStatRepository = playerStatRepository;
   
        }
        //public IActionResult PlayerStatsDetails()
        //{
        //    return View();
        //}

        // Team = Player
        // staff = PlayerStat

        public ViewResult PlayerStatList(int? id)
        {
            IEnumerable<PlayerStat> stat;
            string currentPlayer;

            if (id == null)
            {
                stat = _playerStatRepository.AllStats.OrderBy(p => p.PersonID);
                currentPlayer = "All Players";
            }
            else
            {
                stat = _playerStatRepository.AllStats.Where(p => p.PersonID == id)
                    .OrderBy(p => p.PersonID);
                currentPlayer = _personRepository.AllStaff.FirstOrDefault(c => c.PersonID == id)?.FullName;
            }

            return View(new PlayerStatsViewModel
            {
                Stats = stat,
                CurrentPlayer = currentPlayer
            });
        }
    }
}