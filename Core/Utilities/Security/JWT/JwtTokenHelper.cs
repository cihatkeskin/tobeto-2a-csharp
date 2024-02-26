using Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Utilities.Security.JWT;

public class JwtTokenHelper : ITokenHelper
{
    private IConfiguration _configuration;
    private TokenOptions _tokenOptions;
    public JwtTokenHelper(IConfiguration configuration)
    {
        _configuration = configuration;
        _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
    }

    public AccessToken CreateToken(User user, IList<Role> roles)
    {
        //TODO: Refactor
        DateTime expirationTime = DateTime.Now.AddMinutes(_tokenOptions.ExpirationTime);
        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Email, user.Email));
        roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role.RoleName)));

        var jwt = new JwtSecurityToken(
            issuer: _tokenOptions.Issuer,
            audience: _tokenOptions.Audience,
            expires: expirationTime,
            signingCredentials: signingCredentials,
            notBefore: DateTime.Now,
            claims: claims
            );

        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        string token = handler.WriteToken(jwt);

        return new AccessToken()
        {
            Token = token,
            ExpirationTime = expirationTime
        };
    }
}
