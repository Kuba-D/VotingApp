using VotingApp.Models;
using VotingApp.Repositories;

namespace VotingApp.Services
{
    public class VoterService : IVoterService
    {
        private readonly IVoterRepository _voterRepository;

        public VoterService(IVoterRepository voterRepository)
        {
            _voterRepository = voterRepository;
        }

        public IEnumerable<Voter> GetVoters()
        {
            return _voterRepository.GetVoters();
        }
    }
}
