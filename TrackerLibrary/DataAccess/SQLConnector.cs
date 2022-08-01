using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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
        public PrizeModel CreatePrize(PrizeModel model)
        {
            Console.WriteLine($"ConnectionSrting:{GlobalConfig.SqlConnectionString}");
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.SqlConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PlaceNumber", model.PlaceNumber);
                parameters.Add("@PlaceName", model.PlaceName);
                parameters.Add("@Amount", model.Amount);
                parameters.Add("@Percentage", model.Percentage);
                parameters.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@id");
                return model;
            }
        }
    }
}
