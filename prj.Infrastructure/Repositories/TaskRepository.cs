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

        public int? Delete(int Id)
        {
            var task = FindOne(Id);
            if (task == null)
            {
                return null;
            }
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return task.Id;
        }

        public Domain.Task? FindOne(int id)
        {
            return _context.Tasks.SingleOrDefault(task => task.Id == id);
        }

        public List<Domain.Task> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        public Domain.Task? Update(Domain.Task task)
        {
            var exisTask = FindOne(task.Id);

            if (exisTask == null) { return null; }

            exisTask.Title = task.Title;
            exisTask.Description = task.Description;
            _context.SaveChanges();

            return exisTask;
        }

        int ITaskRepository.CreateTask(Domain.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task.Id;
        }
    }
}