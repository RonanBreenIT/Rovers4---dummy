using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public class EmailModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        //public string Body
        //{
        //    get
        //    {
        //        StringBuilder sb = new StringBuilder("");
        //        sb.Append("\nFixture Type: " + FixtureType.ToString() + "\nKick Off Time: " + KickOffTime + 
        //            "\nOpponent: " + Opponent + "\nVenue: " + HomeOrAway.ToString()
        //            + "\nMeet Location: " + MeetLocation + "\nMeet Time: " + MeetTime);
        //        return sb.ToString();
        //    }
        //}
        public FixtureType FixtureType { get; set; }

        public string FixTypeString
        {
            get
            {
                return FixtureType.ToString();
            }
            set
            {
                value = FixtureType.ToString();
            }
        }
        public HomeOrAway HomeOrAway { get; set; }

        public string HomeOrAwayString
        {
            get
            {
                return HomeOrAway.ToString();
            }
            set
            {
                value = HomeOrAway.ToString();
            }
        }
        public DateTime KickOffTime { get; set; }

        public string Opponent { get; set; }
        public string MeetLocation { get; set; }
        public DateTime MeetTime { get; set; }
    }
}
