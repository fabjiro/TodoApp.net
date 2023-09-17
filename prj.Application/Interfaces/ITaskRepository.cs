namespace prj.Application
{
    public interface ITaskRepository
    {
        List<Domain.Task> GetTasks();
        int CreateTask(Domain.Task task);

        Domain.Task? FindOne(int id);

        Domain.Task? Update(Domain.Task task);

        int? Delete(int Id);

    }
}