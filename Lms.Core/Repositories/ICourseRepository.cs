using Lms.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseAsync(int? id);
        void Remove(Course removed);
        Task<bool> SaveAsync();
        Task AddAsync<T>(T added);
    }
}
