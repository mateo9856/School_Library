using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SchoolLibaryAPI.Models;
using SchoolLibaryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibaryAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class LibaryController : ControllerBase
    {
        private readonly ILibaryRepository _libaryRepository;
        private readonly IMapper _mapper;
        public LibaryController(IMapper mapper ,ILibaryRepository libaryRepository, ILoanRepository loanRepository)
        {
            _mapper = mapper;
            _libaryRepository = libaryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _libaryRepository.GetAll();
            var dto = _mapper.Map<IEnumerable<LibraryDto>>(items);
            return Ok(dto.ToArray());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var getId = await _libaryRepository.GetBook(id);
            if(getId == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<LibraryDto>(getId);
            return Ok(dto);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LibraryDto libary)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Not a valid model.");
            }
            Library book;
            try
            {
                if (libary == null)
                {
                    return BadRequest();
                }
                book = _mapper.Map<Library>(libary);
                await _libaryRepository.AddBook(book);

            } catch (Exception)
            {
                return BadRequest("Not a valid model.");
            }

            return Created(new Uri("/api/Libary", UriKind.Relative), book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]LibraryDto book)
        {
            var getBook = await _libaryRepository.GetBook(id);
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model.");
            }
            try
            {
                _mapper.Map(book, getBook);
                await _libaryRepository.SaveChanges();
                return Ok(_mapper.Map<LibraryDto>(getBook));
            } catch (Exception)
            {
                return NotFound("There is no a such this model.");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var getBook = await _libaryRepository.GetBook(id);
                await _libaryRepository.RemoveBook(getBook);
                return NoContent();
            } catch (Exception)
            {
                return NotFound("There is no a such this model.");
            }

        }
    }
}
