using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        private const string TeamsFile = "TeamModels.csv";
        private const string TeamMembersFile = "TeamMembers.csv";


        public PrizeModel CreatePrize(PrizeModel model)
        {
            //Load the text file
            List<PrizeModel> prizeModels = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();
            //Convert the text to List<PrizeModel>
            // Find the max id
            int currentId = 1;
            if(prizeModels.Count > 0)
                currentId = prizeModels.OrderByDescending(x => x.Id).First().Id + 1;
            model.Id = currentId;

            //Add the new record with the new_id = max_id + 1
            prizeModels.Add(model);
            //convert the prizes to List of string
            //save the list of string to text file
            prizeModels.SaveToPrizesFile(PrizesFile);
            
            return model;
        }

        public PersonModel CreatePerson(PersonModel model)
        {
            //Load the text file
            List<PersonModel> personModels = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
            //Convert the text to List<PrizeModel>
            // Find the max id
            int currentId = 1;
            if (personModels.Count > 0)
                currentId = personModels.OrderByDescending(x => x.Id).First().Id + 1;
            model.Id = currentId;

            //Add the new record with the new_id = max_id + 1
            personModels.Add(model);
            //convert the prizes to List of string
            //save the list of string to text file
            personModels.SaveToPersonFile(PeopleFile);

            return model;
        }

        public List<PersonModel> GetPersons_All()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public TeamModel CreateTeam(TeamModel newTeam)
        {
            List<TeamModel> teams = TeamsFile.FullFilePath().LoadFile().ConvertToTeamModels();

            int current_team_id = 1;
            if(teams.Count > 0)
            {
                current_team_id = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }
            newTeam.Id = current_team_id;
            teams.Add(newTeam);

            teams.SaveToTeamsFile(TeamsFile);

            var teamMemberLines = TeamMembersFile.FullFilePath().LoadFile();
            var currentMemberId = 1;
            if (teamMemberLines.Count > 0)
                currentMemberId = int.Parse(teamMemberLines.OrderByDescending(x => x.Split(",")[0]).First().Split(",")[0]) + 1;

            foreach(var member in newTeam.Members)
            {
                teamMemberLines.Add($"{currentMemberId},{newTeam.Id},{member.Id}");
                currentMemberId++;
            }

            teamMemberLines.SaveToTeamMembersFile(TeamMembersFile);

            return newTeam;
        }

        public List<TeamModel> GetTeam_All()
        {
            throw new NotImplementedException();
        }

        public TournamentModel CreateTournament(TournamentModel tournament)
        {
            throw new NotImplementedException();
        }
    }
}
