using VotingApp.Models;

namespace VotingApp.Services
{
    public interface IVoterService
    {
        public Voter CreateVoter(string voterName);

        public IEnumerable<Voter> GetVoters();
    }
}
