using System.ComponentModel;
using VotingApp.Models;
using VotingApp.Repositories;

namespace VotingApp.Services
{
    public class VoterService : IVoterService
    {
        private readonly IVoterRepository _voterRepository;
        private readonly ICandidateRepository _candidateRepository;

        public VoterService(IVoterRepository voterRepository, ICandidateRepository candidateRepository)
        {
            _voterRepository = voterRepository;
            _candidateRepository = candidateRepository;
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

        public Voter AddVoteToVoter(Guid voterId, Guid candidateId) 
        {
            var voter = _voterRepository.GetVoterById(voterId);
            if (voter == null) 
            {
                throw new ArgumentNullException("Voter with provided Id not found!");
            }
            else if (voter.VotedCandidateId.HasValue)
            {
                throw new ArgumentException("Selected Voter has already Voted!");
            }

            var candidate = _candidateRepository.GetCandidateById(candidateId);
            if (candidate == null)
            {
                throw new ArgumentNullException("Candidate with provided Id not found!");
            }

            voter.VotedCandidateId = candidateId;
            voter.VotedCandidate = candidate;

            return _voterRepository.UpdateVoter(voter);
        }
    }
}
