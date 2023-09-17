using prj.Application;
using prj.Domain;

namespace prj.Infrastructure
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IApplicationDbContext _context;
        public TaskRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Domain.Task? FindOne(int id)
        {
            return _context.Tasks.SingleOrDefault(task => task.Id == id);
        }

        public List<Domain.Task> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        int ITaskRepository.CreateTask(Domain.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task.Id;
        }


    }
}