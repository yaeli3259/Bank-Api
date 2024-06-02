using Solid.Core.Models;
using Solid.Core.Repositories;
using Solid.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service
{
    public class OfficialBankService:IOfficalBankService
    {
        private readonly IOfficalBankRepository _officialBankRepository;

        public OfficialBankService(IOfficalBankRepository officialBankRepository)
        {
            _officialBankRepository = officialBankRepository;
        }

        public async Task<List<OfficialBank>> GetAllAsync()
        {
            return await  _officialBankRepository.GetAllAsync();
        }

        public async Task<OfficialBank> AddAsync(OfficialBank officialBank)
        {
            return await _officialBankRepository.AddAsync(officialBank);
        }
        public async Task RemoveAsync(int id)
        {
           await  _officialBankRepository.RemoveAsync(id);
        }

        public async Task<OfficialBank> UpdateAsync(OfficialBank officialBank)
        {
            return await _officialBankRepository.UpdateAsync(officialBank);
        }
        public async Task<OfficialBank> GetByIdAsync(int id)
        {
            return await _officialBankRepository.GetByIdAsync(id);
        }
    }
}
