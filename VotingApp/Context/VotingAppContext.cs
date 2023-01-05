using Microsoft.EntityFrameworkCore;
using VotingApp.Models;

namespace VotingApp.Context
{
    public class VotingAppContext : DbContext
    {
        /// <summary>
        /// DbSet for <see cref="Voter"/>
        /// </summary>
        public DbSet<Voter> Voters { get; set; } = null!;

        /// <summary>
        /// DbSet for <see cref="Candidate"/>
        /// </summary>
        public DbSet<Candidate> Candidates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=.\VotingAppDb.db");
        }
    }
}
