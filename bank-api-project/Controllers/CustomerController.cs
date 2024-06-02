using AutoMapper;
using bank_api_project.Models;
using Microsoft.AspNetCore.Mvc;
using Solid.Core.DTOs;
using Solid.Core.Models;
using Solid.Core.Services;
using Solid.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bank_api_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var customer = await _customerService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customer));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CostumerPostModel value)
        {
            var newCustomer = await _customerService.AddAsync(_mapper.Map<Customer>(value));
            return Ok(_mapper.Map<CustomerDto>(newCustomer));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CostumerPostModel value)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            _mapper.Map(value, customer);
            await _customerService.UpdateAsync(customer);
            customer = await    _customerService.GetByIdAsync(id);
            return Ok(_mapper.Map<CustomerDto>(customer));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _customerService.RemoveAsync(id);
            return NoContent();
        }
    }
}
