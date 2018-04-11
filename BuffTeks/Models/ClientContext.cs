using Microsoft.EntityFrameworkCore;

namespace BuffTeks.Models
{
    public class ClientContext : DbContext
    {
        public ClientContext (DbContextOptions<ClientContext> options)
            : base(options)
        {
        }

        public DbSet<BuffTeks.Models.Client> Client { get; set; }
    }
}