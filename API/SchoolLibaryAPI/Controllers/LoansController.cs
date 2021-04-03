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
    public class LoansController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;
        public LoansController(IMapper mapper, ILoanRepository loanRepository)
        {
            _mapper = mapper;
            _loanRepository = loanRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var items = _loanRepository.GetAll();
            var dto = _mapper.Map<IEnumerable<LoanDto>>(items);
            return Ok(dto.ToArray());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var getLoan = await _loanRepository.GetById(id);
            if (getLoan == null)
                return NotFound();

            return Ok(_mapper.Map<LoanDto>(getLoan));
        }

        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LoanDto loan)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            Loans newLoan;
            try
            {
                newLoan = _mapper.Map<Loans>(loan);
                await _loanRepository.AddLoan(newLoan);
            } catch(Exception)
            {
                return BadRequest();
            }
            return Created(new Uri("/api/Loans", UriKind.Relative), newLoan);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] LoanDto loan)
        {
            var getLoan = await _loanRepository.GetById(id);
            if(!ModelState.IsValid)
            {
                return BadRequest("Not a valid model.");
            }
            try
            {
                _mapper.Map(loan, getLoan);
                await _loanRepository.SaveChanges();
                return NoContent();
            } catch(Exception)
            {
                return NotFound("Model not found");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _loanRepository.RemoveLoan(id);
                return NoContent();
            } catch(Exception)
            {
                return NotFound("There is no such a model.");
            }
        }
    }
}
