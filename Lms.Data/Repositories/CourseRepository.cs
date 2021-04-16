using Lms.Core.Entities;
using Lms.Core.Repositories;
using Lms.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Repositories
{
    class CourseRepository : ICourseRepository
    {
        private readonly LmsAPIContext db;
       


        public CourseRepository(LmsAPIContext db)
        {
            this.db = db;
        }
        public async Task AddAsync<T>(T added)
        {
            await db.AddAsync(added);
        } 
        public void Remove(Course removed)
        {
             db.Remove(removed);
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {

            return await db.Courses
                        .Include(l => l.Modules)
                        .ToListAsync();
        }

        public async Task<Course> GetCourseAsync(int? id)
        {
            var query =  db.Courses.AsQueryable();
            return await query.Include(c => c.Modules).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> SaveAsync()
        {
            return (await db.SaveChangesAsync()) >= 0;
        }

       
    }
}
