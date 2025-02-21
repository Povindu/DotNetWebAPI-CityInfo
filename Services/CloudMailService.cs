namespace CityInfo.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailto = string.Empty;
        private string _mailFrom = string.Empty;



        //get mailTo and mailFrom addresses from appsettings.json 
        public CloudMailService(IConfiguration configuration)
        {
            _mailto = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailFrom} to {_mailto} , with {nameof(CloudMailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
