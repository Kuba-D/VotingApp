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

        public Voter CreateVoter(string voterName)
        {
            var newVoter = new Voter()
            {
                Id = Guid.NewGuid(),
                Name = voterName,
            };

            return _voterRepository.CreateVoter(newVoter);
        }

        public IEnumerable<Voter> GetVoters()
        {
            return _voterRepository.GetVoters();
        }
    }
}
