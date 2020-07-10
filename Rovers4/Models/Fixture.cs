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
        Win, Loss, Draw
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

        // Reference to Team
        [ForeignKey("TeamName")]
        [Column(Order = 1)]
        public string TeamName { get; set; } // Do I need to add the ID also - good to find out (failing on updating DB)
        public Team Team { get; set; }

        [Display(Name = "Type")]
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

        //[DisplayFormat(NullDisplayText = "TBC")]
        //private string result;

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

        
        //[DisplayFormat(DataFormatString = "{0:dd-MMM}", ApplyFormatInEditMode = true)]
        public string FullText
        {
            get
            {
                //Date Part
                StringBuilder sb = new StringBuilder("");
                string DatesMonth = FixtureDate.ToString("ddd d");
                string DatesTime = FixtureDate.ToString("hh: mm");
                sb.Append(DatesMonth + "st " + DatesTime + " " + FixtureType.ToString() + " " + "Rathfarnham Rovers" + " " + FinalScore + " " + Opponent + " " + HomeOrAway.ToString());
                return sb.ToString(); 
            }
        }




        // ------- Section Reference to Update Player Stats -------- //



        public static int[] Amounts // This will be how many Goals/Assists can be scored and also Playing Team
        {
            get
            {
                return new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            }
        }


        //public int PlayerID { get; set; } // May not be needed

        //public Dictionary<int, int> Goalscorers = new Dictionary<int, int>();

        private List<PlayerStat> goalscorers = null;

        List<PlayerStat> Goalscorers
        {
            get
            {
                if (goalscorers == null)
                {
                    return goalscorers = new List<PlayerStat>();
                }
                return goalscorers;
            }
        }

        public void UpdateGoalscorers(Person _player, int _assists)
        {
            if (goalscorers != null)
            {
                foreach (PlayerStat p in goalscorers)
                {
                    var match = goalscorers.FirstOrDefault(i => i.PersonID == _player.PersonID);
                    if (match != null)
                    {
                        match.Goals += _assists;
                    }
                }
            }
        }

        //public Dictionary<int, int> Assists = new Dictionary<int, int>();

        private List<PlayerStat> assists = null;

        List<PlayerStat> Assists
        {
            get
            {
                if (assists == null)
                {
                    return assists = new List<PlayerStat>();
                }
                return assists;
            }
        }

        public void UpdateAssists(Person _player, int _assists)
        {
            if (assists != null)
            {
                foreach (PlayerStat p in assists)
                {
                    var match = assists.FirstOrDefault(i => i.PersonID == _player.PersonID);
                    if (match != null)
                    {
                        match.Assists += _assists;
                    }
                }
            }
        }

        //public void UpdateAssist(Person _player)
        //{
        //    if (Goalscorers.ContainsKey(1))
        //    {
        //        Goalscorers[1] += 1;
        //    }
        //    else
        //    {
        //        Goalscorers.Add(1, 1);
        //    }
        //    var desiredKeys = Goalscorers.Keys.Where(p => p.Team.Equals(team));
        //    int goalsScoredByTeam = 0;
        //    foreach (var key in desiredKeys)
        //    {
        //        goalsScoredByTeam += Goalscorers[key];
        //    }
        //}

        public PlayerStat Cleansheet;

        public void UpdateCleansheets(Person _player)
        {
            if (Cleansheet.PersonID == _player.PersonID)
            {
                MOTM.CleanSheet += 1;
            }
        }

        [Display(Name = "Man of the Match")]
        public PlayerStat MOTM;

        public void UpdateMOTM(Person _player)
        {
            if (MOTM.PersonID == _player.PersonID)
            {
                MOTM.MotmAward += 1;
            }
        }

        private List<PlayerStat> playingTeam = null;

        [Display(Name = "Playing Team")]
        List<PlayerStat> PlayingTeam
        {
            get
            {
                if (playingTeam == null)
                {
                    return playingTeam = new List<PlayerStat>();
                }
                return playingTeam;
            }
        }

        public void UpdateGamesPlayed(Person _player)
        {
            if (playingTeam != null)
            {
                foreach (PlayerStat p in playingTeam)
                {
                    var match = playingTeam.FirstOrDefault(i => i.PersonID == _player.PersonID);
                    if (match != null)
                    {
                        match.GamesPlayed += 1;
                    }
                }
            }
        }


        private List<PlayerStat> sentOff = null;

        [Display(Name = "Red Cards")]
        List<PlayerStat> SentOff
        {
            get
            {
                if (sentOff == null)
                {
                    return sentOff = new List<PlayerStat>();
                }
                return sentOff;
            }
        }

        public void UpdateRedCardsStat(Person _player)
        {
            if (sentOff != null)
            {
                foreach (PlayerStat p in sentOff)
                {
                    var match = sentOff.FirstOrDefault(i => i.PersonID == _player.PersonID);
                    if (match != null)
                    {
                        match.RedCards += 1;
                    }
                }
            }
        }


        //public int PLayerStatID { get; set; } // May not be needed - added based off https://forums.asp.net/t/2158295.aspx?+Beginner+Create+a+model+class+field+containing+a+list+of+objects+from+another+table+with+ASP+NET+MVC

        //public virtual PlayerStat PlayerStat { get; set; } // // May not be needed Look at this
    }
}
