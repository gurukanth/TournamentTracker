namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Represents the one team in the matchup
        /// </summary>
        public TeamModel TeamCompeting { get; set; }
        /// <summary>
        /// Represents the score for this particular in the current matchup
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// Represents the match-up that this team came from as winner
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }

    }
}