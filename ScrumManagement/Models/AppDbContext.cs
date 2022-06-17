using Microsoft.EntityFrameworkCore;
using ScrumManagement.Models;

namespace ScrumManagement.Models {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
        }

        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<TeamList> TeamLists { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Coach> Coaches { get; set; } = null!;
        public DbSet<Sprint> Sprints { get; set; } = null!;
        public DbSet<Story> Stories { get; set; } = null!;
        public DbSet<TeamMember> TeamMembers { get; set; } = null!;
        public DbSet<ScrumManagement.Models.Strength>? Strength { get; set; }
        public DbSet<ScrumManagement.Models.StrengthList>? StrengthList { get; set; }
    }
    

}
