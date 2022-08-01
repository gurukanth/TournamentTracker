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

        public PersonModel CreatePerson(PersonModel personModel)
        {
            throw new NotImplementedException();
        }

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
    }
}
