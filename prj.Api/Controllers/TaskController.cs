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
            var result = taskService.CreateTask(data);
            return Ok(result);
        }
    }
}
