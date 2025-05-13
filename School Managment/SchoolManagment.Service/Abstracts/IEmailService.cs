namespace SchoolManagment.Service.Abstracts
{
    public interface IEmailService
    {
        public Task<string> SendEmailAsync(string email, string msg);
    }
}
