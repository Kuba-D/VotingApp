using VotingApp.Models;

namespace VotingApp.Services
{
    public interface IVoterService
    {
        public IEnumerable<Voter> GetVoters();
    }
}
