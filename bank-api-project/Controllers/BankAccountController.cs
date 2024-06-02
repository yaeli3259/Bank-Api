using AutoMapper;
using bank_api_project.Models;
using Microsoft.AspNetCore.Mvc;
using Solid.Core.DTOs;
using Solid.Core.Models;
using Solid.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bank_api_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAcountService _bankAccountService;
        private readonly IMapper _mapper;

        public BankAccountController(IBankAcountService bankAccountsService,IMapper mapper)
        {
            _bankAccountService = bankAccountsService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var bankAccount = await _bankAccountService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<BankAccountDto>>(bankAccount));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var bankAccount = await _bankAccountService.GetByIdAsync(id);
            return Ok(_mapper.Map<BankAccountDto>(bankAccount));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BankAccountPostModel value)
        {
            var newBankAccount = await _bankAccountService.AddAsync(_mapper.Map<BankAccount>(value));
            return Ok(_mapper.Map<BankAccountDto>(newBankAccount));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BankAccountPostModel  value)
        {
            var bankAccount = await _bankAccountService.GetByIdAsync(id);
            if (bankAccount is null)
            {
                return NotFound();
            }
            _mapper.Map(value, bankAccount);
            await _bankAccountService.UpdateAsync(bankAccount);
            bankAccount = await _bankAccountService.GetByIdAsync(id);
            return Ok(_mapper.Map<BankAccountDto>(bankAccount));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bankAccountService.RemoveAsync(id);
            return NoContent();
        }

    }
}
