using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public class MockClubRepository: IClubRepository
    {
        private readonly IClubRepository clubRepository = new MockClubRepository();

        //public IEnumerable<Club> Clubs
        //{
        //    get
        //    {
        //        return new List<Club>
        //        {
        //            new Club{ClubID=1, Name = "Demo Club", Address = "Test 1", 
        //                    ClubImage1 = "image1.png", ClubImage2 = "image2.png", ClubImage3 = "image3.png",
        //                    Email = "111@sss.com", Number = "111 1111111"}
        //        };
        //    }
        //}

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
