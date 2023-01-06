using VotingApp.Models;

namespace VotingApp.Repositories
{
    public interface IVoterRepository
    {
        public Voter CreateVoter(Voter voter);

        public Task<Voter> UpdateVoterAsync(Voter voter);

        public List<Voter> GetVoters();
    }
}
