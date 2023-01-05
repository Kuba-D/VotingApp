using VotingApp.Models;

namespace VotingApp.Repositories
{
    public interface IVoterRepository
    {
        public Task<Voter> CreateVoterAsync(Voter voter);

        public Task<Voter> UpdateVoterAsync(Voter voter);

        public List<Voter> GetVoters();
    }
}
