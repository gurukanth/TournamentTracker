using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        PrizeModel CreatePrize(PrizeModel prize);
        PersonModel CreatePerson(PersonModel personModel);
        TeamModel CreateTeam(TeamModel team);
        List<PersonModel> GetPersons_All();
        List<TeamModel> GetTeam_All();
        TournamentModel CreateTournament(TournamentModel tournament);
    }
}
