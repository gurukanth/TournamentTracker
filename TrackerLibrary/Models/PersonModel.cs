using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CellPhoneNumber { get; set; }

        public string ToCsvString()
        {
            return $"{this.Id},{this.FirstName},{this.LastName},{this.EmailAddress},{this.CellPhoneNumber}";
        }

        public string   FullName
        {
            get 
            {
                return $"{this.FirstName} {this.LastName}";
            }
            
        }

    }
}
