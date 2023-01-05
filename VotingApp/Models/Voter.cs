using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VotingApp.Models
{
    public class Voter
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Voter Name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the Voted Candidate.
        /// </summary>
        public Guid? VotedCandidateId { get; set; }

        /// <summary>
        /// Relationship between Voter and Candidate
        /// </summary>
        public virtual Candidate VotedCandidate { get; set; } = default!;
    }
}
