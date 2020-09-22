using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public interface IClubRepository
    {
        //IEnumerable<Club> Clubs { get; }
        ICollection<Club> GetClubs();

        Club GetClubById(int clubId);

        Club CreateClub(Club club);

        Club UpdateClub(Club club);

        Club DeleteClub(Club club);
    }
}
