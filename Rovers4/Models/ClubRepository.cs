using Rovers4.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rovers4.Models
{
    // Using this for Unit testing. Controller actually handles all DB injections. 
    public class ClubRepository : IClubRepository
    {
        private readonly ClubContext _clubContext;

        public ClubRepository(ClubContext clubContext)
        {
            _clubContext = clubContext;
        }
        public ICollection<Club> GetClubs()
        {
            return _clubContext.Clubs.ToList();
        }

        public Club GetClubById(int clubId)
        {
            return _clubContext.Clubs.FirstOrDefault(i => i.ClubID == clubId);
        }


        public Club CreateClub(Club club)
        {
            _clubContext.Clubs.Add(club);
            _clubContext.SaveChanges();
            return club;
        }

        public Club UpdateClub(Club club)
        {
            if (club == null)
            {
                throw new ArgumentNullException(nameof(club));
            }
            var foundclub = _clubContext.Clubs.FirstOrDefault(i => i.ClubID == club.ClubID);
            foundclub.Name = club.Name;
            _clubContext.Clubs.Update(foundclub);
            _clubContext.SaveChanges();
            return club;
        }

        public Club DeleteClub(Club club)
        {
            var foundclub = _clubContext.Clubs.FirstOrDefault(i => i.ClubID == club.ClubID);
            _clubContext.Clubs.Remove(foundclub);
            _clubContext.SaveChanges();
            return foundclub;
        }
    }
}
