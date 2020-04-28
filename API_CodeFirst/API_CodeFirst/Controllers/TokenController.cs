using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessAccess.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ViewModel;

namespace API_CodeFirst.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly AuthOptionsViewModel _authOptions;
        public TokenController(IUserService service, IOptions<AuthOptionsViewModel> authOptionsAccessor)
        {
            _service = service;
            _authOptions = authOptionsAccessor.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] LoginViewModel User)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_service.IsValidUser(User))
            {
                return Unauthorized("User ID or password is wrong");
            }

            var authClaims = new[]
           {
                    new Claim(JwtRegisteredClaimNames.Sub, User.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var token = new JwtSecurityToken(
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                expires: DateTime.Now.AddHours(_authOptions.ExpiresInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.SecureKey)),
                    SecurityAlgorithms.HmacSha256Signature)
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
    }
}