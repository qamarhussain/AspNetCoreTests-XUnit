using AllCoreInOne.Services.AuthorizationPolicy;
using AllCoreInOne.Services.CurrentUser;
using AutoFixture.Xunit2;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AllCoreInOne.Tests.ServiceTests
{
    public class AuthorizationPolicyServiceTests : BaseTest
    {
        [Theory, AutoData]
        public async Task GrantsEmployeeAccess_Given_CurrentUser_access_return_false(Guid currentUserId, Guid employeeId)
        {
            var currentUserMock = new Mock<ICurrentUser>();
            currentUserMock
                .SetupGet(x => x.Id)
                .Returns(currentUserId);

            var dbContext = GetDbContext();
            dbContext.Employees.Add(new Models.Employee { Id = employeeId, FirstName = "Qamar", LastName = "Hussain", DepartmentId = Guid.NewGuid(), CreatedBy = Guid.NewGuid() });
            await dbContext.SaveChangesAsync();

            var service = new AuthorizationPolicyService(currentUserMock.Object, dbContext);
            var result = await service.GrantsEmployeeAccess(employeeId);
            Assert.False(result);
        }

        [Theory, AutoData]
        public async Task GrantsEmployeeAccess_Given_CurrentUser_access_return_true(Guid currentUserId, Guid employeeId)
        {
            var currentUserMock = new Mock<ICurrentUser>();
            currentUserMock
                .SetupGet(x => x.Id)
                .Returns(currentUserId);

            var dbContext = GetDbContext();
            dbContext.Employees.Add(new Models.Employee { Id = employeeId, FirstName = "Qamar", LastName = "Hussain", DepartmentId = Guid.NewGuid(), CreatedBy = currentUserId });
            await dbContext.SaveChangesAsync();

            var service = new AuthorizationPolicyService(currentUserMock.Object, dbContext);
            var result = await service.GrantsEmployeeAccess(employeeId);
            Assert.True(result);
        }
    }
}
