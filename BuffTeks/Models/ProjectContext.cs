using Microsoft.EntityFrameworkCore;

namespace BuffTeks.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<BuffTeks.Models.Project> Project { get; set; }
    }
}