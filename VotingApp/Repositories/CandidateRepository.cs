using Microsoft.EntityFrameworkCore;
using VotingApp.Context;
using VotingApp.Models;

namespace VotingApp.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly VotingAppContext _context;

        public CandidateRepository(VotingAppContext context)
        {
            _context = context;
        }

        public Candidate CreateCandidate(Candidate candidate)
        {
            _context.Set<Candidate>().Add(candidate);
            _context.SaveChanges();
            return candidate;
        }

        public List<Candidate> GetCandidates()
        {
            return _context.Candidates.ToList();
        }

        public Candidate? GetCandidateById(Guid id)
        {
            var voter = _context.Candidates
                .Where(voter => voter.Id == id)
                .FirstOrDefault();
            return voter;
        }

    }
}
