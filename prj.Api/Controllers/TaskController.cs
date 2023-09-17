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

        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int Id)
        {
            return Ok(taskService.Delete(Id));
        }

        [HttpPut("{id}")]
        public ActionResult<Domain.Task> Update(int id, [FromBody] CreateTaskRequest task) {
            
            return Ok(taskService.Update(id, task));
        }
    }
}
