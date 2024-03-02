using CSharpFunctionalExtensions;
using MyLibrary.Application.Models.Identity;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Contracts
{
    public interface IUserService
    {
        Task<Result<List<User>, Error>> GetUsers();
        Task<Result<User, Error>> GetUser(string userId);
    }
}
