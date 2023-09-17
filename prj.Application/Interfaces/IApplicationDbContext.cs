using Microsoft.EntityFrameworkCore;

namespace prj.Application;

public interface IApplicationDbContext {
    DbSet<Domain.Task> Tasks {get; set;}

    int SaveChanges();
}