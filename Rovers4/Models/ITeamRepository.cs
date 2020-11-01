using System.Collections.Generic;

namespace Rovers4.Models
{
    public interface ITeamRepository
    {
        IEnumerable<Team> Teams { get; }

        // For Unit Testing
        ICollection<Team> GetTeams();

        Team GetTeamById(int teamId);

        Team CreateTeam(Team team);

        Team UpdateTeam(Team team);

        Team DeleteTeam(Team team);
    }
}
