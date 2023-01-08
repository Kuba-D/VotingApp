using Microsoft.AspNetCore.Mvc.Rendering;

namespace VotingApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Voter> Voters { get; set; } = new List<Voter>();

        public IEnumerable<Candidate> Candidates { get; set; } = new List<Candidate>();

        public string? NewVoterName { get; set; }

        public string? NewCandidateName { get; set; }

        public Guid? SelectedVoter { get; set; }

        public Guid? SelectedCandidate { get; set; }


    }
}
