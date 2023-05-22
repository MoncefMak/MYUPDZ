namespace MYUPDZ.Infrastructure.Common.Option;

public class JwtSettings
{
    public string SigningKey { get; set; }
    public string Issuer { get; set; }
    public string[] Audiences { get; set; }
    public int ExpirationMinutes { get; set; }
}
