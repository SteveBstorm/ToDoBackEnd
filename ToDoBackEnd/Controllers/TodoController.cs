using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoBackEnd.Models;
using ToDoBackEnd.Services;

namespace ToDoBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _service;

        public TodoController(TodoService service)
        {
            _service = service;
        }

        [HttpGet("liste")]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost("ajouter")]
        public IActionResult Post(Todo newTask)
        {
            List<Todo> todoList = _service.GetAll().ToList();
            foreach (Todo todo in todoList)
            {
                if(newTask.Name == todo.Name)
                {
                    return BadRequest("La tache existe déjà");
                }
            }

            _service.Create(newTask.Name);
            return Ok();
        }

        [HttpPatch("terminer/{name}")]
        public IActionResult Patch(string name)
        {
            _service.Finish(name);
            return Ok();
        }

        [HttpDelete("supprimer/{name}")]
        public IActionResult Delete(string name)
        {
            _service.Delete(name);
            return Ok();
        }
    }
}
