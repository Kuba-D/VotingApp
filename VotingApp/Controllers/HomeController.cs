using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using VotingApp.Models;
using VotingApp.Services;

namespace VotingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVoterService _voterService;
        private readonly ICandidateService _candidateService;

        public HomeController(IVoterService voterService, ICandidateService candidateService)
        {
            _voterService = voterService;
            _candidateService = candidateService;
        }

        public IActionResult Index()
        {
            var votersFromDb = _voterService.GetVoters().ToList();
            var candidatesFromDb = _candidateService.GetCandidates().ToList();

            var candidates = new List<Candidate>()
            {
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name= "Johnny Bravo",
                },
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name= "Pluto",
                },
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name= "Johnny Bravo",
                },
            };
            var voters = new List<Voter>()
            {
                new Voter 
                {
                    Id = Guid.NewGuid(),
                    Name= "Peppa",
                },                
                new Voter 
                {
                    Id = Guid.NewGuid(),
                    Name= "Rumcajs",
                    VotedCandidateId = candidates[1].Id,
                },
                new Voter
                {
                    Id = Guid.NewGuid(),
                    Name= "Dudel",
                    VotedCandidateId = candidates[1].Id,
                },
                new Voter
                {
                    Id = Guid.NewGuid(),
                    Name= "Peppa2",
                },
                new Voter
                {
                    Id = Guid.NewGuid(),
                    Name= "Rumcajs2",
                    VotedCandidateId = candidates[1].Id,
                },
                new Voter
                {
                    Id = Guid.NewGuid(),
                    Name= "Dudel2",
                    VotedCandidateId = candidates[2].Id,
                },
            };

            candidatesFromDb = CalculateVotes(candidatesFromDb, votersFromDb);

            var indexViewModel = new IndexViewModel()
            {
                Voters = votersFromDb,
                Candidates = candidatesFromDb,
            };

            return View(indexViewModel);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel indexViewModel)
        {
            var createVoter = indexViewModel.NewVoterName != string.Empty;
            var createCandidate = indexViewModel.NewCandidateName != string.Empty;
            var voting = indexViewModel.SelectedVoter != null && indexViewModel.SelectedCandidate != null;

            if (createVoter && !createCandidate && !voting)
            {
                _voterService.CreateVoter(indexViewModel.NewVoterName);
            }
            else if (createCandidate && !createVoter && !voting)
            {
                _candidateService.CreateCandidate(indexViewModel.NewCandidateName);
            }
            else if (voting && !createVoter && !createCandidate)
            {
                var test1 = indexViewModel.SelectedVoter;
                var test2 = indexViewModel.SelectedCandidate;
            }

            return Index();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static List<Candidate> CalculateVotes(List<Candidate> candidates, List<Voter> voters)
        {
            foreach(var candidate in candidates)
            {
                candidate.Votes = voters.Count(voter => voter.VotedCandidateId == candidate.Id); 
            }

            return candidates;
        }
    }
}