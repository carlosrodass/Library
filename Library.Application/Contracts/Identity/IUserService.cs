using MyLibrary.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(string userId);
    }
}
