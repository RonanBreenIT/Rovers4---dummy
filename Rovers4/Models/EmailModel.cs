using System;

namespace Rovers4.Models
{
    public class EmailModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }

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
