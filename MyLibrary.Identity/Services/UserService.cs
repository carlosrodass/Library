
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using MyLibrary.Application.Contracts;
using MyLibrary.Application.Models.Identity;
using MyLibrary.Domain.Common;
using MyLibrary.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;



        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<User, Error>> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) { return Error.NotFound; }

            return new User
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<Result<List<User>, Error>> GetUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            return users.Select(user => new User
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            }).ToList();
        }
    }
}
