using CEM.DAL.Entities;
using CEM.Web.API.Models;
using CEM.Web.API.Models.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CEM.Web.API.Controllers
{
    /// <summary>
    /// Manages accounts
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IJwtConfiguration jwtConfiguration;

        /// <summary>
        /// Dependencies required to manage accounts
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="jwtConfiguration"></param>
        public AccountController(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager
            , IJwtConfiguration jwtConfiguration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtConfiguration = jwtConfiguration;
        }

        /// <summary>
        /// Login user or employee
        /// </summary>
        /// <param name="model"></param>
        /// <returns>JWT Token</returns>
        [HttpPost("login", Order = 1)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.Username).ConfigureAwait(false);
                if (user != null && await userManager.CheckPasswordAsync(user, model.Password).ConfigureAwait(false))
                {
                    var userRoles = await userManager.GetRolesAsync(user).ConfigureAwait(false);

                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim("FirstName", user.FirstName),
                        new Claim("LastName", user.LastName),
                        new Claim("Email", user.Email)
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Secret));

                    var token = new JwtSecurityToken(
                        issuer: jwtConfiguration.Issuer,
                        audience: jwtConfiguration.Audience,
                        expires: DateTime.UtcNow.AddHours(5),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                    //set value indicating whether session is persisted and the time at which the authentication was issued
                    var authenticationProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RemeberMe,
                        IssuedUtc = DateTime.UtcNow,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(15) //expire time
                    };

                    await signInManager.SignInAsync(user, authenticationProperties)
                        .ConfigureAwait(false);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        userName = user.UserName,
                        name = user.FirstName,
                        lastName = user.LastName,
                        roles = string.Join(',', userRoles),
                        userId = user.Id
                    });
                }
                else
                    return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
