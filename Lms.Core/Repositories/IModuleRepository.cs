using Lms.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Repositories
{
    public interface IModuleRepository
    {

        Task<IEnumerable<Module>> GetAllModulesAsync(int id);
        Task<Module> GetModuleAsync(int id, int moduleId);
        Task<bool> SaveAsync();
        Task AddAsync<T>(T added);
        void Remove(Module removed);
    }
}
