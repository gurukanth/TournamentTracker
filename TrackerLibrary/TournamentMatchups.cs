using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class TournamentMatchups
    {
        private const int ROUND_ONE = 1;
        //TODO create matchups
        //Order our list of teams in random
        //Check if it is big enough to create matchups(Total Teams = 2**n) otherwise add BYE teams as needed
        //Create first round of matchups - N/2 matchups in 1st round for every N teams
        //Create reamining rounds after first round - For 8 teams, 1st round 4 matchups, 2nd 2matchups, 3rd 1matchup
        
        public static void CreateRounds(TournamentModel tournament)
        {
            tournament.EnteredTeams = RandamizeTeams(tournament.EnteredTeams);
            int noOfRoundsNeeded = DetermineTournamentRounds(tournament.EnteredTeams.Count);
            int byeTeamCount = FindByeTeamsNeeded(noOfRoundsNeeded, tournament.EnteredTeams.Count);

            tournament.Rounds.Add(CreateFirstRoundMatchups(tournament.EnteredTeams, byeTeamCount));
            CreateRemainingRounds(noOfRoundsNeeded, tournament);
        }

        private static List<MatchupModel> CreateFirstRoundMatchups(List<TeamModel> teams, int byeTeams)
        {
            var matchups = new List<MatchupModel>();
            MatchupModel currentMatchup = new MatchupModel();
            
            foreach (var team in teams)
            {
                currentMatchup.Entries.Add(new MatchupEntryModel { TeamCompeting = team });
                if(byeTeams > 0 || currentMatchup.Entries.Count > 1)
                {
                    currentMatchup.Round = ROUND_ONE;
                    matchups.Add(currentMatchup);
                    currentMatchup = new MatchupModel();

                    if (byeTeams > 0)
                        byeTeams--;
                }
            }

            return matchups;
        }

        private static void CreateRemainingRounds(int rounds, TournamentModel tournament)
        {
            List<MatchupModel> previousRoundMatchups = tournament.Rounds.First();
            int currentRound = 2;
            while(currentRound <= rounds)
            {
                var currentRoundMatchups = new List<MatchupModel>();
                var currentMatchup = new MatchupModel { Round = currentRound };

                foreach (var prevMatchup in previousRoundMatchups)
                {
                    currentMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = prevMatchup });
                    
                    if(currentMatchup.Entries.Count > 1)
                    {
                        currentRoundMatchups.Add(currentMatchup);
                        currentMatchup = new MatchupModel { Round = currentRound };
                    }
                }

                tournament.Rounds.Add(currentRoundMatchups);
                previousRoundMatchups = currentRoundMatchups;
                currentRoundMatchups = new List<MatchupModel>();

                currentRound++;
            }
        }

        private static int DetermineTournamentRounds(int teamCount)
        {
            int noOfRounds = 0;
            while(teamCount > 1)
            {
                noOfRounds++;
                teamCount = teamCount % 2 + teamCount / 2;
            } 

            return noOfRounds;
        }

        private static List<TeamModel> RandamizeTeams(List<TeamModel> teams)
        {
            return teams.OrderBy(t => Guid.NewGuid()).ToList();
        }

        private static int FindByeTeamsNeeded(int rounds, int teamCount)
        {
            return (int) Math.Pow(2, rounds) - teamCount;
        }

    }
}
