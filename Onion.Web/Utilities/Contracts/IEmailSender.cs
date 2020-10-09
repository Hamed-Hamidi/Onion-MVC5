namespace Onion.Web.Utilities.Contracts
{
    public interface IEmailSender
    {
        void Send(string to, string subject, string body);
    }
}