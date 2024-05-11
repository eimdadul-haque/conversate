using Conversate.Domain.ApplicationUsers;
using Conversate.Domain.Messages;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Conversate.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<Message> Messages { get; set; }
    }
}
