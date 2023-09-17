namespace prj.Application
{
    public interface ITaskRepository
    {
        List<Domain.Task> GetTasks();
        int CreateTask(Domain.Task task);

        Domain.Task? FindOne(int id);
    }
}