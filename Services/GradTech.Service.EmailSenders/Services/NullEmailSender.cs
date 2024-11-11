
using Microsoft.AspNetCore.Identity.UI.Services;

namespace GradTech.Service.EmailSenders.Services;

public class NullEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        return Task.CompletedTask;
    }
}