using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VotingApp.Models;

namespace VotingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
                    VotedCandidate = candidates[1].Id,
                },
                new Voter
                {
                    Id = Guid.NewGuid(),
                    Name= "Dudel",
                    VotedCandidate = candidates[1].Id,
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
                    VotedCandidate = candidates[1].Id,
                },
                new Voter
                {
                    Id = Guid.NewGuid(),
                    Name= "Dudel2",
                    VotedCandidate = candidates[2].Id,
                },
            };

            candidates = CalculateVotes(candidates, voters);

            var indexViewModel = new IndexViewModel()
            {
                Voters = voters,
                Candidates = candidates,
            };

            return View(indexViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<Candidate> CalculateVotes(List<Candidate> candidates, List<Voter> voters)
        {
            foreach(var candidate in candidates)
            {
                candidate.Votes = voters.Count(voter => voter.VotedCandidate == candidate.Id); 
            }

            return candidates;
        }
    }
}