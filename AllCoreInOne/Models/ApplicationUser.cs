using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AllCoreInOne.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                var fullName = string.IsNullOrWhiteSpace(FirstName) ? string.Empty : FirstName;
                if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName))
                {
                    fullName += " ";
                }

                if (!string.IsNullOrWhiteSpace(LastName))
                {
                    fullName += LastName;
                }

                return fullName;
            }
        }
    }
}
