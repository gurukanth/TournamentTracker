namespace TrackerLibrary
{
    public class TeamModel
    {
        public string Name { get; set; }
        public List<PersonModel> Members { get; set; } = new List<PersonModel>();

    }
}