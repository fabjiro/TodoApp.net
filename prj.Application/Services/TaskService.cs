using System.Runtime.CompilerServices;
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

        public int? Delete(int Id)
        {
            return taskRepository.Delete(Id);
        }

        public Domain.Task? FindOne(int Id)
        {
            return taskRepository.FindOne(Id);
        }

        public Domain.Task? Update(int id, CreateTaskRequest taskData)
        {
            var task = new Domain.Task {
                Id = id,
                Description = taskData.Description,
                Title =taskData.Title
            };

            return taskRepository.Update(task);
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