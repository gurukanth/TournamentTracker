namespace TrackerLibrary.Models
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public List<PersonModel> Members { get; set; } = new List<PersonModel>();

        internal string ToCsvString()
        {
            return $"{this.Id},{this.TeamName}";
        }
    }
}