using VotingApp.Models;

namespace VotingApp.Services
{
    public interface ICandidateService
    {
        public Candidate CreateCandidate(string candidateName);

        public IEnumerable<Candidate> GetCandidates();
    }
}
