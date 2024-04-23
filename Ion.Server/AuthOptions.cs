using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Ion.Server;

public class AuthOptions
{
    public const string Issuer = "IonServer";
    public const string Audience = "IonClient";
    const string Key = "AxG+X#SsD5&aY)Y";
    public const int Lifetime = 1;
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}
