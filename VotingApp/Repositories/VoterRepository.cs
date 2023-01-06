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

        public async Task<Voter> UpdateVoterAsync(Voter voter)
        {
            _context.Set<Voter>().Update(voter);
            await _context.SaveChangesAsync();
            return voter;
        }

        public List<Voter> GetVoters()
        {
            return _context.Voters.ToList();
        }
    }
}
