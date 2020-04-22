using AllCoreInOne.Data;
using AllCoreInOne.Services.CurrentUser;
using AllCoreInOne.ViewModels.Employee;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AllCoreInOne.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private ApplicationDbContext DbContext { get; }
        private IMapper Mapper { get; }
        private ICurrentUser CurrentUser { get; }
        public EmployeeService(ApplicationDbContext dbContext, IMapper mapper, ICurrentUser currentUser)
        {
            DbContext = dbContext;
            Mapper = mapper;
            CurrentUser = currentUser;
        }
        public async Task<EmployeeViewModel> CreateEmployee(EmployeeViewModel model, CancellationToken ct = default)
        {
            var employeeToAdd = new Models.Employee
            {
                FirstName=model.FirstName,
                LastName=model.LastName,
                DepartmentId=model.DepartmentId,
                CreatedBy=CurrentUser.Id
            };
            DbContext.Add(employeeToAdd);
            await DbContext.SaveChangesAsync(ct);
            var viewModel = Mapper.Map<EmployeeViewModel>(employeeToAdd);
            return viewModel;
        }

        public async Task<EmployeeViewModel> UpdateEmployee(Guid employeeId, EmployeeViewModel model, CancellationToken ct = default)
        {
            var employeeEntity = await DbContext.Employees.AsNoTracking().SingleOrDefaultAsync(x => x.Id == employeeId);
            employeeEntity.FirstName = model.FirstName;
            employeeEntity.LastName = model.LastName;
            employeeEntity.DepartmentId = model.DepartmentId;
            DbContext.Update(employeeEntity);
            await DbContext.SaveChangesAsync(ct);
            return Mapper.Map<EmployeeViewModel>(employeeEntity);
        }
    }
}
