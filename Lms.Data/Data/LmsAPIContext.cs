using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lms.Core.Entities;

namespace Lms.Data.Data
{
    public class LmsAPIContext : DbContext
    {
        public LmsAPIContext (DbContextOptions<LmsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Lms.Core.Entities.Course> Courses { get; set; }


        public DbSet<Lms.Core.Entities.Module> Modules { get; set; }
    }
}
