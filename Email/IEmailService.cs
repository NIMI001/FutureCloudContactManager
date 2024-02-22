using Microsoft.AspNetCore.Identity;

namespace FutureCloudContactManager.Email
{
    public interface IEmailService
    {
        Task<IdentityResult> SendEmail(string receiverEmail, string subject, string body);
    }
}
