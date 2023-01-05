namespace VotingApp.Models
{
    public class Voter
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Guid? VotedCandidate { get; set; }
    }
}
