using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        public int Id { get; set; }
        public int PlaceNumber { get; set; }
        public string PlaceName { get; set; }
        public decimal Amount { get; set; }
        public int Percentage { get; set; }

        public PrizeModel()
        {

        }

        public PrizeModel(string placeNumber, string placeName, string amount, string percentage)
        {
            PlaceName = placeName;

            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal primeAmount = 0;
            decimal.TryParse(amount, out primeAmount);
            Amount = primeAmount;

            int percentageValue = 0;
            int.TryParse(percentage, out percentageValue);
            Percentage = percentageValue;
        }

        internal string ToCsvString()
        {
            return $"{this.Id},{this.PlaceNumber},{this.PlaceName},{this.Amount},{this.Percentage}";
        }
    }
}
