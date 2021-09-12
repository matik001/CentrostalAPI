using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CentrostalAPI.Helpers {
    public static class JwtHelper {
        public static void loadConfig(IConfiguration config) {
            var jwtSection = config.GetSection("JWT");
            issuer = jwtSection.GetValue<string>("issuer");
            audience = jwtSection.GetValue<string>("audience");
            lifetime = jwtSection.GetValue<int>("lifetime");
            secret = jwtSection.GetValue<string>("key");
        }

        public static string secret { get; private set; }

        public static int lifetime { get; private set; }

        public static string audience { get; private set; }

        public static string issuer { get; private set; }

        public static DateTime getNewExpirationTime() {
            return DateTime.UtcNow.AddMinutes(lifetime);
        }
        public static string generateToken(User user) {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secret);

            var claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                new Claim("isAdmin", user.isAdmin.ToString()),
            });
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = claimsIdentity,
                Issuer = issuer,
                Audience = audience,
                Expires = getNewExpirationTime(),
                SigningCredentials = signingCredentials,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
