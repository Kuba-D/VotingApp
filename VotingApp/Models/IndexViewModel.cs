namespace VotingApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Voter> Voters { get; set; } = new List<Voter>();

        public IEnumerable<Candidate> Candidates { get; set; } = new List<Candidate>();
    }
}
