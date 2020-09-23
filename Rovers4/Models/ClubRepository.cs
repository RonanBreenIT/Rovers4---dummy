using Rovers4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    // Using this for Unit testing. Controller actually handles all DB injections. 
    public class ClubRepository : IClubRepository
    {
        private readonly ClubContext clubContext;

        public ClubRepository(ClubContext _clubContext )
        {
            clubContext = _clubContext;
        }
        public ICollection<Club> GetClubs()
        {
                return clubContext.Clubs.ToList();
        }

        public Club GetClubById(int clubId)
        {
            return clubContext.Clubs.FirstOrDefault(i => i.ClubID == clubId);
        }


        public Club CreateClub(Club club)
        {
            clubContext.Clubs.Add(club);
            clubContext.SaveChanges();
            return club;
        }
        
        public Club UpdateClub(Club club)
        {
            var foundclub = clubContext.Clubs.FirstOrDefault(i => i.ClubID == club.ClubID);
            foundclub.Name = club.Name;
            clubContext.Clubs.Update(foundclub);
            clubContext.SaveChanges();
            return club;
        }

        public Club DeleteClub(Club club)
        {
            var foundclub = clubContext.Clubs.FirstOrDefault(i => i.ClubID == club.ClubID);
            clubContext.Clubs.Remove(foundclub);
            clubContext.SaveChanges();
            return foundclub;
        }
    }
}
