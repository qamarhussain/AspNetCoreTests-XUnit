using AllCoreInOne.Services.Department;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AllCoreInOne.Tests.ServiceTests
{
    public class DepartmentServiceTests: BaseTest
    {
        [Fact]
        public async Task GetAllDepartments_should_return_list_of_departments()
        {
            var dbContext = GetDbContext();
            dbContext.Departments.Add(new Models.Department { Id = Guid.NewGuid(), Name = "Information Technology" });
            dbContext.Departments.Add(new Models.Department { Id = Guid.NewGuid(), Name = "Business Administration" });
            dbContext.Departments.Add(new Models.Department { Id = Guid.NewGuid(), Name = "Physics" });
            await dbContext.SaveChangesAsync();

            var service = new DepartmentService(dbContext);
            var result = await service.GetAllDepartments();

            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }

        [Theory,AutoData]
        public async Task GetAllDepartmentById_given_departmentId_not_exist_return_true(Guid departmentId)
        {
            var dbContext = GetDbContext();

            var service = new DepartmentService(dbContext);
            var result = await service.GetAllDepartmentById(departmentId);

            Assert.Null(result);
        }

        [Theory, AutoData]
        public async Task GetAllDepartmentById_given_departmentId_exist_return_true(Guid departmentId)
        {
            var id = 1;
            var dbContext = GetDbContext();
            dbContext.Departments.Add(new Models.Department { Id = departmentId, Name = "Information Technology" });
            await dbContext.SaveChangesAsync();

            var service = new DepartmentService(dbContext);
            var result = await service.GetAllDepartmentById(departmentId);

            Assert.NotNull(result);
            Assert.Equal(departmentId, result.Id);
        }
    }
}
