using Microsoft.EntityFrameworkCore;
using VotingApp.Context;
using VotingApp.Models;

namespace VotingApp.Repositories
{

    public class VoterRepository : IVoterRepository
    {
        private readonly VotingAppContext _context;

        public VoterRepository(VotingAppContext context)
        {
            _context = context;
        }

        public Voter CreateVoter(Voter voter)
        {
            _context.Set<Voter>().Add(voter);
            _context.SaveChanges();
            return voter;
        }

        public Voter UpdateVoter(Voter voter)
        {
            _context.Set<Voter>().Update(voter);
            _context.SaveChanges();
            return voter;
        }

        public List<Voter> GetVoters()
        {
            return _context.Voters.ToList();
        }

        public Voter? GetVoterById(Guid id)
        {
            var voter = _context.Voters
                .Where(voter => voter.Id == id)
                .FirstOrDefault();
            return voter;
        }
    }
}
