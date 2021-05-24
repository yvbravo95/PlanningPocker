using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PlanningPocker.Models.Response;
using PlanningPocker.Persistance.Context;
using PlanningPocker.Services.IUserServices;
using PlanningPocker.Services.IUserServices.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PlanningPocker.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<AccessToken>> Register(CreateUserModel request)
        {
            try
            {
                var result = await _userService.Register(request);
                if (result.IsFailure)
                    return BadRequest(result.Error);

                var secretKey = _configuration.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);

                // Creamos los claims (pertenencias, caracter�sticas) del usuario
                ClaimsIdentity identity = new ClaimsIdentity();
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Username));
                identity.AddClaim(new Claim(ClaimTypes.Name, request.Username));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = identity,
                    // Nuestro token va a durar un d�a
                    Expires = DateTime.UtcNow.AddDays(1),
                    // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new AccessToken
                {
                    Token = tokenHandler.WriteToken(createdToken),
                    ExpirationUtc = (DateTime)tokenDescriptor.Expires
                });
            }
            catch (Exception e)
            {
                Serilog.Log.Fatal(e, "Server Error");
                return BadRequest("User could not be registered");
            }
        }
    
        [HttpPost]
        public async Task<ActionResult<AccessToken>> Login(LoginUserModel request)
        {
            var result = await _userService.VerifyLogin(request);
            if (result.IsFailure)
                return BadRequest(result.Error);

            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            // Creamos los claims (pertenencias, caracter�sticas) del usuario
            ClaimsIdentity identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Username));
            identity.AddClaim(new Claim(ClaimTypes.Name, request.Username));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                // Nuestro token va a durar un d�a
                Expires = DateTime.UtcNow.AddDays(1),
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new AccessToken
            {
                Token = tokenHandler.WriteToken(createdToken),
                ExpirationUtc = (DateTime)tokenDescriptor.Expires
            });
        }
    }
}
