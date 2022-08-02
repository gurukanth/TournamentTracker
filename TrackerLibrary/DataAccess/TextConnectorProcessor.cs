using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
        }

        public static List<string> LoadFile(this string file)
        {
            if(! File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadLines(file).ToList();
        }

        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> prizeModels = new List<PrizeModel>();

            foreach(string line in lines)
            {
                string[] columns = line.Split(",");

                var prizeModel = new PrizeModel();
                prizeModel.Id = int.Parse(columns[0]);
                prizeModel.PlaceNumber = int.Parse(columns[1]);
                prizeModel.PlaceName = columns[2];
                prizeModel.Amount = decimal.Parse(columns[3]);
                prizeModel.Percentage = int.Parse(columns[4]);
                
                prizeModels.Add(prizeModel);
            }
            return prizeModels;
        }

        public static void SaveToPrizesFile(this List<PrizeModel> prizes, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (var item in prizes)
            {
                lines.Add(item.ToCsvString());
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> personModels = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] columns = line.Split(",");

                var personModel = new PersonModel();
                personModel.Id = int.Parse(columns[0]);
                personModel.FirstName = columns[1];
                personModel.LastName = columns[2];
                personModel.EmailAddress = columns[3];
                personModel.CellPhoneNumber = columns[4];

                personModels.Add(personModel);
            }
            return personModels;
        }

        public static void SaveToPersonFile(this List<PersonModel> prizes, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (var item in prizes)
            {
                lines.Add(item.ToCsvString());
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}
