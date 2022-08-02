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
                parameters.Add("@TeamName", team.Name);
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

        public List<PersonModel> GetPersons_All()
        {
            List<PersonModel> people; //assiging to an variable explicitly helps debugging

            using (IDbConnection connection = GetConnection())
            {
                people = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }

            return people;
        }
    }
}
