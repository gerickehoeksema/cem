namespace CEM.Web.API.Models.Configuration
{
    public interface IJwtConfiguration
    {
        string Secret { get; set; }
        string Issuer { get; set; }
        string Audience { get; set; }
        string Subject { get; set; }
    }
}
