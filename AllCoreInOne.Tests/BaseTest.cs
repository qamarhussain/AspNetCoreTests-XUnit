using System;
using AllCoreInOne.Data;
using Microsoft.EntityFrameworkCore;

namespace AllCoreInOne.Tests
{
    public abstract class BaseTest
    {
        protected ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                  .Options;
            return new ApplicationDbContext(options);
        }

    }
}
