using Microsoft.AspNetCore.Mvc;
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

            var indexViewModel = new IndexViewModel()
            {
                Voters = votersFromDb,
                Candidates = CalculateVotes(candidatesFromDb),
            };

            return View(indexViewModel);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel indexViewModel)
        {
            var createVoter = indexViewModel.NewVoterName != null;
            var createCandidate = indexViewModel.NewCandidateName != null;
            var voting = indexViewModel.SelectedVoter != null && indexViewModel.SelectedCandidate != null;

            if (createVoter && !createCandidate && !voting)
            {
                _voterService.CreateVoter(indexViewModel.NewVoterName!);
            }
            else if (createCandidate && !createVoter && !voting)
            {
                _candidateService.CreateCandidate(indexViewModel.NewCandidateName!);
            }
            else if (voting && !createVoter && !createCandidate)
            {
                _voterService.AddVoteToVoter((Guid)indexViewModel.SelectedVoter!, (Guid)indexViewModel.SelectedCandidate!);
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static List<Candidate> CalculateVotes(List<Candidate> candidates)
        {
            foreach (var candidate in candidates.Where(candidate => candidate.Voters != null))
            {                    
                candidate.Votes = candidate.Voters!.Count;
            }

            return candidates;
        }
    }
}