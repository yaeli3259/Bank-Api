using AutoMapper;
using bank_api_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Solid.Core.DTOs;
using Solid.Core.Models;
using Solid.Core.Services;
using Solid.Service;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bank_api_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficialBankController : ControllerBase
    {

        private readonly IOfficalBankService _officialBankService;
        private readonly IMapper _mapper;

        public OfficialBankController(IOfficalBankService officialBankService, IMapper mapper)
        {
            _officialBankService = officialBankService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var officialBank = await _officialBankService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<OfficialBankDto>>(officialBank));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var officialBank = await _officialBankService.GetByIdAsync(id);
            return Ok(_mapper.Map<OfficialBankDto>(officialBank));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OfficialBankPostModel value)
        {
            var newOfficialBank = await _officialBankService.AddAsync(_mapper.Map<OfficialBank>(value));
            return Ok(_mapper.Map<OfficialBankDto>(newOfficialBank));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] OfficialBankPostModel value)
        {
            var officialBank = await _officialBankService.GetByIdAsync(id);
            if (officialBank is null)
            {
                return NotFound();
            }
            _mapper.Map(value, officialBank);
            await _officialBankService.UpdateAsync(officialBank);
            officialBank = await _officialBankService.GetByIdAsync(id);
            return Ok(_mapper.Map<OfficialBankDto>(officialBank));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _officialBankService.RemoveAsync(id);
            return NoContent();
        }

    }
}
