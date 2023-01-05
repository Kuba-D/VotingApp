using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VotingApp.Models;

namespace VotingApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
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