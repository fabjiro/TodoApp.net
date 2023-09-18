using Microsoft.AspNetCore.Mvc;
using prj.Application;

namespace prj.API.Controller
{

    [ApiController]
    [Route("task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public ActionResult<IList<Domain.Task>> Get()
        {
            return Ok(taskService.GetTasks());
        }

        [HttpPost]
        public ActionResult<int> Create(CreateTaskRequest data)
        {
            var resultCreate = taskService.CreateTask(data);

            if (resultCreate == null)
            {
                return Problem("Error creating task", "/task/Create", 500);
            }
            return Ok(resultCreate);
        }

        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int Id)
        {
            var deleteResult = taskService.Delete(Id);

            if (deleteResult == null)
            {
                return Problem($"task {Id} not found", "/task/delete", 500);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Domain.Task> Update(int id, [FromBody] CreateTaskRequest task)
        {

            var taskUpdated = taskService.Update(id, task);

            if (taskUpdated == null)
            {
                return Problem($"task {id} not found", "/task/update", 500);
            }
            return Ok(taskUpdated);
        }
    }
}
