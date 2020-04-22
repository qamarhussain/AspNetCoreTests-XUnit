using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllCoreInOne.Services.Department
{
    public interface IDepartmentService
    {
        Task<List<Models.Department>> GetAllDepartments();
        Task<Models.Department> GetAllDepartmentById(Guid id);

    }
}
