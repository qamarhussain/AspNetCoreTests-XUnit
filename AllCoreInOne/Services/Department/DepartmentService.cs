using AllCoreInOne.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllCoreInOne.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private ApplicationDbContext ApplicationDbContext { get; }
        public DepartmentService(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }
        public async Task<Models.Department> GetAllDepartmentById(Guid id)
        {
            var department = await ApplicationDbContext.Departments.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return department;
        }

        public async Task<List<Models.Department>> GetAllDepartments()
        {
            var department = await ApplicationDbContext.Departments.AsNoTracking().ToListAsync();
            return department;
        }
    }
}
