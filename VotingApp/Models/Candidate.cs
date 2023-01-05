namespace VotingApp.Models
{
    public class Candidate
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Votes { get; set; }
    }
}
