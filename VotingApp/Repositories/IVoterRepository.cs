using VotingApp.Models;

namespace VotingApp.Repositories
{
    public interface IVoterRepository
    {
        public Voter CreateVoter(Voter voter);

        public Voter UpdateVoter(Voter voter);

        public List<Voter> GetVoters();

        public Voter? GetVoterById(Guid id);
    }
}
