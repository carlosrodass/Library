using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyLibrary.Application.Contracts.Identity;
using MyLibrary.Application.Exceptions;
using MyLibrary.Application.Models.Identity;
using MyLibrary.Domain.Common;
using MyLibrary.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Identity.Services
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;


        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<Result<AuthResponse, Error>> Login(AuthRequest request)
        {

            Result<ApplicationUser, Error> result = await CheckUserCredentials(request);
            if (result.IsFailure) { return result.Error; }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(result.Value);

            var response = new AuthResponse
            {
                Id = result.Value.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = result.Value.Email,
                UserName = result.Value.UserName
            };


            return response;
        }

        public async Task<Result<RegistrationResponse, Error>> Register(RegistrationRequest request)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                StringBuilder str = new StringBuilder();

                foreach (var err in result.Errors)
                {
                    str.Append(err.Description);
                }

                throw new BadRequestException($"{str}");

            }

            await _userManager.AddToRoleAsync(user, "User");
            return new RegistrationResponse() { UserId = user.Id };
        }

        #region Private methods

        private async Task<Result<ApplicationUser, Error>> CheckUserCredentials(AuthRequest request)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return Error.EmailNotFound;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded == false)
            {
                return Error.ErrorPassword;
            }

            return user;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var rolesClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(rolesClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        #endregion
    }
}
