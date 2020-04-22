using AllCoreInOne.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AllCoreInOne.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new List<Department>()
                {
                    new Department{Id = Guid.Parse("664E2304-A162-4C61-831E-0775BCB4C593"),Name="Computer Science"},
                    new Department{Id = Guid.Parse("664E2304-A162-4C61-831E-0775BCB4C594"),Name="Business Administration"},
                    new Department{Id = Guid.Parse("664E2304-A162-4C61-831E-0775BCB4C595"),Name="Physics"}
                }
                );
        }
    }
}
