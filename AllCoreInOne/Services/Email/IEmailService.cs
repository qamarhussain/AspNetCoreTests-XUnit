using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace AllCoreInOne.Services.Email
{
    public interface IEmailService
    {
        Task SendAsync(string EmailDisplayName, string Subject, string Body, string From, string To);
    }
}
