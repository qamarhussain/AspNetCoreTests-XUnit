using AllCoreInOne.ViewModels.Employee;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AllCoreInOne.Services.Employee
{
    public interface IEmployeeService
    {
        Task<EmployeeViewModel> CreateEmployee(EmployeeViewModel model, CancellationToken ct = default);
        Task<EmployeeViewModel> UpdateEmployee(Guid employeeId, EmployeeViewModel model, CancellationToken ct = default);
    }
}
