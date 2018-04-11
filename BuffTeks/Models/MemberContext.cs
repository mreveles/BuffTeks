using Microsoft.EntityFrameworkCore;

namespace BuffTeks.Models
{
    public class MembersContext : DbContext
    {
        public MembersContext (DbContextOptions<MembersContext> options)
            : base(options)
        {
        }

        public DbSet<BuffTeks.Models.Members> Members { get; set; }
    }
}