namespace TrackerLibrary
{
    public class MatchupEntryModel
    {
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialScore">
        /// Initial Score for this Entry
        /// </param>
        public MatchupEntryModel(double initialScore)
        {
            Score = initialScore;
        }
    }
}