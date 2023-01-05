using System.ComponentModel.DataAnnotations;

namespace VotingApp.Models
{
    public class Candidate
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Candidate Name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Number of Votes for Candidate.
        /// </summary>
        public int Votes { get; set; }

        /// <summary>
        /// Relationship between Candidate and its Voters.
        /// </summary>
        public virtual ICollection<Voter>? Voters { get; set; }
    }
}
