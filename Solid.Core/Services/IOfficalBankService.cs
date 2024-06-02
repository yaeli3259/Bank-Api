using Solid.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Services
{
    public interface IOfficalBankService
    {
        Task<List<OfficialBank>> GetAllAsync();
        Task<OfficialBank> GetByIdAsync(int id);    
        Task<OfficialBank> AddAsync(OfficialBank officialBank);
        Task<OfficialBank> UpdateAsync(OfficialBank officialBank);
        Task RemoveAsync(int id);
    }
}
