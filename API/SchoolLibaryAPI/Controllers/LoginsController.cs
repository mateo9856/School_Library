using Microsoft.AspNetCore.Mvc;
using SchoolLibaryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace SchoolLibaryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase//kontynuować prace tego kontrolera
    {
        private readonly ILoginRepository _loginRepository;
        public LoginsController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _loginRepository.GetLogins();
            return Ok(items.ToArray());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var getItem = _loginRepository.GetLogin(id);
            return Ok(getItem);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Logins login)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Not a valid model...");
            }
            try
            {
                if(login == null)
                {
                    return BadRequest();
                }
                await _loginRepository.AddLogin(login);
            }
            catch(Exception)
            {
                return BadRequest("Not a valid model.");
            }
            return Created(new Uri("/api/Libary", UriKind.Relative), login);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _loginRepository.RemoveLogin(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound("There is no such a model.");
            }
        }
    }
}
