using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

/*	@PlaceNumber int,
	@PlaceName nvarchar(50),
	@Amount money,
    @Percentage int,
    @id int = 0 output*/

namespace TrackerLibrary.DataAccess
{
    public class SQLConnector : IDataConnection
    {
        private static SqlConnection GetConnection()
        {
            return new System.Data.SqlClient.SqlConnection(GlobalConfig.SqlConnectionString);
        }

        public PersonModel CreatePerson(PersonModel model)
        {
            using (IDbConnection connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", model.FirstName);
                parameters.Add("@LastName", model.LastName);
                parameters.Add("@EmailAddress", model.EmailAddress);
                parameters.Add("@CellPhoneNumber", model.CellPhoneNumber);
                parameters.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPeople_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@id");
            }
            return model;
        }

        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PlaceNumber", model.PlaceNumber);
                parameters.Add("@PlaceName", model.PlaceName);
                parameters.Add("@Amount", model.Amount);
                parameters.Add("@Percentage", model.Percentage);
                parameters.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@id");
            }

            return model;
        }

        public TeamModel CreateTeam(TeamModel team)
        {
            using(IDbConnection connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TeamName", team.TeamName);
                parameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeams_Insert", parameters, commandType:CommandType.StoredProcedure);

                team.Id = parameters.Get<int>("@Id");

                foreach(var member in team.Members)
                {
                    var memberParameters = new DynamicParameters();
                    memberParameters.Add("@TeamId", team.Id);
                    memberParameters.Add("@PersonId", member.Id);
                    memberParameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.spTeamMembers_Insert", memberParameters, commandType:CommandType.StoredProcedure);
                    //member.Id = memberParameters.Get<int>("@Id"); member is actually a person so this is not valid
                }
            }
            return team;
        }

        public TournamentModel CreateTournament(TournamentModel tournament)
        {
            using(IDbConnection connection = GetConnection())
            {
                SaveTournamnet(tournament, connection);

                SaveTournamentPrizes(tournament, connection);

                SaveTournamentEntries(tournament, connection);

                SaveTournamentRounds(tournament, connection);
            }
            return tournament;
        }

        private void SaveTournamnet(TournamentModel tournament, IDbConnection connection)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TournamentName", tournament.TournamentName);
            parameters.Add("@EntryFee", tournament.EntryFee);
            parameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute(
                "dbo.spTournaments_Insert",
                param: parameters,
                commandType: CommandType.StoredProcedure);
            tournament.Id = parameters.Get<int>("@Id");
        }

        private void SaveTournamentPrizes(TournamentModel tournament, IDbConnection connection)
        {
            foreach (var prize in tournament.Prizes)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TournamentId", tournament.Id);
                parameters.Add("@PrizeId", prize.Id);
                parameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute(
                    "dbo.spTournamentPrizes_Insert",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournamentEntries(TournamentModel tournament, IDbConnection connection)
        {
            foreach (var entry in tournament.EnteredTeams)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TournamentId", tournament.Id);
                parameters.Add("@TeamId", entry.Id);
                parameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute(
                    "dbo.spTournamentEntries_Insert",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournamentRounds(TournamentModel tournament, IDbConnection connection)
        {
            foreach(var round in tournament.Rounds)
            {
                foreach(MatchupModel matchup in round)
                {
                    SaveMatchup(tournament.Id, matchup, connection);

                    SaveMatchupEntries(matchup, connection);
                }
            }
        }

        private static void SaveMatchup(int tournamentId, MatchupModel matchup, IDbConnection connection)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TournamentId", tournamentId);
            parameters.Add("@Round", matchup.Round);
            parameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spMatchups_Insert", param: parameters, commandType: CommandType.StoredProcedure);
            matchup.Id = parameters.Get<int>("@Id");
        }

        private static void SaveMatchupEntries(MatchupModel matchup, IDbConnection connection)
        {
            foreach (MatchupEntryModel entry in matchup.Entries)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MatchupId", matchup.Id);
                parameters.Add("@ParentMatchupId", entry.ParentMatchup != null ? entry.ParentMatchup.Id : null);
                parameters.Add("@TeamCompetingId", entry.TeamCompeting != null ? entry.TeamCompeting.Id : null);
                parameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spMatchupEntries_Insert", param: parameters, commandType: CommandType.StoredProcedure);
                entry.Id = parameters.Get<int>("@Id");
            }

        }

        public List<PersonModel> GetPersons_All()
        {
            List<PersonModel> people; //assiging to an variable explicitly helps debugging

            using (IDbConnection connection = GetConnection())
            {
                people = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }

            return people;
        }

        public List<TeamModel> GetTeam_All()
        {
            var teams = new List<TeamModel>();

            using(IDbConnection connection = GetConnection())
            {
                teams = connection.Query<TeamModel>("dbo.spTeams_GetAll").ToList();
                foreach(var team in teams)
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@TeamId", team.Id);

                    team.Members = connection.Query<PersonModel>("dbo.spPeople_GetByTeam", param: queryParameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }

            return teams;
        }
    }
}
