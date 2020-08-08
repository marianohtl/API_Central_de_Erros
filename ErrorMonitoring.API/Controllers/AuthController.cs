using ErrorMonitoring.API.DTOs;
using ErrorMonitoring.API.StartupConfig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ErrorMonitoring.API.Controllers
{
   
      
        [Route("api/v{version:apiVersion}/[controller]")]
        [ApiController]
        [Authorize]
        public class AuthController : ControllerBase
        {
            private readonly SignInManager<IdentityUser> _signInManager;
            private readonly UserManager<IdentityUser> _userManager;
            private readonly TokenSettings _appSettings;
            private readonly SigningConfigurations _signingConfigurations;

            public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<TokenSettings> appSettings, SigningConfigurations signingConfigurations)
            {
                _signInManager = signInManager;
                _userManager = userManager;
                _appSettings = appSettings.Value;
                _signingConfigurations = signingConfigurations;
            }

            [HttpGet]
            public async Task<ActionResult> Get()
            {
                return Ok("#ClearSale  <3");
            }

            [HttpPost("cadastrar")]
            [AllowAnonymous]
            public async Task<ActionResult> Cadastrar(RegisterUserDTO registerUser)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = new IdentityUser
                {
                    UserName = registerUser.Email,
                    Email = registerUser.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, registerUser.Password);

                if (result.Succeeded)
                {
                    return Ok(result.Succeeded);
                }

                return BadRequest(ErrorResponse.FromIdentity(result.Errors.ToList()));
            }

            [HttpPost("login")]
            [AllowAnonymous]
            public async Task<ActionResult> Login(LoginUserDTO loginUser)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

                if (result.Succeeded)
                {
                    return Ok(await GerarJwt(loginUser.Email));
                }
                if (result.IsLockedOut)
                {
                    return BadRequest(loginUser);
                }

                return NotFound(loginUser);
            }

            //[HttpPost("logout")]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> Logout()
            //{
            //    await _signInManager.SignOutAsync();
            //    return Ok();
            //}

            
            [HttpPost("forgotPassword")]
            [AllowAnonymous]
            public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPassword)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userManager.FindByEmailAsync(forgotPassword.Email);
                if (user == null)
                {
                    return NotFound($"Usuário '{forgotPassword}' não encontrado.");
                }
                else
                {
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPassword = new ResetPasswordDTO();
                    resetPassword.Code = code;
                    resetPassword.Email = user.Email;
                    resetPassword.UserId = user.Id;
                    return Ok(resetPassword);
                }
            }

 
            [HttpPost("resetPassword")]
            [AllowAnonymous]
            public async Task<IActionResult> ResetPasswordConfirm(ResetPasswordConfirmDTO resetPassword)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userManager.FindByEmailAsync(resetPassword.Email);
                if (user == null)
                {
                    return NotFound($"Usuário ID não encontrado.");
                }
                else
                {
                    return Ok(await _userManager.ResetPasswordAsync(user, resetPassword.Code, resetPassword.Password));
                }
            }

            private async Task<LoginResponseDTO> GerarJwt(string email)
            {
                
                var user = await _userManager.FindByEmailAsync(email);
                
                var claims = await _userManager.GetClaimsAsync(user);
                
                var userRoles = await _userManager.GetRolesAsync(user);

                claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
                claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName));

                foreach (var userRole in userRoles)
                {
                    claims.Add(new Claim("role", userRole));
                }

                var identityClaims = new ClaimsIdentity();
                identityClaims.AddClaims(claims);

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _appSettings.Emissor,
                    Audience = _appSettings.ValidoEm,
                    Subject = identityClaims,
                    NotBefore = DateTime.Now,
                    Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                    SigningCredentials = _signingConfigurations.SigningCredentials
                });

            
                var encodedToken = tokenHandler.WriteToken(token);


                var response = new LoginResponseDTO
                {
                    AccessToken = encodedToken,
                    ExpiresIn = TimeSpan.FromHours(2).TotalSeconds,
                    UserToken = new UserTokenDTO
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Claims = claims.Select(c => new ClaimDTO { Type = c.Type, Value = c.Value })
                    }
                };

                return response;
            }
        }
    }
