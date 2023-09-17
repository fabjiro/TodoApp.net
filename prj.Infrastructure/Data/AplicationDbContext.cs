using Microsoft.EntityFrameworkCore;
using prj.Application;

namespace prj.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        DbSet<Domain.Task> IApplicationDbContext.Tasks { get; set; }

        int IApplicationDbContext.SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}