using Rovers4.Data;
using System.Collections.Generic;
using System.Linq;

namespace Rovers4.Models
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ClubContext clubContext;

        public TeamRepository(ClubContext _clubContext)
        {
            clubContext = _clubContext;
        }
        public IEnumerable<Team> Teams => clubContext.Teams;

        // For Unit Testing
        public ICollection<Team> GetTeams()
        {
            return clubContext.Teams.ToList();
        }


        public Team GetTeamById(int teamId)
        {
            return clubContext.Teams.FirstOrDefault(i => i.TeamID == teamId);
        }

        public Team CreateTeam(Team team)
        {
            clubContext.Teams.Add(team);
            clubContext.SaveChanges();
            return team;
        }

        public Team UpdateTeam(Team team)
        {
            var foundTeam = clubContext.Teams.FirstOrDefault(i => i.TeamID == team.TeamID);
            foundTeam.Name = team.Name;
            clubContext.Teams.Update(foundTeam);
            clubContext.SaveChanges();
            return foundTeam;
        }

        public Team DeleteTeam(Team team)
        {
            var foundTeam = clubContext.Teams.FirstOrDefault(i => i.TeamID == team.TeamID);
            clubContext.Teams.Remove(foundTeam);
            clubContext.SaveChanges();
            return foundTeam;
        }
    }
}
