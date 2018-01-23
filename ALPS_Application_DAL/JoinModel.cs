namespace ALPS_Application.Models
{
    public class JoinModelOffices
    {
        public string City { get; set; }
        public int USState { get; set; }
    }

    public class JoinModelUSStates
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}
