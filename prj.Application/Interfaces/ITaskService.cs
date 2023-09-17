namespace prj.Application
{
    public interface ITaskService
    {
        List<Domain.Task> GetTasks();

        Domain.Task CreateTask(CreateTaskRequest task);

        Domain.Task? FindOne(int Id);
    }
}