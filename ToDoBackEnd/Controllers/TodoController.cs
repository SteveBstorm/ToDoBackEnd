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
        public IActionResult Post(Todo task)
        {
            _service.Create(task.Name);
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
