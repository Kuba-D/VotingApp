using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// Relationship between Candidate and its Voters.
        /// </summary>
        public virtual ICollection<Voter>? Voters { get; set; }

        /// <summary>
        /// Number of Votes for Candidate.
        /// </summary>
        [NotMapped]
        public int Votes
        { 
            get
            {
                if(Voters != null)
                {
                    return Voters.Count;
                }
                else
                {
                    return 0;
                }

            }
        }
    }
}
