using VotingApp.Models;
using VotingApp.Repositories;

namespace VotingApp.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository) 
        {
            _candidateRepository = candidateRepository;
        }

        public Candidate CreateCandidate(string candidateName)
        {
            var newCandidate = new Candidate()
            {
                Id = Guid.NewGuid(),
                Name = candidateName,
            };

            return _candidateRepository.CreateCandidate(newCandidate);
        }

        public IEnumerable<Candidate> GetCandidates()
        {
            return _candidateRepository.GetCandidates();
        }
    }
}
