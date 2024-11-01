﻿using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Application.Interfaces;

namespace Infrastructure.Services
{
    public class AuthenticationService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthenticacionServiceOptions _options;

        public AuthenticationService(IUserRepository userRepository, IOptions<AuthenticacionServiceOptions> options)
        {
            _userRepository = userRepository;
            _options = options.Value;
        }

        private User? ValidateUser(LoginRequest rq)
        {
            if (string.IsNullOrEmpty(rq.Email) || string.IsNullOrEmpty(rq.Password))
                return null;

            var user = _userRepository.GetUser(rq.Email, rq.Password);

            return user;

        }

        public string? Login(LoginRequest rq)
        {
            var user = ValidateUser(rq);

            if (user == null)
            {
                return null;
            }


            //Crear el token
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey)); 

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new("sub", user.Id.ToString()),
                new ("role", "Cliente")
            };

            var jwtSecurityToken = new JwtSecurityToken( 
              _options.Issuer,
              _options.Audience,
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return tokenToReturn.ToString();
        }
        public class AuthenticacionServiceOptions
        {
            public const string AuthenticacionService = "AuthenticacionService";

            public string Issuer { get; set; }
            public string Audience { get; set; }
            public string SecretForKey { get; set; }
        }
    }
}