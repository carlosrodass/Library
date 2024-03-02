using CSharpFunctionalExtensions;
using MyLibrary.Application.Models.Identity;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<Result<AuthResponse, Error>> Login(AuthRequest request);
        Task<Result<RegistrationResponse, Error>> Register(RegistrationRequest request);
    }
}
