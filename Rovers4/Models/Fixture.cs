using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public enum FixtureType
    {
        League, Cup, Friendly, Training
    }

    public enum ResultDescription
    {
        TBC, Win, Loss, Draw
    }

    public enum HomeOrAway
    {
        Home, Away
    }
    public class Fixture
    {
        [Key]
        [Column(Order = 0)]
        public int FixtureID { get; set; }

        [ForeignKey("TeamID")]
        public int TeamID { get; set; }
        public Team Team { get; set; }

        [Display(Name = "Fixture Type")]
        [Column(Order = 2)]
        public FixtureType FixtureType { get; set; }

        //[DataType(DataType.Date)]
        [Display(Name = "Date")]
        [Column(Order = 3)]
        public DateTime FixtureDate { get; set; }

        [Column(Order = 4)]
        public string Location { get; set; }

        // -- This section for Events --- //
        [DisplayFormat(NullDisplayText = "TBC")]
        [Display(Name = "Home/Away")]
        [Column(Order = 5)]
        public HomeOrAway HomeOrAway { get; set; }

        public string HomeOrAwayToShortString
        {
            get
            {
                return HomeOrAway.ToString()[0].ToString();
            }
        }

        // May get rid of meet times and location - these are for events
        [Display(Name = "Meet Time")]
        [Column(Order = 6)]
        public DateTime MeetTime { get; set; }

        [DisplayFormat(NullDisplayText = "TBC")]
        [Display(Name = "Meet Location")]
        [Column(Order = 7)]
        public string MeetLocation { get; set; } = null;

        // ----- This section for Result Details ------ //

        [Display(Name = "Rovers Score")]
        [Column(Order = 8)]
        public int? OurScore { get; set; }

        [DisplayFormat(NullDisplayText = "Not Applicable")]
        [Column(Order = 9)]
        public string Opponent { get; set; }

        [Display(Name = "Opponent Score")]
        [Column(Order = 10)]
        public int? OpponentScore { get; set; }


        [Column(Order = 11)]
        [DisplayFormat(NullDisplayText = "TBC")]
        [Display(Name = "Score")]
        public string FinalScore
        {
            get
            {
                return OurScore.ToString() + "-" + OpponentScore.ToString();
            }
        }

        [DisplayFormat(NullDisplayText = "TBC")]
        [Display(Name = "Win/Loss/Draw")]
        [Column(Order = 12)]
        public ResultDescription ResultDescription { get; set; }

        [DisplayFormat(NullDisplayText = "TBC")]
        [Display(Name = "Match Report")]
        [Column(Order = 13)]
        public string MatchReport { get; set; } = null;

        public string FullDatesText
        {
            get
            {
                //Date Part
                StringBuilder sb = new StringBuilder("");
                string DatesMonth = FixtureDate.ToString("d ddd");
                string DatesTime = FixtureDate.ToString("hh:mm");
                sb.Append(DatesMonth + " - " + DatesTime + "\t- " + FixtureType.ToString());
                return sb.ToString(); 
            }
        }

        public List<PersonStats> Players { get; set; }
    }
}
