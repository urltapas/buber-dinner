namespace BuberDinner.Infra.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";

    public string SecrectKey { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public int ExpiryMinutes { get; set; }
}
