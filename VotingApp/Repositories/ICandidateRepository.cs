using VotingApp.Models;

namespace VotingApp.Repositories
{
    public interface ICandidateRepository
    {
        public Candidate CreateCandidate(Candidate candidate);

        public List<Candidate> GetCandidates();

        public Candidate? GetCandidateById(Guid id);
    }
}
