using Microsoft.EntityFrameworkCore;
using Solid.Core.Models;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Solid.Data.Repositories
{
    public class OfficialBankRepository:IOfficalBankRepository
    {
        private readonly DataContext _dataOfficalBank;

        public OfficialBankRepository(DataContext OfficialBank)
        {
            _dataOfficalBank = OfficialBank;
        }

        public async Task<List<OfficialBank>> GetAllAsync()
        {
            return await _dataOfficalBank.OfficialBanks.ToListAsync();
        }
        public async Task<OfficialBank> GetByIdAsync(int id)
        {
            return await _dataOfficalBank.OfficialBanks.FirstAsync(x => x.Id == id);
        }
        public async Task<OfficialBank> AddAsync(OfficialBank officialBank)
        {
            _dataOfficalBank.OfficialBanks.Add(officialBank);
            await _dataOfficalBank.SaveChangesAsync();
            return officialBank;
        }

        public async Task<OfficialBank> UpdateAsync(OfficialBank officialBank)
        {
           OfficialBank existOfficialBank = await GetByIdAsync(officialBank.Id);
           _dataOfficalBank.Entry(existOfficialBank).CurrentValues.SetValues(officialBank);
           await  _dataOfficalBank.SaveChangesAsync();
           return existOfficialBank;
        }

        public async Task RemoveAsync(int id)
        {
            OfficialBank temp = await GetByIdAsync(id);
            if (temp != null)
            {
                _dataOfficalBank.OfficialBanks.Remove(temp);
                await _dataOfficalBank.SaveChangesAsync();
            }
        }
    }
}
