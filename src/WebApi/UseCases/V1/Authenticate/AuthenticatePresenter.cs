namespace WebApi.UseCases.V1.Authenticate
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using Application.Boundaries.Authenticate;

    public sealed class AuthenticatePresenter: IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }

        public void Standard(AuthenticateOutput output)
        {
            string secret = output.JWTSecret;
            string customerId = output.CustomerId.ToString();

            // generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, customerId) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            var authenticateResponse = new AuthenticateResponse(
                output.CustomerId,
                output.SSN.ToString(),
                output.Username.ToString(),
                output.Name.ToString(),
                token
            );

            ViewModel = new OkObjectResult(authenticateResponse);
        }
    }
}
