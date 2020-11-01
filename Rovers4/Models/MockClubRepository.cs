using System;
using System.Collections.Generic;

namespace Rovers4.Models
{
    public class MockClubRepository : IClubRepository
    {
        private readonly IClubRepository clubRepository = new MockClubRepository();

        public Club GetClubById(int clubId)
        {
            throw new NotImplementedException();
        }

        public Club CreateClub(Club club)
        {
            throw new NotImplementedException();
        }

        public Club UpdateClub(Club club)
        {
            throw new NotImplementedException();
        }

        public Club DeleteClub(Club club)
        {
            throw new NotImplementedException();
        }

        public ICollection<Club> GetClubs()
        {
            throw new NotImplementedException();
        }
    }
}
