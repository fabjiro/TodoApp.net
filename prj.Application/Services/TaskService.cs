using prj.Application;

namespace prj.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public Domain.Task? FindOne(int Id)
        {
            return taskRepository.FindOne(Id);
        }

        Domain.Task ITaskService.CreateTask(CreateTaskRequest task)
        {
            var newTask = new Domain.Task
            {
                Title = task.Title,
                Description = task.Description,
            };
            taskRepository.CreateTask(newTask);
            return FindOne(newTask.Id)!;
        }

        List<Domain.Task> ITaskService.GetTasks()
        {
            return taskRepository.GetTasks();
        }
    }
}