using Api.Taskfy.Models;
using Api.Taskfy.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Taskfy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;
        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Listar todas as tarefas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ListAllTask()
        {
            var tasks = await _taskService.ListTasks();
            return Ok(tasks);
        }

        /// <summary>
        /// Listrar tarefa por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Id")]
        public async Task<IActionResult> GetTaskId(long id)
        {
            var task = await _taskService.FindTask(id);
            return Ok(task);
        }

        /// <summary>
        /// Criar uma nova tarefa
        /// </summary>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskModel taskModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (string.IsNullOrWhiteSpace(taskModel.Title))
                    return BadRequest("Título é obrigatório.");

                var task = await _taskService.CreateTaskAsync(taskModel);
                return Created("", task);


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar a tarefa: {ex.Message}");
            }
        }

        /// <summary>
        /// Alterar uma tarefa
        /// </summary>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> AlterTask([FromBody] TaskModel taskModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var task = await _taskService.AlterTask(taskModel);

                if (task == null)
                    return NotFound();

                return NoContent();


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar a tarefa: {ex.Message}");
            }
        }

        /// <summary>
        /// Alterar o status da tarefa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isCompleted"></param>
        /// <returns></returns>
        [HttpPut("AlterStatus")]
        public async Task<IActionResult> AlterStatusTask(long id, bool isCompleted)
        {
            try
            {
                var task = await _taskService.FindTask(id);

                if (task == null)
                    return NotFound();

                task = await _taskService.AlterStatusTask(task, isCompleted);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao alterar o status da tarefa: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletar uma tarefa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteTask(long id)
        {
            try
            {
                var task = await _taskService.FindTask(id);

                if (task == null)
                    return NotFound();

                task = await _taskService.DeleteTask(task);

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar tarefa: {ex.Message}");
            }
        }
    }
}
