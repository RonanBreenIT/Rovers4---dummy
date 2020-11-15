using Rovers4.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rovers4.Models
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ClubContext _clubContext;

        public TeamRepository(ClubContext clubContext)
        {
            _clubContext = clubContext;
        }
        public IEnumerable<Team> Teams => _clubContext.Teams;

        // For Unit Testing
        public ICollection<Team> GetTeams()
        {
            return _clubContext.Teams.ToList();
        }


        public Team GetTeamById(int teamId)
        {
            return _clubContext.Teams.FirstOrDefault(i => i.TeamID == teamId);
        }

        public Team CreateTeam(Team team)
        {
            _clubContext.Teams.Add(team);
            _clubContext.SaveChanges();
            return team;
        }

        public Team UpdateTeam(Team team)
        {
            if (team == null)
            {
                throw new ArgumentNullException(nameof(team));
            }
            var foundTeam = _clubContext.Teams.FirstOrDefault(i => i.TeamID == team.TeamID);
            foundTeam.Name = team.Name;
            _clubContext.Teams.Update(foundTeam);
            _clubContext.SaveChanges();
            return foundTeam;
        }

        public Team DeleteTeam(Team team)
        {
            var foundTeam = _clubContext.Teams.FirstOrDefault(i => i.TeamID == team.TeamID);
            _clubContext.Teams.Remove(foundTeam);
            _clubContext.SaveChanges();
            return foundTeam;
        }
    }
}
